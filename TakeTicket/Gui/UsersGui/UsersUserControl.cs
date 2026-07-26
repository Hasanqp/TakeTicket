using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Data;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.UsersGui
{
    public partial class UsersUserControl : UserControl
    {
        // Variables
        private readonly IDataHelper<Users> dataHelper;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private static UsersUserControl _usersUserControl;
        private int RowId;
        private readonly LoadingGui.LoadingForm loadingForm;
        private List<int> IdList = new List<int>();
        private string SearchItem;
        private bool _isLoading = false;
        private bool isAnimating = false;
        private DataTable _exportTable;
        private bool expand = false;
        private DataTable _originalTable;

        public UsersUserControl(IDataHelper<Users> dataHelper, IDataHelper<SystemRecords> dataHelperSystemRecords)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            this.dataHelper = dataHelper;
            this.dataHelperSystemRecords = dataHelperSystemRecords;
            loadingForm = new LoadingGui.LoadingForm();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await LoadDataAsync();
        }
        #region Evints
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<AddUserForm>();

            async Task OnUserSavedHandler()
            {
                await LoadDataAsync();
            }

            form.OnUserSaved += OnUserSavedHandler;

            form.FormClosed += (s, args) =>
            {
                form.OnUserSaved -= OnUserSavedHandler;
            };

            form.SetData(0, false);
            form.ShowDialog();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUsers.RowCount > 0)
                {
                    var Deleteresult = MessageCollections.ShowDeleteDialog();
                    if (Deleteresult)
                    {
                        IdList.Clear();
                        SetIdRowForDelete();
                        loadingForm.Show();
                        if (IdList.Count > 0)
                        {
                            for (int i = 0; i < IdList.Count; i++)
                            {
                                RowId = IdList[i];
                                var user = await dataHelper.FindAsync(RowId);
                                var result = await dataHelper.DeleteAsync(RowId);

                                if (result == 1)
                                {
                                    // Save System Records
                                    SystemRecords systemRecords = new SystemRecords
                                    {
                                        Title = localizer.Get("DeleteActionTitle"),
                                        UserName = Properties.Settings.Default.UserName,
                                        Details = string.Format(localizer.Get("DeleteUserDetails"), RowId),
                                        AddedDate = DateTime.Now
                                    };
                                    await dataHelperSystemRecords.AddAsync(systemRecords);

                                    Logger.Audit($"User Deleted: {user?.UserName} / ID={RowId}");

                                    MessageCollections.ShowDeleteNotification();
                                }
                                else
                                {
                                    MessageCollections.ShowErrorServer();
                                }
                            }
                            await LoadDataAsync();
                        }
                        else
                        {
                            MessageCollections.ShowRequiredDeleteRow();
                        }
                    }
                    loadingForm.Hide();
                }
                else
                {
                    MessageCollections.ShowEmptyDataMessage();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Delete User");
                MessageCollections.ShowErrorServer();

            }

        }

        private async void buttonRefrech_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            await Search();
        }

        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            await Search();
        }

        private async void comboBoxPageNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CloseExportMenu();

                loadingForm.Show();

                var data = await dataHelper.GetAllDataAsync();

                var dataId = data.Select(x => x.Id).ToArray();

                int index = comboBoxPageNumber.SelectedIndex;
                int IndexNoOfRow = index * Properties.Settings.Default.DataGridViewRowNo;

                var pageData = data.Where(x => x.Id >= dataId[IndexNoOfRow])
                    .Take(Properties.Settings.Default.DataGridViewRowNo)
                    .ToList();

                DataTable dt = new DataTable();

                using (var reader = FastMember.ObjectReader.Create(pageData))
                {
                    dt.Load(reader);
                }

                _originalTable = dt.Copy();

                dataGridViewUsers.DataSource = SetViewTable(dt);

                if (dataGridViewUsers.DataSource == null)
                {
                    MessageCollections.ShowErrorServer();
                }
                else
                {
                    SetColumnsTitle();
                }
                Logger.Audit($"Users Page Changed: {comboBoxPageNumber.SelectedIndex + 1}");
                data.Clear();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Users Pagination");
            }
            finally
            {
                loadingForm.Hide();
            }

        }

        private void UsersUserControl_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        private void buttonAsXlsx_Click(object sender, EventArgs e)
        {
            if (_exportTable == null)
            {
                MessageCollections.ShowWarning(localizer.Get("PressExportFirst"));
                return;
            }
            // Export data to as sheet Excel
            ExportAsXlsxFile(_exportTable);
            CloseExportMenu();
        }

        private void buttonAsPDF_Click(object sender, EventArgs e)
        {
            if (_exportTable == null)
            {
                MessageCollections.ShowWarning(localizer.Get("PressExportFirst"));
                return;
            }

            // Export data to as pdf
            ExportAsPdfFile(_exportTable);
            CloseExportMenu();
        }

        private void buttonAsDocx_Click(object sender, EventArgs e)
        {
            if (_exportTable == null)
            {
                MessageCollections.ShowWarning(localizer.Get("PressExportFirst"));
                return;
            }
            // Export data to docx file
            ExportAsDocxFile(_exportTable);
            CloseExportMenu();
        }

        private void timerExport_Tick(object sender, EventArgs e)
        {
            int target = expand
                ? flowLayoutPanelExportContainer.MinimumSize.Height
                : flowLayoutPanelExportContainer.MaximumSize.Height;

            int difference = target - flowLayoutPanelExportContainer.Height;

            flowLayoutPanelExportContainer.Height += difference / 4;

            if (Math.Abs(difference) < 5)
            {
                flowLayoutPanelExportContainer.Height = target;
                timerExportDelay.Stop();
                expand = !expand;
                isAnimating = false;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

            if (_originalTable == null || _originalTable.Rows.Count == 0)
            {
                MessageCollections.ShowInfo(localizer.Get("NoData"));
                return;
            }

            //_exportTable = SetExportTable(_originalTable);

            if (expand)
            {
                CloseExportMenu();
                return;
            }

            _exportTable = GetUsersExportTableFromGrid();

            if (isAnimating) return;

            isAnimating = true;
            timerExportDelay.Start();
        }
        #endregion
        #region Methods

        public async Task LoadDataAsync()
        {
            ApplyLayout();
            CloseExportMenu();

            if (_isLoading) return;

            _isLoading = true;

            try
            {
                loadingForm.Show();

                var data = await dataHelper.GetAllDataAsync();

                if (data == null || data.Count == 0)
                {
                    dataGridViewUsers.DataSource = null;
                    return;
                }

                var list = data
                    .Take(Properties.Settings.Default.DataGridViewRowNo)
                    .ToList();

                DataTable dt = new DataTable();
                using (var reader = FastMember.ObjectReader.Create(list))
                {
                    dt.Load(reader);
                }

                _originalTable = dt.Copy();

                dataGridViewUsers.DataSource = null;
                dataGridViewUsers.DataSource = SetViewTable(dt);

                comboBoxPageNumber.Items.Clear();

                double value = (double)data.Count / Properties.Settings.Default.DataGridViewRowNo;
                int NoOfPage = (int)Math.Ceiling(value);

                for (int i = 0; i < NoOfPage; i++)
                {
                    comboBoxPageNumber.Items.Add(i + 1);
                }

                if (comboBoxPageNumber.Items.Count > 0)
                    comboBoxPageNumber.SelectedIndex = 0;

                SetColumnsTitle();
                Logger.Audit("Loaded Users");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Load Users");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
                _isLoading = false;
            }
        }

        private void SetColumnsTitle()
        {
            if (dataGridViewUsers.Columns.Count < 7)
                return;

            dataGridViewUsers.Columns[0].HeaderText = localizer.Get("ColumnId");
            dataGridViewUsers.Columns[1].HeaderText = localizer.Get("ColumnFullName");
            dataGridViewUsers.Columns[2].HeaderText = localizer.Get("ColumnUserName");
            //dataGridView1.Columns[3].HeaderText = "ColumnPassword";
            dataGridViewUsers.Columns[3].HeaderText = localizer.Get("ColumnEmail");
            dataGridViewUsers.Columns[4].HeaderText = localizer.Get("ColumnPhone");
            dataGridViewUsers.Columns[5].HeaderText = localizer.Get("ColumnAddedDate");
        }

        private void Edit()
        {
            if (dataGridViewUsers.RowCount > 0)
            {
                // Get Id
                RowId = Convert.ToInt32(dataGridViewUsers.CurrentRow.Cells[0].Value);
                Logger.Audit($"Open Edit User Form: ID={RowId}");
                var form = Program.ServiceProvider.GetRequiredService<AddUserForm>();

                form.SetData(RowId, false);

                form.OnUserSaved += OnUserSavedHandler;

                async Task OnUserSavedHandler()
                {
                    await LoadDataAsync();
                }

                form.ShowDialog();
            }
            else
            {
                MessageCollections.ShowEmptyDataMessage();
            }
        }

        private void SetIdRowForDelete()
        {
            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                if (row.Selected)
                {
                    IdList.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }

        }

        public async Task Search()
        {
            try
            {
                CloseExportMenu();

                loadingForm.Show();
                SearchItem = textBoxSearch.Text;

                var data = await dataHelper.SearchAsync(SearchItem);

                if (data == null || data.Count == 0)
                {
                    dataGridViewUsers.DataSource = null;
                }
                else
                {
                    DataTable dt = new DataTable();

                    using (var reader = FastMember.ObjectReader.Create(data))
                    {
                        dt.Load(reader);
                    }

                    _originalTable = dt;

                    dataGridViewUsers.DataSource = SetViewTable(dt);

                    SetColumnsTitle();
                }

                Logger.Audit($"Users Search: {SearchItem}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Search Users");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private void ExportAsXlsxFile(DataTable dataTableArranged)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = localizer.Get("ExportExcelTitle");
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = localizer.Get("ExcelFileFilter");
            saveFileDialog.RestoreDirectory = true;
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook xLWorkbook = new XLWorkbook()) // creat Excel File
                    {
                        xLWorkbook.AddWorksheet(dataTableArranged, "Data"); // Add Sheet
                        using (MemoryStream ma = new MemoryStream())
                        {
                            xLWorkbook.SaveAs(ma);
                            File.WriteAllBytes(saveFileDialog.FileName, ma.ToArray());
                        }
                    }
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });

                    Logger.Audit("Exported Users To Excel");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Excel");
                    MessageCollections.ShowErrorServer();
                }
            }
        }

        private void ApplyRoundedCorners(Button btn, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private void ExportAsDocxFile(DataTable dataTableArranged)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = localizer.Get("ExportWordTitle");
            saveFileDialog.Filter = localizer.Get("WordFileFilter");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (WordprocessingDocument doc =
                        WordprocessingDocument.Create(saveFileDialog.FileName,
                        WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = doc.AddMainDocumentPart();
                        mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                        Body body = new Body();

                        Table table = new Table();

                        TableProperties props = new TableProperties(
                            new TableBorders(
                                new TopBorder { Val = BorderValues.Single, Size = 12 },
                                new BottomBorder { Val = BorderValues.Single, Size = 12 },
                                new LeftBorder { Val = BorderValues.Single, Size = 12 },
                                new RightBorder { Val = BorderValues.Single, Size = 12 },
                                new InsideHorizontalBorder { Val = BorderValues.Single, Size = 12 },
                                new InsideVerticalBorder { Val = BorderValues.Single, Size = 12 }
                            )
                        );

                        table.AppendChild(props);

                        // Headers
                        TableRow headerRow = new TableRow();
                        foreach (DataColumn column in dataTableArranged.Columns)
                        {
                            TableCell cell = new TableCell(
                                new Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text(column.ColumnName ?? "")))
                            );
                            headerRow.Append(cell);
                        }
                        table.Append(headerRow);

                        // Data
                        foreach (DataRow row in dataTableArranged.Rows)
                        {
                            TableRow dataRow = new TableRow();

                            foreach (var item in row.ItemArray)
                            {
                                TableCell cell = new TableCell(
                                    new Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text(item?.ToString() ?? "")))
                                );
                                dataRow.Append(cell);
                            }

                            table.Append(dataRow);
                        }

                        body.Append(table);
                        mainPart.Document.Append(body);

                        mainPart.Document.Save();
                    }

                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });

                    Logger.Audit("Exported Users To Word");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Word");
                    MessageCollections.ShowErrorServer();
                }
            }
        }

        private void ExportAsPdfFile(DataTable dataTableArranged)
        {
            try
            {
                if (dataTableArranged == null || dataTableArranged.Rows.Count == 0)
                {
                    MessageBox.Show(MessagesLocal.NoDataToExport);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = localizer.Get("ExportPdfTitle");
                saveFileDialog.Filter = localizer.Get("PdfFileFilter");

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = saveFileDialog.FileName;

                QuestPDF.Settings.License = LicenseType.Community;

                QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(20);

                        page.Content().Table(t =>
                        {
                            // Rows count
                            t.ColumnsDefinition(columns =>
                            {
                                for (int i = 0; i < dataTableArranged.Columns.Count; i++)
                                    columns.RelativeColumn();
                            });

                            // Header
                            t.Header(header =>
                            {
                                foreach (DataColumn col in dataTableArranged.Columns)
                                {
                                    header.Cell().Border(1).Padding(5).Text(col.ColumnName);
                                }
                            });

                            // Rows
                            foreach (DataRow row in dataTableArranged.Rows)
                            {
                                foreach (var item in row.ItemArray)
                                {
                                    t.Cell().Border(1).Padding(5).Text(item?.ToString() ?? "");
                                }
                            }
                        });
                    });
                })
                .GeneratePdf(filePath);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });

                Logger.Audit("Exported Users To PDF");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Export PDF");
                MessageCollections.ShowErrorServer();
            }
        }

        private DataTable SetViewTable(DataTable dataTable)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnId"));
            dt.Columns.Add(localizer.Get("ColumnFullName"));
            dt.Columns.Add(localizer.Get("ColumnUserName"));
            //dt.Columns.Add("ColumnPassword");
            dt.Columns.Add(localizer.Get("ColumnEmail"));
            dt.Columns.Add(localizer.Get("ColumnPhone"));
            dt.Columns.Add(localizer.Get("ColumnAddedDate"));

            foreach (DataRow row in dataTable.Rows)
            {
                dt.Rows.Add(
                    row["Id"],
                    row["FullName"],
                    row["UserName"],
                    //row["Password"],
                    row["Email"],
                    row["Phone"],
                    row["AddedDate"]
                );
            }

            return dt;
        }

        private void CloseExportMenu()
        {
            _exportTable = null;

            if (expand)
            {
                if (isAnimating) return;

                isAnimating = true;
                timerExportDelay.Start();
            }
        }

        private DataTable GetUsersExportTableFromGrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnFullName"));
            dt.Columns.Add(localizer.Get("ColumnUserName"));
            //dt.Columns.Add("ColumnPassword");
            dt.Columns.Add(localizer.Get("ColumnEmail"));
            dt.Columns.Add(localizer.Get("ColumnPhone"));
            dt.Columns.Add(localizer.Get("ColumnAddedDate"));

            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                if (row.IsNewRow) continue;

                dt.Rows.Add(
                    row.Cells[localizer.Get("ColumnFullName")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnUserName")].Value?.ToString(),
                    //row.Cells["ColumnPassword"].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnEmail")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnPhone")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnAddedDate")].Value?.ToString()
                );
            }

            return dt;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.UserLocal.UsersUserControlLocalization");

        private void ApplyLocalization()
        {
            buttonAdd.Text =
                localizer.Get("ButtonAdd");

            buttonEdit.Text =
                localizer.Get("ButtonEdit");

            buttonDelete.Text =
                localizer.Get("ButtonDelete");

            buttonRefrech.Text =
                localizer.Get("ButtonRefresh");

            buttonSearch.Text =
                localizer.Get("ButtonSearch");

            buttonExport.Text =
                localizer.Get("ButtonExport");
        }
        #endregion
        #region RTL
        private void ApplyLayout()
        {
            string language =
                Properties.Settings.Default.Language;

            switch (language)
            {
                case "ar":
                    ApplyArabicLayout();
                    break;

                case "ru":
                    ApplyRussianLayout();
                    break;

                default:
                    ApplyEnglishLayout();
                    break;
            }
        }

        private void ApplyArabicLayout()
        {
            SuspendLayout();

            // UserControl
            RightToLeft = RightToLeft.Yes;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);
            Size = new System.Drawing.Size(1280, 720);

            // Toolbar
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 63);
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.RightToLeft = RightToLeft.Yes;

            // Add Button
            buttonAdd.Text = "إضافة";
            buttonAdd.Location = new Point(1121, 10);
            buttonAdd.Size = new System.Drawing.Size(127, 42);

            // Edit Button
            buttonEdit.Text = "تعديل";
            buttonEdit.Location = new Point(984, 10);
            buttonEdit.Size = new System.Drawing.Size(127, 42);

            // Delete Button
            buttonDelete.Text = "حذف";
            buttonDelete.Location = new Point(847, 10);
            buttonDelete.Size = new System.Drawing.Size(127, 42);

            // Export Container
            flowLayoutPanelExportContainer.Location = new Point(533, 8);
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(155, 44);
            flowLayoutPanelExportContainer.MaximumSize =
                new System.Drawing.Size(155, 79);

            flowLayoutPanelExportContainer.Size =
                new System.Drawing.Size(155, 44);

            // Export Button Panel
            panelExportButton.Location = new Point(0, 0);
            panelExportButton.Size = new System.Drawing.Size(155, 44);

            buttonExport.Text = "تصدير";
            buttonExport.Location = new Point(0, 1);
            buttonExport.Size = new System.Drawing.Size(154, 42);

            // Export Formats Panel
            panelExportFormats.Location =
                new Point(0, 44);

            panelExportFormats.Size = new System.Drawing.Size(155, 35);

            buttonExportAsDocx.Location =
                new Point(6, 2);

            buttonExportAsXlsx.Location =
                new Point(54, 2);

            buttonExportAsPdf.Location =
                new Point(102, 2);

            // Refresh Button
            buttonRefrech.Text = "تحديث";
            buttonRefrech.Location =
                new Point(686, 10);

            buttonRefrech.Size =
                new System.Drawing.Size(149, 42);

            // Search Panel
            panelSearch.RightToLeft =
                RightToLeft.Yes;

            panelSearch.Location = new Point(843, 8);

            panelSearch.Size = new System.Drawing.Size(404, 44);

            buttonSearch.Text = "بحث";
            buttonSearch.Size = new System.Drawing.Size(116, 44);
            textBoxSearch.Size = new System.Drawing.Size(289, 44);

            // DataGrid
            dataGridViewUsers.Location =
                new Point(0, 63);

            dataGridViewUsers.Size =
                new System.Drawing.Size(1280, 657);

            // Pagination
            comboBoxPageNumber.Location =
                new Point(1173, 686);

            comboBoxPageNumber.Size =
                new System.Drawing.Size(104, 31);

            ResumeLayout();
        }

        private void ApplyEnglishLayout()
        {
            RightToLeft = RightToLeft.No;

            // Toolbar
            flowLayoutPanelToolbar.RightToLeft = RightToLeft.No;
            flowLayoutPanelToolbar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelToolbar.Padding = new Padding(5);

            // Search Panel
            panelSearch.RightToLeft = RightToLeft.No;

            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            buttonSearch.Dock = DockStyle.Left;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.ImageAlign = ContentAlignment.MiddleRight;
            buttonSearch.TextImageRelation = TextImageRelation.ImageBeforeText;

            // Export buttons
            buttonExportAsPdf.Text = string.Empty;
            buttonExportAsDocx.Text = string.Empty;
            buttonExportAsXlsx.Text = string.Empty;

            // ComboBox
            comboBoxPageNumber.RightToLeft = RightToLeft.No;

            // Grid
            dataGridViewUsers.RightToLeft = RightToLeft.No;
        }

        private void ApplyRussianLayout()
        {
            RightToLeft = RightToLeft.No;

            flowLayoutPanelToolbar.RightToLeft = RightToLeft.No;
            flowLayoutPanelToolbar.FlowDirection = FlowDirection.LeftToRight;

            // Buttons
            buttonAdd.Size = new System.Drawing.Size(165, 42);
            buttonAdd.TextAlign = ContentAlignment.MiddleCenter;
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.Padding = new Padding(10, 0, 0, 0);

            buttonEdit.Size = new System.Drawing.Size(201, 42);
            buttonEdit.TextAlign = ContentAlignment.MiddleCenter;
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.Padding = new Padding(10, 0, 0, 0);

            buttonDelete.Size = new System.Drawing.Size(165, 42);
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.Padding = new Padding(10, 0, 0, 0);

            buttonExport.Size = new System.Drawing.Size(142, 42);
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.Padding = new Padding(10, 0, 0, 0);

            buttonRefrech.Size = new System.Drawing.Size(165, 42);
            buttonRefrech.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefrech.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefrech.Padding = new Padding(10, 0, 0, 0);

            // Search panel
            panelSearch.RightToLeft = RightToLeft.No;

            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            buttonSearch.Dock = DockStyle.Left;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.ImageAlign = ContentAlignment.MiddleRight;
            buttonSearch.Padding = new Padding(0, 0, 10, 0);

            // Export container
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(145, 44);
            flowLayoutPanelExportContainer.MaximumSize = new System.Drawing.Size(145, 79);

            // Pagination
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        }
        #endregion
    }
}
