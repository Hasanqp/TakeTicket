using Microsoft.Extensions.DependencyInjection;
using System.Data;
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
    public partial class LoginUserForm : Form
    {
        // Variables
        private readonly int ID;
        private readonly UsersUserControl _usersUserControl;
        private readonly IDataHelper<Users> dataHelper;
        private readonly IDataHelper<UsersRoles> dataHelperUsersRoles;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private readonly IUserService userService;
        private readonly LoadingGui.LoadingForm loadingForm;
        private Dictionary<string, bool> ListOfRoles = new Dictionary<string, bool>();

        public LoginUserForm(IDataHelper<Users> dataHelper, IDataHelper<UsersRoles> dataHelperUsersRoles, IDataHelper<SystemRecords> dataHelperSystemRecords, IUserService userService)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            this.dataHelper = dataHelper;
            this.dataHelperUsersRoles = dataHelperUsersRoles;
            this.dataHelperSystemRecords = dataHelperSystemRecords;
            loadingForm = new LoadingGui.LoadingForm();
            this.userService = userService;
            Debug.WriteLine("LoginUserForm Created");
        }
        #region Evints
        private void LoginUserForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = buttonLogin;
        }

        private async Task<Users> Login(string userName, string password)
        {
            try
            {
                var user = await userService.GetByUserNameAsync(userName);

                if (user == null)
                {
                    await Task.Delay(300);
                    Logger.Audit($"Failed Login: {userName}");
                    return null;
                }

                if (string.IsNullOrEmpty(user.Password))
                {
                    Logger.Audit($"User has empty password: {userName}");
                    return null;
                }

                bool isHashed =
                    user.Password.StartsWith("$2a$")
                    || user.Password.StartsWith("$2b$")
                    || user.Password.StartsWith("$2y$");

                if (isHashed)
                {
                    if (!PasswordHasher.Verify(password, user.Password))
                    {
                        await Task.Delay(300);
                        Logger.Audit($"Failed Login: {userName}");
                        return null;
                    }
                }
                else
                {
                    // old users
                    if (user.Password != password)
                    {
                        Logger.Audit($"Failed Login: {userName}");
                        return null;
                    }

                    // upgrade to hash
                    user.Password = PasswordHasher.Hash(password);
                    await userService.UpdateAsync(user);
                }

                Properties.Settings.Default.UserName = user.FullName;
                Properties.Settings.Default.Save();

                var listRoles = dataHelperUsersRoles
                    .GetAllData()
                    .Where(x => x.UserId == user.Id);

                UsersRolesManager.ClearRoles();


                foreach (var item in listRoles)
                {
                    UsersRolesManager.Register(item.Key, item.Value);
                }

                Debug.WriteLine("===== ALL ROLES =====");

                foreach (var item in listRoles)
                {
                    Debug.WriteLine($"{item.Key} = {item.Value}");
                }

                Logger.Audit($"User Login: {user.UserName}");

                dataHelperSystemRecords.Add(new SystemRecords
                {
                    Title = localizer.Get("SystemRecordLoginTitle"),
                    UserName = user.FullName,
                    Details = string.Format(
                        localizer.Get("SystemRecordLoginDetails"),
                        user.FullName),
                    AddedDate = DateTime.Now
                });

                return user;
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Login");
                return null;
            }
        }

        private void LoginUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Methods
        private bool IsFiledsEmpty()
        {
            if (
                textBoxUserName.Text == string.Empty
                || textBoxPassword.Text == string.Empty
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GenerateRecoveryCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (IsFiledsEmpty())
            {
                MessageCollections.ShowFieldsRequired();
                return;
            }

            buttonLogin.Enabled = false;
            loadingForm.Show();

            try
            {
                var userName = textBoxUserName.Text.Trim();
                var password = textBoxPassword.Text;

                var user = await Login(userName, password);

                if (user == null)
                {
                    MessageBox.Show(localizer.Get("InvalidLogin"));
                    return;
                }


                var currentUser = Program.ServiceProvider.GetRequiredService<ICurrentUserService>();
                #region DEBUG
                //Debug.WriteLine("Step 1: Getting ICurrentUserService...");
                //Debug.WriteLine("Step 2: Got it. Setting UserId...");
                //Debug.WriteLine("Step 3: CurrentUser set. Getting Main form...");
                //var registered = Program.ServiceProvider.GetService<Main>();
                //Debug.WriteLine($"Main registered: {registered != null}");
                //Debug.WriteLine("Step 4: Got Main. Showing...");
                //Debug.WriteLine("Step 5: Main shown. Hiding login...");
                //Debug.WriteLine("Step 6: Done.");
                #endregion
                currentUser.UserId = user.Id;
                currentUser.UserName = user.FullName;

                var main = Program.ServiceProvider.GetRequiredService<Main>();

                main.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                #region DEBUG
                //Debug.WriteLine($"INNER EXCEPTION: {innerEx.Message}");
                //Debug.WriteLine($"INNER CAUSE: {innerEx.InnerException?.Message}");
                //Debug.WriteLine($"DEEP CAUSE: {innerEx.InnerException?.InnerException?.Message}");
                //MessageBox.Show(innerEx.InnerException?.Message ?? innerEx.Message, "Debug");
                #endregion
                Logger.Log(ex, "Login Click");
                MessageBox.Show(localizer.Get("LoginServerError"));
            }
            finally
            {
                loadingForm.Hide();
                buttonLogin.Enabled = true;
            }
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotForm = Program.ServiceProvider.GetRequiredService<ForgotPasswordForm>();
            forgotForm.Show();
            this.Hide();
        }

        private readonly Localizer localizer =
            new Localizer(
        "TakeTicket.Shared.Localization.Forms.UserLocal.LoginUserFormLocalization");

        private void ApplyLocalization()
        {
            buttonLogin.Text =
                localizer.Get("LoginButton");

            labelUserName.Text =
                localizer.Get("UserNameLabel");

            labelPassword.Text =
                localizer.Get("PasswordLabel");

            linkLabelForgotPassword.Text =
                localizer.Get("ForgotPasswordLink");

            labelTitle.Text =
                localizer.Get("TitleLabel");

            labelSubtitle.Text =
                localizer.Get("SubLabel");
        }
        #endregion

        #region RTL Mehtods
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
                new Point(1, -1);

            labelUserName.Location =
                new Point(304, 229);

            labelPassword.Location =
                new Point(309, 300);

            pictureBoxUserName.Location = new Point(4, 9);
            pictureBoxUserName.Size = new Size(25, 25);

            pictureBoxPassword.Location =
                new Point(5, 7);

            textBoxUserName.Location = new Point(35, 12);

            textBoxPassword.Location =
                new Point(31, 11);

            textBoxUserName.TextAlign =
                HorizontalAlignment.Left;

            textBoxPassword.TextAlign =
                HorizontalAlignment.Left;

            linkLabelForgotPassword.Location =
                new Point(166, 397);

            pictureBoxLoginIcon.Location =
                new Point(140, 435);
        }

        private void ApplyEnglishLayout()
        {
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            textBoxUserName.TextAlign = HorizontalAlignment.Left;
            textBoxPassword.TextAlign = HorizontalAlignment.Left;

            labelUserName.AutoSize = true;
            labelPassword.AutoSize = true;

            buttonCloseWindow.Location = new Point(395, 1);
            labelUserName.Location = new Point(44, 228);
            labelPassword.Location = new Point(45, 299);
            pictureBoxUserName.Location = new Point(4, 9);
            pictureBoxPassword.Location = new Point(5, 7);
            textBoxUserName.Location = new Point(35, 12);
            textBoxPassword.Location = new Point(31, 11);
            linkLabelForgotPassword.Location = new Point(153, 394);
            pictureBoxLoginIcon.Location = new Point(151, 435);
        }

        private void ApplyRussianLayout()
        {
            ApplyEnglishLayout();

            labelUserName.AutoSize = false;
            labelUserName.Size = new Size(160, 20);

            labelPassword.AutoSize = false;
            labelPassword.Size = new Size(120, 20);

            pictureBoxLoginIcon.Location = new Point(151, 435);
        }
        #endregion
    }
}
