using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Data;
using System.Diagnostics;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Services;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Gui.MessageGui;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.PassengerEnrollmentGui
{
    public partial class PssengerUserControl : UserControl
    {
        // Variables
        private readonly IDataHelper<Customers> dataHelper;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private readonly IDataHelper<Buses> busDataHelper;
        private readonly CustomerService _customerService;
        private int RowId;
        private readonly LoadingGui.LoadingForm loadingForm;
        private List<int> IdList = new List<int>();
        private string SearchItem;
        private bool expand = false;
        private bool isAnimating = false;
        private ICurrentUserService _currentUserService;
        private DataTable _exportTable;
        private DataTable _originalTable;

        public PssengerUserControl(ICurrentUserService currentUserService, IDataHelper<Customers> dataHelper,
            IDataHelper<SystemRecords> dataHelperSystemRecords, IDataHelper<Buses> busDataHelper, CustomerService customerService)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            _currentUserService = currentUserService;

            this.dataHelper = dataHelper;

            this.dataHelperSystemRecords = dataHelperSystemRecords;

            this.busDataHelper = busDataHelper;

            _customerService = customerService;

            loadingForm = new LoadingGui.LoadingForm();

            SetRoles();
        }

        #region Evints
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<AddPassengerForm>();

            form.OnCustomerSaved += OnUserSavedHandler;

            async Task OnUserSavedHandler()
            {
                await LoadDataAsync();
            }

            form.SetData(0);

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
                if (dataGridViewPassengers.RowCount > 0)
                {
                    var form = Program.ServiceProvider.GetRequiredService<AddPassengerForm>();

                    form.OnCustomerSaved += OnUserSavedHandler;

                    async Task OnUserSavedHandler()
                    {
                        await LoadDataAsync();
                    }

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

                                var customer = await dataHelper.FindAsync(RowId);
                                var result = await dataHelper.DeleteAsync(RowId);


                                if (result == 1)
                                {
                                    Logger.Audit(
                                        $"Customer Deleted: {customer?.Name} / ID={RowId}");
                                    // Save System Records
                                    SystemRecords systemRecords = new SystemRecords
                                    {
                                        Title = "إجراء حذف",
                                        UserName = Properties.Settings.Default.UserName,
                                        Details = $"تم حذف الراكب {customer?.Name} - رقم {RowId}",
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
                Logger.Log(ex, "Delete Customer");
                MessageCollections.ShowErrorServer();
            }
        }

        private async void buttonRefrech_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
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

            _exportTable = GetExportTableFromGrid(
                localizer.Get("ColumnSeatNumber"),
                localizer.Get("ColumnPassengerName"),
                localizer.Get("ColumnNationality"),
                localizer.Get("ColumnPhone")
            );

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

            dataGridViewPassengers.DataSource = null;
            dataGridViewPassengers.Columns.Clear();
            dataGridViewPassengers.AutoGenerateColumns = true;
            dataGridViewPassengers.DataSource = SetViewTable(dt);

            HideInternalColumns();

            if (dataGridViewPassengers.DataSource == null)
            {
                MessageCollections.ShowErrorServer();
            }
            else
            {
                ApplyRowColors();
            }
            loadingForm.Hide();
            data.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        private async void PssengerUserControl_Load(object sender, EventArgs e)
        {
            ApplyLayout();
            await LoadDataAsync();
        }

        private async void pictureBoxSendMessage_Click(object sender, EventArgs e)
        {
            if (dataGridViewPassengers.CurrentRow == null)
            {
                MessageCollections.ShowWarning(
                    localizer.Get("SelectPassengerFirst"));
                return;
            }
            int customerId = Convert.ToInt32(dataGridViewPassengers.CurrentRow.Cells[0].Value);

            var form = Program.ServiceProvider.GetRequiredService<SendMessageForm>();
            form.SetData(_customerService, customerId);
            form.ShowDialog();


            // After closing, reload the data to update the colors
            await LoadDataAsync();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowColors();

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

        private async void buttonTicketGenrator_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPassengers.CurrentRow == null)
                {
                    MessageBox.Show(MessagesLocal.SelectPassenger);
                    return;
                }

                int id = Convert.ToInt32(dataGridViewPassengers.CurrentRow.Cells[0].Value);

                var customer = await dataHelper.FindAsync(id);

                if (customer == null)
                {
                    MessageBox.Show(MessagesLocal.PassengerNotFound);
                    return;
                }

                var ticketService =
                    Program.ServiceProvider.GetRequiredService<TicketService>();

                var path = await ticketService.CreateFullTicketAsync(customer);

                MessageBox.Show($"{MessagesLocal.TicketCreated}\n{path}");
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Generate Ticket");
                MessageBox.Show(MessagesLocal.TicketCreationFailed);
            }
        }
        #endregion
        #region Methods
        public async Task LoadDataAsync()
        {
            CloseExportMenu();

            loadingForm.Show();
            var data = await dataHelper.GetAllDataAsync();

            // for test
            //dataGridView1.DataSource = data.Take(Properties.Settings.Default.DataGridViewRowNo).ToList();

            var list = data.Take(Properties.Settings.Default.DataGridViewRowNo).ToList();

            DataTable dt = new DataTable();
            using (var reader = FastMember.ObjectReader.Create(list))
            {
                dt.Load(reader);
            }

            _originalTable = dt.Copy();

            dataGridViewPassengers.DataSource = null;
            dataGridViewPassengers.Columns.Clear();
            dataGridViewPassengers.AutoGenerateColumns = true;
            dataGridViewPassengers.DataSource = SetViewTable(dt);

            HideInternalColumns();

            labelTotalCustomers.Text =
                $"{localizer.Get("LabelTotalPassengers")}: {data.Count}";

            labelUpcomingTrips.Text =
                $"{localizer.Get("LabelUpcomingTrips")}: " +
                data.Count(x => x.StartDate.Date == DateTime.Today.AddDays(2));

            labelSentToday.Text =
                $"{localizer.Get("LabelSentToday")}: " +
                data.Count(x => x.ConfirmationAutoSentDate == DateTime.Today);

            // Add No of page into combo box
            comboBoxPageNumber.Items.Clear();
            double value = (Convert.ToDouble(data.Count) / Convert.ToDouble(Properties.Settings.Default.DataGridViewRowNo));
            int NoOfPage = (int)Math.Ceiling(value);

            for (int i = 0; i < NoOfPage; i++)
            {
                comboBoxPageNumber.Items.Add(i + 1);
            }
            //

            if (dataGridViewPassengers.DataSource == null)
            {
                MessageCollections.ShowErrorServer();
            }
            else
            {
                ApplyRowColors();
            }
            loadingForm.Hide();
            data.Clear();
        }

        private void Edit()
        {
            if (dataGridViewPassengers.RowCount > 0)
            {
                // Get Id
                RowId = Convert.ToInt32(dataGridViewPassengers.CurrentRow.Cells[0].Value);
                var form = Program.ServiceProvider.GetRequiredService<AddPassengerForm>();
                form.SetData(RowId);
                form.ShowDialog();
            }
            else
            {
                MessageCollections.ShowEmptyDataMessage();
            }
        }

        private void SetIdRowForDelete()
        {
            foreach (DataGridViewRow row in dataGridViewPassengers.Rows)
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

                if (result == null)
                {
                    MessageCollections.ShowErrorServer();
                    return;
                }

                DataTable table = new DataTable();

                using (var reader = FastMember.ObjectReader.Create(result))
                {
                    table.Load(reader);
                }

                _originalTable = table;

                var dt = SetViewTable(table);

                dataGridViewPassengers.DataSource = null;
                dataGridViewPassengers.Columns.Clear();
                dataGridViewPassengers.AutoGenerateColumns = true;
                dataGridViewPassengers.DataSource = dt;

                HideInternalColumns();

                ApplyRowColors();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Customer Search");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
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

                    Logger.Audit("Exported Customers To Word");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Word");
                    MessageCollections.ShowErrorServer();
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

                    Logger.Audit("Exported Customers To Excel");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex, "Export Excel");
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

                Logger.Audit("Exported Customers To PDF");
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
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dataGridViewPassengers.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView)?.Row;

                if (dataRow == null) continue;

                if (!dataRow.Table.Columns.Contains("ConfirmationMessageSent") ||
                    !dataRow.Table.Columns.Contains("RegistrationMessageSent"))
                    continue;

                bool isConfirmed = Convert.ToBoolean(dataRow["ConfirmationMessageSent"]);
                bool isRegistered = Convert.ToBoolean(dataRow["RegistrationMessageSent"]);

                if (isConfirmed && isRegistered)
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                else if (isConfirmed)
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                else if (isRegistered)
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                else
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
        }

        private DataTable SetViewTable(DataTable dataTable)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(localizer.Get("ColumnId"));
            dt.Columns.Add(localizer.Get("ColumnSeatNumber"));
            dt.Columns.Add(localizer.Get("ColumnPassengerName"));
            dt.Columns.Add(localizer.Get("ColumnNationality"));
            dt.Columns.Add(localizer.Get("ColumnPassport"));
            dt.Columns.Add(localizer.Get("ColumnPhone"));
            dt.Columns.Add(localizer.Get("ColumnDeparture"));
            dt.Columns.Add(localizer.Get("ColumnReturn"));
            dt.Columns.Add(localizer.Get("ColumnTripType"));
            dt.Columns.Add(localizer.Get("ColumnLocation"));
            dt.Columns.Add(localizer.Get("ColumnDetails"));
            dt.Columns.Add(localizer.Get("ColumnAddedDate"));
            dt.Columns.Add(localizer.Get("ColumnBusNumber"));

            dt.Columns.Add("ConfirmationMessageSent", typeof(bool));
            dt.Columns.Add("RegistrationMessageSent", typeof(bool));

            foreach (DataRow row in dataTable.Rows)
            {
                dt.Rows.Add(
                    row["Id"],

                    row["ReservationType"]?.ToString() == "Reserve"
                    ? localizer.Get("ReserveSeat")
                    : row["SeatNumber"]?.ToString(),

                    row["Name"],
                    row["Nationality"],
                    row["Passport"],
                    row["PhoneNumber"],
                    ((DateTime)row["StartDate"]).ToString("yyyy-MM-dd"),
                    ((DateTime)row["FinishDate"]).ToString("yyyy-MM-dd"),
                    row["TripType"],
                    row["Address"],
                    row["Details"],
                    Convert.ToDateTime(row["AddedDate"]).ToString("g"),

                    row["BusId"],

                    row.Table.Columns.Contains("ConfirmationMessageSent")
                    ? row["ConfirmationMessageSent"]
                    : false,

                    row.Table.Columns.Contains("RegistrationMessageSent")
                    ? row["RegistrationMessageSent"]
                    : false
                );
            }

            return dt;
        }

        private void HideInternalColumns()
        {
            if (dataGridViewPassengers.Columns.Contains("ConfirmationMessageSent"))
                dataGridViewPassengers.Columns["ConfirmationMessageSent"].Visible = false;

            if (dataGridViewPassengers.Columns.Contains("RegistrationMessageSent"))
                dataGridViewPassengers.Columns["RegistrationMessageSent"].Visible = false;
        }

        private DataTable GetExportTableFromGrid(params string[] columnNames)
        {
            DataTable dt = new DataTable();

            // Create columns
            foreach (var colName in columnNames)
            {
                dt.Columns.Add(colName);
            }

            // Fill the rows from DataGridView
            foreach (DataGridViewRow row in dataGridViewPassengers.Rows)
            {
                if (row.IsNewRow) continue;

                var values = new object[columnNames.Length];

                for (int i = 0; i < columnNames.Length; i++)
                {
                    values[i] = row.Cells[columnNames[i]].Value?.ToString();
                }

                dt.Rows.Add(values);
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

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.PassengerEnrollmentLocal.PassengerUserControlLocalization");

        private void ApplyLocalization()
        {
            buttonAdd.Text =
                localizer.Get("ButtonAdd");

            buttonEdit.Text =
                localizer.Get("ButtonEdit");

            buttonDelete.Text =
                localizer.Get("ButtonDelete");

            buttonRefresh.Text =
                localizer.Get("ButtonRefresh");

            buttonExport.Text =
                localizer.Get("ButtonExport");

            buttonSearch.Text =
                localizer.Get("ButtonSearch");

            buttonTicketViewer.Text =
                localizer.Get("ButtonTicket");

            labelSentToday.Text =
                localizer.Get("LabelSentToday");

            labelTotalCustomers.Text =
                localizer.Get("LabelTotalPassengers");

            labelUpcomingTrips.Text =
                localizer.Get("LabelUpcomingTrips");

            pictureBoxSendMessage.Tag =
                localizer.Get("MsgSendTooltip");
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

        private void ApplyEnglishLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new System.Drawing.Size(1280, 720);
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Toolbar
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 64);
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;

            // Buttons
            // Add Button
            buttonAdd.Text = "Add";
            buttonAdd.Size = new System.Drawing.Size(166, 42);
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;

            // Edit Button
            buttonEdit.Text = "Edit";
            buttonEdit.Size = new System.Drawing.Size(174, 42);
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;

            // Delete Button
            buttonDelete.Text = "Delete";
            buttonDelete.Size = new System.Drawing.Size(149, 42);
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;

            // Refresh Button
            buttonRefresh.Text = "Refresh";
            buttonRefresh.Size = new System.Drawing.Size(156, 42);
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.TextAlign = ContentAlignment.MiddleRight;

            // Export Button
            buttonExport.Text = "Export";
            buttonExport.Size = new System.Drawing.Size(157, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;

            // Generate Ticket Button
            buttonTicketViewer.Text = "Ticket";
            buttonTicketViewer.Size = new System.Drawing.Size(132, 42);
            buttonTicketViewer.ImageAlign = ContentAlignment.MiddleLeft;

            // Search Panel
            panelSearch.Size = new System.Drawing.Size(396, 44);

            buttonSearch.Text = "Search";
            buttonSearch.Size = new System.Drawing.Size(116, 44);
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;

            textBoxSearch.Size = new System.Drawing.Size(280, 44);
            textBoxSearch.Font = new System.Drawing.Font("Arial Narrow", 24F, FontStyle.Bold);

            // Send Message Panel
            panelSendMessage.Size = new System.Drawing.Size(38, 42);

            // Export Formats Panel (Hidden by default)
            flowLayoutPanelExportContainer.Size = new System.Drawing.Size(157, 44);
            panelExportButton.Size = new System.Drawing.Size(159, 43);
            panelExportFormats.Size = new System.Drawing.Size(150, 35);

            buttonExportAsXlsx.Size = new System.Drawing.Size(48, 30);
            buttonExportAsPdf.Size = new System.Drawing.Size(48, 30);
            buttonExportAsDocx.Size = new System.Drawing.Size(48, 30);

            // DataGridView
            dataGridViewPassengers.Dock = DockStyle.Fill;
            dataGridViewPassengers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPassengers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Bottom Controls
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNumber.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNumber.Location = new Point(1173, 686);
            comboBoxPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;

            // Labels
            labelTotalCustomers.Text = "Total Customers: 0";
            labelTotalCustomers.Location = new Point(555, 658);
            labelTotalCustomers.AutoSize = true;

            labelSentToday.Text = "Sent Today: 0";
            labelSentToday.Location = new Point(270, 658);
            labelSentToday.AutoSize = true;

            labelUpcomingTrips.Text = "Upcoming Trips: 0";
            labelUpcomingTrips.Location = new Point(849, 658);
            labelUpcomingTrips.AutoSize = true;

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
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 64);
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;

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
            buttonRefresh.Text = "تحديث";
            buttonRefresh.Size = new System.Drawing.Size(127, 42);
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.TextAlign = ContentAlignment.MiddleCenter;

            // Export Button
            buttonExport.Text = "تصدير";
            buttonExport.Size = new System.Drawing.Size(154, 42);
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;

            // Generate Ticket Button
            buttonTicketViewer.Text = "تذكرة";
            buttonTicketViewer.Size = new System.Drawing.Size(127, 42);
            buttonTicketViewer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTicketViewer.TextAlign = ContentAlignment.MiddleCenter;

            // Export Container
            flowLayoutPanelExportContainer.Size = new System.Drawing.Size(155, 44);
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(155, 44);
            flowLayoutPanelExportContainer.MaximumSize = new System.Drawing.Size(155, 79);
            panelExportButton.Size = new System.Drawing.Size(155, 44);
            panelExportFormats.Size = new System.Drawing.Size(155, 35);

            buttonExportAsXlsx.Size = new System.Drawing.Size(49, 30);
            buttonExportAsPdf.Size = new System.Drawing.Size(49, 30);
            buttonExportAsDocx.Size = new System.Drawing.Size(49, 30);

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
            panelSendMessage.Size = new System.Drawing.Size(38, 42);

            // DataGridView (RTL Support)
            dataGridViewPassengers.Dock = DockStyle.Fill;
            dataGridViewPassengers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPassengers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Applying RTL to DataGridView
            dataGridViewPassengers.RightToLeft = RightToLeft.Yes;

            // Aligning text in cells
            dataGridViewPassengers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewPassengers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewPassengers.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Bottom Controls
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxPageNumber.Size = new System.Drawing.Size(104, 31);
            comboBoxPageNumber.Location = new Point(3, 686);
            comboBoxPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNumber.RightToLeft = RightToLeft.Yes;

            labelTotalCustomers.Text = "إجمالي العملاء: 0";
            labelTotalCustomers.Location = new Point(555, 658);
            labelTotalCustomers.AutoSize = true;
            labelTotalCustomers.TextAlign = ContentAlignment.MiddleRight;

            labelSentToday.Text = "تم الإرسال اليوم: 0";
            labelSentToday.Location = new Point(270, 658);
            labelSentToday.AutoSize = true;
            labelSentToday.TextAlign = ContentAlignment.MiddleRight;

            labelUpcomingTrips.Text = "الرحلات القادمة: 0";
            labelUpcomingTrips.Location = new Point(849, 658);
            labelUpcomingTrips.AutoSize = true;
            labelUpcomingTrips.TextAlign = ContentAlignment.MiddleRight;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // UserControl
            RightToLeft = RightToLeft.No;

            // Toolbar
            flowLayoutPanelToolbar.RightToLeft = RightToLeft.No;
            flowLayoutPanelToolbar.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelToolbar.Size = new System.Drawing.Size(1280, 64);
            flowLayoutPanelToolbar.Padding = new Padding(5);

            // Add Button
            buttonAdd.Text = "Добавить";
            buttonAdd.Size = new System.Drawing.Size(166, 42);
            buttonAdd.TextAlign = ContentAlignment.MiddleCenter;
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.Padding = new Padding(10, 0, 0, 0);

            // Edit Button
            buttonEdit.Text = "Редактировать";

            buttonEdit.Size = new System.Drawing.Size(200, 42);
            buttonEdit.TextAlign = ContentAlignment.MiddleCenter;
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.Padding = new Padding(10, 0, 0, 0);

            // Delete Button
            buttonDelete.Text = "Удалить";
            buttonDelete.Size = new System.Drawing.Size(149, 42);
            buttonDelete.TextAlign = ContentAlignment.MiddleCenter;
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;

            buttonDelete.Padding = new Padding(10, 0, 0, 0);

            // Refresh Button
            buttonRefresh.Text = "Обновить";
            buttonRefresh.Size = new System.Drawing.Size(156, 42);
            buttonRefresh.TextAlign = ContentAlignment.MiddleCenter;
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.Padding = new Padding(10, 0, 0, 0);

            // Export Container
            flowLayoutPanelExportContainer.MinimumSize = new System.Drawing.Size(145, 44);
            flowLayoutPanelExportContainer.MaximumSize = new System.Drawing.Size(157, 79);
            flowLayoutPanelExportContainer.Size = new System.Drawing.Size(157, 44);

            // Export Button Panel
            panelExportButton.Size = new System.Drawing.Size(159, 43);

            // Export Button
            buttonExport.Text = "Экспорт";
            buttonExport.Size = new System.Drawing.Size(157, 42);
            buttonExport.TextAlign = ContentAlignment.MiddleCenter;
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.Padding = new Padding(10, 0, 0, 0);

            // Export Formats Panel
            panelExportFormats.Size = new System.Drawing.Size(150, 35);
            buttonExportAsDocx.Location = new Point(6, 2);
            buttonExportAsXlsx.Location = new Point(54, 2);
            buttonExportAsPdf.Location = new Point(102, 2);

            // Generate Ticket Button
            buttonTicketViewer.Text = "Билет";
            buttonTicketViewer.Size = new System.Drawing.Size(132, 42);
            buttonTicketViewer.TextAlign = ContentAlignment.MiddleCenter;
            buttonTicketViewer.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTicketViewer.Padding = new Padding(10, 0, 0, 0);

            // Search Panel
            panelSearch.RightToLeft = RightToLeft.No;
            panelSearch.Size = new System.Drawing.Size(396, 44);

            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBoxSearch.Size = new System.Drawing.Size(280, 44);

            buttonSearch.Dock = DockStyle.Left;
            buttonSearch.Text = "Поиск";
            buttonSearch.Size = new System.Drawing.Size(116, 44);
            buttonSearch.TextAlign = ContentAlignment.MiddleCenter;
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.Padding = new Padding(10, 0, 0, 0);

            // Send Message Panel
            panelSendMessage.Size = new System.Drawing.Size(38, 42);

            // DataGrid
            dataGridViewPassengers.RightToLeft = RightToLeft.No;

            // Pagination
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNumber.RightToLeft = RightToLeft.No;

            // Labels
            labelTotalCustomers.Text =
                "Всего клиентов: 0";

            labelSentToday.Text =
                "Отправлено сегодня: 0";

            labelUpcomingTrips.Text =
                "Предстоящие поездки: 0";

            ResumeLayout();
            PerformLayout();
        }
        #endregion

        private async void buttonTicketViewer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPassengers.CurrentRow == null)
                {
                    MessageBox.Show(
                        MessagesLocal.SelectPassenger);

                    return;
                }

                int id = Convert.ToInt32(
                    dataGridViewPassengers.CurrentRow.Cells[0].Value);

                var customer =
                    await dataHelper.FindAsync(id);

                if (customer == null)
                {
                    MessageBox.Show(
                        MessagesLocal.PassengerNotFound);

                    return;
                }

                var ticketService =
                    Program.ServiceProvider
                        .GetRequiredService<TicketService>();

                var path =
                    await ticketService
                        .GetTicketPathAsync(customer);

                if (string.IsNullOrWhiteSpace(path) ||
                    !File.Exists(path))
                {
                    MessageBox.Show(
                        MessagesLocal.TicketNotFound);

                    return;
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "View Ticket");

                MessageBox.Show(
                    MessagesLocal.TicketOpenFailed);
            }
        }
    }
}
