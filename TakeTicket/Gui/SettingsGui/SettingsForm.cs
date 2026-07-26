using TakeTicket.Infrastructure;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Infrastructure.Validation;
using TakeTicket.Data.SqlServer;
using TakeTicket.Gui.LoadingGui;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.SettingsGui
{
    public partial class SettingsForm : Form
    {
        private LoadingForm loading;
        private bool firstStart;
        private readonly BackUpRestoreHelper backUpRestoreHelper;

        public SettingsForm(BackUpRestoreHelper backUpRestoreHelper)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            loading = new LoadingForm();
            this.backUpRestoreHelper = backUpRestoreHelper;

            SetGeneralSettings();
        }

        #region Evints
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstStart == true)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void SettingsForm_Activated(object sender, EventArgs e)
        {

        }

        private void linkLabelImportImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (firstStart)
            {
                MessageBox.Show(MessagesLocal.DatabaseSetupRequired);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = localizer.Get("SelectLogoTitle");
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = localizer.Get("ImageFilter");

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBoxImportImage.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(MessagesLocal.ImageLoadError);
                }
            }
        }

        private void buttonSaveGeneralSettings_Click(object sender, EventArgs e)
        {
            SaveGeneralSettings();
        }

        private void buttonSaveConString_Click(object sender, EventArgs e)
        {
            if (!ValidateConnectionInputs())
            {
                MessageCollections.ShowFieldsRequired();
                return;
            }

            var Server = comboBoxServer.Text;
            var DataBase = textBoxDataBase.Text;
            var Timeout = numericUpDownTimeout.Value;
            var UserName = textBoxUserName.Text;
            var Password = textBoxPassword.Text;

            if (radioButtonLocalCon.Checked)
            {
                // Local Con
                SetLocalCon(Server, DataBase);
            }
            else
            {
                // Network Con
                SetNetWorkCon(Server, DataBase, UserName, Password, Timeout);
            }

            Properties.Settings.Default.DatabaseConfigured = true;
            Properties.Settings.Default.Save();

            MessageBox.Show(localizer.Get("ConnectionSaved"));
            System.Windows.Forms.Application.Exit();
        }

        private async void buttonBackUp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = localizer.Get("BackupFolderDescription");
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                loading.Show();
                string processResult = await Task.Run(() => backUpRestoreHelper.BackUp(folderBrowserDialog.SelectedPath));
                if (processResult == "1")
                {
                    loading.Hide();
                    MessageBox.Show(MessagesLocal.BackupSuccess);
                }
                else
                {
                    loading.Hide();
                    MessageBox.Show($"{MessagesLocal.BackupFailed} {processResult}");
                }
            }
        }

        private async void buttonRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = localizer.Get("SelectBackupFile");
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Filter = localizer.Get("BackupFileFilter");
                var result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    loading.Show();
                    string processResult = await Task.Run(() => backUpRestoreHelper.Restore(openFileDialog.FileName));
                    if (processResult == "1")
                    {
                        loading.Hide();
                        MessageCollections.ShowInfo(localizer.Get("RestoreSuccess"));
                    }
                    else
                    {
                        loading.Hide();
                        MessageCollections.ShowError($"{localizer.Get("RestoreFailed")} {processResult}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageCollections.ShowException(ex, "Restore Backup");
            }
            finally
            {
                loading.Hide();
            }
        }

        private void radioButtonLocalCon_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserName.Enabled = false;
            textBoxPassword.Enabled = false;
            numericUpDownTimeout.Enabled = false;
        }

        private void radioButtonNetworkCon_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserName.Enabled = true;
            textBoxPassword.Enabled = true;
            numericUpDownTimeout.Enabled = true;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ApplyLayout();
            comboBoxLanguage.Items.Add("English");
            comboBoxLanguage.Items.Add("العربية");
            comboBoxLanguage.Items.Add("Русский");

            var lang = Properties.Settings.Default.Language;

            comboBoxLanguage.SelectedIndex = lang switch
            {
                "en" => 0,
                "ar" => 1,
                "ru" => 2,
                _ => 0
            };
        }

        private void buttonSaveLanguage_Click(object sender, EventArgs e)
        {
            string culture = "en";

            switch (comboBoxLanguage.SelectedIndex)
            {
                case 0:
                    culture = "en";
                    break;

                case 1:
                    culture = "ar";
                    break;

                case 2:
                    culture = "ru";
                    break;
            }

            Properties.Settings.Default.Language = culture;

            Properties.Settings.Default.Save();

            MessageBox.Show(localizer.Get("LanguageRestartMessage"));

            System.Windows.Forms.Application.Restart();
        }
        #endregion
        #region Methods
        private void SaveGeneralSettings()
        {
            try
            {
                Properties.Settings.Default.CompanyName = textBoxCompanyName.Text;
                Properties.Settings.Default.HideNotificationInterval = Convert.ToInt32(numericUpDownNotification.Value);
                Properties.Settings.Default.DataGridViewRowNo = Convert.ToInt32(numericUpDownDataRow.Value);

                // Save Picture
                if (pictureBoxImportImage.Image != null)
                {
                    using (MemoryStream ma = new MemoryStream())
                    {
                        pictureBoxImportImage.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                        Properties.Settings.Default.CompanyLogo = Convert.ToBase64String(ma.ToArray());
                    }
                }

                // Save Settings
                Properties.Settings.Default.Save();
                MessageCollections.ShowInfo(localizer.Get("SettingsSaved"));
            }
            catch (Exception ex)
            {
                MessageCollections.ShowException(ex, "Save General Settings");
            }
        }

        private void SetLocalCon(string server, string dataBase)
        {
            var conString =
                $"Server={server};Database={dataBase};Trusted_Connection=True;TrustServerCertificate=True;";

            var protectedCon =
                SecureSettingsHelper.Protect(conString);

            Properties.Settings.Default.SqlServerString = protectedCon;

            Properties.Settings.Default.Save();
        }

        private void SetNetWorkCon(string server,
            string dataBase,
            string userName,
            string password,
            decimal timeout)
        {
            var conString =
                $"Server={server};Database={dataBase};User Id={userName};Password={password};TrustServerCertificate=True;Connection Timeout={timeout};";

            var protectedCon =
                SecureSettingsHelper.Protect(conString);

            Properties.Settings.Default.SqlServerString = protectedCon;

            Properties.Settings.Default.Save();
        }

        private void SetGeneralSettings()
        {
            textBoxCompanyName.Text = Properties.Settings.Default.CompanyName;
            numericUpDownNotification.Value = Properties.Settings.Default.HideNotificationInterval;
            numericUpDownDataRow.Value = Properties.Settings.Default.DataGridViewRowNo;

            // Set Picture
            if (Properties.Settings.Default.CompanyLogo != string.Empty) // Check if first open
            {
                var ImageAsByte = Convert.FromBase64String(Properties.Settings.Default.CompanyLogo); // Convert string to byte

                using (MemoryStream ma = new MemoryStream(ImageAsByte))
                {
                    pictureBoxImportImage.Image = Image.FromStream(ma); // Set picture
                }
            }
        }

        public void SetFirstStart(bool value)
        {
            firstStart = value;

            if (firstStart)
            {
                ApplyFirstRunMode();
            }
        }

        private void ApplyFirstRunMode()
        {
            // Disable general settings
            grpGeneralSettings.Enabled = false;

            // Disable backup
            grpBackupRestore.Enabled = false;

            // Disable image loading
            linkLabelImportImage.Enabled = false;

            // Explanatory note
            labelOrganizationLogo.Text = localizer.Get("DatabaseSetupHint");
        }

        private bool ValidateConnectionInputs()
        {
            bool valid = true;

            valid &= Validator.Required(
                comboBoxServer,
                errorProvider,
                localizer.Get("ServerRequired"));

            valid &= Validator.Required(
                textBoxDataBase,
                errorProvider,
                localizer.Get("DatabaseRequired"));

            if (radioButtonNetworkCon.Checked)
            {
                valid &= Validator.Required(
                    textBoxUserName,
                    errorProvider,
                    localizer.Get("UsernameRequired"));

                valid &= Validator.Required(
                    textBoxPassword,
                    errorProvider,
                    localizer.Get("PasswordRequired"));
            }

            return valid;
        }
        #endregion

        private void labelColse_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelImportPicture_Click(object sender, EventArgs e)
        {
            if (firstStart)
            {
                MessageBox.Show(MessagesLocal.DatabaseSetupRequired);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = localizer.Get("DatabaseSetupHint");
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = localizer.Get("ImageFilter");

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        pictureBoxImportImage.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(MessagesLocal.ImageLoadError);
                }
            }
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.SettingsLocal.SettingsFormLocalization");

        private void ApplyLocalization()
        {
            buttonBackup.Text =
                localizer.Get("ButtonBackup");

            buttonRestoreBackup.Text =
                localizer.Get("ButtonRestore");

            buttonSaveConString.Text =
                localizer.Get("ButtonSaveConString");

            buttonSaveGeneralSettings.Text =
                localizer.Get("ButtonSaveGeneral");

            buttonSaveLanguage.Text =
                localizer.Get("ButtonSaveLanguage");

            grpGeneralSettings.Text =
                localizer.Get("GroupBoxGeneral");

            grpDatabaseSettings.Text =
                localizer.Get("GroupBoxDatabases");

            grpLanguageSettings.Text =
                localizer.Get("GroupBoxLanguages");

            grpBackupRestore.Text =
                localizer.Get("GroupBoxBackup");

            labelTitle.Text =
                localizer.Get("LabelTitle");

            labelSubtitle.Text =
                localizer.Get("LabelSub");

            labelOrganizationName.Text =
                localizer.Get("LabelOrganizationName");

            labelOrganizationLogo.Text =
                localizer.Get("LabelOrganizationLogo");

            labelClickToUpload.Text =
                localizer.Get("LabelClickToUpload");

            labelNumberOfRecordsDisplayed.Text =
                localizer.Get("LabelNumberOfRecords");

            labelNotificationTimeout.Text =
                localizer.Get("LabelNotificationTimeout");

            labelConnectionType.Text =
                localizer.Get("LabelConnectionType");

            labelServer.Text =
                localizer.Get("LabelServer");

            labelDataBase.Text =
                localizer.Get("LabelDataBase");

            labelUserName.Text =
                localizer.Get("LabelUserName");

            labelPassword.Text =
                localizer.Get("LabelPassword");

            labelTimeConnection.Text =
                localizer.Get("LabelTimeConnection");

            labelLaguage.Text =
                localizer.Get("LabelLanguage");

            linkLabelImportImage.Text =
                localizer.Get("LinkLabelUpload");

            radioButtonLocalCon.Text =
                localizer.Get("RadioLocalCon");

            radioButtonNetworkCon.Text =
                localizer.Get("RadioNetworkCon");

            Text =
                localizer.Get("FormTitle");
        }


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

            // Form
            ClientSize = new Size(939, 678);
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";

            // Title Bar
            panelTitleBar.Size = new Size(939, 20);
            labelColseWindow.Location = new Point(918, 0);
            labelColseWindow.Text = "X";
            labelColseWindow.TextAlign = ContentAlignment.TopRight;

            // Header
            panelHeader.Size = new Size(939, 74);
            panelIconContainer.Location = new Point(12, 17);
            panelIconContainer.Size = new Size(51, 48);

            labelTitle.Text = "Settings";
            labelTitle.Location = new Point(69, 17);
            labelTitle.Font = new Font("Arial", 18F);

            labelSubtitle.Text = "General Settings | DataBase | Language | Backup";
            labelSubtitle.Location = new Point(69, 42);
            labelSubtitle.Size = new Size(382, 25);
            labelSubtitle.Font = new Font("Arial", 12.75F);

            // GroupBox: General Settings
            grpGeneralSettings.Location = new Point(0, 100);
            grpGeneralSettings.Size = new Size(440, 545);
            grpGeneralSettings.Text = "⚙️ General Settings";

            // Organization Name
            labelOrganizationName.Text = "Organization Name";
            labelOrganizationName.Location = new Point(16, 54);
            textBoxCompanyName.Location = new Point(165, 54);
            textBoxCompanyName.Size = new Size(260, 26);
            textBoxCompanyName.TextAlign = HorizontalAlignment.Center;

            // Notification Timeout
            labelNotificationTimeout.Text = "Notification Timeout (sec)";
            labelNotificationTimeout.Location = new Point(43, 123);
            numericUpDownNotification.Location = new Point(227, 123);
            numericUpDownNotification.Size = new Size(174, 26);

            // Number of Records Displayed
            labelNumberOfRecordsDisplayed.Text = "Number of Records Displayed";
            labelNumberOfRecordsDisplayed.Location = new Point(25, 195);
            numericUpDownDataRow.Location = new Point(227, 193);
            numericUpDownDataRow.Size = new Size(174, 26);

            // Organization Logo
            labelOrganizationLogo.Text = "Organization Logo";
            labelOrganizationLogo.Location = new Point(47, 272);

            panelImportPicture.Location = new Point(47, 295);
            panelImportPicture.Size = new Size(337, 147);
            pictureBoxImportImage.Location = new Point(130, 27);
            pictureBoxImportImage.Size = new Size(76, 53);
            labelClickToUpload.Text = "Click to upload logo";
            labelClickToUpload.Location = new Point(119, 83);
            linkLabelImportImage.Text = "Upload";
            linkLabelImportImage.Location = new Point(148, 100);

            // Save Button
            buttonSaveGeneralSettings.Text = "Save general settings";
            buttonSaveGeneralSettings.Location = new Point(63, 465);
            buttonSaveGeneralSettings.Size = new Size(299, 51);
            buttonSaveGeneralSettings.ImageAlign = ContentAlignment.MiddleLeft;

            // GroupBox: DataBases
            grpDatabaseSettings.Location = new Point(446, 100);
            grpDatabaseSettings.Size = new Size(489, 340);
            grpDatabaseSettings.Text = "🛢️ DataBases";

            // Connection Type
            labelConnectionType.Text = "Connection Type:";
            labelConnectionType.Location = new Point(20, 34);
            radioButtonLocalCon.Text = "Local";
            radioButtonLocalCon.Location = new Point(341, 36);
            radioButtonNetworkCon.Text = "Network";
            radioButtonNetworkCon.Location = new Point(191, 36);

            // Server
            labelServer.Text = "Server";
            labelServer.Location = new Point(29, 73);
            comboBoxServer.Location = new Point(145, 73);
            comboBoxServer.Size = new Size(308, 28);

            // DataBase
            labelDataBase.Text = "DataBase";
            labelDataBase.Location = new Point(29, 110);
            textBoxDataBase.Location = new Point(145, 110);
            textBoxDataBase.Size = new Size(308, 26);
            textBoxDataBase.Text = "TakeTicketDB";
            textBoxDataBase.TextAlign = HorizontalAlignment.Center;
            textBoxDataBase.RightToLeft = RightToLeft.No;

            // Time Connection
            labelTimeConnection.Text = "Time connection (Seconds)";
            labelTimeConnection.Location = new Point(26, 140);
            labelTimeConnection.Size = new Size(114, 49);
            numericUpDownTimeout.Location = new Point(145, 148);
            numericUpDownTimeout.Size = new Size(306, 26);

            // Username
            labelUserName.Text = "Username";
            labelUserName.Location = new Point(29, 196);
            textBoxUserName.Location = new Point(145, 192);
            textBoxUserName.Size = new Size(308, 26);
            textBoxUserName.TextAlign = HorizontalAlignment.Center;
            textBoxUserName.Enabled = false;

            // Password
            labelPassword.Text = "Password";
            labelPassword.Location = new Point(31, 235);
            textBoxPassword.Location = new Point(145, 230);
            textBoxPassword.Size = new Size(308, 26);
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.Enabled = false;
            textBoxPassword.PasswordChar = '*';

            // Save Connection Button
            buttonSaveConString.Text = "Save";
            buttonSaveConString.Location = new Point(196, 281);
            buttonSaveConString.Size = new Size(215, 39);
            buttonSaveConString.ImageAlign = ContentAlignment.MiddleLeft;

            // GroupBox: Languages
            grpLanguageSettings.Location = new Point(443, 446);
            grpLanguageSettings.Size = new Size(493, 96);
            grpLanguageSettings.Text = "🔠 Languages";

            labelLaguage.Text = "Select Language";
            labelLaguage.Location = new Point(14, 25);
            comboBoxLanguage.Location = new Point(16, 55);
            comboBoxLanguage.Size = new Size(301, 28);
            buttonSaveLanguage.Text = "Save";
            buttonSaveLanguage.Location = new Point(325, 55);
            buttonSaveLanguage.Size = new Size(89, 29);
            buttonSaveLanguage.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveLanguage.ForeColor = Color.White;
            buttonSaveLanguage.BackColor = Color.FromArgb(15, 110, 86);

            // GroupBox: Backup and Restore
            grpBackupRestore.Location = new Point(446, 548);
            grpBackupRestore.Size = new Size(493, 97);
            grpBackupRestore.Text = "🛢️ Backup and Restore (or Backup and Set)";

            buttonBackup.Text = "Backup";
            buttonBackup.Location = new Point(252, 38);
            buttonBackup.Size = new Size(238, 51);
            buttonBackup.ImageAlign = ContentAlignment.MiddleLeft;

            buttonRestoreBackup.Text = "Restore Backup";
            buttonRestoreBackup.Location = new Point(9, 38);
            buttonRestoreBackup.Size = new Size(238, 51);
            buttonRestoreBackup.ImageAlign = ContentAlignment.MiddleLeft;

            // Error Provider
            errorProvider.RightToLeft = false;

            ResumeLayout();
        }

        private void ApplyArabicLayout()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(921, 648);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            StartPosition = FormStartPosition.CenterScreen;

            // Title Bar
            panelTitleBar.Size = new Size(921, 20);
            labelColseWindow.Location = new Point(1, 0);
            labelColseWindow.Text = "X";
            labelColseWindow.TextAlign = ContentAlignment.TopLeft;

            // Header
            panelHeader.Size = new Size(921, 74);
            panelIconContainer.Location = new Point(865, 15);
            panelIconContainer.Size = new Size(51, 48);

            labelTitle.Text = "الإعدادات";
            labelTitle.Location = new Point(759, 15);
            labelTitle.Font = new Font("Arial", 18F);

            labelSubtitle.Text = "الإعدادات العامة | قاعدة البيانات | اللغة | النسخ الاحتياطي";
            labelSubtitle.Location = new Point(477, 42);
            labelSubtitle.Size = new Size(382, 25);
            labelSubtitle.Font = new Font("Arial", 12.75F);

            // GroupBox: General Settings
            grpGeneralSettings.Location = new Point(0, 100);
            grpGeneralSettings.Size = new Size(440, 545);
            grpGeneralSettings.Text = "⚙️ الإعدادات العامة";

            // Organization Name
            labelOrganizationName.Text = "اسم المنظمة / الشركة";
            labelOrganizationName.Location = new Point(290, 57);
            textBoxCompanyName.Location = new Point(6, 54);
            textBoxCompanyName.Size = new Size(260, 26);
            textBoxCompanyName.TextAlign = HorizontalAlignment.Center;

            // Notification Timeout
            labelNotificationTimeout.Text = "مهلة التنبيهات (ثانية)";
            labelNotificationTimeout.Location = new Point(290, 127);
            numericUpDownNotification.Location = new Point(92, 123);
            numericUpDownNotification.Size = new Size(174, 26);

            // Number of Records Displayed
            labelNumberOfRecordsDisplayed.Text = "عدد السجلات المعروضة";
            labelNumberOfRecordsDisplayed.Location = new Point(274, 197);
            numericUpDownDataRow.Location = new Point(92, 194);
            numericUpDownDataRow.Size = new Size(174, 26);

            // Organization Logo
            labelOrganizationLogo.Text = "شعار المنظمة";
            labelOrganizationLogo.Location = new Point(292, 272);

            panelImportPicture.Location = new Point(47, 295);
            panelImportPicture.Size = new Size(337, 147);
            pictureBoxImportImage.Location = new Point(130, 27);
            pictureBoxImportImage.Size = new Size(76, 53);
            labelClickToUpload.Text = "انقر لرفع الشعار";
            labelClickToUpload.Location = new Point(125, 83);
            linkLabelImportImage.Text = "رفع";
            linkLabelImportImage.Location = new Point(155, 100);

            // Save Button
            buttonSaveGeneralSettings.Text = "حفظ الإعدادات العامة";
            buttonSaveGeneralSettings.Location = new Point(63, 465);
            buttonSaveGeneralSettings.Size = new Size(299, 51);
            buttonSaveGeneralSettings.ImageAlign = ContentAlignment.MiddleRight;

            // GroupBox: DataBases
            grpDatabaseSettings.Location = new Point(442, 100);
            grpDatabaseSettings.Size = new Size(470, 340);
            grpDatabaseSettings.Text = "🛢️ قواعد البيانات";

            // Connection Type
            labelConnectionType.Text = "نوع الاتصال:";
            labelConnectionType.Location = new Point(362, 36);
            radioButtonLocalCon.Text = "محلي";
            radioButtonLocalCon.Location = new Point(63, 36);
            radioButtonNetworkCon.Text = "شبكي";
            radioButtonNetworkCon.Location = new Point(191, 36);

            // Server
            labelServer.Text = "السيرفر (الخادم)";
            labelServer.Location = new Point(339, 72);
            comboBoxServer.Location = new Point(25, 71);
            comboBoxServer.Size = new Size(308, 28);

            // DataBase
            labelDataBase.Text = "قاعدة البيانات";
            labelDataBase.Location = new Point(339, 109);
            textBoxDataBase.Location = new Point(25, 108);
            textBoxDataBase.Size = new Size(308, 26);
            textBoxDataBase.Text = "TakeTicketDB";
            textBoxDataBase.TextAlign = HorizontalAlignment.Center;
            textBoxDataBase.RightToLeft = RightToLeft.No;

            // Time Connection
            labelTimeConnection.Text = "مهلة الاتصال (ثواني)";
            labelTimeConnection.Location = new Point(339, 135);
            labelTimeConnection.Size = new Size(91, 49);
            numericUpDownTimeout.Location = new Point(25, 146);
            numericUpDownTimeout.Size = new Size(306, 26);

            // Username
            labelUserName.Text = "اسم المستخدم";
            labelUserName.Location = new Point(339, 195);
            textBoxUserName.Location = new Point(25, 190);
            textBoxUserName.Size = new Size(308, 26);
            textBoxUserName.TextAlign = HorizontalAlignment.Center;
            textBoxUserName.Enabled = false;

            // Password
            labelPassword.Text = "كلمة المرور";
            labelPassword.Location = new Point(339, 234);
            textBoxPassword.Location = new Point(25, 228);
            textBoxPassword.Size = new Size(308, 26);
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.Enabled = false;
            textBoxPassword.PasswordChar = '*';

            // Save Connection Button
            buttonSaveConString.Text = "حفظ";
            buttonSaveConString.Location = new Point(196, 281);
            buttonSaveConString.Size = new Size(187, 39);
            buttonSaveConString.ImageAlign = ContentAlignment.MiddleRight;

            // GroupBox: Languages
            grpLanguageSettings.Location = new Point(443, 446);
            grpLanguageSettings.Size = new Size(471, 96);
            grpLanguageSettings.Text = "🔠 اللغات";

            labelLaguage.Text = "اختر اللغة";
            labelLaguage.Location = new Point(353, 32);
            comboBoxLanguage.Location = new Point(118, 55);
            comboBoxLanguage.Size = new Size(308, 28);

            buttonSaveLanguage.Text = "حفظ";
            buttonSaveLanguage.Location = new Point(27, 54);
            buttonSaveLanguage.Size = new Size(89, 29);
            buttonSaveLanguage.ImageAlign = ContentAlignment.MiddleRight;
            buttonSaveLanguage.ForeColor = Color.White;
            buttonSaveLanguage.BackColor = Color.FromArgb(15, 110, 86);

            // GroupBox: Backup and Restore
            grpBackupRestore.Location = new Point(442, 548);
            grpBackupRestore.Size = new Size(474, 97);
            grpBackupRestore.Text = "🛢️ النسخ الاحتياطي والاستعادة";

            buttonBackup.Text = "نسخ احتياطي";
            buttonBackup.Location = new Point(258, 38);
            buttonBackup.Size = new Size(199, 51);
            buttonBackup.ImageAlign = ContentAlignment.MiddleRight;

            buttonRestoreBackup.Text = "استعادة";
            buttonRestoreBackup.Location = new Point(19, 38);
            buttonRestoreBackup.Size = new Size(197, 51);
            buttonRestoreBackup.ImageAlign = ContentAlignment.MiddleRight;

            // Error Provider
            errorProvider.RightToLeft = true;

            ResumeLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // Form
            ClientSize = new Size(939, 646);
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            StartPosition = FormStartPosition.CenterScreen;

            // Title Bar
            panelTitleBar.Size = new Size(939, 20);
            labelColseWindow.Location = new Point(918, 0);
            labelColseWindow.Text = "X";
            labelColseWindow.TextAlign = ContentAlignment.TopRight;

            // Header
            panelHeader.Size = new Size(939, 74);
            panelIconContainer.Location = new Point(12, 17);
            panelIconContainer.Size = new Size(51, 48);

            labelTitle.Text = "Настройки";
            labelTitle.Location = new Point(69, 17);
            labelTitle.Font = new Font("Arial", 18F);

            labelSubtitle.Text = "Общие настройки | База данных | Язык | Резервное копирование";
            labelSubtitle.Location = new Point(69, 42);
            labelSubtitle.Size = new Size(510, 19);
            labelSubtitle.Font = new Font("Arial", 12.75F);

            // GroupBox: Общие настройки
            grpGeneralSettings.Location = new Point(0, 100);
            grpGeneralSettings.Size = new Size(440, 545);
            grpGeneralSettings.Text = "⚙️ Общие настройки";

            // Organization Name
            labelOrganizationName.Text = "Название организации";
            labelOrganizationName.Location = new Point(16, 55);
            textBoxCompanyName.Location = new Point(174, 54);
            textBoxCompanyName.Size = new Size(260, 26);
            textBoxCompanyName.TextAlign = HorizontalAlignment.Center;

            // Notification Timeout
            labelNotificationTimeout.Text = "Время ожидания уведомления (сек)";
            labelNotificationTimeout.Location = new Point(16, 126);
            numericUpDownNotification.Location = new Point(174, 148);
            numericUpDownNotification.Size = new Size(260, 26);

            // Number of Records Displayed
            labelNumberOfRecordsDisplayed.Text = "Количество отображаемых записей";
            labelNumberOfRecordsDisplayed.Location = new Point(16, 196);
            numericUpDownDataRow.Location = new Point(174, 218);
            numericUpDownDataRow.Size = new Size(260, 26);

            // Organization Logo
            labelOrganizationLogo.Text = "Логотип организации";
            labelOrganizationLogo.Location = new Point(49, 272);

            panelImportPicture.Location = new Point(47, 295);
            panelImportPicture.Size = new Size(337, 147);
            pictureBoxImportImage.Location = new Point(130, 27);
            pictureBoxImportImage.Size = new Size(76, 53);
            labelClickToUpload.Text = "Нажмите для загрузки логотипа";
            labelClickToUpload.Location = new Point(84, 83);
            linkLabelImportImage.Text = "Загрузить";
            linkLabelImportImage.Location = new Point(139, 100);

            // Save Button
            buttonSaveGeneralSettings.Text = "Сохранить общие настройки";
            buttonSaveGeneralSettings.Location = new Point(63, 465);
            buttonSaveGeneralSettings.Size = new Size(299, 51);
            buttonSaveGeneralSettings.ImageAlign = ContentAlignment.MiddleLeft;

            // GroupBox: Базы данных
            grpDatabaseSettings.Location = new Point(446, 100);
            grpDatabaseSettings.Size = new Size(489, 340);
            grpDatabaseSettings.Text = "🛢️ Базы данных";

            // Connection Type
            labelConnectionType.Text = "Тип подключения:";
            labelConnectionType.Location = new Point(19, 36);
            radioButtonLocalCon.Text = "Локальный";
            radioButtonLocalCon.Location = new Point(341, 36);
            radioButtonNetworkCon.Text = "Сетевой";
            radioButtonNetworkCon.Location = new Point(191, 36);

            // Server
            labelServer.Text = "Сервер";
            labelServer.Location = new Point(18, 73);
            comboBoxServer.Location = new Point(145, 73);
            comboBoxServer.Size = new Size(308, 28);

            // DataBase
            labelDataBase.Text = "База данных";
            labelDataBase.Location = new Point(18, 110);
            textBoxDataBase.Location = new Point(145, 110);
            textBoxDataBase.Size = new Size(308, 26);
            textBoxDataBase.Text = "TakeTicketDB";
            textBoxDataBase.TextAlign = HorizontalAlignment.Center;
            textBoxDataBase.RightToLeft = RightToLeft.No;

            // Time Connection
            labelTimeConnection.Text = "Время соединения (секунды)";
            labelTimeConnection.Location = new Point(18, 140);
            labelTimeConnection.Size = new Size(114, 49);
            numericUpDownTimeout.Location = new Point(145, 148);
            numericUpDownTimeout.Size = new Size(306, 26);

            // Username
            labelUserName.Text = "Имя пользователя";
            labelUserName.Location = new Point(18, 196);
            textBoxUserName.Location = new Point(145, 192);
            textBoxUserName.Size = new Size(308, 26);
            textBoxUserName.TextAlign = HorizontalAlignment.Center;
            textBoxUserName.Enabled = false;

            // Password
            labelPassword.Text = "Пароль";
            labelPassword.Location = new Point(18, 235);
            textBoxPassword.Location = new Point(145, 230);
            textBoxPassword.Size = new Size(308, 26);
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.Enabled = false;
            textBoxPassword.PasswordChar = '*';

            // Save Connection Button
            buttonSaveConString.Text = "Сохранить";
            buttonSaveConString.Location = new Point(196, 281);
            buttonSaveConString.Size = new Size(215, 39);
            buttonSaveConString.ImageAlign = ContentAlignment.MiddleLeft;

            // GroupBox: Языки
            grpLanguageSettings.Location = new Point(443, 446);
            grpLanguageSettings.Size = new Size(493, 96);
            grpLanguageSettings.Text = "🔠 Языки";

            labelLaguage.Text = "Выберите язык";
            labelLaguage.Location = new Point(14, 25);
            comboBoxLanguage.Location = new Point(16, 55);
            comboBoxLanguage.Size = new Size(301, 28);

            buttonSaveLanguage.Text = "Сохранить";
            buttonSaveLanguage.Location = new Point(325, 55);
            buttonSaveLanguage.Size = new Size(89, 29);
            buttonSaveLanguage.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveLanguage.ForeColor = Color.White;
            buttonSaveLanguage.BackColor = Color.FromArgb(15, 110, 86);

            // GroupBox: Резервное копирование и восстановление
            grpBackupRestore.Location = new Point(446, 548);
            grpBackupRestore.Size = new Size(493, 97);
            grpBackupRestore.Text = "🛢️ Резервное копирование и восстановление";

            buttonBackup.Text = "Резервное копирование";
            buttonBackup.Location = new Point(252, 38);
            buttonBackup.Size = new Size(238, 51);
            buttonBackup.ImageAlign = ContentAlignment.MiddleLeft;

            buttonRestoreBackup.Text = "Восстановить";
            buttonRestoreBackup.Location = new Point(9, 38);
            buttonRestoreBackup.Size = new Size(238, 51);
            buttonRestoreBackup.ImageAlign = ContentAlignment.MiddleLeft;

            // Error Provider
            errorProvider.RightToLeft = false;

            ResumeLayout();
        }
        #endregion
    }
}
