using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Services;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Infrastructure.Validation;
using TakeTicket.Domain;
using TakeTicket.Domain.Enums;
using TakeTicket.Domain.Repositories;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.PassengerEnrollmentGui
{
    public partial class AddPassengerForm : Form
    {
        // Variables
        private int ID;
        private Customers customers;
        private readonly IDataHelper<Customers> customerDataHelper;
        private readonly LoadingGui.LoadingForm loadingForm;
        private readonly IDataHelper<SystemRecords> systemRecordsHelper;
        private readonly IDataHelper<Buses> busDataHelper;
        private readonly CustomerService customerService;
        private bool isLoading = false;
        private readonly ICustomerRepository customerRepository;
        private readonly ICurrentUserService _currentUserService;
        public event Func<Task> OnCustomerSaved;

        public AddPassengerForm(CustomerService customerService,
            ICustomerRepository customerRepository,
            ICurrentUserService currentUserService,
            IDataHelper<Customers> customerDataHelper,
            IDataHelper<SystemRecords> systemRecordsHelper,
            IDataHelper<Buses> busDataHelper)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            this.customerService = customerService;

            loadingForm = new LoadingGui.LoadingForm();

            this.customerDataHelper = customerDataHelper;

            this.systemRecordsHelper = systemRecordsHelper;

            this.busDataHelper = busDataHelper;

            comboBoxBusNumber.SelectedIndexChanged += comboBoxBusNumber_SelectedIndexChanged;

            this.customerRepository = customerRepository;

            _currentUserService = currentUserService;

            textBoxAddress.ReadOnly = true;
            radioButtonMain.Checked = true;
        }

        #region Evints
        private async void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            if (IsFieldsEmpty())
            {
                MessageCollections.ShowFieldsRequired();
            }
            else
            {
                loadingForm.Show();

                try
                {
                    if (!ValidateInputs())
                    {
                        MessageCollections.ShowFieldsRequired();
                        return;
                    }

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
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageCollections.ShowFieldsRequired();
                return;
            }
            else
            {
                loadingForm.Show();

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
                loadingForm.Hide();
            }
        }

        private async void AddCustomerForm_Load(object sender, EventArgs e)
        {
            ApplyLayout();
            loadingForm.Show();

            isLoading = true;

            await LoadBuses();
            await SetFieldData();

            isLoading = false;

            loadingForm.Hide();

        }

        private async void comboBoxBusNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            try
            {
                isLoading = true;

                if (comboBoxBusNumber.SelectedItem is Buses bus)
                {
                    await UpdateBusSeats(bus);

                    labelTripTypeValue.Text = bus.TripType;
                    labelDepartureDateValue.Text = bus.StartDate.ToShortDateString();
                    labelReturnDateValue.Text = bus.FinishDate.ToShortDateString();
                    textBoxAddress.Text = bus.Address;
                }
            }
            finally
            {
                isLoading = false;
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

        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Methods
        private async Task<bool> SaveData()
        {
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

        private bool IsFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(textBoxPassengerName.Text)
                || string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text);
        }

        private async Task<bool> AddData()
        {
            try
            {
                if (!radioButtonMain.Checked && !radioButtonExtra.Checked)
                {
                    MessageCollections.ShowNotification(localizer.Get("ReservationTypeRequired"));
                    return false;
                }

                var bus = comboBoxBusNumber.SelectedItem as Buses;

                if (bus == null)
                {
                    MessageCollections.ShowNotification(localizer.Get("BusRequiredMessage")); return false;
                }

                string seatNumber = await GenerateSeatNumber(bus);

                // Set Data
                customers = new Customers
                {
                    SeatNumber = seatNumber,
                    Name = textBoxPassengerName.Text,
                    Nationality = textBoxNationality.Text,
                    Passport = textBoxPasportId.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,

                    TripType = bus.TripType,
                    Address = bus.Address,
                    StartDate = bus.StartDate,
                    FinishDate = bus.FinishDate,

                    //StartDate = dateTimePickerStart.Value,
                    //FinishDate = dateTimePickerFinish.Value,
                    //TripType = comboBoxTripType.SelectedItem?.ToString(),

                    //Address = textBoxAddress.Text,
                    Details = richTextBoxDetails.Text,
                    AddedDate = DateTime.Now,
                    BusId = bus.Id,
                    ReservationType = radioButtonMain.Checked
                    ? ReservationType.Main
                    : ReservationType.Reserve,

                    CreatedByUserId = _currentUserService.UserId
                };

                var customersList = await customerRepository.GetByBusIdAsync(bus.Id);

                if (customersList == null)
                    return false;

                int mainCount = customersList.Count(c =>
                c.ReservationType == ReservationType.Main);

                int reserveCount = customersList.Count(c =>
                    c.ReservationType == ReservationType.Reserve);

                if ((customers.ReservationType == ReservationType.Main && mainCount >= bus.Capacity)
                    ||
                    (customers.ReservationType == ReservationType.Reserve && reserveCount >= bus.ExtraCapacity))
                {
                    MessageCollections.ShowNotification(localizer.Get("BusFullMessage"));
                    return false;
                }

                // Save
                var result = await customerService.AddCustomerAsync(
                    customers,
                    Properties.Settings.Default.UserName);

                if (result == 1)
                {
                    await UpdateBusSeats(bus);
                    await systemRecordsHelper.AddAsync(new SystemRecords
                    {
                        Title = localizer.Get("AddPassengerTitle"),
                        UserName = Properties.Settings.Default.UserName,
                        Details = string.Format(
                            localizer.Get("PassengerAddedDetails"),
                            customers.Name,
                            customers.SeatLabel),
                        AddedDate = DateTime.Now
                    });

                    Logger.Audit($"New Customer Added: {customers.Name} / Seat={customers.SeatLabel}");

                    MessageCollections.ShowNotification(
                        string.Format(
                            localizer.Get("PassengerAddedSuccessfully"),
                            customers.SeatLabel));
                    if (OnCustomerSaved != null)
                        await OnCustomerSaved();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Add Customer");
                return false;
            }
        }

        private async Task<bool> EditData()
        {
            try
            {
                var bus = comboBoxBusNumber.SelectedItem as Buses;

                if (bus == null)
                {
                    MessageCollections.ShowWarning(localizer.Get("BusRequiredMessage"));
                    return false;
                }
                var oldCustomer = await customerDataHelper.FindAsync(ID);

                if (oldCustomer == null)
                    return false;

                var newReservationType =
                    radioButtonMain.Checked
                    ? ReservationType.Main
                    : ReservationType.Reserve;

                // Has the bus or booking type changed?
                bool shouldRegenerateSeat =
                    oldCustomer.BusId != bus.Id ||
                    oldCustomer.ReservationType != newReservationType;

                string seatNumber = oldCustomer.SeatNumber;

                // Generate a new number when needed
                if (shouldRegenerateSeat)
                {
                    seatNumber = await GenerateSeatNumber(bus, ID);

                    if (string.IsNullOrWhiteSpace(seatNumber))
                    {
                        MessageCollections.ShowNotification(localizer.Get("NoAvailableSeats"));
                        return false;
                    }
                }

                // Set Data
                customers = new Customers
                {
                    Id = ID,
                    SeatNumber = seatNumber,

                    Name = textBoxPassengerName.Text,
                    Nationality = textBoxNationality.Text,
                    Passport = textBoxPasportId.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,

                    BusId = bus?.Id,
                    TripType = bus?.TripType,
                    Address = bus?.Address,
                    StartDate = bus?.StartDate ?? DateTime.Now,
                    FinishDate = bus?.FinishDate ?? DateTime.Now,

                    Details = richTextBoxDetails.Text,
                    // preserve
                    AddedDate = oldCustomer.AddedDate,
                    RegistrationMessageSent = oldCustomer.RegistrationMessageSent,
                    ConfirmationMessageSent = oldCustomer.ConfirmationMessageSent,
                    ConfirmationAutoSentDate = oldCustomer.ConfirmationAutoSentDate,
                    CreatedByUserId = oldCustomer.CreatedByUserId,

                    // update
                    UpdatedByUserId = _currentUserService.UserId,
                    UpdatedDate = DateTime.Now,

                    ReservationType = newReservationType
                };

                // Sumbit
                var result = await customerService.UpdateCustomerAsync(
                    customers,
                    Properties.Settings.Default.UserName);

                if (result == 1)
                {
                    Logger.Audit($"Customer Updated: {customers.Name} / ID={customers.Id}");

                    // Save System Records
                    SystemRecords systemRecords = new SystemRecords
                    {
                        Title = localizer.Get("EditPassengerTitle"),
                        UserName = Properties.Settings.Default.UserName,
                        Details = string.Format(localizer.Get("PassengerUpdatedDetails"), customers.Name, customers.SeatLabel),
                        AddedDate = DateTime.Now
                    };
                    await systemRecordsHelper.AddAsync(systemRecords);

                    if (OnCustomerSaved != null)
                        await OnCustomerSaved();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Edit Customer");
                return false;
            }
        }

        private async Task SetFieldData()
        {
            if (ID > 0)
            {
                // Set Field
                customers = await customerDataHelper.FindAsync(ID);
                if (customers != null)
                {
                    textBoxPassengerName.Text = customers.Name;
                    textBoxNationality.Text = customers.Nationality;
                    textBoxPasportId.Text = customers.Passport;
                    textBoxPhoneNumber.Text = customers.PhoneNumber;


                    //dateTimePickerStart.Value = customers.StartDate;
                    //dateTimePickerFinish.Value = customers.FinishDate;
                    //comboBoxTripType.SelectedItem = customers.TripType;
                    //textBoxAddress.Text = customers.Address;
                    richTextBoxDetails.Text = customers.Details;

                    // ReservationType
                    if (customers.ReservationType == ReservationType.Main)
                        radioButtonMain.Checked = true;
                    else
                        radioButtonExtra.Checked = true;

                    isLoading = true;

                    if (customers.BusId.HasValue)
                        comboBoxBusNumber.SelectedValue = customers.BusId.Value;

                    isLoading = false;
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
            }
        }

        private async Task LoadBuses()
        {
            radioButtonMain.Checked = true;
            comboBoxBusNumber.SelectedIndexChanged -= comboBoxBusNumber_SelectedIndexChanged;
            var buses = await busDataHelper.GetAllDataAsync();

            if (buses.Count == 0)
            {
                MessageCollections.ShowWarning(localizer.Get("NoBusesFound"));
                comboBoxBusNumber.Enabled = false;
                return;
            }
            comboBoxBusNumber.DataSource = buses;
            //comboBoxBusNumber.DisplayMember = "BusDisplay";
            //comboBoxBusNumber.ValueMember = "Id";

            comboBoxBusNumber.DisplayMember = nameof(Buses.BusDisplay);
            comboBoxBusNumber.ValueMember = nameof(Buses.Id);

            comboBoxBusNumber.SelectedIndexChanged += comboBoxBusNumber_SelectedIndexChanged;

            comboBoxBusNumber.SelectedIndex = 0;

            if (comboBoxBusNumber.SelectedItem is Buses bus)
            {
                await UpdateBusSeats(bus);

                labelTripTypeValue.Text = bus.TripType;
                labelDepartureDateValue.Text = bus.StartDate.ToShortDateString();
                labelReturnDateValue.Text = bus.FinishDate.ToShortDateString();
                textBoxAddress.Text = bus.Address;
            }
        }

        private async Task UpdateBusSeats(Buses bus)
        {
            int busId = bus.Id;

            var customers = await customerRepository.GetByBusIdAsync(busId);

            if (customers == null)
                return;

            int mainCount = customers.Count(c =>
                c.BusId == busId &&
                c.ReservationType == ReservationType.Main);

            int reserveCount = customers.Count(c =>
                c.BusId == busId &&
                c.ReservationType == ReservationType.Reserve);

            int remainingMain = bus.Capacity - mainCount;
            int remainingReserve = bus.ExtraCapacity - reserveCount;

            if (remainingMain == 0 && remainingReserve == 0)
            {
                buttonSave.Enabled = false;
                buttonSaveAndClose.Enabled = false;

                labelMainSeats.Text = localizer.Get("BusFullMessage");
                labelMainSeats.ForeColor = Color.Red;
                return;
            }

            if (remainingMain == 0)
            {
                radioButtonMain.Enabled = false;
                radioButtonExtra.Checked = true;
            }
            else
            {
                radioButtonMain.Enabled = true;
            }

            buttonSave.Enabled = true;
            buttonSaveAndClose.Enabled = true;

            labelMainSeats.Text = string.Format(localizer.Get("MainSeatsRemaining"), remainingMain);
            labelReserveSeats.Text = string.Format(localizer.Get("ReserveSeatsRemaining"), remainingReserve);

            labelMainSeats.ForeColor = remainingMain == 0 ? Color.Red : Color.Green;
            labelReserveSeats.ForeColor = remainingReserve == 0 ? Color.Red : Color.Green;
        }

        public void SetData(int id)
        {
            this.ID = id;
        }

        private void ClearFields()
        {
            textBoxPassengerName.Clear();
            textBoxNationality.Clear();
            textBoxPasportId.Clear();
            textBoxPhoneNumber.Clear();
            richTextBoxDetails.Clear();

            radioButtonMain.Checked = true;

            textBoxPassengerName.Focus();
        }

        private async Task<string> GenerateSeatNumber(Buses bus, int? excludeCustomerId = null)
        {
            var customers = await customerRepository.GetByBusIdAsync(bus.Id);

            if (excludeCustomerId.HasValue)
            {
                customers = customers
                    .Where(x => x.Id != excludeCustomerId.Value)
                    .ToList();
            }

            // Reserve
            if (radioButtonExtra.Checked)
            {
                int reserveCount = customers.Count(x =>
                    x.ReservationType == ReservationType.Reserve);

                return $"أ {reserveCount + 1}";
            }

            // Main
            var usedSeats = customers
                .Where(x => x.ReservationType == ReservationType.Main)
                .Select(x =>
                {
                    int.TryParse(x.SeatNumber, out int n);
                    return n;
                })
                .ToHashSet();

            for (int i = 1; i <= bus.Capacity; i++)
            {
                if (!usedSeats.Contains(i))
                    return i.ToString();
            }

            return null;
        }

        private bool ValidateInputs()
        {
            bool valid = true;

            valid &= Validator.Required(
                textBoxPassengerName,
                errorProvider,
                localizer.Get("PassengerNameRequired"));

            valid &= Validator.Required(
                textBoxPhoneNumber,
                errorProvider,
                localizer.Get("PhoneRequired"));

            valid &= Validator.Phone(
                textBoxPhoneNumber,
                errorProvider,
                localizer.Get("PhoneDigitsOnly"));

            valid &= Validator.Required(
                comboBoxBusNumber,
                errorProvider,
                localizer.Get("BusRequiredMessage"));

            return valid;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.PassengerEnrollmentLocal.AddPassengerFormLocalization");

        private void ApplyLocalization()
        {
            buttonSave.Text = localizer.Get("ButtonSave");
            buttonSaveAndClose.Text = localizer.Get("ButtonSaveAndClose");

            groupBoxBookingType.Text = localizer.Get("GroupBoxBookingType");
            groupBoxPassengerInfo.Text = localizer.Get("GroupBoxPassengerInfo");
            groupBoxSeatsSummary.Text = localizer.Get("GroupBoxSeatsSummary");
            groupBoxTripInfoDisplay.Text = localizer.Get("GroupBoxTripInfo");
            grpSelectBus.Text = localizer.Get("GroupBoxChooseBus");

            labelPassengerName.Text = localizer.Get("LabelPassengerName");
            labelNationality.Text = localizer.Get("LabelNationality");
            labelPhoneNumber.Text = localizer.Get("LabelPhoneNumber");
            labelPassportNumber.Text = localizer.Get("LabelPassportNumber");
            labelAddress.Text = localizer.Get("LabelAddress");
            labelDetails.Text = localizer.Get("LabelDetails");
            labelBusNumberText.Text = localizer.Get("LabelBusNumberText");

            labelTripType.Text = localizer.Get("LabelTripType");
            labelDeparture.Text = localizer.Get("LabelDeparture");
            labelReturn.Text = localizer.Get("LabelReturn");

            labelSubtitle.Text = localizer.Get("LabelSub");
            labelTitle.Text = localizer.Get("LabelTitle");

            radioButtonMain.Text = localizer.Get("RadioMainSeat");
            radioButtonExtra.Text = localizer.Get("RadioExtraSeat");

            Text = localizer.Get("FormTitle");
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

            // Form
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;

            Font = new Font("Arial Narrow", 12F);

            // Close button
            labelCloseWindow.Location = new Point(3, 2);

            // Header
            panelIconContainer.Location = new Point(690, 3);

            labelTitle.Location =
                new Point(517, 5);

            labelSubtitle.Location =
                new Point(394, 29);

            // labels
            labelTripType.Location = new Point(330, 33);
            labelDeparture.Location = new Point(330, 103);
            labelReturn.Location = new Point(330, 157);
            labelAddress.Location = new Point(330, 220);
            lblRequiredAddress.Location = new Point(317, 220);

            labelBusNumberText.Location = new Point(331, 35);
            labelBusNumberStar.Location = new Point(319, 35);

            radioButtonMain.Location = new Point(299, 43);
            radioButtonExtra.Location = new Point(206, 43);

            // Main Layout
            grpSelectBus.Location =
                new Point(3, 91);

            groupBoxSeatsSummary.Location =
                new Point(423, 91);

            groupBoxPassengerInfo.Location =
                new Point(7, 179);

            groupBoxTripInfoDisplay.Location = new Point(340, 179);
            groupBoxBookingType.Location = new Point(340, 428);

            // panelBusNumber
            panelBusNumber.Location = new Point(11, 32);

            // comboBoxBusNumber
            comboBoxBusNumber.Location = new Point(2, 2);

            // Bottom buttons
            buttonSave.Location = new Point(14, 6);

            buttonSaveAndClose.Location = new Point(570, 5);

            // Text Align
            textBoxPassengerName.TextAlign =
                HorizontalAlignment.Right;

            textBoxPhoneNumber.TextAlign =
                HorizontalAlignment.Right;

            textBoxNationality.TextAlign =
                HorizontalAlignment.Right;

            textBoxPasportId.TextAlign =
                HorizontalAlignment.Right;

            textBoxAddress.TextAlign =
                HorizontalAlignment.Left;

            richTextBoxDetails.RightToLeft =
                RightToLeft.Yes;

            comboBoxBusNumber.RightToLeft =
                RightToLeft.Yes;

            // Radio buttons
            radioButtonMain.RightToLeft =
                RightToLeft.Yes;

            radioButtonExtra.RightToLeft =
                RightToLeft.Yes;

            // labels
            labelPassengerName.Location = new Point(262, 26);
            labelPassengerNameStar.Location = new Point(249, 26);

            labelPhoneNumber.Location = new Point(234, 81);
            labelPhoneNumberStar.Location = new Point(222, 81);

            labelNationality.Location = new Point(250, 138);
            labelNationalityStar.Location = new Point(238, 138);

            labelPassportNumber.Location = new Point(229, 195);
            labelPassportNumberStar.Location = new Point(217, 195);

            labelDetails.Location = new Point(243, 253);

            labelTripTypeValue.Location = new Point(126, 33);
            labelDepartureDateValue.Location = new Point(122, 96);
            labelReturnDateValue.Location = new Point(122, 157);

            // textBoxAddress
            textBoxAddress.Location = new Point(9, 217);

            // radios
            radioButtonMain.Location = new Point(299, 43);
            radioButtonExtra.Location = new Point(206, 43);

            // Required labels (*)
            labelPassengerNameStar.Location =
                new Point(
                    labelPassengerName.Left - 15,
                    labelPassengerName.Top);

            labelPhoneNumberStar.Location =
                new Point(
                    labelPhoneNumber.Left - 15,
                    labelPhoneNumber.Top);

            labelNationalityStar.Location =
                new Point(
                    labelNationality.Left - 15,
                    labelNationality.Top);

            labelPassportNumberStar.Location =
                new Point(
                    labelPassportNumber.Left - 15,
                    labelPassportNumber.Top);

            lblRequiredAddress.Location =
                new Point(
                    labelAddress.Left - 15,
                    labelAddress.Top);

            ResumeLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // Form
            Width = 840;
            Height = 620;
            MinimumSize = new Size(840, 620);

            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;

            Font = new Font("Arial Narrow", 12F);

            // Header
            panelIconContainer.Location =
                new Point(26, 7);

            labelTitle.Location =
                new Point(84, 6);

            labelSubtitle.Location =
                new Point(84, 34);

            labelTitle.Font =
                new Font("Arial", 18F);

            labelSubtitle.Font =
                new Font("Arial", 12.75F);

            // Close button
            labelCloseWindow.Location =
                new Point(ClientSize.Width - 24, 1);

            // GroupBoxes Layout
            // Top section
            grpSelectBus.Location =
                new Point(5, 91);

            grpSelectBus.Size =
                new Size(450, 82);

            groupBoxSeatsSummary.Location =
                new Point(460, 91);

            groupBoxSeatsSummary.Size =
                new Size(360, 82);

            // Main content
            groupBoxPassengerInfo.Location = new Point(5, 179);
            groupBoxPassengerInfo.Size = new Size(350, 328);
            groupBoxTripInfoDisplay.Location = new Point(360, 179);
            groupBoxTripInfoDisplay.Size = new Size(460, 249);

            // Booking type
            groupBoxBookingType.Location = new Point(360, 432);
            groupBoxBookingType.Size = new Size(460, 78);

            // Bus selection section
            panelBusNumber.Location = new Point(140, 28);
            panelBusNumber.Size = new Size(300, 32);
            comboBoxBusNumber.Width = 296;

            // Fix required star
            labelBusNumberStar.Location = new Point(labelBusNumberText.Right + 3, labelBusNumberText.Top);


            // Passenger info sizing
            int inputWidth = 315;
            panelPassengerName.Width = inputWidth;
            panelPhoneNumber.Width = inputWidth;
            panelNationality.Width = inputWidth;
            panelPassportNumber.Width = inputWidth;
            panelDetails.Width = inputWidth;

            // TextBoxes
            textBoxPassengerName.Width = inputWidth - 5;
            textBoxPhoneNumber.Width = inputWidth - 5;
            textBoxNationality.Width = inputWidth - 5;
            textBoxPasportId.Width = inputWidth - 5;

            richTextBoxDetails.Width = inputWidth - 8;

            // Center align for Russian UX
            textBoxPassengerName.TextAlign = HorizontalAlignment.Center;
            textBoxPhoneNumber.TextAlign = HorizontalAlignment.Center;
            textBoxNationality.TextAlign = HorizontalAlignment.Center;
            textBoxPasportId.TextAlign = HorizontalAlignment.Center;
            textBoxAddress.TextAlign = HorizontalAlignment.Center;

            // Required labels (*)
            labelPassengerNameStar.Location = new Point(labelPassengerName.Right + 3, labelPassengerName.Top);
            labelPhoneNumberStar.Location = new Point(labelPhoneNumber.Right + 3, labelPhoneNumber.Top);
            labelNationalityStar.Location = new Point(labelNationality.Right + 3, labelNationality.Top);
            labelPassportNumberStar.Location = new Point(labelPassportNumber.Right + 3, labelPassportNumber.Top);
            lblRequiredAddress.Location = new Point(labelAddress.Right + 3, labelAddress.Top);

            // Trip info section
            textBoxAddress.Location = new Point(130, 214);
            textBoxAddress.Size = new Size(297, 26);
            labelTripTypeValue.Location = new Point(170, 31);
            labelDepartureDateValue.Location = new Point(170, 99);
            labelReturnDateValue.Location = new Point(170, 157);

            // Stretch separators for width
            labelLineSeparator1.Width = 410;
            labelLineSeparator2.Width = 410;
            labelLineSeparator3.Width = 410;

            // Booking type radios
            radioButtonMain.Location = new Point(30, 42);
            radioButtonExtra.Location = new Point(185, 42);

            // Bottom buttons
            pnlBottomButtons.Height = 64;
            buttonSave.Location = new Point(15, 6);
            buttonSave.Size = new Size(180, 51);
            buttonSaveAndClose.Location = new Point(600, 6);
            buttonSaveAndClose.Size = new Size(220, 51);

            ResumeLayout();
        }

        private void ApplyEnglishLayout()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(753, 573);
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            Font = new Font("Arial Narrow", 12F);

            // Title Bar
            panelTitleBar.Size = new Size(753, 24);
            labelCloseWindow.Location = new Point(733, 1);

            // Header
            panelHeader.Size = new Size(753, 61);

            labelTitle.Text = "Add / Edit passenger";
            labelTitle.Location = new Point(84, 6);
            labelTitle.AutoSize = true;

            labelSubtitle.Text =
                "Enter passenger details and select the bus and journey";
            labelSubtitle.Location = new Point(83, 32);
            labelSubtitle.Size = new Size(295, 25);

            panelIconContainer.Location = new Point(26, 7);

            // Select Bus
            grpSelectBus.Text = "🚌 Choose a bus";
            grpSelectBus.Location = new Point(3, 91);
            grpSelectBus.Size = new Size(414, 82);

            labelBusNumberText.Text = "Bus No";
            labelBusNumberText.Location = new Point(25, 33);

            labelBusNumberStar.Location = new Point(76, 33);

            panelBusNumber.Location = new Point(103, 28);
            panelBusNumber.Size = new Size(305, 32);

            comboBoxBusNumber.Size = new Size(300, 28);

            // Seats Summary
            groupBoxSeatsSummary.Text = "🎟 Seats summary";
            groupBoxSeatsSummary.Location = new Point(423, 91);
            groupBoxSeatsSummary.Size = new Size(327, 82);

            labelMainSeats.Location = new Point(6, 25);
            labelReserveSeats.Location = new Point(6, 56);

            // Passenger Information
            groupBoxPassengerInfo.Text = "👤 Passenger information";
            groupBoxPassengerInfo.Location = new Point(7, 179);
            groupBoxPassengerInfo.Size = new Size(327, 328);

            // Name
            labelPassengerName.Text = "Name";
            labelPassengerName.Location = new Point(11, 24);

            labelPassengerNameStar.Location = new Point(60, 24);

            panelPassengerName.Location = new Point(10, 48);
            panelPassengerName.Size = new Size(291, 32);

            textBoxPassengerName.Size = new Size(287, 19);

            // Phone
            labelPhoneNumber.Text = "Phone Number";
            labelPhoneNumber.Location = new Point(8, 81);

            labelPhoneNumberStar.Location = new Point(105, 83);

            panelPhoneNumber.Location = new Point(8, 103);
            panelPhoneNumber.Size = new Size(293, 32);

            // Nationality
            labelNationality.Text = "Nationality";
            labelNationality.Location = new Point(10, 134);

            labelNationalityStar.Location = new Point(77, 138);

            panelNationality.Location = new Point(8, 160);
            panelNationality.Size = new Size(293, 32);

            // Passport
            labelPassportNumber.Text = "Passport";
            labelPassportNumber.Location = new Point(7, 194);

            labelPassportNumberStar.Location = new Point(66, 195);

            panelPassportNumber.Location = new Point(7, 217);
            panelPassportNumber.Size = new Size(294, 32);

            // Details
            labelDetails.Text = "Details";
            labelDetails.Location = new Point(8, 252);

            panelDetails.Location = new Point(7, 275);
            panelDetails.Size = new Size(294, 44);

            richTextBoxDetails.Size = new Size(285, 34);

            // Trip Information
            groupBoxTripInfoDisplay.Text = "🚌 Trip information display";
            groupBoxTripInfoDisplay.Location = new Point(340, 179);
            groupBoxTripInfoDisplay.Size = new Size(410, 249);

            labelTripType.Text = "Trip Type";
            labelTripType.Location = new Point(6, 33);

            labelTripTypeValue.Location = new Point(141, 33);

            labelDeparture.Text = "Departure";
            labelDeparture.Location = new Point(6, 103);

            labelDepartureDateValue.Location = new Point(137, 96);

            labelReturn.Text = "Return";
            labelReturn.Location = new Point(16, 157);

            labelReturnDateValue.Location = new Point(137, 157);

            labelLineSeparator1.Text =
                "__________________________________________________";
            labelLineSeparator1.Location = new Point(26, 59);

            labelLineSeparator2.Text =
                "__________________________________________________";
            labelLineSeparator2.Location = new Point(26, 119);

            labelLineSeparator3.Text =
                "__________________________________________________";
            labelLineSeparator3.Location = new Point(26, 177);

            // Address
            labelAddress.Text = "Address";
            labelAddress.Location = new Point(26, 220);

            lblRequiredAddress.Location = new Point(89, 220);

            textBoxAddress.Location = new Point(104, 217);
            textBoxAddress.Size = new Size(295, 26);

            // Booking Type
            groupBoxBookingType.Text = "🎫 Booking type";
            groupBoxBookingType.Location = new Point(340, 428);
            groupBoxBookingType.Size = new Size(410, 82);

            radioButtonMain.Text = "Main Seat";
            radioButtonMain.Location = new Point(26, 43);

            radioButtonExtra.Text = "Extra Seat";
            radioButtonExtra.Location = new Point(142, 43);

            // Bottom Buttons
            pnlBottomButtons.Size = new Size(753, 64);

            buttonSave.Text = "     Save";
            buttonSave.Location = new Point(14, 6);
            buttonSave.Size = new Size(214, 51);

            buttonSaveAndClose.Text = "Save and close";
            buttonSaveAndClose.Location = new Point(535, 6);
            buttonSaveAndClose.Size = new Size(191, 51);

            ResumeLayout();
        }
        #endregion
    }
}
