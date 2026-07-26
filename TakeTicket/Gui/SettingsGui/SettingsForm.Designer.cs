namespace TakeTicket.Gui.SettingsGui
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            grpGeneralSettings = new GroupBox();
            panelImportPicture = new Panel();
            pictureBoxImportImage = new PictureBox();
            linkLabelImportImage = new LinkLabel();
            labelClickToUpload = new Label();
            buttonSaveGeneralSettings = new Button();
            numericUpDownDataRow = new NumericUpDown();
            numericUpDownNotification = new NumericUpDown();
            textBoxCompanyName = new TextBox();
            labelOrganizationName = new Label();
            labelNotificationTimeout = new Label();
            labelOrganizationLogo = new Label();
            labelNumberOfRecordsDisplayed = new Label();
            textBoxPassword = new TextBox();
            textBoxUserName = new TextBox();
            textBoxDataBase = new TextBox();
            labelUserName = new Label();
            labelPassword = new Label();
            labelDataBase = new Label();
            labelServer = new Label();
            grpDatabaseSettings = new GroupBox();
            buttonSaveConString = new Button();
            comboBoxServer = new ComboBox();
            numericUpDownTimeout = new NumericUpDown();
            radioButtonLocalCon = new RadioButton();
            radioButtonNetworkCon = new RadioButton();
            labelTimeConnection = new Label();
            labelConnectionType = new Label();
            buttonSaveLanguage = new Button();
            comboBoxLanguage = new ComboBox();
            labelLaguage = new Label();
            grpBackupRestore = new GroupBox();
            buttonRestoreBackup = new Button();
            buttonBackup = new Button();
            errorProvider = new ErrorProvider(components);
            panelTitleBar = new Panel();
            labelColseWindow = new Label();
            panelHeader = new Panel();
            panelIconContainer = new Panel();
            pictureBoxIcon = new PictureBox();
            labelSubtitle = new Label();
            labelTitle = new Label();
            grpLanguageSettings = new GroupBox();
            grpGeneralSettings.SuspendLayout();
            panelImportPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImportImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDataRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNotification).BeginInit();
            grpDatabaseSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).BeginInit();
            grpBackupRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            panelTitleBar.SuspendLayout();
            panelHeader.SuspendLayout();
            panelIconContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            grpLanguageSettings.SuspendLayout();
            SuspendLayout();
            // 
            // grpGeneralSettings
            // 
            grpGeneralSettings.Controls.Add(panelImportPicture);
            grpGeneralSettings.Controls.Add(buttonSaveGeneralSettings);
            grpGeneralSettings.Controls.Add(numericUpDownDataRow);
            grpGeneralSettings.Controls.Add(numericUpDownNotification);
            grpGeneralSettings.Controls.Add(textBoxCompanyName);
            grpGeneralSettings.Controls.Add(labelOrganizationName);
            grpGeneralSettings.Controls.Add(labelNotificationTimeout);
            grpGeneralSettings.Controls.Add(labelOrganizationLogo);
            grpGeneralSettings.Controls.Add(labelNumberOfRecordsDisplayed);
            grpGeneralSettings.ForeColor = Color.FromArgb(26, 86, 160);
            grpGeneralSettings.Location = new Point(0, 100);
            grpGeneralSettings.Name = "grpGeneralSettings";
            grpGeneralSettings.Size = new Size(440, 545);
            grpGeneralSettings.TabIndex = 1;
            grpGeneralSettings.TabStop = false;
            grpGeneralSettings.Text = "⚙️ General Settings";
            // 
            // panelImportPicture
            // 
            panelImportPicture.BackColor = Color.FromArgb(238, 237, 254);
            panelImportPicture.Controls.Add(pictureBoxImportImage);
            panelImportPicture.Controls.Add(linkLabelImportImage);
            panelImportPicture.Controls.Add(labelClickToUpload);
            panelImportPicture.Location = new Point(47, 295);
            panelImportPicture.Name = "panelImportPicture";
            panelImportPicture.Size = new Size(337, 147);
            panelImportPicture.TabIndex = 5;
            panelImportPicture.Click += panelImportPicture_Click;
            // 
            // pictureBoxImportImage
            // 
            pictureBoxImportImage.BackColor = Color.Transparent;
            pictureBoxImportImage.Image = (Image)resources.GetObject("pictureBoxImportImage.Image");
            pictureBoxImportImage.Location = new Point(130, 27);
            pictureBoxImportImage.Name = "pictureBoxImportImage";
            pictureBoxImportImage.Size = new Size(76, 53);
            pictureBoxImportImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImportImage.TabIndex = 0;
            pictureBoxImportImage.TabStop = false;
            // 
            // linkLabelImportImage
            // 
            linkLabelImportImage.AutoSize = true;
            linkLabelImportImage.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkLabelImportImage.LinkColor = Color.FromArgb(197, 193, 243);
            linkLabelImportImage.Location = new Point(148, 100);
            linkLabelImportImage.Name = "linkLabelImportImage";
            linkLabelImportImage.Size = new Size(41, 16);
            linkLabelImportImage.TabIndex = 3;
            linkLabelImportImage.TabStop = true;
            linkLabelImportImage.Text = "Upload";
            linkLabelImportImage.LinkClicked += linkLabelImportImage_LinkClicked;
            // 
            // labelClickToUpload
            // 
            labelClickToUpload.AutoSize = true;
            labelClickToUpload.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelClickToUpload.Location = new Point(119, 83);
            labelClickToUpload.Name = "labelClickToUpload";
            labelClickToUpload.Size = new Size(98, 16);
            labelClickToUpload.TabIndex = 2;
            labelClickToUpload.Text = "Click to upload logo";
            // 
            // buttonSaveGeneralSettings
            // 
            buttonSaveGeneralSettings.BackColor = Color.White;
            buttonSaveGeneralSettings.FlatAppearance.BorderColor = SystemColors.ControlDark;
            buttonSaveGeneralSettings.FlatAppearance.BorderSize = 2;
            buttonSaveGeneralSettings.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            buttonSaveGeneralSettings.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            buttonSaveGeneralSettings.FlatStyle = FlatStyle.Flat;
            buttonSaveGeneralSettings.ForeColor = Color.Black;
            buttonSaveGeneralSettings.Image = Properties.Resources.icons8_save_32;
            buttonSaveGeneralSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveGeneralSettings.Location = new Point(63, 465);
            buttonSaveGeneralSettings.Margin = new Padding(5);
            buttonSaveGeneralSettings.Name = "buttonSaveGeneralSettings";
            buttonSaveGeneralSettings.Size = new Size(299, 51);
            buttonSaveGeneralSettings.TabIndex = 4;
            buttonSaveGeneralSettings.Text = "Save general settings";
            buttonSaveGeneralSettings.UseVisualStyleBackColor = false;
            buttonSaveGeneralSettings.Click += buttonSaveGeneralSettings_Click;
            // 
            // numericUpDownDataRow
            // 
            numericUpDownDataRow.Location = new Point(227, 193);
            numericUpDownDataRow.Name = "numericUpDownDataRow";
            numericUpDownDataRow.Size = new Size(174, 26);
            numericUpDownDataRow.TabIndex = 2;
            numericUpDownDataRow.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // numericUpDownNotification
            // 
            numericUpDownNotification.Location = new Point(227, 123);
            numericUpDownNotification.Name = "numericUpDownNotification";
            numericUpDownNotification.Size = new Size(174, 26);
            numericUpDownNotification.TabIndex = 1;
            numericUpDownNotification.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // textBoxCompanyName
            // 
            textBoxCompanyName.Location = new Point(165, 54);
            textBoxCompanyName.Name = "textBoxCompanyName";
            textBoxCompanyName.Size = new Size(260, 26);
            textBoxCompanyName.TabIndex = 0;
            textBoxCompanyName.TextAlign = HorizontalAlignment.Center;
            // 
            // labelOrganizationName
            // 
            labelOrganizationName.AutoSize = true;
            labelOrganizationName.ForeColor = Color.Black;
            labelOrganizationName.Location = new Point(16, 54);
            labelOrganizationName.Name = "labelOrganizationName";
            labelOrganizationName.Size = new Size(127, 20);
            labelOrganizationName.TabIndex = 2;
            labelOrganizationName.Text = "Organization Name";
            // 
            // labelNotificationTimeout
            // 
            labelNotificationTimeout.AutoSize = true;
            labelNotificationTimeout.ForeColor = Color.Black;
            labelNotificationTimeout.Location = new Point(43, 123);
            labelNotificationTimeout.Name = "labelNotificationTimeout";
            labelNotificationTimeout.Size = new Size(168, 20);
            labelNotificationTimeout.TabIndex = 2;
            labelNotificationTimeout.Text = "Notification Timeout (sec)";
            // 
            // labelOrganizationLogo
            // 
            labelOrganizationLogo.AutoSize = true;
            labelOrganizationLogo.ForeColor = Color.Black;
            labelOrganizationLogo.Location = new Point(47, 272);
            labelOrganizationLogo.Name = "labelOrganizationLogo";
            labelOrganizationLogo.Size = new Size(124, 20);
            labelOrganizationLogo.TabIndex = 2;
            labelOrganizationLogo.Text = "Organization Logo";
            // 
            // labelNumberOfRecordsDisplayed
            // 
            labelNumberOfRecordsDisplayed.AutoSize = true;
            labelNumberOfRecordsDisplayed.ForeColor = Color.Black;
            labelNumberOfRecordsDisplayed.Location = new Point(25, 195);
            labelNumberOfRecordsDisplayed.Name = "labelNumberOfRecordsDisplayed";
            labelNumberOfRecordsDisplayed.Size = new Size(194, 20);
            labelNumberOfRecordsDisplayed.TabIndex = 2;
            labelNumberOfRecordsDisplayed.Text = "Number of Records Displayed";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Enabled = false;
            textBoxPassword.Location = new Point(145, 230);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(308, 26);
            textBoxPassword.TabIndex = 11;
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Enabled = false;
            textBoxUserName.Location = new Point(145, 192);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(308, 26);
            textBoxUserName.TabIndex = 10;
            textBoxUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxDataBase
            // 
            textBoxDataBase.Location = new Point(145, 110);
            textBoxDataBase.Name = "textBoxDataBase";
            textBoxDataBase.RightToLeft = RightToLeft.No;
            textBoxDataBase.Size = new Size(308, 26);
            textBoxDataBase.TabIndex = 8;
            textBoxDataBase.Text = "TakeTicketDB";
            textBoxDataBase.TextAlign = HorizontalAlignment.Center;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(29, 196);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(71, 20);
            labelUserName.TabIndex = 2;
            labelUserName.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(31, 235);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(69, 20);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password";
            // 
            // labelDataBase
            // 
            labelDataBase.AutoSize = true;
            labelDataBase.Location = new Point(29, 110);
            labelDataBase.Name = "labelDataBase";
            labelDataBase.Size = new Size(66, 20);
            labelDataBase.TabIndex = 2;
            labelDataBase.Text = "DataBase";
            // 
            // labelServer
            // 
            labelServer.AutoSize = true;
            labelServer.Location = new Point(29, 73);
            labelServer.Name = "labelServer";
            labelServer.Size = new Size(49, 20);
            labelServer.TabIndex = 2;
            labelServer.Text = "Server";
            // 
            // grpDatabaseSettings
            // 
            grpDatabaseSettings.Controls.Add(buttonSaveConString);
            grpDatabaseSettings.Controls.Add(comboBoxServer);
            grpDatabaseSettings.Controls.Add(textBoxPassword);
            grpDatabaseSettings.Controls.Add(labelPassword);
            grpDatabaseSettings.Controls.Add(numericUpDownTimeout);
            grpDatabaseSettings.Controls.Add(textBoxUserName);
            grpDatabaseSettings.Controls.Add(labelUserName);
            grpDatabaseSettings.Controls.Add(radioButtonLocalCon);
            grpDatabaseSettings.Controls.Add(radioButtonNetworkCon);
            grpDatabaseSettings.Controls.Add(labelTimeConnection);
            grpDatabaseSettings.Controls.Add(textBoxDataBase);
            grpDatabaseSettings.Controls.Add(labelConnectionType);
            grpDatabaseSettings.Controls.Add(labelServer);
            grpDatabaseSettings.Controls.Add(labelDataBase);
            grpDatabaseSettings.Location = new Point(446, 100);
            grpDatabaseSettings.Name = "grpDatabaseSettings";
            grpDatabaseSettings.Size = new Size(489, 340);
            grpDatabaseSettings.TabIndex = 1;
            grpDatabaseSettings.TabStop = false;
            grpDatabaseSettings.Text = "🛢️ DataBases";
            // 
            // buttonSaveConString
            // 
            buttonSaveConString.BackColor = Color.White;
            buttonSaveConString.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonSaveConString.FlatAppearance.BorderSize = 2;
            buttonSaveConString.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonSaveConString.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonSaveConString.FlatStyle = FlatStyle.Flat;
            buttonSaveConString.Image = Properties.Resources.icons8_save_32_green;
            buttonSaveConString.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveConString.Location = new Point(196, 281);
            buttonSaveConString.Margin = new Padding(5);
            buttonSaveConString.Name = "buttonSaveConString";
            buttonSaveConString.Size = new Size(215, 39);
            buttonSaveConString.TabIndex = 12;
            buttonSaveConString.Text = "     Save";
            buttonSaveConString.UseVisualStyleBackColor = false;
            buttonSaveConString.Click += buttonSaveConString_Click;
            // 
            // comboBoxServer
            // 
            comboBoxServer.FormattingEnabled = true;
            comboBoxServer.Items.AddRange(new object[] { ".\\SQLEXPRESS", "(localdb)\\MSSQLLocalDB" });
            comboBoxServer.Location = new Point(145, 73);
            comboBoxServer.Name = "comboBoxServer";
            comboBoxServer.Size = new Size(308, 28);
            comboBoxServer.TabIndex = 13;
            // 
            // numericUpDownTimeout
            // 
            numericUpDownTimeout.Enabled = false;
            numericUpDownTimeout.Location = new Point(145, 148);
            numericUpDownTimeout.Name = "numericUpDownTimeout";
            numericUpDownTimeout.Size = new Size(306, 26);
            numericUpDownTimeout.TabIndex = 9;
            numericUpDownTimeout.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // radioButtonLocalCon
            // 
            radioButtonLocalCon.AutoSize = true;
            radioButtonLocalCon.Checked = true;
            radioButtonLocalCon.Location = new Point(341, 36);
            radioButtonLocalCon.Name = "radioButtonLocalCon";
            radioButtonLocalCon.Size = new Size(61, 24);
            radioButtonLocalCon.TabIndex = 5;
            radioButtonLocalCon.TabStop = true;
            radioButtonLocalCon.Text = "Local";
            radioButtonLocalCon.UseVisualStyleBackColor = true;
            radioButtonLocalCon.CheckedChanged += radioButtonLocalCon_CheckedChanged;
            // 
            // radioButtonNetworkCon
            // 
            radioButtonNetworkCon.AutoSize = true;
            radioButtonNetworkCon.Location = new Point(191, 36);
            radioButtonNetworkCon.Name = "radioButtonNetworkCon";
            radioButtonNetworkCon.Size = new Size(76, 24);
            radioButtonNetworkCon.TabIndex = 6;
            radioButtonNetworkCon.Text = "Network";
            radioButtonNetworkCon.UseVisualStyleBackColor = true;
            radioButtonNetworkCon.CheckedChanged += radioButtonNetworkCon_CheckedChanged;
            // 
            // labelTimeConnection
            // 
            labelTimeConnection.Location = new Point(26, 140);
            labelTimeConnection.Name = "labelTimeConnection";
            labelTimeConnection.Size = new Size(114, 49);
            labelTimeConnection.TabIndex = 2;
            labelTimeConnection.Text = "Time connection (Seconds)";
            // 
            // labelConnectionType
            // 
            labelConnectionType.AutoSize = true;
            labelConnectionType.Location = new Point(20, 34);
            labelConnectionType.Name = "labelConnectionType";
            labelConnectionType.Size = new Size(118, 20);
            labelConnectionType.TabIndex = 2;
            labelConnectionType.Text = "Connection Type:";
            // 
            // buttonSaveLanguage
            // 
            buttonSaveLanguage.BackColor = Color.FromArgb(15, 110, 86);
            buttonSaveLanguage.FlatAppearance.BorderColor = Color.FromArgb(15, 110, 86);
            buttonSaveLanguage.FlatAppearance.BorderSize = 0;
            buttonSaveLanguage.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 110, 86);
            buttonSaveLanguage.FlatAppearance.MouseOverBackColor = Color.FromArgb(15, 110, 86);
            buttonSaveLanguage.FlatStyle = FlatStyle.Flat;
            buttonSaveLanguage.ForeColor = Color.White;
            buttonSaveLanguage.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveLanguage.Location = new Point(325, 55);
            buttonSaveLanguage.Margin = new Padding(5);
            buttonSaveLanguage.Name = "buttonSaveLanguage";
            buttonSaveLanguage.Size = new Size(89, 29);
            buttonSaveLanguage.TabIndex = 14;
            buttonSaveLanguage.Text = "Save";
            buttonSaveLanguage.UseVisualStyleBackColor = false;
            buttonSaveLanguage.Click += buttonSaveLanguage_Click;
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Location = new Point(16, 55);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(301, 28);
            comboBoxLanguage.TabIndex = 13;
            // 
            // labelLaguage
            // 
            labelLaguage.AutoSize = true;
            labelLaguage.ForeColor = Color.Black;
            labelLaguage.Location = new Point(14, 25);
            labelLaguage.Name = "labelLaguage";
            labelLaguage.Size = new Size(130, 20);
            labelLaguage.TabIndex = 2;
            labelLaguage.Text = "Enter the Langauge";
            // 
            // grpBackupRestore
            // 
            grpBackupRestore.Controls.Add(buttonRestoreBackup);
            grpBackupRestore.Controls.Add(buttonBackup);
            grpBackupRestore.ForeColor = Color.FromArgb(255, 128, 128);
            grpBackupRestore.Location = new Point(446, 548);
            grpBackupRestore.Name = "grpBackupRestore";
            grpBackupRestore.Size = new Size(493, 97);
            grpBackupRestore.TabIndex = 2;
            grpBackupRestore.TabStop = false;
            grpBackupRestore.Text = "🛢️ Backup and Restore (or Backup and Set)";
            // 
            // buttonRestoreBackup
            // 
            buttonRestoreBackup.BackColor = Color.White;
            buttonRestoreBackup.FlatAppearance.BorderColor = Color.BlueViolet;
            buttonRestoreBackup.FlatAppearance.BorderSize = 2;
            buttonRestoreBackup.FlatAppearance.MouseDownBackColor = Color.BlueViolet;
            buttonRestoreBackup.FlatAppearance.MouseOverBackColor = Color.BlueViolet;
            buttonRestoreBackup.FlatStyle = FlatStyle.Flat;
            buttonRestoreBackup.ForeColor = Color.Black;
            buttonRestoreBackup.Image = Properties.Resources.icons8_Database_Restore_32px_1;
            buttonRestoreBackup.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRestoreBackup.Location = new Point(9, 38);
            buttonRestoreBackup.Margin = new Padding(5);
            buttonRestoreBackup.Name = "buttonRestoreBackup";
            buttonRestoreBackup.Size = new Size(238, 51);
            buttonRestoreBackup.TabIndex = 14;
            buttonRestoreBackup.Text = "Restore Backup     ";
            buttonRestoreBackup.UseVisualStyleBackColor = false;
            buttonRestoreBackup.Click += buttonRestore_Click;
            // 
            // buttonBackup
            // 
            buttonBackup.BackColor = Color.White;
            buttonBackup.FlatAppearance.BorderColor = Color.Blue;
            buttonBackup.FlatAppearance.BorderSize = 2;
            buttonBackup.FlatAppearance.MouseDownBackColor = Color.Blue;
            buttonBackup.FlatAppearance.MouseOverBackColor = Color.Blue;
            buttonBackup.FlatStyle = FlatStyle.Flat;
            buttonBackup.ForeColor = Color.Black;
            buttonBackup.Image = Properties.Resources.icons8_data_backup_32px;
            buttonBackup.ImageAlign = ContentAlignment.MiddleLeft;
            buttonBackup.Location = new Point(252, 38);
            buttonBackup.Margin = new Padding(5);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(238, 51);
            buttonBackup.TabIndex = 13;
            buttonBackup.Text = "Backup          ";
            buttonBackup.UseVisualStyleBackColor = false;
            buttonBackup.Click += buttonBackUp_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(83, 74, 183);
            panelTitleBar.Controls.Add(labelColseWindow);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(939, 20);
            panelTitleBar.TabIndex = 3;
            // 
            // labelColseWindow
            // 
            labelColseWindow.AutoSize = true;
            labelColseWindow.ForeColor = Color.White;
            labelColseWindow.Location = new Point(918, 0);
            labelColseWindow.Name = "labelColseWindow";
            labelColseWindow.Size = new Size(18, 20);
            labelColseWindow.TabIndex = 2;
            labelColseWindow.Text = "X";
            labelColseWindow.Click += labelColse_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(panelIconContainer);
            panelHeader.Controls.Add(labelSubtitle);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 20);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(939, 74);
            panelHeader.TabIndex = 4;
            // 
            // panelIconContainer
            // 
            panelIconContainer.BackColor = Color.Transparent;
            panelIconContainer.BackgroundImage = Properties.Resources.mega_creator;
            panelIconContainer.BackgroundImageLayout = ImageLayout.Zoom;
            panelIconContainer.Controls.Add(pictureBoxIcon);
            panelIconContainer.ForeColor = Color.FromArgb(230, 241, 251);
            panelIconContainer.Location = new Point(12, 17);
            panelIconContainer.Name = "panelIconContainer";
            panelIconContainer.Size = new Size(51, 48);
            panelIconContainer.TabIndex = 32;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxIcon.Image = (Image)resources.GetObject("pictureBoxIcon.Image");
            pictureBoxIcon.Location = new Point(13, 12);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(25, 25);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // labelSubtitle
            // 
            labelSubtitle.Font = new Font("Arial", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSubtitle.ForeColor = Color.Black;
            labelSubtitle.Location = new Point(69, 42);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(382, 25);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "General Settings | DataBase | Language | Backup";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(69, 17);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(100, 27);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Settings";
            // 
            // grpLanguageSettings
            // 
            grpLanguageSettings.Controls.Add(buttonSaveLanguage);
            grpLanguageSettings.Controls.Add(comboBoxLanguage);
            grpLanguageSettings.Controls.Add(labelLaguage);
            grpLanguageSettings.ForeColor = Color.FromArgb(15, 110, 86);
            grpLanguageSettings.Location = new Point(443, 446);
            grpLanguageSettings.Name = "grpLanguageSettings";
            grpLanguageSettings.Size = new Size(493, 96);
            grpLanguageSettings.TabIndex = 2;
            grpLanguageSettings.TabStop = false;
            grpLanguageSettings.Text = "🔠 Languages";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(939, 678);
            Controls.Add(panelHeader);
            Controls.Add(panelTitleBar);
            Controls.Add(grpLanguageSettings);
            Controls.Add(grpBackupRestore);
            Controls.Add(grpDatabaseSettings);
            Controls.Add(grpGeneralSettings);
            Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            Activated += SettingsForm_Activated;
            FormClosing += SettingsForm_FormClosing;
            Load += SettingsForm_Load;
            grpGeneralSettings.ResumeLayout(false);
            grpGeneralSettings.PerformLayout();
            panelImportPicture.ResumeLayout(false);
            panelImportPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImportImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDataRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNotification).EndInit();
            grpDatabaseSettings.ResumeLayout(false);
            grpDatabaseSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).EndInit();
            grpBackupRestore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            grpLanguageSettings.ResumeLayout(false);
            grpLanguageSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpGeneralSettings;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxDataBase;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelDataBase;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelOrganizationName;
        private System.Windows.Forms.PictureBox pictureBoxImportImage;
        private System.Windows.Forms.GroupBox grpDatabaseSettings;
        private System.Windows.Forms.RadioButton radioButtonNetworkCon;
        private System.Windows.Forms.RadioButton radioButtonLocalCon;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.Label labelTimeConnection;
        private System.Windows.Forms.Button buttonSaveConString;
        private System.Windows.Forms.Button buttonSaveGeneralSettings;
        private System.Windows.Forms.NumericUpDown numericUpDownDataRow;
        private System.Windows.Forms.NumericUpDown numericUpDownNotification;
        private System.Windows.Forms.Label labelNotificationTimeout;
        private System.Windows.Forms.Label labelNumberOfRecordsDisplayed;
        private System.Windows.Forms.LinkLabel linkLabelImportImage;
        private System.Windows.Forms.Label labelOrganizationLogo;
        private System.Windows.Forms.GroupBox grpBackupRestore;
        private System.Windows.Forms.Button buttonRestoreBackup;
        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private ErrorProvider errorProvider;
        private ComboBox comboBoxLanguage;
        private Label labelLaguage;
        private Button buttonSaveLanguage;
        private Panel panelTitleBar;
        private Label labelColseWindow;
        private Panel panelHeader;
        private Panel panelIconContainer;
        private PictureBox pictureBoxIcon;
        private Label labelSubtitle;
        private Label labelTitle;
        private Panel panelImportPicture;
        private Label labelClickToUpload;
        private GroupBox grpLanguageSettings;
        private Label labelConnectionType;
    }
}