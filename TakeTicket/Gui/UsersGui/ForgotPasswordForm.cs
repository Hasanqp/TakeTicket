using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Common.Security;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.UsersGui
{
    public partial class ForgotPasswordForm : Form
    {
        // Variables
        private readonly int ID;
        private readonly UsersUserControl _usersUserControl;
        private readonly IDataHelper<Users> dataHelper;
        private readonly IDataHelper<UsersRoles> dataHelperUsersRoles;
        private readonly LoadingGui.LoadingForm loadingForm;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private Dictionary<string, bool> ListOfRoles = new Dictionary<string, bool>();
        private readonly IUserService userService;
        private Users currentUser;
        private bool isWaitingMessage = false;

        public ForgotPasswordForm(IDataHelper<Users> dataHelper, IDataHelper<UsersRoles> dataHelperUsersRoles, IDataHelper<SystemRecords> dataHelperSystemRecords, IUserService userService)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            this.dataHelper = dataHelper;
            this.dataHelperUsersRoles = dataHelperUsersRoles;
            this.dataHelperSystemRecords = dataHelperSystemRecords;
            this.userService = userService;

            this.currentUser = null;
            loadingForm = new LoadingGui.LoadingForm();
        }

        #region Evints
        private async void buttonVerfiy_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                if (string.IsNullOrWhiteSpace(textBoxUserName.Text))
                {
                    MessageCollections.ShowWarning(MessagesLocal.EnterUsername);
                    return;
                }

                loadingForm.Show();

                try
                {
                    var user = await userService.GetByUserNameAsync(textBoxUserName.Text);

                    if (user == null)
                    {
                        MessageBox.Show(localizer.Get("UserNotFound"));
                        return;
                    }

                    currentUser = user;

                    comboBoxRecoveryMethod.Enabled = true;
                    buttonSendRecoveryCode.Enabled = true;

                    MessageBox.Show(localizer.Get("UserVerifiedChooseMethod"));
                }
                finally
                {
                    loadingForm.Hide();
                }

                return;
            }

            var method = comboBoxRecoveryMethod.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(method))
            {
                MessageBox.Show(localizer.Get("ChooseRecoveryMethod"));
                return;
            }

            if (method == localizer.Get("RecoveryCodeMethod"))
            {
                if (string.IsNullOrWhiteSpace(textBoxRecoveryCode.Text))
                {
                    MessageBox.Show(MessagesLocal.EnterRecoveryCode);
                    return;
                }

                if (currentUser.RecoveryCodeExpiry == null || currentUser.RecoveryCodeExpiry < DateTime.Now)
                {
                    MessageBox.Show(localizer.Get("RecoveryCodeExpired"));
                    return;
                }

                if (string.IsNullOrEmpty(currentUser.RecoveryCode))
                {
                    MessageBox.Show(localizer.Get("RecoveryCodeNotRequested"));
                    return;
                }

                if (!PasswordHasher.Verify(textBoxRecoveryCode.Text.Trim(), currentUser.RecoveryCode))
                {
                    MessageBox.Show(localizer.Get("InvalidRecoveryCode"));
                    return;
                }
            }
            else if (method == localizer.Get("RecoveryQuestionMethod"))
            {
                if (string.IsNullOrWhiteSpace(textBoxAnswer.Text))
                {
                    MessageBox.Show(localizer.Get("EnterAnswer"));
                    return;
                }

                if (!PasswordHasher.Verify(textBoxAnswer.Text, currentUser.SecurityAnswer))
                {
                    MessageBox.Show(localizer.Get("InvalidAnswer"));
                    return;
                }
            }

            // Success
            var resetForm = Program.ServiceProvider.GetRequiredService<RestPasswordForm>();
            resetForm.SetUser(currentUser);
            resetForm.Show();
            this.Hide();
        }

        private async void buttonSendCode_Click(object sender, EventArgs e)
        {
            var user = currentUser;

            if (user == null)
            {
                MessageBox.Show(localizer.Get("UserNotFound"));
                return;
            }

            if (user.NextRecoveryCodeRequestAt != null &&
                user.NextRecoveryCodeRequestAt > DateTime.Now)
            {
                if (isWaitingMessage)
                    return;

                isWaitingMessage = true;

                try
                {
                    var remaining = Math.Max(1, (int)Math.Ceiling(
                            (user.NextRecoveryCodeRequestAt.Value - DateTime.Now)
                            .TotalSeconds));

                    await MessageCollections.ShowCountdownNotification(
                        localizer.Get("WaitBeforeNewCode"),
                        remaining,
                        this);
                }
                finally
                {
                    isWaitingMessage = false;
                }

                return;
            }

            if (string.IsNullOrWhiteSpace(user.Phone))
            {
                MessageBox.Show(localizer.Get("PhoneNumberRequired"));
                return;
            }

            var code = LoginUserForm.GenerateRecoveryCode();

            user.RecoveryCode = PasswordHasher.Hash(code);
            user.RecoveryCodeExpiry = DateTime.Now.AddMinutes(10);

            user.RecoveryCodeSentAt = DateTime.Now;
            user.NextRecoveryCodeRequestAt = DateTime.Now.AddMinutes(1);

            await userService.UpdateAsync(user);

            string message = string.Format(localizer.Get("DefinitionRecoveryCode"), code);

            message += Environment.NewLine + Environment.NewLine + localizer.Get("WarningRecoveryCode");

            string phone = user.Phone.Replace("+", "");

            string url = $"https://web.whatsapp.com/send?phone={phone}&text={Uri.EscapeDataString(message)}";

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });

            MessageCollections.ShowNotification(localizer.Get("RecoveryCodeSent"));

            Logger.Audit($"Recovery Code Generated: {user.UserName}");
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            buttonSendRecoveryCode.Enabled = false;
            comboBoxRecoveryMethod.Enabled = false;

            comboBoxRecoveryMethod.Items.Clear();
            comboBoxRecoveryMethod.Items.Add(localizer.Get("RecoveryCodeMethod"));
            comboBoxRecoveryMethod.Items.Add(localizer.Get("RecoveryQuestionMethod"));
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            var login =
                Program.ServiceProvider
                .GetRequiredService<LoginUserForm>();

            login.Show();
            this.Close();
        }

        private void comboBoxRecoveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentUser == null)
            {
                MessageBox.Show(localizer.Get("VerifyUsernameFirst"));
                comboBoxRecoveryMethod.SelectedIndex = -1;
                return;
            }


            // Hide all recovery inputs
            comboBoxSecurityQuestion.Visible = false;
            textBoxAnswer.Visible = false;
            textBoxRecoveryCode.Visible = false;

            if (comboBoxRecoveryMethod.SelectedItem.ToString() == localizer.Get("RecoveryCodeMethod"))
            {
                textBoxRecoveryCode.Visible = true;
            }
            else if (comboBoxRecoveryMethod.SelectedItem.ToString() == localizer.Get("RecoveryQuestionMethod"))
            {
                comboBoxSecurityQuestion.Visible = true;
                textBoxAnswer.Visible = true;

                // load the user's security question
                comboBoxSecurityQuestion.Items.Clear();

                if (!string.IsNullOrEmpty(currentUser.SecurityQuestion))
                {
                    comboBoxSecurityQuestion.Items.Add(localizer.Get(currentUser.SecurityQuestion));
                    comboBoxSecurityQuestion.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(localizer.Get("NoSecurityQuestion"));
                }
            }
        }

        #endregion
        #region Methods
        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.UserLocal.ForgotPasswordFormLocalization");

        private void ApplyLocalization()
        {
            this.Text =
                localizer.Get("ForgotPasswordForm.Text");

            buttonSendRecoveryCode.Text =
                localizer.Get("buttonSendCode.Text");

            buttonVerify.Text =
                localizer.Get("buttonVerfiy.Text");

            labelRecoveryCodeSubtitle.Text =
                localizer.Get("LabelSubRecoveryCode");

            labelMethodATitle.Text =
                localizer.Get("LabelARecoveryCode");

            labelAnswer.Text =
                localizer.Get("labelAnswer.Text");

            labelMethodBIndicator.Text =
                localizer.Get("labelAnswerMethod.Text");

            labelMethodBTitle.Text =
                localizer.Get("labelBMethodsecurityQuestion.Text");

            labelRecoveryMethod.Text =
                localizer.Get("labelChoiceRecveryMethod.Text");

            labelMethodAIndicator.Text =
                localizer.Get("labelRecoveryMehtod.Text");

            labelSecurityQuestion.Text =
                localizer.Get("labelsecurityQuestion.Text");

            labelSubtitle.Text =
                localizer.Get("labelSub.Text");

            labelTitle.Text =
                localizer.Get("labelTitle.Text");

            labelUserName.Text =
                localizer.Get("labelUser.Text");
        }
        #endregion

        #region RTL
        private void ApplyLayout()
        {
            switch (Thread.CurrentThread
                .CurrentUICulture
                .TwoLetterISOLanguageName)
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

            // Title & Subtitle
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // Close Button
            buttonCloseWindow.Location = new Point(0, 1);
            panelIconContainer.Location = new Point(188, 44);
            pictureBoxIcon.Location = new Point(15, 16);

            // Username
            panelUserName.Location = new Point(33, 200);
            labelUserName.Location = new Point(335, 181);
            labelRequiredUserName.Location = new Point(321, 181);
            pictureBoxUserName.Location = new Point(7, 7);
            textBoxUserName.Location = new Point(34, 12);
            textBoxUserName.Size = new Size(338, 17);
            textBoxUserName.TextAlign = HorizontalAlignment.Right;

            // Recovery Method
            labelRecoveryMethod.Location = new Point(322, 258);
            comboBoxRecoveryMethod.RightToLeft = RightToLeft.Yes;
            panelRecoveryMethod.Location = new Point(33, 277);
            comboBoxRecoveryMethod.Location = new Point(2, 6);
            comboBoxRecoveryMethod.Size = new Size(371, 26);

            // Method A (Recovery Code)
            panelMethodAIconContainer.Location = new Point(381, 356);
            labelMethodAIndicator.Location = new Point(6, 5);
            labelMethodATitle.Location = new Point(302, 360);
            labelRecoveryCodeSubtitle.Location = new Point(329, 386);
            pictureBoxKeyIcon.Location = new Point(7, 8);
            textBoxRecoveryCode.Location = new Point(34, 11);
            textBoxRecoveryCode.TextAlign = HorizontalAlignment.Right;
            buttonSendRecoveryCode.Location = new Point(33, 407);

            // Method B (Security Question)
            panelMethodBIconContainer.Location = new Point(381, 451);
            labelMethodBIndicator.Location = new Point(2, 2);
            labelMethodBTitle.Location = new Point(306, 454);

            // Secutity question
            labelSecurityQuestion.Location = new Point(336, 491);
            panelSecurityQuestion.Location = new Point(33, 511);
            comboBoxSecurityQuestion.Location = new Point(3, 7);
            comboBoxSecurityQuestion.RightToLeft = RightToLeft.Yes;

            // Answer
            panelAnswer.Location = new Point(33, 574);
            labelAnswer.Location = new Point(364, 554);
            pictureBoxAnswerIcon.Location = new Point(3, 9);
            textBoxAnswer.Location = new Point(35, 13);
            textBoxAnswer.TextAlign = HorizontalAlignment.Right;

            // Verify Button Icon
            pictureBoxVerifyIcon.Location = new Point(132, 636);
            buttonVerify.Location = new Point(116, 629);

            // Recovery Code Panel
            panelRecoveryCode.Location = new Point(132, 405);
        }

        private void ApplyEnglishLayout()
        {
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;

            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            labelUserName.Location = new Point(40, 181);
            labelRequiredUserName.Location = new Point(110, 181);

            pictureBoxUserName.Location =
                new Point(7, 7);

            textBoxUserName.Location =
                new Point(34, 12);

            textBoxUserName.TextAlign =
                HorizontalAlignment.Left;
        }

        private void ApplyRussianLayout()
        {
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;

            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            labelUserName.Location = new Point(40, 181);
            labelRequiredUserName.Location = new Point(178, 181);

            pictureBoxUserName.Location =
                new Point(7, 7);

            textBoxUserName.Location =
                new Point(34, 12);

            textBoxUserName.TextAlign =
                HorizontalAlignment.Left;

            buttonSendRecoveryCode.Size =
                new Size(120, 37);

            //buttonSendRecoveryCode.Font =
            //    new Font("Arial", 11F, FontStyle.Bold);
        }

        #endregion

    }
}
