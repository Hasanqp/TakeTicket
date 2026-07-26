using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Data;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.SystemRecordsGui
{
    public partial class SystemRecordsUserControl : UserControl
    {
        // Variables
        private readonly IDataHelper<SystemRecords> dataHelper;
        private static SystemRecordsUserControl _SystemRecordsUserControl;
        private int RowId;
        private readonly LoadingGui.LoadingForm loadingForm;
        private List<int> IdList = new List<int>();
        private string SearchItem;
        private DataTable _exportTable;
        private DataTable _originalTable;
        private bool isAnimating = false;
        private bool expand = false;

        public SystemRecordsUserControl(IDataHelper<SystemRecords> dataHelper)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            SetRoles();
            this.dataHelper = dataHelper;
            loadingForm = new LoadingGui.LoadingForm();
            _ = LoadDataAsync();
        }

        #region Evints
        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSystemRecords.RowCount > 0)
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
                                var systemRecords = await dataHelper.FindAsync(RowId);
                                var result = await dataHelper.DeleteAsync(RowId);
                                
                                if (result == 1)
                                {
                                    Logger.Audit($"User={Properties.Settings.Default.UserName} Deleted SystemRecord ID={RowId} Title={systemRecords?.Title}");

                                    MessageCollections.ShowDeleteNotification();
                                }
                                else
                                {
                                    Logger.Log($"Failed to delete SystemRecord ID={RowId}");
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
                Logger.Log(ex, "Delete System Records");
                MessageCollections.ShowErrorServer();
            }

        }

        private async void buttonRefrech_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void buttoneExport_Click(object sender, EventArgs e)
        {
            if (_originalTable == null || _originalTable.Rows.Count == 0)
            {
                MessageCollections.ShowInfo(localizer.Get("NoData"));
                return;
            }

            if (expand)
            {
                CloseExportMenu();
                return;
            }

            //_exportTable = _originalTable != null
            //    ? SetExportTable(_originalTable)
            //    : null;

            _exportTable = GetSystemRecordsExportTableFromGrid();

            if (isAnimating) return;

            isAnimating = true;
            timerExportDelay.Start();
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

            dataGridViewSystemRecords.DataSource = null;
            dataGridViewSystemRecords.Columns.Clear();
            dataGridViewSystemRecords.AutoGenerateColumns = true;
            dataGridViewSystemRecords.DataSource = SetViewTable(dt);

            SetColumnsTitle();

            if (dataGridViewSystemRecords.DataSource == null)
            {
                MessageCollections.ShowErrorServer();
            }
            else
            {
                SetColumnsTitle();
            }
            loadingForm.Hide();
            data.Clear();
        }

        private async void SystemRecordsUserControl_Load(object sender, EventArgs e)
        {
            ApplyLayout();
            await LoadDataAsync();
        }

        private void SystemRecordsUserControl_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void buttonAsDocs_Click(object sender, EventArgs e)
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
        #endregion
        #region Methods
        public async Task LoadDataAsync()
        {
            CloseExportMenu();

            loadingForm.Show();
            var data = await dataHelper.GetAllDataAsync();

            var list = data
                .Take(Properties.Settings.Default.DataGridViewRowNo)
                .ToList();

            DataTable dt = new DataTable();
            using (var reader = FastMember.ObjectReader.Create(list))
            {
                dt.Load(reader);
            }

            _originalTable = dt.Copy();

            dataGridViewSystemRecords.DataSource = SetViewTable(dt);
            
            // Add No of page into combo box
            comboBoxPageNumber.Items.Clear();
            double value = (Convert.ToDouble(data.Count) / Convert.ToDouble(Properties.Settings.Default.DataGridViewRowNo));
            int NoOfPage = (int)Math.Round(value, MidpointRounding.AwayFromZero);

            for (int i = 0; i < NoOfPage; i++)
            {
                comboBoxPageNumber.Items.Add(i);
            }
            //

            if (dataGridViewSystemRecords.DataSource == null)
            {
                MessageCollections.ShowErrorServer();
            }
            else
            {
                SetColumnsTitle();
            }
            loadingForm.Hide();
            data.Clear();
        }

        private void SetColumnsTitle()
        {
            dataGridViewSystemRecords.Columns[0].HeaderText =
                localizer.Get("ColumnId");

            dataGridViewSystemRecords.Columns[1].HeaderText =
                localizer.Get("ColumnUserName");

            dataGridViewSystemRecords.Columns[2].HeaderText =
                localizer.Get("ColumnTitle");

            dataGridViewSystemRecords.Columns[3].HeaderText =
                localizer.Get("ColumnDetails");

            dataGridViewSystemRecords.Columns[4].HeaderText =
                localizer.Get("ColumnAddedDate");
        }

        private void SetIdRowForDelete()
        {
            foreach (DataGridViewRow row in dataGridViewSystemRecords.Rows)
            {
                if (row.Selected)
                {
                    IdList.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }

        }

        public async Task Search()
        {
            CloseExportMenu();

            try
            {
                loadingForm.Show();

                SearchItem = textBoxSearch.Text;
                var result = await dataHelper.SearchAsync(SearchItem);

                //Logger.Audit($"User={Properties.Settings.Default.UserName} Search='{SearchItem}' Results={result?.Count}");
                if (result == null)
                {
                    MessageCollections.ShowErrorServer();
                    return;
                }
                else
                {
                    DataTable table = new DataTable();

                    using (var reader = FastMember.ObjectReader.Create(result))
                    {
                        table.Load(reader);
                    }
                    _originalTable = table;

                    var dt = SetViewTable(table);

                    dataGridViewSystemRecords.DataSource = null;
                    dataGridViewSystemRecords.Columns.Clear();
                    dataGridViewSystemRecords.AutoGenerateColumns = true;
                    dataGridViewSystemRecords.DataSource = dt;

                    SetColumnsTitle();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "System Records Search");
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

                    Logger.Audit($"User={Properties.Settings.Default.UserName}" + $" Exported System Records To Excel Rows={dataTableArranged.Rows.Count}");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Excel");
                    MessageCollections.ShowException(ex, "Export Excel");
                }
            }
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

                        DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                        TableProperties props = new TableProperties(
                            new TableBorders(
                                new DocumentFormat.OpenXml.Wordprocessing.TopBorder { Val = BorderValues.Single, Size = 12 },
                                new DocumentFormat.OpenXml.Wordprocessing.BottomBorder { Val = BorderValues.Single, Size = 12 },
                                new DocumentFormat.OpenXml.Wordprocessing.LeftBorder { Val = BorderValues.Single, Size = 12 },
                                new DocumentFormat.OpenXml.Wordprocessing.RightBorder { Val = BorderValues.Single, Size = 12 },
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
                                new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(column.ColumnName ?? "")))
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
                                    new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(item?.ToString() ?? "")))
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

                    Logger.Audit($"User={Properties.Settings.Default.UserName} Exported System Records To Word Rows={dataTableArranged.Rows.Count}");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export word");
                    MessageCollections.ShowException(ex, "Export Word");
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

                Logger.Audit($"User={Properties.Settings.Default.UserName} Exported System Records To PDF Rows={dataTableArranged.Rows.Count}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, $"Export PDF User={Properties.Settings.Default.UserName}");
                MessageCollections.ShowErrorServer();
            }
        }

        private void SetRoles()
        {
            if (!UsersRolesManager.GetRole("checkBoxOperationDelete"))
            {
                buttonDelete.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxOperationSearch"))
            {
                buttonSearch.Visible = false;
            }
        }

        private DataTable SetViewTable(DataTable dataTable)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnId"));
            dt.Columns.Add(localizer.Get("ColumnUserName"));
            dt.Columns.Add(localizer.Get("ColumnTitle"));
            dt.Columns.Add(localizer.Get("ColumnDetails"));
            dt.Columns.Add(localizer.Get("ColumnAddedDate"));

            foreach (DataRow row in dataTable.Rows)
            {
                dt.Rows.Add(
                    row["Id"]?.ToString(),
                    row["UserName"]?.ToString(),
                    row["Title"]?.ToString(),
                    row["Details"]?.ToString(),
                    row["AddedDate"]?.ToString()
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

        private DataTable GetSystemRecordsExportTableFromGrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnId"));
            dt.Columns.Add(localizer.Get("ColumnUserName"));
            dt.Columns.Add(localizer.Get("ColumnTitle"));
            dt.Columns.Add(localizer.Get("ColumnDetails"));
            dt.Columns.Add(localizer.Get("ColumnAddedDate"));

            foreach (DataGridViewRow row in dataGridViewSystemRecords.Rows)
            {
                if (row.IsNewRow) continue;

                dt.Rows.Add(
                    row.Cells[localizer.Get("ColumnId")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnUserName")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnTitle")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnDetails")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnAddedDate")].Value?.ToString()
                );
            }

            return dt;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.SystemRecordsLocal.SystemRecordsUserControlLocalization");

        private void ApplyLocalization()
        {
            buttonDelete.Text =
                localizer.Get("ButtonDelete");

            buttonRefresh.Text =
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
            string language = Properties.Settings.Default.Language;

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

        private void ApplyEnglishLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new System.Drawing.Size(1280, 720);
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Toolbar
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 63);
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;
            flowLayoutPanelToolbar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelToolbar.BackColor = SystemColors.Control;

            // Buttons
            // Delete Button
            buttonDelete.Text = "Delete";
            buttonDelete.Size = new System.Drawing.Size(165, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;
            buttonDelete.Padding = new Padding(10, 0, 0, 0);

            // Refresh Button
            buttonRefresh.Text = "Refresh";
            buttonRefresh.Size = new System.Drawing.Size(165, 42);
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefresh.Padding = new Padding(10, 0, 0, 0);

            // Export Container
            flowLayoutPanelExportContainer.Size = new System.Drawing.Size(145, 44);
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(145, 44);
            flowLayoutPanelExportContainer.MaximumSize = new System.Drawing.Size(145, 79);

            panelExportButton.Size = new System.Drawing.Size(150, 43);

            buttonExport.Text = "Export";
            buttonExport.Size = new System.Drawing.Size(145, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;
            buttonExport.Padding = new Padding(10, 0, 0, 0);

            panelExportFormats.Size = new System.Drawing.Size(150, 35);

            buttonExportAsDocx.Location = new Point(6, 2);
            buttonExportAsDocx.Size = new System.Drawing.Size(48, 30);
            buttonExportAsXlsx.Location = new Point(54, 2);
            buttonExportAsXlsx.Size = new System.Drawing.Size(48, 30);
            buttonExportAsPdf.Location = new Point(102, 2);
            buttonExportAsPdf.Size = new System.Drawing.Size(48, 30);

            // Search Panel
            panelSearch.Size = new System.Drawing.Size(391, 44);

            buttonSearch.Text = "Search";
            buttonSearch.Size = new System.Drawing.Size(113, 44);
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.Padding = new Padding(10, 0, 0, 0);

            textBoxSearch.Size = new System.Drawing.Size(280, 44);
            textBoxSearch.Font = new System.Drawing.Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            // DataGridView
            dataGridViewSystemRecords.Dock = DockStyle.Fill;
            dataGridViewSystemRecords.BackgroundColor = System.Drawing.Color.White;
            dataGridViewSystemRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSystemRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSystemRecords.RightToLeft = RightToLeft.No;
            dataGridViewSystemRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNumber.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNumber.Location = new Point(1173, 686);
            comboBoxPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNumber.RightToLeft = RightToLeft.No;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyArabicLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new System.Drawing.Size(1280, 720);
            RightToLeft = RightToLeft.Yes;
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Toolbar
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 63);
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;
            flowLayoutPanelToolbar.BackColor = SystemColors.Control;

            // Buttons (Arabic Layout)
            // Delete Button
            buttonDelete.Text = "حذف";
            buttonDelete.Size = new System.Drawing.Size(127, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;

            // Refresh Button
            buttonRefresh.Text = "تحديث";
            buttonRefresh.Size = new System.Drawing.Size(127, 42);
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.TextAlign = ContentAlignment.MiddleCenter;

            // Export Container
            flowLayoutPanelExportContainer.Size = new System.Drawing.Size(155, 44);
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(155, 44);
            flowLayoutPanelExportContainer.MaximumSize = new System.Drawing.Size(155, 79);

            panelExportButton.Size = new System.Drawing.Size(155, 44);

            buttonExport.Text = "تصدير";
            buttonExport.Size = new System.Drawing.Size(154, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;

            panelExportFormats.Size = new System.Drawing.Size(150, 35);

            buttonExportAsDocx.Location = new Point(6, 2);
            buttonExportAsDocx.Size = new System.Drawing.Size(49, 30);
            buttonExportAsXlsx.Location = new Point(54, 2);
            buttonExportAsXlsx.Size = new System.Drawing.Size(49, 30);
            buttonExportAsPdf.Location = new Point(102, 2);
            buttonExportAsPdf.Size = new System.Drawing.Size(49, 30);

            // Search Panel
            panelSearch.Size = new System.Drawing.Size(404, 44);

            buttonSearch.Text = "بحث";
            buttonSearch.Size = new System.Drawing.Size(116, 44);
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;

            textBoxSearch.Size = new System.Drawing.Size(289, 44);
            textBoxSearch.Font = new System.Drawing.Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            textBoxSearch.RightToLeft = RightToLeft.Yes;

            // DataGridView (RTL Support)
            dataGridViewSystemRecords.Dock = DockStyle.Fill;
            dataGridViewSystemRecords.BackgroundColor = System.Drawing.Color.White;
            dataGridViewSystemRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSystemRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSystemRecords.RightToLeft = RightToLeft.Yes;
            dataGridViewSystemRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxPageNumber.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNumber.Location = new Point(3, 686);
            comboBoxPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNumber.RightToLeft = RightToLeft.Yes;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new System.Drawing.Size(1280, 720);
            RightToLeft = RightToLeft.No;
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Toolbar
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 63);
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;
            flowLayoutPanelToolbar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelToolbar.BackColor = SystemColors.Control;

            // Buttons (Russian Layout)
            // Delete Button
            buttonDelete.Text = "Удалить";
            buttonDelete.Size = new System.Drawing.Size(165, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;
            buttonDelete.Padding = new Padding(10, 0, 0, 0);

            // Refresh Button
            buttonRefresh.Text = "Обновить";
            buttonRefresh.Size = new System.Drawing.Size(165, 42);
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefresh.Padding = new Padding(10, 0, 0, 0);

            // Export Container
            flowLayoutPanelExportContainer.Size = new System.Drawing.Size(145, 44);
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(145, 44);
            flowLayoutPanelExportContainer.MaximumSize = new System.Drawing.Size(145, 79);

            panelExportButton.Size = new System.Drawing.Size(150, 43);

            buttonExport.Text = "Экспорт";
            buttonExport.Size = new System.Drawing.Size(145, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;
            buttonExport.Padding = new Padding(10, 0, 0, 0);

            panelExportFormats.Size = new System.Drawing.Size(150, 35);

            buttonExportAsDocx.Location = new Point(6, 2);
            buttonExportAsDocx.Size = new System.Drawing.Size(48, 30);
            buttonExportAsXlsx.Location = new Point(54, 2);
            buttonExportAsXlsx.Size = new System.Drawing.Size(48, 30);
            buttonExportAsPdf.Location = new Point(102, 2);
            buttonExportAsPdf.Size = new System.Drawing.Size(48, 30);

            // Search Panel
            panelSearch.Size = new System.Drawing.Size(391, 44);

            buttonSearch.Text = "Поиск";
            buttonSearch.Size = new System.Drawing.Size(113, 44);
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.Padding = new Padding(10, 0, 0, 0);

            textBoxSearch.Size = new System.Drawing.Size(280, 44);
            textBoxSearch.Font = new System.Drawing.Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxSearch.RightToLeft = RightToLeft.No;

            // DataGridView
            dataGridViewSystemRecords.Dock = DockStyle.Fill;
            dataGridViewSystemRecords.BackgroundColor = System.Drawing.Color.White;
            dataGridViewSystemRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSystemRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSystemRecords.RightToLeft = RightToLeft.No;
            dataGridViewSystemRecords.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNumber.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNumber.Location = new Point(1173, 686);
            comboBoxPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNumber.RightToLeft = RightToLeft.No;

            ResumeLayout();
            PerformLayout();
        }
        #endregion
    }
}
