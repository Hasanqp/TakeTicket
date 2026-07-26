using Microsoft.Extensions.DependencyInjection;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Common.Security;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.UsersGui
{
    public partial class RestPasswordForm : Form
    {
        // Variables
        private readonly int ID;
        private readonly UsersUserControl _usersUserControl;
        private Users users;
        private readonly IDataHelper<Users> dataHelper;
        private readonly IDataHelper<UsersRoles> dataHelperUsersRoles;
        private readonly LoadingGui.LoadingForm loadingForm;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private Dictionary<string, bool> ListOfRoles = new Dictionary<string, bool>();
        private Users _currentUser;
        private readonly IUserService userService;

        public RestPasswordForm(IDataHelper<Users> dataHelper, IDataHelper<UsersRoles> dataHelperUsersRoles, IDataHelper<SystemRecords> dataHelperSystemRecords, IUserService userService)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            this.dataHelper = dataHelper;
            this.dataHelperUsersRoles = dataHelperUsersRoles;
            this.dataHelperSystemRecords = dataHelperSystemRecords;
            this.userService = userService;
            loadingForm = new LoadingGui.LoadingForm();

        }
        #region Evints

        private void RestPasswordForm_Load(object sender, EventArgs e)
        {
            if(_currentUser == null)
            {
                MessageBox.Show(localizer.Get("UserNotFound"));

                Close();
                return;
            }

            textBoxUserName.Text = _currentUser.UserName;

            textBoxUserName.ReadOnly = true;
        }

        private async void buttonRest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                MessageBox.Show(localizer.Get("EnterPassword"));
                return;
            }

            if (_currentUser == null)
            {
                MessageBox.Show(localizer.Get("OperationError"));
                return;
            }

            if (textBoxConfirmPassword.Text != textBoxNewPassword.Text)
            {
                MessageBox.Show(localizer.Get("PasswordNotMatch"));
                return;
            }

            loadingForm.Show();

            try
            {
                _currentUser.Password = PasswordHasher.Hash(textBoxConfirmPassword.Text);

                _currentUser.RecoveryCode = null;
                _currentUser.RecoveryCodeExpiry = null;

                await userService.UpdateAsync(_currentUser);

                Logger.Audit($"Password Reset: UserId={_currentUser.Id} User={_currentUser.UserName}");
                MessageBox.Show(localizer.Get("PasswordChangedSuccess"));

                var login = Program.ServiceProvider.GetRequiredService<LoginUserForm>();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "ResetPassword");
                MessageBox.Show(localizer.Get("UnexpectedError"));
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            var login =
                Program.ServiceProvider
                .GetRequiredService<LoginUserForm>();

            login.Show();
            this.Close();
        }
        #endregion
        #region Methods
        public void SetUser(Users user)
        {
            _currentUser = user;
        }

        private readonly Localizer localizer = new Localizer(
            "TakeTicket.Shared.Localization.Forms.UserLocal.RestPasswordFormLocalization");

        private void ApplyLocalization()
        {
            buttonReset.Text =
                localizer.Get("ResetButton");

            labelAccountInformation.Text =
                localizer.Get("AccountInformationLabel");

            labelConfirmPassword.Text =
                localizer.Get("ConfirmPasswordLabel");

            labelNewPassword.Text =
                localizer.Get("NewPasswordLabel");

            labelSubtitle.Text =
                localizer.Get("ResetPasswordSubLabel");

            labelTitle.Text =
                localizer.Get("ResetPasswordTitle");

            labelUserName.Text =
                localizer.Get("UserNameLabel");

            this.Text =
                localizer.Get("AccountRecoveryTitle");
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
            ApplyEnglishLayout();

            RightToLeft =
                RightToLeft.Yes;

            RightToLeftLayout =
                true;

            buttonCloseWindow.Location =
                new Point(3, 3);

            pictureBoxResetIcon.Location =
                new Point(275, 11);

            pictureBoxAccountIcon.Location =
                new Point(415, 110);

            panelIconContainer.Location =
                new Point(386, 35);

            labelTitle.Location =
                new Point(194, 31);

            labelSubtitle.Location =
                new Point(85, 58);

            labelAccountInformation.Location =
                new Point(317, 111);

            labelUserName.Location =
                new Point(371, 146);

            labelNewPassword.Location =
                new Point(349, 211);

            labelConfirmPassword.Location =
                new Point(349, 280);

            labelRequiredUserName.Location =
                new Point(357, 146);

            labelRequiredNewPassword.Location =
                new Point(336, 211);

            labelRequiredConfirmPassword.Location =
                new Point(336, 280);

            textBoxUserName.TextAlign =
                HorizontalAlignment.Right;

            textBoxNewPassword.TextAlign =
                HorizontalAlignment.Right;

            textBoxConfirmPassword.TextAlign =
                HorizontalAlignment.Right;
        }

        private void ApplyEnglishLayout()
        {
            RightToLeft =
                RightToLeft.No;

            RightToLeftLayout =
                false;

            buttonCloseWindow.Location =
                new Point(435, 4);

            pictureBoxResetIcon.Location =
                new Point(167, 13);

            pictureBoxAccountIcon.Location =
                new Point(46, 110);

            panelIconContainer.Location =
                new Point(21, 34);

            labelTitle.Location =
                new Point(76, 34);

            labelSubtitle.Location =
                new Point(78, 58);

            labelAccountInformation.Location =
                new Point(74, 110);

            labelUserName.Location =
                new Point(47, 146);

            labelNewPassword.Location =
                new Point(47, 211);

            labelConfirmPassword.Location =
                new Point(47, 280);

            labelRequiredUserName.Location =
                new Point(120, 146);

            labelRequiredNewPassword.Location =
                new Point(151, 211);

            labelRequiredConfirmPassword.Location =
                new Point(173, 280);

            textBoxUserName.TextAlign =
                HorizontalAlignment.Left;

            textBoxNewPassword.TextAlign =
                HorizontalAlignment.Left;

            textBoxConfirmPassword.TextAlign =
                HorizontalAlignment.Left;

            labelUserName.AutoSize = true;
            labelNewPassword.AutoSize = true;
            labelConfirmPassword.AutoSize = true;
            labelAccountInformation.AutoSize = true;
        }

        private void ApplyRussianLayout()
        {
            ApplyEnglishLayout();

            labelUserName.AutoSize = false;
            labelUserName.Size =
                new Size(150, 20);

            labelNewPassword.AutoSize = false;
            labelNewPassword.Size =
                new Size(130, 20);

            labelConfirmPassword.AutoSize = false;
            labelConfirmPassword.Size =
                new Size(180, 20);

            labelAccountInformation.AutoSize = false;
            labelAccountInformation.Size =
                new Size(160, 20);

            labelSubtitle.Size =
                new Size(363, 40);
        }
        #endregion
    }
}
