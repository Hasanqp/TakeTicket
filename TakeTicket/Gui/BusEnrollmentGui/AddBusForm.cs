using System.Threading.Tasks;
using TakeTicket.Application.Services;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Infrastructure.Validation;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.BusEnrollmentGui
{
    public partial class AddBusForm : Form
    {
        // Variables
        private int ID;
        private Buses buses;
        private readonly IDataHelper<Buses> dataHelper;
        private readonly LoadingGui.LoadingForm loadingForm;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private readonly BusService _busService;
        private bool _isCheckingBusNo = false;

        public AddBusForm(IDataHelper<Buses> dataHelper, IDataHelper<SystemRecords> dataHelperSystemRecords, BusService busService)
        {
            InitializeComponent();

            ApplyLocalization();
            LoadTripTypes();
            ApplyLayout();

            this.dataHelper = dataHelper;
            this.dataHelperSystemRecords = dataHelperSystemRecords;

            _busService = busService;

            loadingForm = new LoadingGui.LoadingForm();
        }

        #region Evints
        // Buttons
        private async void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageCollections.ShowFieldsRequired();
                return;
            }

            loadingForm.Show();

            try
            {
                if (await SaveData())
                {
                    if (ID == 0)
                    {
                        MessageCollections.ShowAddNotification();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageCollections.ShowUpdateNotification();
                    }

                    Close();
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageCollections.ShowFieldsRequired();
                return;
            }

            loadingForm.Show();

            try
            {
                if (await SaveData())
                {
                    if (ID == 0)
                    {
                        MessageCollections.ShowAddNotification();
                        ClearFields();
                    }
                    else
                    {
                        MessageCollections.ShowUpdateNotification();
                    }
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddBusForm_Load(object sender, EventArgs e)
        {
            try
            {
                loadingForm.Show();
                ApplyLayout();
                await SetFieldData();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "AddBusForm Load");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private async void textBoxBusNo_Leave(object sender, EventArgs e)
        {
            if (_isCheckingBusNo) return;

            try
            {
                _isCheckingBusNo = true;

                if (!int.TryParse(textBoxBusNumber.Text, out int busNo))
                {
                    errorProvider.SetError(textBoxBusNumber, localizer.Get("InvalidBusNo"));
                    return;
                }

                bool exists = await _busService.IsBusNoExists(busNo, ID);

                bool alreadyHasError =
                    !string.IsNullOrEmpty(errorProvider.GetError(textBoxBusNumber));

                if (exists)
                {
                    errorProvider.SetError(textBoxBusNumber, localizer.Get("BusNoUsed"));

                    if (!alreadyHasError)
                    {
                        MessageCollections.ShowNotification($"❌ {localizer.Get("BusNoAlreadyExists")}");
                    }
                }
                else
                {
                    errorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Check Bus Number");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                _isCheckingBusNo = false;
            }
        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void textBoxBusModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Methods
        private async Task<bool> SaveData()
        {
            if (!string.IsNullOrEmpty(errorProvider.GetError(textBoxBusNumber)))
            {
                MessageCollections.ShowWarning(localizer.Get("FixErrorsFirst"));
                return false;
            }

            // Add
            if (ID == 0)
            {
                return await AddData();
            }
            // Edit
            else
            {
                return await EditData();
            }
        }

        private async Task<bool> AddData()
        {
            try
            {
                int busNo = Convert.ToInt32(textBoxBusNumber.Text);

                if (await _busService.IsBusNumberExists(textBoxBusLicensePlate.Text, ID))
                {
                    MessageCollections.ShowNotification($"❌ {localizer.Get("LicensePlateUsed")}");
                    return false;
                }

                if (await _busService.IsBusNoExists(busNo))
                {
                    MessageCollections.ShowNotification($"❌ {localizer.Get("BusNoAlreadyExists")}");
                    return false;
                }

                // Set Data
                buses = new Buses
                {
                    BusDriver = textBoxBusDriver.Text,
                    BusDriverAssistant = textBoxBusDriverAssistant.Text,
                    BusNo = Convert.ToInt32(textBoxBusNumber.Text),
                    BusNumber = textBoxBusLicensePlate.Text,
                    Capacity = (int)numericUpDownCapacity.Value,
                    ExtraCapacity = (int)numericUpDownExtraCapacity.Value,
                    BusModel = textBoxBusModel.Text,
                    Address = textBoxAddress.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    Details = richTextBoxDetails.Text,
                    AddedDate = DateTime.Now,
                    TripType = comboBoxTripType.SelectedItem?.ToString(),
                    StartDate = dateTimePickerStartDate.Value,
                    FinishDate = dateTimePickerEndDate.Value
                };

                // Sumbit
                var result = await dataHelper.AddAsync(buses);
                if (result == 1)
                {
                    // Save System Records
                    SystemRecords systemRecords = new SystemRecords
                    {
                        Title = localizer.Get("AddBusTitle"),
                        UserName = Properties.Settings.Default.UserName,
                        Details = string.Format(localizer.Get("BusAddedDetail"), buses.BusNumber, buses.Capacity, buses.ExtraCapacity),
                        AddedDate = DateTime.Now
                    };

                    Logger.Audit($"New Bus Added: {buses.BusNumber} / Seats = {buses.Capacity} - extara seats = {buses.ExtraCapacity}");

                    MessageCollections.ShowNotification(
                            string.Format(localizer.Get("RegistrationSuccess"), buses.BusNumber));

                    await dataHelperSystemRecords.AddAsync(systemRecords);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Add Bus");
                return false;
            }
        }

        private async Task<bool> EditData()
        {
            try
            {
                int busNo = Convert.ToInt32(textBoxBusNumber.Text);

                if (await _busService.IsBusNumberExists(textBoxBusLicensePlate.Text, ID))
                {
                    MessageCollections.ShowNotification($"❌ {localizer.Get("LicensePlateUsed")}");
                    return false;
                }

                if (await _busService.IsBusNoExists(busNo, ID))
                {
                    MessageCollections.ShowNotification($"❌ {localizer.Get("BusNoAlreadyExists")}");
                    return false;
                }

                var oldBus = await dataHelper.FindAsync(ID);

                if (oldBus == null)
                {
                    MessageCollections.ShowErrorServer();
                    return false;
                }

                // Set Data
                buses = new Buses
                {
                    Id = ID,
                    BusDriver = textBoxBusDriver.Text,
                    BusDriverAssistant = textBoxBusDriverAssistant.Text,
                    BusNo = Convert.ToInt32(textBoxBusNumber.Text),
                    BusNumber = textBoxBusLicensePlate.Text,
                    Capacity = (int)numericUpDownCapacity.Value,
                    ExtraCapacity = (int)numericUpDownExtraCapacity.Value,
                    BusModel = textBoxBusModel.Text,
                    TripType = comboBoxTripType.SelectedItem?.ToString(),
                    StartDate = dateTimePickerStartDate.Value,
                    FinishDate = dateTimePickerEndDate.Value,
                    Address = textBoxAddress.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    Details = richTextBoxDetails.Text,
                };

                // Sumbit
                var result = await dataHelper.EditAsync(buses);
                if (result == 1)
                {
                    // Save System Records
                    SystemRecords systemRecords = new SystemRecords
                    {
                        Title = localizer.Get("EditBusRecordTitle"),
                        UserName = Properties.Settings.Default.UserName,
                        Details = string.Format(localizer.Get("BusUpdatedDetail"), buses.BusNumber),
                        AddedDate = DateTime.Now
                    };
                    await dataHelperSystemRecords.AddAsync(systemRecords);

                    Logger.Audit($"Bus Updated: {buses.BusNumber} / ID={buses.Id}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Edit Bus");
                return false;
            }
        }

        private async Task SetFieldData()
        {
            try
            {
                if (ID > 0)
                {
                    // Set Field
                    buses = await dataHelper.FindAsync(ID);
                    if (buses != null)
                    {
                        textBoxBusDriver.Text = buses.BusDriver;
                        textBoxBusDriverAssistant.Text = buses.BusDriverAssistant;
                        textBoxBusNumber.Text = buses.BusNo.ToString();
                        textBoxBusLicensePlate.Text = buses.BusNumber;
                        textBoxAddress.Text = buses.Address ?? "";
                        textBoxPhoneNumber.Text = buses.PhoneNumber;
                        richTextBoxDetails.Text = buses.Details;
                        numericUpDownCapacity.Value = buses.Capacity;
                        numericUpDownExtraCapacity.Value = buses.ExtraCapacity;
                        comboBoxTripType.SelectedItem = buses.TripType;
                        dateTimePickerStartDate.Value = buses.StartDate;
                        dateTimePickerEndDate.Value = buses.FinishDate;
                        textBoxBusModel.Text = buses.BusModel;
                    }
                    else
                    {
                        MessageCollections.ShowErrorServer();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Set Bus Fields");
                MessageCollections.ShowErrorServer();
            }
        }

        public void SetData(int id)
        {
            this.ID = id;
        }

        private void ClearFields()
        {
            // Bus Information
            textBoxBusLicensePlate.Clear();
            textBoxBusNumber.Clear();
            textBoxBusModel.Clear();

            // Drver Information
            textBoxBusDriver.Clear();
            textBoxBusDriverAssistant.Clear();
            textBoxPhoneNumber.Clear();
            richTextBoxDetails.Clear();

            // More Information
            richTextBoxDetails.Clear();
        }

        private bool ValidateInputs()
        {
            bool valid = true;

            valid &= Validator.Required(
                textBoxBusDriver,
                errorProvider,
                localizer.Get("DriverNameRequired"));

            valid &= Validator.Required(
                comboBoxTripType,
                errorProvider,
                localizer.Get("TripTypeRequired"));

            valid &= Validator.DateRange(
                dateTimePickerStartDate,
                dateTimePickerEndDate,
                errorProvider,
                localizer.Get("DateRangeInvalid"));

            return valid;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.BusEnrollmentLocal.AddBusFormLocalization");

        private void ApplyLocalization()
        {
            // Buttons
            buttonCancel.Text =
                localizer.Get("ButtonCancel");

            buttonSave.Text =
                localizer.Get("ButtonSave");

            buttonSaveAndClose.Text =
                localizer.Get("ButtonSaveAndClose");

            // Form Title
            this.Text =
                localizer.Get("FormTitle");

            // Header
            labelTitle.Text =
                localizer.Get("LabelTitle");

            labelSub.Text =
                localizer.Get("LabelSub");

            // GroupBoxes
            groupBoxInfo.Text =
                localizer.Get("GroupBoxInfo");

            groupBoxDriverInfo.Text =
                localizer.Get("GroupBoxDriverInfo");

            groupBoxTripInfo.Text =
                localizer.Get("GroupBoxTripInfo");

            groupBoxMoreInfo.Text =
                localizer.Get("GroupBoxMoreInfo");

            groupBoxCapacity.Text =
                localizer.Get("GroupBoxCapacity");

            // Bus Info
            labelBusModel.Text =
                localizer.Get("LabelBusModel");

            labelBusNumber.Text =
                localizer.Get("LabelBusNumber");

            labelLicensePlate.Text =
                localizer.Get("LabelLicensePlate");

            // Driver Info
            labelDriverName.Text =
                localizer.Get("LabelDriverName");

            labelDriverAssistant.Text =
                localizer.Get("LabelDriverAssistant");

            labelPhoneNumber.Text =
                localizer.Get("LabelPhoneNumber");

            // Trip Info
            labelTripType.Text =
                localizer.Get("LabelTripType");

            labelDepartureDate.Text =
                localizer.Get("LabelDepartureDate");

            labelReturnDate.Text =
                localizer.Get("LabelReturnDate");

            // More Info
            labelAddress.Text =
                localizer.Get("LabelAddress");

            labelDetails.Text =
                localizer.Get("LabelDetails");

            // Capacity
            labelCapacity.Text =
                localizer.Get("LabelCapacity");

            labelExtraCapacity.Text =
                localizer.Get("LabelExtraCapacity");
        }

        private void LoadTripTypes()
        {
            comboBoxTripType.Items.Clear();

            comboBoxTripType.Items.Add(
                localizer.Get("TripTypeMakkahOnly"));

            comboBoxTripType.Items.Add(
                localizer.Get("TripTypeMakkahMadinah"));
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

        private void ApplyArabicLayout()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(839, 569);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;

            //  Title Bar
            panelTitleBar.Size = new Size(839, 25);
            buttonCloseWindow.Location = new Point(-2, 0);
            buttonCloseWindow.Size = new Size(27, 25);
            buttonCloseWindow.Text = "X";

            // Header
            panelHeader.Size = new Size(839, 73);
            panelIconContainer.Location = new Point(781, 12);
            panelIconContainer.Size = new Size(51, 48);

            labelTitle.Text = "إضافة / تعديل باص";
            labelTitle.Location = new Point(613, 11);
            labelTitle.Font = new Font("Arial", 18F);

            labelSub.Text = "أدخل تفاصيل الباص الجديد";
            labelSub.Location = new Point(619, 40);
            labelSub.Font = new Font("Arial", 12.75F);

            // Main Container
            grpMainContainer.Location = new Point(0, 88);
            grpMainContainer.Size = new Size(839, 399);

            // GroupBox: Bus information
            groupBoxInfo.Location = new Point(0, 13);
            groupBoxInfo.Size = new Size(839, 106);
            groupBoxInfo.Text = "معلومات الباص";

            // Bus Number
            labelBusNumber.Location = new Point(491, 35);
            labelBusNumberStar.Location = new Point(475, 36);
            panelBusNumber.Location = new Point(302, 61);
            panelBusNumber.Size = new Size(270, 32);

            // Bus Model
            labelBusModel.Location = new Point(185, 34);
            labelModelStar.Location = new Point(169, 35);
            panelBusModel.Location = new Point(15, 60);
            panelBusModel.Size = new Size(263, 32);

            // License Plate
            labelLicensePlate.Location = new Point(745, 35);
            labelLicensePlateStar.Location = new Point(730, 35);
            panelLicensePlate.Location = new Point(589, 60);
            panelLicensePlate.Size = new Size(237, 32);

            // TextBox TextAlign
            textBoxBusNumber.TextAlign = HorizontalAlignment.Center;
            textBoxBusModel.TextAlign = HorizontalAlignment.Center;
            textBoxBusLicensePlate.TextAlign = HorizontalAlignment.Center;

            // GroupBox: Drivers inforamtion
            groupBoxDriverInfo.Location = new Point(0, 118);
            groupBoxDriverInfo.Size = new Size(839, 96);
            groupBoxDriverInfo.Text = "معلومات السائقين";

            // Driver Name
            labelDriverName.Location = new Point(743, 22);
            labelDriverNameStar.Location = new Point(728, 23);
            panelDriverName.Location = new Point(588, 48);
            panelDriverName.Size = new Size(237, 32);

            // Assistant Driver
            labelDriverAssistant.Location = new Point(443, 23);
            labelAssistantDrverNameStar.Location = new Point(429, 24);
            pnlAssistantDriver.Location = new Point(301, 49);
            pnlAssistantDriver.Size = new Size(270, 32);

            // Phone Number
            labelPhoneNumber.Location = new Point(194, 26);
            lblRequiredPhoneNumber.Location = new Point(180, 26);
            panelPhoneNumber.Location = new Point(13, 51);
            panelPhoneNumber.Size = new Size(264, 32);

            // TextBox TextAlign
            textBoxBusDriver.TextAlign = HorizontalAlignment.Center;
            textBoxBusDriverAssistant.TextAlign = HorizontalAlignment.Center;
            textBoxPhoneNumber.TextAlign = HorizontalAlignment.Center;

            // GroupBox: Trip Information
            groupBoxTripInfo.Location = new Point(0, 214);
            groupBoxTripInfo.Size = new Size(838, 96);
            groupBoxTripInfo.Text = "معلومات الرحلة";

            // Trip Type
            labelTripType.Location = new Point(741, 24);
            labelTripTypeStar.Location = new Point(727, 26);
            panelTripType.Location = new Point(587, 51);
            panelTripType.Size = new Size(237, 32);
            comboBoxTripType.RightToLeft = RightToLeft.Yes;

            // Departure Date
            labelDepartureDate.Location = new Point(175, 28);
            lblRequiredDepartureDate.Location = new Point(161, 29);
            dateTimePickerStartDate.Location = new Point(14, 54);
            dateTimePickerStartDate.Size = new Size(264, 29);
            dateTimePickerStartDate.RightToLeft = RightToLeft.No;

            // Return Date
            labelReturnDate.Location = new Point(479, 28);
            labelReturnDateStar.Location = new Point(465, 29);
            dateTimePickerEndDate.Location = new Point(301, 54);
            dateTimePickerEndDate.Size = new Size(270, 29);
            dateTimePickerEndDate.RightToLeft = RightToLeft.No;

            // GroupBox: Capacity
            groupBoxCapacity.Location = new Point(525, 309);
            groupBoxCapacity.Size = new Size(315, 91);
            groupBoxCapacity.Text = "السعة";

            labelCapacity.Location = new Point(104, 31);
            labelCapacityStar.Location = new Point(90, 31);
            numericUpDownCapacity.Location = new Point(49, 56);
            numericUpDownCapacity.Size = new Size(103, 29);

            labelExtraCapacity.Location = new Point(192, 30);
            labelExtraCapacityStar.Location = new Point(178, 31);
            numericUpDownExtraCapacity.Location = new Point(181, 55);
            numericUpDownExtraCapacity.Size = new Size(118, 29);

            // GroupBox: More information
            groupBoxMoreInfo.Location = new Point(-2, 309);
            groupBoxMoreInfo.Size = new Size(528, 91);
            groupBoxMoreInfo.Text = "معلومات إضافية";

            labelAddress.Location = new Point(219, 22);
            panelAddress.Location = new Point(15, 48);
            panelAddress.Size = new Size(263, 32);
            textBoxAddress.TextAlign = HorizontalAlignment.Center;

            labelDetails.Location = new Point(452, 24);
            labelDetailsStar.Location = new Point(205, 23);
            pnlDetails.Location = new Point(284, 48);
            pnlDetails.Size = new Size(236, 32);
            richTextBoxDetails.RightToLeft = RightToLeft.Yes;

            // Bottom Buttons
            panelDown.Size = new Size(839, 76);

            buttonSave.Text = "حفظ";
            buttonSave.Location = new Point(19, 15);
            buttonSave.Size = new Size(229, 54);
            buttonSave.ImageAlign = ContentAlignment.MiddleRight;

            buttonSaveAndClose.Text = "حفظ وإغلاق";
            buttonSaveAndClose.Location = new Point(300, 15);
            buttonSaveAndClose.Size = new Size(229, 54);
            buttonSaveAndClose.ImageAlign = ContentAlignment.MiddleRight;

            buttonCancel.Text = "إلغاء";
            buttonCancel.Location = new Point(636, 15);
            buttonCancel.Size = new Size(181, 54);
            buttonCancel.ImageAlign = ContentAlignment.MiddleRight;

            // Error Provider
            errorProvider.RightToLeft = true;

            ResumeLayout();
        }

        private void ApplyEnglishLayout()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(839, 569);
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Text = "Add / Edit Bus  🚌";

            // Title Bar
            panelTitleBar.Size = new Size(839, 25);
            buttonCloseWindow.Location = new Point(812, 0);
            buttonCloseWindow.Size = new Size(27, 25);
            buttonCloseWindow.Text = "X";

            // Header
            panelHeader.Size = new Size(839, 73);
            panelIconContainer.Location = new Point(13, 14);
            panelIconContainer.Size = new Size(51, 48);

            labelTitle.Text = "Add / Edit Bus";
            labelTitle.Location = new Point(81, 13);
            labelTitle.Font = new Font("Arial", 18F);

            labelSub.Text = "Enter new bus details";
            labelSub.Location = new Point(81, 40);
            labelSub.Font = new Font("Arial", 12.75F);

            // Main Container
            grpMainContainer.Location = new Point(0, 88);
            grpMainContainer.Size = new Size(839, 399);

            // GroupBox: Bus information
            groupBoxInfo.Location = new Point(0, 13);
            groupBoxInfo.Size = new Size(839, 106);
            groupBoxInfo.Text = "Bus information";

            // Bus Model
            labelBusModel.Text = "Bus model";
            labelBusModel.Location = new Point(17, 36);
            labelModelStar.Location = new Point(106, 36);
            panelBusModel.Location = new Point(15, 60);
            panelBusModel.Size = new Size(263, 32);

            // Bus Number
            labelBusNumber.Text = "Bus Number";
            labelBusNumber.Location = new Point(301, 33);
            labelBusNumberStar.Location = new Point(403, 35);
            panelBusNumber.Location = new Point(302, 61);
            panelBusNumber.Size = new Size(270, 32);

            // License Plate
            labelLicensePlate.Text = "License plate";
            labelLicensePlate.Location = new Point(588, 33);
            labelLicensePlateStar.Location = new Point(698, 35);
            panelLicensePlate.Location = new Point(589, 60);
            panelLicensePlate.Size = new Size(237, 32);

            // TextBox TextAlign
            textBoxBusModel.TextAlign = HorizontalAlignment.Center;
            textBoxBusNumber.TextAlign = HorizontalAlignment.Center;
            textBoxBusLicensePlate.TextAlign = HorizontalAlignment.Center;

            // GroupBox: Drivers information
            groupBoxDriverInfo.Location = new Point(0, 118);
            groupBoxDriverInfo.Size = new Size(839, 96);
            groupBoxDriverInfo.Text = "Drivers information";

            // Phone Number
            labelPhoneNumber.Text = "Phone number";
            labelPhoneNumber.Location = new Point(13, 28);
            lblRequiredPhoneNumber.Location = new Point(135, 28);
            panelPhoneNumber.Location = new Point(13, 51);
            panelPhoneNumber.Size = new Size(264, 32);

            // Assistant Driver
            labelDriverAssistant.Text = "Assistant driver name";
            labelDriverAssistant.Location = new Point(303, 22);
            labelAssistantDrverNameStar.Location = new Point(472, 24);
            pnlAssistantDriver.Location = new Point(301, 49);
            pnlAssistantDriver.Size = new Size(270, 32);

            // Driver Name
            labelDriverName.Text = "Driver name";
            labelDriverName.Location = new Point(589, 22);
            labelDriverNameStar.Location = new Point(692, 25);
            panelDriverName.Location = new Point(588, 48);
            panelDriverName.Size = new Size(237, 32);

            // TextBox TextAlign
            textBoxPhoneNumber.TextAlign = HorizontalAlignment.Center;
            textBoxBusDriverAssistant.TextAlign = HorizontalAlignment.Center;
            textBoxBusDriver.TextAlign = HorizontalAlignment.Center;

            // GroupBox: Trip information
            groupBoxTripInfo.Location = new Point(0, 214);
            groupBoxTripInfo.Size = new Size(838, 96);
            groupBoxTripInfo.Text = "Trip information";

            // Departure Date
            labelDepartureDate.Text = "Departure date";
            labelDepartureDate.Location = new Point(17, 25);
            lblRequiredDepartureDate.Location = new Point(135, 25);
            dateTimePickerStartDate.Location = new Point(14, 48);
            dateTimePickerStartDate.Size = new Size(264, 29);
            dateTimePickerStartDate.RightToLeft = RightToLeft.No;

            // Return Date
            labelReturnDate.Text = "Return date";
            labelReturnDate.Location = new Point(303, 22);
            labelReturnDateStar.Location = new Point(398, 22);
            dateTimePickerEndDate.Location = new Point(301, 48);
            dateTimePickerEndDate.Size = new Size(270, 29);
            dateTimePickerEndDate.RightToLeft = RightToLeft.No;

            // Trip Type
            labelTripType.Text = "Trip type";
            labelTripType.Location = new Point(587, 18);
            labelTripTypeStar.Location = new Point(666, 18);
            panelTripType.Location = new Point(587, 45);
            panelTripType.Size = new Size(237, 32);
            comboBoxTripType.RightToLeft = RightToLeft.No;

            // GroupBox: Capacity
            groupBoxCapacity.Location = new Point(525, 309);
            groupBoxCapacity.Size = new Size(315, 91);
            groupBoxCapacity.Text = "Capacity";

            // Capacity
            labelCapacity.Text = "Capacity";
            labelCapacity.Location = new Point(9, 29);
            labelCapacityStar.Location = new Point(82, 31);
            numericUpDownCapacity.Location = new Point(13, 56);
            numericUpDownCapacity.Size = new Size(103, 29);

            // Extra Capacity
            labelExtraCapacity.Text = "Extra capacity";
            labelExtraCapacity.Location = new Point(141, 29);
            labelExtraCapacityStar.Location = new Point(255, 29);
            numericUpDownExtraCapacity.Location = new Point(141, 55);
            numericUpDownExtraCapacity.Size = new Size(103, 29);

            // GroupBox: More Information
            groupBoxMoreInfo.Location = new Point(-2, 309);
            groupBoxMoreInfo.Size = new Size(528, 91);
            groupBoxMoreInfo.Text = "More Information";

            // Address
            labelAddress.Text = "Address";
            labelAddress.Location = new Point(16, 22);
            panelAddress.Location = new Point(15, 48);
            panelAddress.Size = new Size(263, 32);
            textBoxAddress.TextAlign = HorizontalAlignment.Center;

            // Details
            labelDetails.Text = "Details";
            labelDetails.Location = new Point(284, 22);
            labelDetailsStar.Location = new Point(83, 22);
            pnlDetails.Location = new Point(284, 48);
            pnlDetails.Size = new Size(236, 32);
            richTextBoxDetails.RightToLeft = RightToLeft.No;

            // Bottom Buttons
            panelDown.Size = new Size(839, 76);

            // Save button
            buttonSave.Text = "Save";
            buttonSave.Location = new Point(19, 15);
            buttonSave.Size = new Size(229, 54);
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;

            // Save and Close button
            buttonSaveAndClose.Text = "Save and close";
            buttonSaveAndClose.Location = new Point(300, 15);
            buttonSaveAndClose.Size = new Size(229, 54);
            buttonSaveAndClose.ImageAlign = ContentAlignment.MiddleLeft;

            // Cancel button
            buttonCancel.Text = "Cancel";
            buttonCancel.Location = new Point(588, 15);
            buttonCancel.Size = new Size(229, 54);
            buttonCancel.ImageAlign = ContentAlignment.MiddleLeft;

            // Error Provider
            errorProvider.RightToLeft = false;

            ResumeLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(839, 569);
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;

            // Title Bar
            panelTitleBar.Size = new Size(839, 25);
            buttonCloseWindow.Location = new Point(812, 0);
            buttonCloseWindow.Size = new Size(27, 25);
            buttonCloseWindow.Text = "X";

            // Header
            panelHeader.Size = new Size(839, 73);
            panelIconContainer.Location = new Point(13, 14);
            panelIconContainer.Size = new Size(51, 48);

            labelTitle.Text = "Добавить / Редактировать автобус";
            labelTitle.Location = new Point(81, 13);
            labelTitle.Font = new Font("Arial", 18F);

            labelSub.Text = "Введите данные нового автобуса";
            labelSub.Location = new Point(81, 40);
            labelSub.Font = new Font("Arial", 12.75F);

            // Main Container
            grpMainContainer.Location = new Point(0, 88);
            grpMainContainer.Size = new Size(839, 399);

            // GroupBox: Информация об автобусе
            groupBoxInfo.Location = new Point(0, 13);
            groupBoxInfo.Size = new Size(839, 106);
            groupBoxInfo.Text = "Информация об автобусе";

            // Bus Model (Left side)
            labelBusModel.Text = "Модель автобуса";
            labelBusModel.Location = new Point(18, 35);
            labelModelStar.Location = new Point(165, 35);
            panelBusModel.Location = new Point(15, 60);
            panelBusModel.Size = new Size(263, 32);

            // Bus Number
            labelBusNumber.Text = "Номер автобуса";
            labelBusNumber.Location = new Point(305, 35);
            labelBusNumberStar.Location = new Point(441, 36);
            panelBusNumber.Location = new Point(302, 61);
            panelBusNumber.Size = new Size(270, 32);

            // License Plate
            labelLicensePlate.Text = "Номерной знак";
            labelLicensePlate.Location = new Point(592, 35);
            labelLicensePlateStar.Location = new Point(718, 35);
            panelLicensePlate.Location = new Point(589, 60);
            panelLicensePlate.Size = new Size(237, 32);

            // TextBox TextAlign
            textBoxBusModel.TextAlign = HorizontalAlignment.Center;
            textBoxBusNumber.TextAlign = HorizontalAlignment.Center;
            textBoxBusLicensePlate.TextAlign = HorizontalAlignment.Center;

            // GroupBox: Информация о водителях
            groupBoxDriverInfo.Location = new Point(0, 118);
            groupBoxDriverInfo.Size = new Size(839, 96);
            groupBoxDriverInfo.Text = "Информация о водителях";

            // Phone Number (Left side)
            labelPhoneNumber.Text = "Номер телефона";
            labelPhoneNumber.Location = new Point(16, 27);
            lblRequiredPhoneNumber.Location = new Point(156, 26);
            panelPhoneNumber.Location = new Point(13, 51);
            panelPhoneNumber.Size = new Size(264, 32);

            // Assistant Driver
            labelDriverAssistant.Text = "Имя помощника водителя";
            labelDriverAssistant.Location = new Point(304, 23);
            labelAssistantDrverNameStar.Location = new Point(516, 24);
            pnlAssistantDriver.Location = new Point(301, 49);
            pnlAssistantDriver.Size = new Size(270, 32);

            // Driver Name
            labelDriverName.Text = "Имя водителя";
            labelDriverName.Location = new Point(591, 22);
            labelDriverNameStar.Location = new Point(709, 23);
            panelDriverName.Location = new Point(588, 48);
            panelDriverName.Size = new Size(237, 32);

            // TextBox TextAlign
            textBoxPhoneNumber.TextAlign = HorizontalAlignment.Center;
            textBoxBusDriverAssistant.TextAlign = HorizontalAlignment.Center;
            textBoxBusDriver.TextAlign = HorizontalAlignment.Center;

            // GroupBox: Информация о поездке
            groupBoxTripInfo.Location = new Point(0, 214);
            groupBoxTripInfo.Size = new Size(838, 96);
            groupBoxTripInfo.Text = "Информация о поездке";

            // Departure Date
            labelDepartureDate.Text = "Дата отправления";
            labelDepartureDate.Location = new Point(17, 24);
            lblRequiredDepartureDate.Location = new Point(167, 23);
            dateTimePickerStartDate.Location = new Point(14, 48);
            dateTimePickerStartDate.Size = new Size(264, 29);
            dateTimePickerStartDate.RightToLeft = RightToLeft.No;

            // Return Date
            labelReturnDate.Text = "Дата возвращения";
            labelReturnDate.Location = new Point(303, 22);
            labelReturnDateStar.Location = new Point(457, 23);
            dateTimePickerEndDate.Location = new Point(301, 48);
            dateTimePickerEndDate.Size = new Size(270, 29);
            dateTimePickerEndDate.RightToLeft = RightToLeft.No;

            // Trip Type
            labelTripType.Text = "Тип поездки";
            labelTripType.Location = new Point(590, 20);
            labelTripTypeStar.Location = new Point(693, 20);
            panelTripType.Location = new Point(587, 45);
            panelTripType.Size = new Size(237, 32);
            comboBoxTripType.RightToLeft = RightToLeft.No;

            // GroupBox: Вместимость
            groupBoxCapacity.Location = new Point(525, 309);
            groupBoxCapacity.Size = new Size(315, 91);
            groupBoxCapacity.Text = "Вместимость";

            // Capacity
            labelCapacity.Text = "Вмес.";
            labelCapacity.Location = new Point(16, 30);
            labelCapacityStar.Location = new Point(67, 31);
            numericUpDownCapacity.Location = new Point(13, 56);
            numericUpDownCapacity.Size = new Size(103, 29);

            // Extra Capacity
            labelExtraCapacity.Text = "Доп. вмес.";
            labelExtraCapacity.Location = new Point(144, 29);
            labelExtraCapacityStar.Location = new Point(232, 29);
            numericUpDownExtraCapacity.Location = new Point(141, 55);
            numericUpDownExtraCapacity.Size = new Size(103, 29);

            // GroupBox: Дополнительная информация
            groupBoxMoreInfo.Location = new Point(-2, 309);
            groupBoxMoreInfo.Size = new Size(528, 91);
            groupBoxMoreInfo.Text = "Дополнительная информация";

            // Address
            labelAddress.Text = "Адрес";
            labelAddress.Location = new Point(18, 23);
            panelAddress.Location = new Point(15, 48);
            panelAddress.Size = new Size(263, 32);
            textBoxAddress.TextAlign = HorizontalAlignment.Center;

            // Details
            labelDetails.Text = "Подробности";
            labelDetails.Location = new Point(287, 23);
            labelDetailsStar.Location = new Point(74, 23);
            pnlDetails.Location = new Point(284, 48);
            pnlDetails.Size = new Size(236, 32);
            richTextBoxDetails.RightToLeft = RightToLeft.No;

            // Bottom Buttons
            panelDown.Size = new Size(839, 76);

            // Save button
            buttonSave.Text = "Сохранить";
            buttonSave.Location = new Point(19, 15);
            buttonSave.Size = new Size(229, 54);
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;

            // Save and Close button
            buttonSaveAndClose.Text = "Сохранить и закрыть";
            buttonSaveAndClose.Location = new Point(285, 15);
            buttonSaveAndClose.Size = new Size(258, 54);
            buttonSaveAndClose.ImageAlign = ContentAlignment.MiddleLeft;

            // Cancel button
            buttonCancel.Text = "Отмена";
            buttonCancel.Location = new Point(588, 15);
            buttonCancel.Size = new Size(229, 54);
            buttonCancel.ImageAlign = ContentAlignment.MiddleLeft;

            // Error Provider
            errorProvider.RightToLeft = false;

            ResumeLayout();
        }
        #endregion
    }
}
