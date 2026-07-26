using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Data;
using System.Diagnostics;
using TakeTicket.Application.Services;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.BusEnrollmentGui
{
    public partial class BusUserControl : UserControl
    {
        // Variables
        private readonly IDataHelper<Buses> busDataHelper;
        private readonly IDataHelper<Customers> customerDataHelper;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private static BusUserControl _BusUserControl;
        private readonly BusService _busService;
        private int RowId;
        private readonly LoadingGui.LoadingForm loadingForm;
        private List<int> IdList = new List<int>();
        private string SearchItem;
        private DataTable _exportTable;
        private bool expand = false;
        private bool isAnimating = false;
        private DataTable _originalTable;

        public BusUserControl(IDataHelper<Buses> busDataHelper, IDataHelper<SystemRecords> dataHelperSystemRecords, IDataHelper<Customers> customerDataHelper, BusService busService)
        {
            InitializeComponent();

            ApplyLocalization();
            SetRoles();
            ApplyLayout();

            this.busDataHelper = busDataHelper;

            this.dataHelperSystemRecords = dataHelperSystemRecords;

            this.customerDataHelper = customerDataHelper;

            _busService = busService;

            loadingForm = new LoadingGui.LoadingForm();

            LoadDataAsync();
        }

        #region Evints
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<AddBusForm>();

            form.SetData(0);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDataAsync();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount > 0)
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

                                var bus = await busDataHelper.FindAsync(RowId);
                                var result = await _busService.DeleteBusAsync(RowId);
                                if (result == -1)
                                {
                                    loadingForm.Hide();
                                    MessageBox.Show(
                                        localizer.Get("DeleteWarningPassengers"),
                                        localizer.Get("WarningTitle"),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    return;
                                }
                                if (result == 1)
                                {
                                    Logger.Audit(
                                        $"Bus Deleted: {bus?.BusNumber} / ID={RowId}");

                                    // Save System Records
                                    SystemRecords systemRecords = new SystemRecords
                                    {
                                        Title = localizer.Get("DeleteActionTitle"),
                                        UserName = Properties.Settings.Default.UserName,
                                        Details = string.Format(localizer.Get("DeleteBusDetails"),RowId),
                                        AddedDate = DateTime.Now
                                    };
                                    await dataHelperSystemRecords.AddAsync(systemRecords);

                                    MessageCollections.ShowDeleteNotification();
                                }
                                else
                                {
                                    MessageCollections.ShowErrorServer();
                                }
                            }
                            LoadDataAsync();
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
                Logger.Log(ex, "Delete Bus");
                MessageCollections.ShowErrorServer();
            }

        }

        private void buttonRefrech_Click(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private async void comboBoxPageNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseExportMenu();

            loadingForm.Show();
            var data = await busDataHelper.GetAllDataAsync();
            var dataId = data.Select(x => x.Id).ToArray();
            int index = comboBoxPageNo.SelectedIndex;
            int IndexNoOfRow = index * Properties.Settings.Default.DataGridViewRowNo;

            var pageData = data.Where(x => x.Id >= dataId[IndexNoOfRow])
                .Take(Properties.Settings.Default.DataGridViewRowNo)
                .ToList();

            DataTable dt = new DataTable();
            using (var reader = FastMember.ObjectReader.Create(pageData))
            {
                dt.Load(reader);
            }

            dataGridView1.DataSource = SetViewTable(dt);

            if (dataGridView1.DataSource == null)
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

        private void BusUserControl_Load(object sender, EventArgs e)
        {
            ApplyLayout();
        }

        private void BusUserControl_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        private void pictureBoxWhatsApp_Click(object sender, EventArgs e)
        {
            var url = localizer.Get("WhatsappUrl");
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void pictureBoxGmail_Click(object sender, EventArgs e)
        {
            var url = localizer.Get("GmailUrl");
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void buttonExport_Click(object sender, EventArgs e)
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

            _exportTable = GetBusExportTableFromGrid();
            

            if (isAnimating) return;

            isAnimating = true;
            timerExport.Start();
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
            // Export data to Docs file
            ExportAsDocxFile(_exportTable);

            CloseExportMenu();
        }

        private void timerExport_Tick(object sender, EventArgs e)
        {
            int target = expand
                ? flowLayoutPanelDropDownContainer.MinimumSize.Height
                : flowLayoutPanelDropDownContainer.MaximumSize.Height;

            int difference = target - flowLayoutPanelDropDownContainer.Height;

            flowLayoutPanelDropDownContainer.Height += difference / 4;

            if (Math.Abs(difference) < 5)
            {
                flowLayoutPanelDropDownContainer.Height = target;
                timerExport.Stop();
                expand = !expand;
                isAnimating = false;
            }
        }
        #endregion
        #region Methods
        public async void LoadDataAsync()
        {
            CloseExportMenu();

            try
            {
                loadingForm.Show();
                var data = await busDataHelper.GetAllDataAsync();

                dataGridView1.DataSource = data.Take(Properties.Settings.Default.DataGridViewRowNo).ToList();

                // Add No of page into combo box
                comboBoxPageNo.Items.Clear();
                double value = (Convert.ToDouble(data.Count) / Convert.ToDouble(Properties.Settings.Default.DataGridViewRowNo));

                int NoOfPage = (int)Math.Round(value, MidpointRounding.AwayFromZero);

                for (int i = 0; i < NoOfPage; i++)
                {
                    comboBoxPageNo.Items.Add(i);
                }

                //
                if (dataGridView1.DataSource != null)
                {
                    var list = data.Take(Properties.Settings.Default.DataGridViewRowNo).ToList();

                    // Convert to DataTable
                    DataTable table = new DataTable();
                    using (var reader = FastMember.ObjectReader.Create(list))
                    {
                        table.Load(reader);
                    }

                    _originalTable = table.Copy();

                    dataGridView1.DataSource = SetViewTable(table);

                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = SetViewTable(table);

                    SetColumnsTitle();
                    await ApplyBusRowColorsAsync();
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
                data.Clear();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Load Buses");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
            }

        }

        private void Edit()
        {
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    // Get Id
                    RowId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    var form = Program.ServiceProvider.GetRequiredService<AddBusForm>();
                    form.SetData(RowId);
                    form.ShowDialog();
                }
                else
                {
                    MessageCollections.ShowEmptyDataMessage();
                }
            }
            catch(Exception ex)
            {
                Logger.Log(ex, "Open Edit Bus Form");
                MessageCollections.ShowErrorServer();
            }
        }

        private void SetIdRowForDelete()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    IdList.Add(Convert.ToInt32(row.Cells[0].Value));
                }
            }

        }

        public async void Search()
        {
            CloseExportMenu();
            try
            {
                loadingForm.Show();

                SearchItem = textBoxSearch.Text;
                var result = await busDataHelper.SearchAsync(SearchItem);

                if (result == null)
                {
                    MessageCollections.ShowErrorServer();
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

                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;

                    SetColumnsTitle();
                    await ApplyBusRowColorsAsync();
                }

            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Bus Search");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private void SetColumnsTitle()
        {
            dataGridView1.Columns[0].HeaderText = localizer.Get("ColumnId");
            dataGridView1.Columns[1].HeaderText = localizer.Get("ColumnDriverName");
            dataGridView1.Columns[2].HeaderText = localizer.Get("ColumnAssistantDriver");
            dataGridView1.Columns[3].HeaderText = localizer.Get("ColumnBusNo");
            dataGridView1.Columns[4].HeaderText = localizer.Get("ColumnBusInfo");
            dataGridView1.Columns[5].HeaderText = localizer.Get("ColumnCapacity");
            dataGridView1.Columns[6].HeaderText = localizer.Get("ColumnExtraCapacity");
            dataGridView1.Columns[7].HeaderText = localizer.Get("ColumnBusModel");
            dataGridView1.Columns[8].HeaderText = localizer.Get("ColumnAddress");
            dataGridView1.Columns[9].HeaderText = localizer.Get("ColumnPhone");
            dataGridView1.Columns[10].HeaderText = localizer.Get("ColumnTripType");
            dataGridView1.Columns[11].HeaderText = localizer.Get("ColumnDeparture");
            dataGridView1.Columns[12].HeaderText = localizer.Get("ColumnReturn");
            dataGridView1.Columns[13].HeaderText = localizer.Get("ColumnDetails");
            // Hide relitions
            if (dataGridView1.Columns.Contains("Customers"))
                dataGridView1.Columns["Customers"].Visible = false;
        }

        private void ExportAsDocxFile(DataTable dataTableArranged)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = localizer.Get("ExportWordTitle");
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = localizer.Get("WordFileFilter");
            saveFileDialog.RestoreDirectory = true;

            var result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
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

                        // Create table
                        Table table = new Table();

                        // Table Properties (Borders)
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

                        // First column (Headers)
                        TableRow headerRow = new TableRow();
                        foreach (DataColumn column in dataTableArranged.Columns)
                        {
                            TableCell cell = new TableCell(
                                new Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text(column.ColumnName)))
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
                    }

                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = saveFileDialog.FileName,
                        UseShellExecute = true
                    });

                    Logger.Audit("Exported Buses To Word");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Word");
                    MessageCollections.ShowException(ex, localizer.Get("ExportWordError"));
                }
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
                        xLWorkbook.AddWorksheet(dataTableArranged, localizer.Get("ExcelSheetName")); // Add Sheet
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

                    Logger.Audit("Exported Buses To Excel");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Excel");
                    MessageCollections.ShowException(ex, "Export Excel");
                }
            }
        }

        private void ExportAsPdfFile(DataTable dataTableArranged)
        {
            try
            {
                if (dataTableArranged == null || dataTableArranged.Rows.Count == 0)
                {
                    MessageCollections.ShowInfo(localizer.Get("NoDataToExport"));
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
                            // Number of columns
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

                Logger.Audit("Exported Buses To PDF");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Export PDF");
                MessageCollections.ShowErrorServer();
            }
        }

        private void SetRoles()
        {
            if (!UsersRolesManager.GetRole("checkBoxOperationAdd"))
            {
                buttonAdd.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxOperationDelete"))
            {
                buttonDelete.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxOperationEdit"))
            {
                buttonEdit.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxOperationExport"))
            {
                buttonExport.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxOperationSearch"))
            {
                buttonSearch.Visible = false;
            }
            // ToDo: Add Role For Messages
            //if(!UsersRolesManager.GetRole("checkBoxMessage"))
            //{
            //    buttonRefrech.Visible = false;
            //}
        }

        private async Task ApplyBusRowColorsAsync()
        {
            try
            {
                var passengerCounts = await _busService.GetPassengerCountsForAllBusesAsync();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[localizer.Get("ColumnId")].Value == null)
                        continue;

                    int busId = Convert.ToInt32(
                        row.Cells[localizer.Get("ColumnId")].Value);

                    int mainCount = 0;
                    int reserveCount = 0;

                    if (passengerCounts.ContainsKey(busId))
                    {
                        mainCount = passengerCounts[busId].main;
                        reserveCount = passengerCounts[busId].reserve;
                    }

                    int capacity = Convert.ToInt32(row.Cells[localizer.Get("ColumnCapacity")].Value);
                    int extraCapacity = Convert.ToInt32(row.Cells[localizer.Get("ColumnExtraCapacity")].Value);

                    bool mainFull = mainCount >= capacity;
                    bool reserveFull = reserveCount >= extraCapacity;

                    if (mainFull && reserveFull)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    else if (mainFull)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Khaki;
                    else
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Apply Bus Row Colors");
            }
        }

        private DataTable SetViewTable(DataTable dataTable)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnId"));
            dt.Columns.Add(localizer.Get("ColumnDriverName"));
            dt.Columns.Add(localizer.Get("ColumnAssistantDriver"));
            dt.Columns.Add(localizer.Get("ColumnBusNo"));
            dt.Columns.Add(localizer.Get("ColumnBusInfo"));
            dt.Columns.Add(localizer.Get("ColumnCapacity"));
            dt.Columns.Add(localizer.Get("ColumnExtraCapacity"));
            dt.Columns.Add(localizer.Get("ColumnBusModel"));
            dt.Columns.Add(localizer.Get("ColumnAddress"));
            dt.Columns.Add(localizer.Get("ColumnPhone"));
            dt.Columns.Add(localizer.Get("ColumnTripType"));
            dt.Columns.Add(localizer.Get("ColumnDeparture"));
            dt.Columns.Add(localizer.Get("ColumnReturn"));
            dt.Columns.Add(localizer.Get("ColumnDetails"));

            foreach (DataRow row in dataTable.Rows)
            {
                dt.Rows.Add(
                    row["Id"],
                    row["BusDriver"],
                    row["BusDriverAssistant"],
                    row["BusNo"],
                    string.Format(localizer.Get("BusInfoTemplate"),
                    row["BusNo"],
                    row["BusModel"],
                    row["BusNumber"]),
                    row["Capacity"],
                    row["ExtraCapacity"],
                    row["BusModel"],
                    row["Address"],
                    row["PhoneNumber"],
                    row["TripType"],
                    ((DateTime)row["StartDate"]).ToString("yyyy-MM-dd"),
                    ((DateTime)row["FinishDate"]).ToString("yyyy-MM-dd"),
                    row["Details"]
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
                timerExport.Start();
            }
        }

        private DataTable GetBusExportTableFromGrid()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnDriverName"));
            dt.Columns.Add(localizer.Get("ColumnAssistantDriver"));
            dt.Columns.Add(localizer.Get("ColumnPhone"));
            dt.Columns.Add(localizer.Get("ColumnBusInfo"));
            dt.Columns.Add(localizer.Get("PassengersColumn"));
            dt.Columns.Add(localizer.Get("ColumnTripType"));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                dt.Rows.Add(
                    row.Cells[localizer.Get("ColumnDriverName")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnAssistantDriver")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnPhone")].Value?.ToString(),
                    row.Cells[localizer.Get("ColumnBusInfo")].Value?.ToString(),
                    string.Format(localizer.Get("PassengerInfo"),
                    row.Cells[localizer.Get("ColumnCapacity")].Value,
                    row.Cells[localizer.Get("ColumnExtraCapacity")].Value),
                    row.Cells[localizer.Get("ColumnTripType")].Value?.ToString()
                );
            }

            return dt;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.BusEnrollmentLocal.BusUserControlLocalization");

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
            flowLayoutPanel1.Size = new System.Drawing.Size(1280, 62);
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;

            // Buttons
            // Add Button
            buttonAdd.Text = "Add";
            buttonAdd.Size = new System.Drawing.Size(149, 42);
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.TextAlign = ContentAlignment.MiddleCenter;
            buttonAdd.Padding = new Padding(10, 0, 0, 0);

            // Edit Button
            buttonEdit.Text = "Edit";
            buttonEdit.Size = new System.Drawing.Size(149, 42);
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.TextAlign = ContentAlignment.MiddleCenter;
            buttonEdit.Padding = new Padding(10, 0, 0, 0);

            // Delete Button
            buttonDelete.Text = "Delete";
            buttonDelete.Size = new System.Drawing.Size(149, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;
            buttonDelete.Padding = new Padding(10, 0, 0, 0);

            // Refresh Button
            buttonRefrech.Text = "Refresh";
            buttonRefrech.Size = new System.Drawing.Size(149, 42);
            buttonRefrech.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefrech.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefrech.Padding = new Padding(10, 0, 0, 0);

            // Export Container
            flowLayoutPanelDropDownContainer.Size = new System.Drawing.Size(145, 44);
            flowLayoutPanelDropDownContainer.MinimumSize = new System.Drawing.Size(145, 44);
            flowLayoutPanelDropDownContainer.MaximumSize = new System.Drawing.Size(145, 79);

            panelExportButton.Size = new System.Drawing.Size(150, 43);

            buttonExport.Text = "Export";
            buttonExport.Size = new System.Drawing.Size(145, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;
            buttonExport.Padding = new Padding(10, 0, 0, 0);

            panelExportFormats.Size = new System.Drawing.Size(150, 35);

            buttonAsDocx.Location = new Point(6, 2);
            buttonAsDocx.Size = new System.Drawing.Size(48, 30);
            buttonAsXlsx.Location = new Point(54, 2);
            buttonAsXlsx.Size = new System.Drawing.Size(48, 30);
            buttonAsPDF.Location = new Point(102, 2);
            buttonAsPDF.Size = new System.Drawing.Size(48, 30);

            // Search Panel
            panelSearch.Size = new System.Drawing.Size(406, 44);

            buttonSearch.Text = "Search";
            buttonSearch.Size = new System.Drawing.Size(113, 44);
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.Padding = new Padding(10, 0, 0, 0);

            textBoxSearch.Size = new System.Drawing.Size(294, 44);
            textBoxSearch.Font = new System.Drawing.Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            // Send Message Panel
            panel2.Size = new System.Drawing.Size(38, 42);

            // DataGridView
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RightToLeft = RightToLeft.No;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNo.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNo.Location = new Point(1173, 686);
            comboBoxPageNo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNo.RightToLeft = RightToLeft.No;

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
            flowLayoutPanel1.Size = new System.Drawing.Size(1280, 62);
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Dock = DockStyle.Top;

            // Buttons (Arabic Layout)
            // Add Button
            buttonAdd.Text = "إضافة";
            buttonAdd.Size = new System.Drawing.Size(127, 42);
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.TextAlign = ContentAlignment.MiddleCenter;

            // Edit Button
            buttonEdit.Text = "تعديل";
            buttonEdit.Size = new System.Drawing.Size(127, 42);
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.TextAlign = ContentAlignment.MiddleCenter;

            // Delete Button
            buttonDelete.Text = "حذف";
            buttonDelete.Size = new System.Drawing.Size(127, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;

            // Refresh Button
            buttonRefrech.Text = "تحديث";
            buttonRefrech.Size = new System.Drawing.Size(127, 42);
            buttonRefrech.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefrech.TextAlign = ContentAlignment.MiddleCenter;

            // Export Container
            flowLayoutPanelDropDownContainer.Size = new System.Drawing.Size(155, 44);
            flowLayoutPanelDropDownContainer.MinimumSize = new System.Drawing.Size(155, 44);
            flowLayoutPanelDropDownContainer.MaximumSize = new System.Drawing.Size(155, 79);

            panelExportButton.Size = new System.Drawing.Size(155, 44);

            buttonExport.Text = "تصدير";
            buttonExport.Size = new System.Drawing.Size(154, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;

            panelExportFormats.Size = new System.Drawing.Size(155, 35);

            buttonAsDocx.Location = new Point(6, 2);
            buttonAsDocx.Size = new System.Drawing.Size(49, 30);
            buttonAsXlsx.Location = new Point(54, 2);
            buttonAsXlsx.Size = new System.Drawing.Size(49, 30);
            buttonAsPDF.Location = new Point(102, 2);
            buttonAsPDF.Size = new System.Drawing.Size(49, 30);

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

            // Send Message Panel
            panel2.Size = new System.Drawing.Size(38, 42);

            // DataGridView (RTL Support)
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RightToLeft = RightToLeft.Yes;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxPageNo.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNo.Location = new Point(3, 686);
            comboBoxPageNo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNo.RightToLeft = RightToLeft.Yes;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            RightToLeft = RightToLeft.No;


            // UserControl
            Size = new System.Drawing.Size(1280, 720);
            RightToLeft = RightToLeft.No;
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Toolbar
            flowLayoutPanel1.Size = new System.Drawing.Size(1280, 62);
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;

            // Buttons (Russian Layout)
            // Add Button
            buttonAdd.Text = "Добавить";
            buttonAdd.Size = new System.Drawing.Size(149, 42);
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.TextAlign = ContentAlignment.MiddleCenter;
            buttonAdd.Padding = new Padding(10, 0, 0, 0);

            // Edit Button
            buttonEdit.Size = new System.Drawing.Size(201, 42);
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.TextAlign = ContentAlignment.MiddleCenter;
            buttonEdit.Padding = new Padding(0, 0, 0, 0);

            // Delete Button
            buttonDelete.Text = "Удалить";
            buttonDelete.Size = new System.Drawing.Size(149, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;
            buttonDelete.Padding = new Padding(10, 0, 0, 0);

            // Refresh Button
            buttonRefrech.Text = "Обновить";
            buttonRefrech.Size = new System.Drawing.Size(149, 42);
            buttonRefrech.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefrech.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefrech.Padding = new Padding(10, 0, 0, 0);

            // Export Container
            flowLayoutPanelDropDownContainer.Size = new System.Drawing.Size(145, 44);
            flowLayoutPanelDropDownContainer.MinimumSize = new System.Drawing.Size(145, 44);
            flowLayoutPanelDropDownContainer.MaximumSize = new System.Drawing.Size(145, 79);

            panelExportButton.Size = new System.Drawing.Size(150, 43);

            buttonExport.Text = "Экспорт";
            buttonExport.Size = new System.Drawing.Size(145, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;
            buttonExport.Padding = new Padding(10, 0, 0, 0);

            panelExportFormats.Size = new System.Drawing.Size(150, 35);

            buttonAsDocx.Location = new Point(6, 2);
            buttonAsDocx.Size = new System.Drawing.Size(48, 30);
            buttonAsXlsx.Location = new Point(54, 2);
            buttonAsXlsx.Size = new System.Drawing.Size(48, 30);
            buttonAsPDF.Location = new Point(102, 2);
            buttonAsPDF.Size = new System.Drawing.Size(48, 30);

            // Search Panel
            panelSearch.Size = new System.Drawing.Size(404, 44);

            buttonSearch.Text = "Поиск";
            buttonSearch.Size = new System.Drawing.Size(138, 44);
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.Padding = new Padding(10, 0, 0, 0);

            textBoxSearch.Size = new System.Drawing.Size(268, 44);
            textBoxSearch.Font = new System.Drawing.Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxSearch.RightToLeft = RightToLeft.No;

            // Send Message Panel
            panel2.Size = new System.Drawing.Size(38, 42);

            // DataGridView
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.RightToLeft = RightToLeft.No;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNo.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNo.Location = new Point(1173, 686);
            comboBoxPageNo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNo.RightToLeft = RightToLeft.No;

            ResumeLayout();
            PerformLayout();
        }
        #endregion
    }
}
