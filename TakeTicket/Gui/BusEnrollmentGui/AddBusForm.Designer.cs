namespace TakeTicket.Gui.BusEnrollmentGui
{
    partial class AddBusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBusForm));
            panelDown = new Panel();
            buttonCancel = new Button();
            buttonSaveAndClose = new Button();
            buttonSave = new Button();
            labelDetails = new Label();
            labelAddress = new Label();
            labelReturnDate = new Label();
            labelDepartureDate = new Label();
            textBoxAddress = new TextBox();
            richTextBoxDetails = new RichTextBox();
            dateTimePickerStartDate = new DateTimePicker();
            dateTimePickerEndDate = new DateTimePicker();
            labelDetailsStar = new Label();
            labelReturnDateStar = new Label();
            lblRequiredDepartureDate = new Label();
            groupBoxInfo = new GroupBox();
            panelBusModel = new Panel();
            textBoxBusModel = new TextBox();
            panelLicensePlate = new Panel();
            textBoxBusLicensePlate = new TextBox();
            panelBusNumber = new Panel();
            textBoxBusNumber = new TextBox();
            labelLicensePlate = new Label();
            labelLicensePlateStar = new Label();
            labelBusNumber = new Label();
            labelBusNumberStar = new Label();
            labelBusModel = new Label();
            labelModelStar = new Label();
            groupBoxTripInfo = new GroupBox();
            panelTripType = new Panel();
            comboBoxTripType = new ComboBox();
            labelTripType = new Label();
            labelTripTypeStar = new Label();
            groupBoxDriverInfo = new GroupBox();
            panelDriverName = new Panel();
            textBoxBusDriver = new TextBox();
            labelDriverName = new Label();
            labelDriverNameStar = new Label();
            labelDriverAssistant = new Label();
            labelAssistantDrverNameStar = new Label();
            labelPhoneNumber = new Label();
            lblRequiredPhoneNumber = new Label();
            panelPhoneNumber = new Panel();
            textBoxPhoneNumber = new TextBox();
            pnlAssistantDriver = new Panel();
            textBoxBusDriverAssistant = new TextBox();
            groupBoxMoreInfo = new GroupBox();
            pnlDetails = new Panel();
            panelAddress = new Panel();
            errorProvider = new ErrorProvider(components);
            groupBoxCapacity = new GroupBox();
            labelCapacity = new Label();
            numericUpDownExtraCapacity = new NumericUpDown();
            labelCapacityStar = new Label();
            labelExtraCapacity = new Label();
            numericUpDownCapacity = new NumericUpDown();
            labelExtraCapacityStar = new Label();
            grpMainContainer = new GroupBox();
            panelTitleBar = new Panel();
            buttonCloseWindow = new Button();
            panelHeader = new Panel();
            panelIconContainer = new Panel();
            pictureBoxIcon = new PictureBox();
            labelSub = new Label();
            labelTitle = new Label();
            panelDown.SuspendLayout();
            groupBoxInfo.SuspendLayout();
            panelBusModel.SuspendLayout();
            panelLicensePlate.SuspendLayout();
            panelBusNumber.SuspendLayout();
            groupBoxTripInfo.SuspendLayout();
            panelTripType.SuspendLayout();
            groupBoxDriverInfo.SuspendLayout();
            panelDriverName.SuspendLayout();
            panelPhoneNumber.SuspendLayout();
            pnlAssistantDriver.SuspendLayout();
            groupBoxMoreInfo.SuspendLayout();
            pnlDetails.SuspendLayout();
            panelAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxCapacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExtraCapacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).BeginInit();
            grpMainContainer.SuspendLayout();
            panelTitleBar.SuspendLayout();
            panelHeader.SuspendLayout();
            panelIconContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            SuspendLayout();
            // 
            // panelDown
            // 
            panelDown.Controls.Add(buttonCancel);
            panelDown.Controls.Add(buttonSaveAndClose);
            panelDown.Controls.Add(buttonSave);
            panelDown.Dock = DockStyle.Bottom;
            panelDown.Location = new Point(0, 493);
            panelDown.Margin = new Padding(4, 3, 4, 3);
            panelDown.Name = "panelDown";
            panelDown.Size = new Size(839, 76);
            panelDown.TabIndex = 5;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            buttonCancel.FlatAppearance.BorderSize = 2;
            buttonCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Image = Properties.Resources.icons8_cancel_32;
            buttonCancel.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancel.Location = new Point(588, 15);
            buttonCancel.Margin = new Padding(6);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(229, 54);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSaveAndClose
            // 
            buttonSaveAndClose.BackColor = Color.White;
            buttonSaveAndClose.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            buttonSaveAndClose.FlatAppearance.BorderSize = 2;
            buttonSaveAndClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            buttonSaveAndClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            buttonSaveAndClose.FlatStyle = FlatStyle.Flat;
            buttonSaveAndClose.Image = Properties.Resources.icons8_save_32px;
            buttonSaveAndClose.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveAndClose.Location = new Point(300, 15);
            buttonSaveAndClose.Margin = new Padding(6);
            buttonSaveAndClose.Name = "buttonSaveAndClose";
            buttonSaveAndClose.Size = new Size(229, 54);
            buttonSaveAndClose.TabIndex = 14;
            buttonSaveAndClose.Text = "Save and close";
            buttonSaveAndClose.UseVisualStyleBackColor = false;
            buttonSaveAndClose.Click += buttonSaveAndClose_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.White;
            buttonSave.FlatAppearance.BorderColor = SystemColors.HotTrack;
            buttonSave.FlatAppearance.BorderSize = 2;
            buttonSave.FlatAppearance.MouseDownBackColor = SystemColors.HotTrack;
            buttonSave.FlatAppearance.MouseOverBackColor = SystemColors.HotTrack;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Image = Properties.Resources.icons8_blue_save_32;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(19, 15);
            buttonSave.Margin = new Padding(6);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(229, 54);
            buttonSave.TabIndex = 13;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelDetails
            // 
            labelDetails.AutoSize = true;
            labelDetails.ForeColor = Color.Black;
            labelDetails.Location = new Point(284, 22);
            labelDetails.Margin = new Padding(4, 0, 4, 0);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new Size(61, 23);
            labelDetails.TabIndex = 0;
            labelDetails.Text = "Details";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.ForeColor = Color.Black;
            labelAddress.Location = new Point(16, 22);
            labelAddress.Margin = new Padding(4, 0, 4, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(74, 23);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Address";
            // 
            // labelReturnDate
            // 
            labelReturnDate.AutoSize = true;
            labelReturnDate.ForeColor = Color.Black;
            labelReturnDate.Location = new Point(303, 22);
            labelReturnDate.Margin = new Padding(4, 0, 4, 0);
            labelReturnDate.Name = "labelReturnDate";
            labelReturnDate.Size = new Size(98, 23);
            labelReturnDate.TabIndex = 0;
            labelReturnDate.Text = "Return date";
            // 
            // labelDepartureDate
            // 
            labelDepartureDate.AutoSize = true;
            labelDepartureDate.ForeColor = Color.Black;
            labelDepartureDate.Location = new Point(17, 25);
            labelDepartureDate.Margin = new Padding(4, 0, 4, 0);
            labelDepartureDate.Name = "labelDepartureDate";
            labelDepartureDate.Size = new Size(122, 23);
            labelDepartureDate.TabIndex = 0;
            labelDepartureDate.Text = "Departure date";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BackColor = Color.FromArgb(235, 244, 255);
            textBoxAddress.BorderStyle = BorderStyle.None;
            textBoxAddress.Location = new Point(1, 5);
            textBoxAddress.Margin = new Padding(4, 3, 4, 3);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(258, 22);
            textBoxAddress.TabIndex = 0;
            textBoxAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // richTextBoxDetails
            // 
            richTextBoxDetails.BackColor = Color.FromArgb(235, 244, 255);
            richTextBoxDetails.Location = new Point(0, 2);
            richTextBoxDetails.Margin = new Padding(4, 3, 4, 3);
            richTextBoxDetails.Name = "richTextBoxDetails";
            richTextBoxDetails.Size = new Size(235, 29);
            richTextBoxDetails.TabIndex = 1;
            richTextBoxDetails.Text = "";
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.CalendarMonthBackground = Color.FromArgb(235, 244, 255);
            dateTimePickerStartDate.Format = DateTimePickerFormat.Short;
            dateTimePickerStartDate.Location = new Point(14, 48);
            dateTimePickerStartDate.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.RightToLeft = RightToLeft.No;
            dateTimePickerStartDate.Size = new Size(264, 29);
            dateTimePickerStartDate.TabIndex = 1;
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.CalendarMonthBackground = Color.FromArgb(235, 244, 255);
            dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            dateTimePickerEndDate.Location = new Point(301, 48);
            dateTimePickerEndDate.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.RightToLeft = RightToLeft.No;
            dateTimePickerEndDate.Size = new Size(270, 29);
            dateTimePickerEndDate.TabIndex = 2;
            // 
            // labelDetailsStar
            // 
            labelDetailsStar.AutoSize = true;
            labelDetailsStar.ForeColor = Color.Red;
            labelDetailsStar.Location = new Point(83, 22);
            labelDetailsStar.Margin = new Padding(4, 0, 4, 0);
            labelDetailsStar.Name = "labelDetailsStar";
            labelDetailsStar.Size = new Size(16, 23);
            labelDetailsStar.TabIndex = 20;
            labelDetailsStar.Text = "*";
            // 
            // labelReturnDateStar
            // 
            labelReturnDateStar.AutoSize = true;
            labelReturnDateStar.ForeColor = Color.Red;
            labelReturnDateStar.Location = new Point(398, 22);
            labelReturnDateStar.Margin = new Padding(4, 0, 4, 0);
            labelReturnDateStar.Name = "labelReturnDateStar";
            labelReturnDateStar.Size = new Size(16, 23);
            labelReturnDateStar.TabIndex = 20;
            labelReturnDateStar.Text = "*";
            // 
            // lblRequiredDepartureDate
            // 
            lblRequiredDepartureDate.AutoSize = true;
            lblRequiredDepartureDate.ForeColor = Color.Red;
            lblRequiredDepartureDate.Location = new Point(135, 25);
            lblRequiredDepartureDate.Margin = new Padding(4, 0, 4, 0);
            lblRequiredDepartureDate.Name = "lblRequiredDepartureDate";
            lblRequiredDepartureDate.Size = new Size(16, 23);
            lblRequiredDepartureDate.TabIndex = 20;
            lblRequiredDepartureDate.Text = "*";
            // 
            // groupBoxInfo
            // 
            groupBoxInfo.Controls.Add(panelBusModel);
            groupBoxInfo.Controls.Add(panelLicensePlate);
            groupBoxInfo.Controls.Add(panelBusNumber);
            groupBoxInfo.Controls.Add(labelLicensePlate);
            groupBoxInfo.Controls.Add(labelLicensePlateStar);
            groupBoxInfo.Controls.Add(labelBusNumber);
            groupBoxInfo.Controls.Add(labelBusNumberStar);
            groupBoxInfo.Controls.Add(labelBusModel);
            groupBoxInfo.Controls.Add(labelModelStar);
            groupBoxInfo.ForeColor = Color.FromArgb(200, 118, 10);
            groupBoxInfo.Location = new Point(0, 13);
            groupBoxInfo.Margin = new Padding(4, 3, 4, 3);
            groupBoxInfo.Name = "groupBoxInfo";
            groupBoxInfo.Padding = new Padding(4, 3, 4, 3);
            groupBoxInfo.Size = new Size(839, 106);
            groupBoxInfo.TabIndex = 0;
            groupBoxInfo.TabStop = false;
            groupBoxInfo.Text = "Bus information";
            // 
            // panelBusModel
            // 
            panelBusModel.BackColor = Color.FromArgb(253, 243, 227);
            panelBusModel.Controls.Add(textBoxBusModel);
            panelBusModel.Location = new Point(14, 59);
            panelBusModel.Name = "panelBusModel";
            panelBusModel.Size = new Size(263, 32);
            panelBusModel.TabIndex = 35;
            // 
            // textBoxBusModel
            // 
            textBoxBusModel.BackColor = Color.FromArgb(253, 243, 227);
            textBoxBusModel.BorderStyle = BorderStyle.None;
            textBoxBusModel.Location = new Point(2, 6);
            textBoxBusModel.Margin = new Padding(4, 3, 4, 3);
            textBoxBusModel.Name = "textBoxBusModel";
            textBoxBusModel.Size = new Size(260, 22);
            textBoxBusModel.TabIndex = 2;
            textBoxBusModel.TextAlign = HorizontalAlignment.Center;
            textBoxBusModel.KeyPress += textBoxBusModel_KeyPress;
            // 
            // panelLicensePlate
            // 
            panelLicensePlate.BackColor = Color.FromArgb(253, 243, 227);
            panelLicensePlate.Controls.Add(textBoxBusLicensePlate);
            panelLicensePlate.Location = new Point(588, 59);
            panelLicensePlate.Name = "panelLicensePlate";
            panelLicensePlate.Size = new Size(237, 32);
            panelLicensePlate.TabIndex = 34;
            // 
            // textBoxBusLicensePlate
            // 
            textBoxBusLicensePlate.BackColor = Color.FromArgb(253, 243, 227);
            textBoxBusLicensePlate.BorderStyle = BorderStyle.None;
            textBoxBusLicensePlate.Location = new Point(1, 5);
            textBoxBusLicensePlate.Margin = new Padding(4, 3, 4, 3);
            textBoxBusLicensePlate.Name = "textBoxBusLicensePlate";
            textBoxBusLicensePlate.Size = new Size(233, 22);
            textBoxBusLicensePlate.TabIndex = 0;
            textBoxBusLicensePlate.TextAlign = HorizontalAlignment.Center;
            // 
            // panelBusNumber
            // 
            panelBusNumber.BackColor = Color.FromArgb(253, 243, 227);
            panelBusNumber.Controls.Add(textBoxBusNumber);
            panelBusNumber.Location = new Point(301, 60);
            panelBusNumber.Name = "panelBusNumber";
            panelBusNumber.Size = new Size(270, 32);
            panelBusNumber.TabIndex = 34;
            // 
            // textBoxBusNumber
            // 
            textBoxBusNumber.BackColor = Color.FromArgb(253, 243, 227);
            textBoxBusNumber.BorderStyle = BorderStyle.None;
            textBoxBusNumber.Location = new Point(2, 5);
            textBoxBusNumber.Margin = new Padding(4, 3, 4, 3);
            textBoxBusNumber.Name = "textBoxBusNumber";
            textBoxBusNumber.Size = new Size(266, 22);
            textBoxBusNumber.TabIndex = 1;
            textBoxBusNumber.TextAlign = HorizontalAlignment.Center;
            textBoxBusNumber.Leave += textBoxBusNo_Leave;
            // 
            // labelLicensePlate
            // 
            labelLicensePlate.AutoSize = true;
            labelLicensePlate.ForeColor = Color.FromArgb(0, 0, 3, 51);
            labelLicensePlate.Location = new Point(588, 33);
            labelLicensePlate.Margin = new Padding(4, 0, 4, 0);
            labelLicensePlate.Name = "labelLicensePlate";
            labelLicensePlate.Size = new Size(111, 23);
            labelLicensePlate.TabIndex = 0;
            labelLicensePlate.Text = "License plate";
            // 
            // labelLicensePlateStar
            // 
            labelLicensePlateStar.AutoSize = true;
            labelLicensePlateStar.ForeColor = Color.Red;
            labelLicensePlateStar.Location = new Point(698, 35);
            labelLicensePlateStar.Margin = new Padding(4, 0, 4, 0);
            labelLicensePlateStar.Name = "labelLicensePlateStar";
            labelLicensePlateStar.Size = new Size(16, 23);
            labelLicensePlateStar.TabIndex = 15;
            labelLicensePlateStar.Text = "*";
            // 
            // labelBusNumber
            // 
            labelBusNumber.AutoSize = true;
            labelBusNumber.ForeColor = Color.FromArgb(0, 0, 3, 51);
            labelBusNumber.Location = new Point(301, 33);
            labelBusNumber.Margin = new Padding(4, 0, 4, 0);
            labelBusNumber.Name = "labelBusNumber";
            labelBusNumber.Size = new Size(104, 23);
            labelBusNumber.TabIndex = 16;
            labelBusNumber.Text = "Bus Number";
            // 
            // labelBusNumberStar
            // 
            labelBusNumberStar.AutoSize = true;
            labelBusNumberStar.ForeColor = Color.Red;
            labelBusNumberStar.Location = new Point(403, 35);
            labelBusNumberStar.Margin = new Padding(4, 0, 4, 0);
            labelBusNumberStar.Name = "labelBusNumberStar";
            labelBusNumberStar.Size = new Size(16, 23);
            labelBusNumberStar.TabIndex = 18;
            labelBusNumberStar.Text = "*";
            // 
            // labelBusModel
            // 
            labelBusModel.AutoSize = true;
            labelBusModel.ForeColor = Color.FromArgb(0, 0, 3, 51);
            labelBusModel.Location = new Point(17, 36);
            labelBusModel.Margin = new Padding(4, 0, 4, 0);
            labelBusModel.Name = "labelBusModel";
            labelBusModel.Size = new Size(91, 23);
            labelBusModel.TabIndex = 13;
            labelBusModel.Text = "Bus model";
            // 
            // labelModelStar
            // 
            labelModelStar.AutoSize = true;
            labelModelStar.ForeColor = Color.Red;
            labelModelStar.Location = new Point(106, 36);
            labelModelStar.Margin = new Padding(4, 0, 4, 0);
            labelModelStar.Name = "labelModelStar";
            labelModelStar.Size = new Size(16, 23);
            labelModelStar.TabIndex = 12;
            labelModelStar.Text = "*";
            // 
            // groupBoxTripInfo
            // 
            groupBoxTripInfo.Controls.Add(panelTripType);
            groupBoxTripInfo.Controls.Add(dateTimePickerStartDate);
            groupBoxTripInfo.Controls.Add(labelReturnDateStar);
            groupBoxTripInfo.Controls.Add(dateTimePickerEndDate);
            groupBoxTripInfo.Controls.Add(lblRequiredDepartureDate);
            groupBoxTripInfo.Controls.Add(labelTripType);
            groupBoxTripInfo.Controls.Add(labelTripTypeStar);
            groupBoxTripInfo.Controls.Add(labelDepartureDate);
            groupBoxTripInfo.Controls.Add(labelReturnDate);
            groupBoxTripInfo.ForeColor = Color.FromArgb(38, 124, 102);
            errorProvider.SetIconPadding(groupBoxTripInfo, 2);
            groupBoxTripInfo.Location = new Point(0, 214);
            groupBoxTripInfo.Margin = new Padding(4, 3, 4, 3);
            groupBoxTripInfo.Name = "groupBoxTripInfo";
            groupBoxTripInfo.Padding = new Padding(4, 3, 4, 3);
            groupBoxTripInfo.Size = new Size(838, 96);
            groupBoxTripInfo.TabIndex = 2;
            groupBoxTripInfo.TabStop = false;
            groupBoxTripInfo.Text = "Trip information";
            // 
            // panelTripType
            // 
            panelTripType.BackColor = Color.FromArgb(235, 244, 255);
            panelTripType.Controls.Add(comboBoxTripType);
            panelTripType.Location = new Point(587, 45);
            panelTripType.Name = "panelTripType";
            panelTripType.Size = new Size(237, 32);
            panelTripType.TabIndex = 34;
            // 
            // comboBoxTripType
            // 
            comboBoxTripType.BackColor = Color.FromArgb(235, 244, 255);
            comboBoxTripType.FormattingEnabled = true;
            comboBoxTripType.Location = new Point(0, 0);
            comboBoxTripType.Margin = new Padding(4, 3, 4, 3);
            comboBoxTripType.Name = "comboBoxTripType";
            comboBoxTripType.Size = new Size(235, 31);
            comboBoxTripType.TabIndex = 0;
            // 
            // labelTripType
            // 
            labelTripType.AutoSize = true;
            labelTripType.ForeColor = Color.Black;
            labelTripType.Location = new Point(587, 18);
            labelTripType.Margin = new Padding(4, 0, 4, 0);
            labelTripType.Name = "labelTripType";
            labelTripType.Size = new Size(77, 23);
            labelTripType.TabIndex = 0;
            labelTripType.Text = "Trip type";
            // 
            // labelTripTypeStar
            // 
            labelTripTypeStar.AutoSize = true;
            labelTripTypeStar.BackColor = Color.Transparent;
            labelTripTypeStar.ForeColor = Color.Red;
            labelTripTypeStar.Location = new Point(666, 18);
            labelTripTypeStar.Margin = new Padding(4, 0, 4, 0);
            labelTripTypeStar.Name = "labelTripTypeStar";
            labelTripTypeStar.Size = new Size(16, 23);
            labelTripTypeStar.TabIndex = 20;
            labelTripTypeStar.Text = "*";
            // 
            // groupBoxDriverInfo
            // 
            groupBoxDriverInfo.Controls.Add(panelDriverName);
            groupBoxDriverInfo.Controls.Add(labelDriverName);
            groupBoxDriverInfo.Controls.Add(labelDriverNameStar);
            groupBoxDriverInfo.Controls.Add(labelDriverAssistant);
            groupBoxDriverInfo.Controls.Add(labelAssistantDrverNameStar);
            groupBoxDriverInfo.Controls.Add(labelPhoneNumber);
            groupBoxDriverInfo.Controls.Add(lblRequiredPhoneNumber);
            groupBoxDriverInfo.Controls.Add(panelPhoneNumber);
            groupBoxDriverInfo.Controls.Add(pnlAssistantDriver);
            groupBoxDriverInfo.ForeColor = Color.FromArgb(26, 86, 160);
            errorProvider.SetIconPadding(groupBoxDriverInfo, 1);
            groupBoxDriverInfo.Location = new Point(0, 118);
            groupBoxDriverInfo.Margin = new Padding(4, 3, 4, 3);
            groupBoxDriverInfo.Name = "groupBoxDriverInfo";
            groupBoxDriverInfo.Padding = new Padding(4, 3, 4, 3);
            groupBoxDriverInfo.Size = new Size(839, 96);
            groupBoxDriverInfo.TabIndex = 1;
            groupBoxDriverInfo.TabStop = false;
            groupBoxDriverInfo.Text = "Drivers information";
            // 
            // panelDriverName
            // 
            panelDriverName.BackColor = Color.FromArgb(235, 244, 255);
            panelDriverName.Controls.Add(textBoxBusDriver);
            panelDriverName.Location = new Point(588, 48);
            panelDriverName.Name = "panelDriverName";
            panelDriverName.Size = new Size(237, 32);
            panelDriverName.TabIndex = 34;
            // 
            // textBoxBusDriver
            // 
            textBoxBusDriver.BackColor = Color.FromArgb(235, 244, 255);
            textBoxBusDriver.BorderStyle = BorderStyle.None;
            textBoxBusDriver.Location = new Point(1, 6);
            textBoxBusDriver.Margin = new Padding(4, 3, 4, 3);
            textBoxBusDriver.Name = "textBoxBusDriver";
            textBoxBusDriver.Size = new Size(235, 22);
            textBoxBusDriver.TabIndex = 0;
            textBoxBusDriver.TextAlign = HorizontalAlignment.Center;
            // 
            // labelDriverName
            // 
            labelDriverName.AutoSize = true;
            labelDriverName.ForeColor = Color.FromArgb(0, 0, 3, 51);
            labelDriverName.Location = new Point(589, 22);
            labelDriverName.Margin = new Padding(4, 0, 4, 0);
            labelDriverName.Name = "labelDriverName";
            labelDriverName.Size = new Size(101, 23);
            labelDriverName.TabIndex = 0;
            labelDriverName.Text = "Driver name";
            // 
            // labelDriverNameStar
            // 
            labelDriverNameStar.AutoSize = true;
            labelDriverNameStar.ForeColor = Color.Red;
            labelDriverNameStar.Location = new Point(692, 25);
            labelDriverNameStar.Margin = new Padding(4, 0, 4, 0);
            labelDriverNameStar.Name = "labelDriverNameStar";
            labelDriverNameStar.Size = new Size(16, 23);
            labelDriverNameStar.TabIndex = 0;
            labelDriverNameStar.Text = "*";
            // 
            // labelDriverAssistant
            // 
            labelDriverAssistant.AutoSize = true;
            labelDriverAssistant.ForeColor = Color.FromArgb(0, 0, 3, 51);
            labelDriverAssistant.Location = new Point(303, 22);
            labelDriverAssistant.Margin = new Padding(4, 0, 4, 0);
            labelDriverAssistant.Name = "labelDriverAssistant";
            labelDriverAssistant.Size = new Size(169, 23);
            labelDriverAssistant.TabIndex = 0;
            labelDriverAssistant.Text = "Assistant diver name";
            // 
            // labelAssistantDrverNameStar
            // 
            labelAssistantDrverNameStar.AutoSize = true;
            labelAssistantDrverNameStar.ForeColor = Color.Red;
            labelAssistantDrverNameStar.Location = new Point(472, 24);
            labelAssistantDrverNameStar.Margin = new Padding(4, 0, 4, 0);
            labelAssistantDrverNameStar.Name = "labelAssistantDrverNameStar";
            labelAssistantDrverNameStar.Size = new Size(16, 23);
            labelAssistantDrverNameStar.TabIndex = 0;
            labelAssistantDrverNameStar.Text = "*";
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.ForeColor = Color.FromArgb(0, 0, 3, 51);
            labelPhoneNumber.Location = new Point(13, 28);
            labelPhoneNumber.Margin = new Padding(4, 0, 4, 0);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(122, 23);
            labelPhoneNumber.TabIndex = 0;
            labelPhoneNumber.Text = "Phone number";
            // 
            // lblRequiredPhoneNumber
            // 
            lblRequiredPhoneNumber.AutoSize = true;
            lblRequiredPhoneNumber.ForeColor = Color.Red;
            lblRequiredPhoneNumber.Location = new Point(135, 28);
            lblRequiredPhoneNumber.Margin = new Padding(4, 0, 4, 0);
            lblRequiredPhoneNumber.Name = "lblRequiredPhoneNumber";
            lblRequiredPhoneNumber.Size = new Size(16, 23);
            lblRequiredPhoneNumber.TabIndex = 12;
            lblRequiredPhoneNumber.Text = "*";
            // 
            // panelPhoneNumber
            // 
            panelPhoneNumber.BackColor = Color.FromArgb(235, 244, 255);
            panelPhoneNumber.Controls.Add(textBoxPhoneNumber);
            panelPhoneNumber.Location = new Point(13, 51);
            panelPhoneNumber.Name = "panelPhoneNumber";
            panelPhoneNumber.Size = new Size(264, 32);
            panelPhoneNumber.TabIndex = 33;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.BackColor = Color.FromArgb(235, 244, 255);
            textBoxPhoneNumber.BorderStyle = BorderStyle.None;
            textBoxPhoneNumber.Location = new Point(1, 6);
            textBoxPhoneNumber.Margin = new Padding(4, 3, 4, 3);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(260, 22);
            textBoxPhoneNumber.TabIndex = 2;
            textBoxPhoneNumber.TextAlign = HorizontalAlignment.Center;
            textBoxPhoneNumber.KeyPress += textBoxPhoneNumber_KeyPress;
            // 
            // pnlAssistantDriver
            // 
            pnlAssistantDriver.BackColor = Color.FromArgb(235, 244, 255);
            pnlAssistantDriver.Controls.Add(textBoxBusDriverAssistant);
            pnlAssistantDriver.Location = new Point(301, 49);
            pnlAssistantDriver.Name = "pnlAssistantDriver";
            pnlAssistantDriver.Size = new Size(270, 32);
            pnlAssistantDriver.TabIndex = 33;
            // 
            // textBoxBusDriverAssistant
            // 
            textBoxBusDriverAssistant.BackColor = Color.FromArgb(235, 244, 255);
            textBoxBusDriverAssistant.BorderStyle = BorderStyle.None;
            textBoxBusDriverAssistant.Location = new Point(1, 5);
            textBoxBusDriverAssistant.Margin = new Padding(4, 3, 4, 3);
            textBoxBusDriverAssistant.Name = "textBoxBusDriverAssistant";
            textBoxBusDriverAssistant.Size = new Size(266, 22);
            textBoxBusDriverAssistant.TabIndex = 1;
            textBoxBusDriverAssistant.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBoxMoreInfo
            // 
            groupBoxMoreInfo.Controls.Add(labelDetails);
            groupBoxMoreInfo.Controls.Add(labelDetailsStar);
            groupBoxMoreInfo.Controls.Add(labelAddress);
            groupBoxMoreInfo.Controls.Add(pnlDetails);
            groupBoxMoreInfo.Controls.Add(panelAddress);
            groupBoxMoreInfo.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            groupBoxMoreInfo.ForeColor = Color.FromArgb(142, 142, 136);
            errorProvider.SetIconPadding(groupBoxMoreInfo, 3);
            groupBoxMoreInfo.Location = new Point(-2, 309);
            groupBoxMoreInfo.Margin = new Padding(4, 5, 4, 5);
            groupBoxMoreInfo.Name = "groupBoxMoreInfo";
            groupBoxMoreInfo.Padding = new Padding(4, 5, 4, 5);
            groupBoxMoreInfo.Size = new Size(528, 91);
            groupBoxMoreInfo.TabIndex = 4;
            groupBoxMoreInfo.TabStop = false;
            groupBoxMoreInfo.Text = "More Information";
            // 
            // pnlDetails
            // 
            pnlDetails.BackColor = Color.FromArgb(235, 244, 255);
            pnlDetails.Controls.Add(richTextBoxDetails);
            pnlDetails.Location = new Point(284, 48);
            pnlDetails.Name = "pnlDetails";
            pnlDetails.Size = new Size(236, 32);
            pnlDetails.TabIndex = 33;
            // 
            // panelAddress
            // 
            panelAddress.BackColor = Color.FromArgb(235, 244, 255);
            panelAddress.Controls.Add(textBoxAddress);
            panelAddress.Location = new Point(15, 48);
            panelAddress.Name = "panelAddress";
            panelAddress.Size = new Size(263, 32);
            panelAddress.TabIndex = 33;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            errorProvider.RightToLeft = true;
            // 
            // groupBoxCapacity
            // 
            groupBoxCapacity.Controls.Add(labelCapacity);
            groupBoxCapacity.Controls.Add(numericUpDownExtraCapacity);
            groupBoxCapacity.Controls.Add(labelCapacityStar);
            groupBoxCapacity.Controls.Add(labelExtraCapacity);
            groupBoxCapacity.Controls.Add(numericUpDownCapacity);
            groupBoxCapacity.Controls.Add(labelExtraCapacityStar);
            groupBoxCapacity.ForeColor = Color.FromArgb(111, 74, 183);
            errorProvider.SetIconPadding(groupBoxCapacity, 3);
            groupBoxCapacity.Location = new Point(525, 309);
            groupBoxCapacity.Margin = new Padding(4, 3, 4, 3);
            groupBoxCapacity.Name = "groupBoxCapacity";
            groupBoxCapacity.Padding = new Padding(4, 3, 4, 3);
            groupBoxCapacity.Size = new Size(315, 91);
            groupBoxCapacity.TabIndex = 3;
            groupBoxCapacity.TabStop = false;
            groupBoxCapacity.Text = "Capacity";
            // 
            // labelCapacity
            // 
            labelCapacity.AutoSize = true;
            labelCapacity.ForeColor = Color.Black;
            labelCapacity.Location = new Point(9, 29);
            labelCapacity.Margin = new Padding(4, 0, 4, 0);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(76, 23);
            labelCapacity.TabIndex = 7;
            labelCapacity.Text = "Capacity";
            // 
            // numericUpDownExtraCapacity
            // 
            numericUpDownExtraCapacity.BackColor = Color.FromArgb(235, 244, 255);
            numericUpDownExtraCapacity.Location = new Point(141, 55);
            numericUpDownExtraCapacity.Margin = new Padding(8, 3, 8, 3);
            numericUpDownExtraCapacity.Maximum = new decimal(new int[] { 49, 0, 0, 0 });
            numericUpDownExtraCapacity.Name = "numericUpDownExtraCapacity";
            numericUpDownExtraCapacity.Size = new Size(103, 29);
            numericUpDownExtraCapacity.TabIndex = 1;
            // 
            // labelCapacityStar
            // 
            labelCapacityStar.AutoSize = true;
            labelCapacityStar.ForeColor = Color.Red;
            labelCapacityStar.Location = new Point(82, 31);
            labelCapacityStar.Margin = new Padding(4, 0, 4, 0);
            labelCapacityStar.Name = "labelCapacityStar";
            labelCapacityStar.Size = new Size(16, 23);
            labelCapacityStar.TabIndex = 0;
            labelCapacityStar.Text = "*";
            // 
            // labelExtraCapacity
            // 
            labelExtraCapacity.AutoSize = true;
            labelExtraCapacity.ForeColor = Color.Black;
            labelExtraCapacity.Location = new Point(141, 29);
            labelExtraCapacity.Margin = new Padding(4, 0, 4, 0);
            labelExtraCapacity.Name = "labelExtraCapacity";
            labelExtraCapacity.Size = new Size(117, 23);
            labelExtraCapacity.TabIndex = 8;
            labelExtraCapacity.Text = "Extra capacity";
            // 
            // numericUpDownCapacity
            // 
            numericUpDownCapacity.BackColor = Color.FromArgb(235, 244, 255);
            numericUpDownCapacity.Location = new Point(13, 56);
            numericUpDownCapacity.Margin = new Padding(8, 3, 8, 3);
            numericUpDownCapacity.Maximum = new decimal(new int[] { 49, 0, 0, 0 });
            numericUpDownCapacity.Name = "numericUpDownCapacity";
            numericUpDownCapacity.Size = new Size(103, 29);
            numericUpDownCapacity.TabIndex = 0;
            numericUpDownCapacity.Value = new decimal(new int[] { 49, 0, 0, 0 });
            // 
            // labelExtraCapacityStar
            // 
            labelExtraCapacityStar.AutoSize = true;
            labelExtraCapacityStar.ForeColor = Color.Red;
            labelExtraCapacityStar.Location = new Point(255, 29);
            labelExtraCapacityStar.Margin = new Padding(4, 0, 4, 0);
            labelExtraCapacityStar.Name = "labelExtraCapacityStar";
            labelExtraCapacityStar.Size = new Size(16, 23);
            labelExtraCapacityStar.TabIndex = 0;
            labelExtraCapacityStar.Text = "*";
            // 
            // grpMainContainer
            // 
            grpMainContainer.Controls.Add(groupBoxInfo);
            grpMainContainer.Controls.Add(groupBoxCapacity);
            grpMainContainer.Controls.Add(groupBoxMoreInfo);
            grpMainContainer.Controls.Add(groupBoxDriverInfo);
            grpMainContainer.Controls.Add(groupBoxTripInfo);
            grpMainContainer.Location = new Point(0, 88);
            grpMainContainer.Name = "grpMainContainer";
            grpMainContainer.Size = new Size(839, 399);
            grpMainContainer.TabIndex = 19;
            grpMainContainer.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(200, 118, 10);
            panelTitleBar.Controls.Add(buttonCloseWindow);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(839, 25);
            panelTitleBar.TabIndex = 20;
            // 
            // buttonCloseWindow
            // 
            buttonCloseWindow.BackColor = Color.FromArgb(200, 118, 10);
            buttonCloseWindow.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            buttonCloseWindow.FlatAppearance.BorderSize = 0;
            buttonCloseWindow.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            buttonCloseWindow.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            buttonCloseWindow.FlatStyle = FlatStyle.Flat;
            buttonCloseWindow.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonCloseWindow.ForeColor = Color.White;
            buttonCloseWindow.ImageAlign = ContentAlignment.MiddleRight;
            buttonCloseWindow.Location = new Point(812, 0);
            buttonCloseWindow.Margin = new Padding(6);
            buttonCloseWindow.Name = "buttonCloseWindow";
            buttonCloseWindow.Size = new Size(27, 25);
            buttonCloseWindow.TabIndex = 33;
            buttonCloseWindow.Text = "X";
            buttonCloseWindow.UseVisualStyleBackColor = false;
            buttonCloseWindow.Click += buttonClose_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(panelIconContainer);
            panelHeader.Controls.Add(labelSub);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 25);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(839, 73);
            panelHeader.TabIndex = 21;
            // 
            // panelIconContainer
            // 
            panelIconContainer.BackColor = Color.Transparent;
            panelIconContainer.BackgroundImage = (Image)resources.GetObject("panelIconContainer.BackgroundImage");
            panelIconContainer.BackgroundImageLayout = ImageLayout.Zoom;
            panelIconContainer.Controls.Add(pictureBoxIcon);
            panelIconContainer.ForeColor = Color.FromArgb(230, 241, 251);
            panelIconContainer.Location = new Point(13, 14);
            panelIconContainer.Name = "panelIconContainer";
            panelIconContainer.Size = new Size(51, 48);
            panelIconContainer.TabIndex = 32;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.FromArgb(253, 243, 227);
            pictureBoxIcon.Image = (Image)resources.GetObject("pictureBoxIcon.Image");
            pictureBoxIcon.Location = new Point(13, 12);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(25, 25);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // labelSub
            // 
            labelSub.AutoSize = true;
            labelSub.Font = new Font("Arial", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSub.ForeColor = Color.Black;
            labelSub.Location = new Point(81, 40);
            labelSub.Name = "labelSub";
            labelSub.Size = new Size(164, 19);
            labelSub.TabIndex = 1;
            labelSub.Text = "Enter new bus details";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(81, 13);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(167, 27);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Add / Edit Bus";
            // 
            // AddBusForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(839, 569);
            Controls.Add(panelHeader);
            Controls.Add(panelTitleBar);
            Controls.Add(grpMainContainer);
            Controls.Add(panelDown);
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBusForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Load += AddBusForm_Load;
            panelDown.ResumeLayout(false);
            groupBoxInfo.ResumeLayout(false);
            groupBoxInfo.PerformLayout();
            panelBusModel.ResumeLayout(false);
            panelBusModel.PerformLayout();
            panelLicensePlate.ResumeLayout(false);
            panelLicensePlate.PerformLayout();
            panelBusNumber.ResumeLayout(false);
            panelBusNumber.PerformLayout();
            groupBoxTripInfo.ResumeLayout(false);
            groupBoxTripInfo.PerformLayout();
            panelTripType.ResumeLayout(false);
            groupBoxDriverInfo.ResumeLayout(false);
            groupBoxDriverInfo.PerformLayout();
            panelDriverName.ResumeLayout(false);
            panelDriverName.PerformLayout();
            panelPhoneNumber.ResumeLayout(false);
            panelPhoneNumber.PerformLayout();
            pnlAssistantDriver.ResumeLayout(false);
            pnlAssistantDriver.PerformLayout();
            groupBoxMoreInfo.ResumeLayout(false);
            groupBoxMoreInfo.PerformLayout();
            pnlDetails.ResumeLayout(false);
            panelAddress.ResumeLayout(false);
            panelAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxCapacity.ResumeLayout(false);
            groupBoxCapacity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExtraCapacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).EndInit();
            grpMainContainer.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Button buttonSaveAndClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelDepartureDate;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.RichTextBox richTextBoxDetails;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelDetailsStar;
        private System.Windows.Forms.Label labelReturnDateStar;
        private System.Windows.Forms.Label lblRequiredDepartureDate;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelLicensePlate;
        private System.Windows.Forms.TextBox textBoxBusLicensePlate;
        private System.Windows.Forms.Label labelLicensePlateStar;
        private System.Windows.Forms.Label labelBusNumber;
        private System.Windows.Forms.TextBox textBoxBusNumber;
        private System.Windows.Forms.Label labelBusNumberStar;
        private System.Windows.Forms.TextBox textBoxBusModel;
        private System.Windows.Forms.Label labelBusModel;
        private System.Windows.Forms.Label labelModelStar;
        private System.Windows.Forms.GroupBox groupBoxTripInfo;
        private System.Windows.Forms.Label labelTripType;
        private System.Windows.Forms.ComboBox comboBoxTripType;
        private System.Windows.Forms.Label labelTripTypeStar;
        private System.Windows.Forms.GroupBox groupBoxDriverInfo;
        private System.Windows.Forms.Label labelDriverName;
        private System.Windows.Forms.Label labelDriverNameStar;
        private System.Windows.Forms.TextBox textBoxBusDriver;
        private System.Windows.Forms.Label labelDriverAssistant;
        private System.Windows.Forms.Label labelAssistantDrverNameStar;
        private System.Windows.Forms.TextBox textBoxBusDriverAssistant;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label lblRequiredPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.GroupBox groupBoxMoreInfo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox grpMainContainer;
        private Panel panelHeader;
        private Panel panelTitleBar;
        private Panel panelIconContainer;
        private PictureBox pictureBoxIcon;
        private Label labelSub;
        private Label labelTitle;
        private Button buttonCloseWindow;
        private Panel panelBusModel;
        private Panel panelLicensePlate;
        private Panel panelBusNumber;
        private Panel panelDriverName;
        private Panel panelPhoneNumber;
        private Panel pnlAssistantDriver;
        private Panel panelTripType;
        private Panel pnlDetails;
        private Panel panelAddress;
        private GroupBox groupBoxCapacity;
        private Label labelCapacity;
        private NumericUpDown numericUpDownExtraCapacity;
        private Label labelCapacityStar;
        private Label labelExtraCapacity;
        private NumericUpDown numericUpDownCapacity;
        private Label labelExtraCapacityStar;
    }
}