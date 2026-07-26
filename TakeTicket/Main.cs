using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Gui.BusEnrollmentGui;
using TakeTicket.Gui.HomeGui;
using TakeTicket.Gui.PassengerEnrollmentGui;
using TakeTicket.Gui.SettingsGui;
using TakeTicket.Gui.SystemRecordsGui;
using TakeTicket.Gui.UsersGui;
using TakeTicket.Shared.Localization;

namespace TakeTicket
{
    public partial class Main : Form
    {
        private readonly PageManager pageManager;
        private readonly ICurrentUserService _currentUserService;

        public Main(ICurrentUserService currentUserService)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();
            _currentUserService = currentUserService;

            pageManager = new PageManager(this);
            SetRoles();

            // Load Home Page
            pageManager.LoadPage(Program.ServiceProvider.GetRequiredService<HomeUserControl>());
            Debug.WriteLine("Main Created");
        }

        #region Evints
        private void buttonHome_Click(object sender, EventArgs e)
        {
            // Load Home Page
            pageManager.LoadPage(Program.ServiceProvider.GetRequiredService<HomeUserControl>());
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            // Load Users Page 
            pageManager.LoadPage(Program.ServiceProvider.GetRequiredService<UsersUserControl>());
        }

        private void buttonBusEnrollment_Click(object sender, EventArgs e)
        {
            // Load Buses Page
            pageManager.LoadPage(Program.ServiceProvider.GetRequiredService<BusUserControl>());

        }

        private void buttonSystemRecords_Click(object sender, EventArgs e)
        {
            // Load SystemRecords Page
            pageManager.LoadPage(Program.ServiceProvider.GetRequiredService<SystemRecordsUserControl>());
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = Program.ServiceProvider.GetRequiredService<SettingsForm>();
            settingsForm.Show();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            Gui.AboutGui.About aboutForm = new Gui.AboutGui.About();
            aboutForm.Show();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            // Load customers Page
            var control = Program.ServiceProvider.GetRequiredService<PssengerUserControl>();
            pageManager.LoadPage(control);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var loginForm = Program.ServiceProvider.GetRequiredService<LoginUserForm>();
            loginForm.Show();
            Hide();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        #endregion
        #region Methods
        /*private void SetRoles()
        {
            if (!UsersRolesManager.GetRole("checkBoxHome"))
            {
                buttonHome.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxBuses"))
            {
                buttonBusEnrollment.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxCustomers"))
            {
                buttonCustomers.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxUsers"))
            {
                buttonUsers.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxSettings"))
            {
                buttonSettings.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxSystemRecords"))
            {
                buttonSystemRecords.Visible = false;
            }
            // it is well be Update with new version
        }*/

        private void SetRoles()
        {
            Debug.WriteLine("===== ROLES =====");
            Debug.WriteLine(UsersRolesManager.GetRole("checkBoxTabHome"));
            Debug.WriteLine(UsersRolesManager.GetRole("checkBoxTabBuses"));
            Debug.WriteLine(UsersRolesManager.GetRole("checkBoxTabPassenger"));
            Debug.WriteLine(UsersRolesManager.GetRole("checkBoxTabUsers"));
            Debug.WriteLine(UsersRolesManager.GetRole("checkBoxTabSettings"));
            Debug.WriteLine(UsersRolesManager.GetRole("checkBoxTabSystemRecords"));

            if (!UsersRolesManager.GetRole("checkBoxTabHome"))
            {
                buttonHome.Visible = false;
            }

            if (!UsersRolesManager.GetRole("checkBoxTabBuses"))
            {
                buttonBusEnrollment.Visible = false;
            }

            if (!UsersRolesManager.GetRole("checkBoxTabPassenger"))
            {
                buttonCustomers.Visible = false;
            }

            if (!UsersRolesManager.GetRole("checkBoxTabUsers"))
            {
                buttonUsers.Visible = false;
            }

            if (!UsersRolesManager.GetRole("checkBoxTabSettings"))
            {
                buttonSettings.Visible = false;
            }

            if (!UsersRolesManager.GetRole("checkBoxTabSystemRecords"))
            {
                buttonSystemRecords.Visible = false;
            }
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.MainLocal.MainLocalization");

        private void ApplyLocalization()
        {
            buttonHome.Text =
                localizer.Get("ButtonHomeText");

            toolTip1.SetToolTip(
                buttonHome,
                localizer.Get("ButtonHomeToolTip"));

            buttonUsers.Text =
                localizer.Get("ButtonUsersText");

            toolTip1.SetToolTip(
                buttonUsers,
                localizer.Get("ButtonUsersToolTip"));

            buttonCustomers.Text =
                localizer.Get("ButtonPassengersText");

            toolTip1.SetToolTip(
                buttonCustomers,
                localizer.Get("ButtonPassengersToolTip"));

            buttonSystemRecords.Text =
                localizer.Get("ButtonRecordsText");

            toolTip1.SetToolTip(
                buttonSystemRecords,
                localizer.Get("ButtonRecordsToolTip"));

            buttonSettings.Text =
                localizer.Get("ButtonSettingsText");

            toolTip1.SetToolTip(
                buttonSettings,
                localizer.Get("ButtonSettingsToolTip"));

            buttonAbout.Text =
                localizer.Get("ButtonAboutText");

            toolTip1.SetToolTip(
                buttonAbout,
                localizer.Get("ButtonAboutToolTip"));

            buttonBusEnrollment.Text =
                localizer.Get("ButtonBusesText");

            toolTip1.SetToolTip(
                buttonBusEnrollment,
                localizer.Get("ButtonBusesToolTip"));

            buttonLogout.Text =
                localizer.Get("ButtonLogoutText");

            toolTip1.SetToolTip(
                buttonLogout,
                localizer.Get("ButtonLogoutToolTip"));

            this.Text =
                localizer.Get("FormTitle");
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

            // Form
            Size = new System.Drawing.Size(1280, 720);
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 15.75F, FontStyle.Bold);

            // flowLayoutPanel
            flowLayoutPanel1.Size = new System.Drawing.Size(1264, 71);

            // Buttons
            // Home Button
            buttonHome.Text = "Home";
            buttonHome.Size = new System.Drawing.Size(120, 51);
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;

            // Buses Button
            buttonBusEnrollment.Text = "Buses";
            buttonBusEnrollment.Size = new System.Drawing.Size(120, 51);
            buttonBusEnrollment.ImageAlign = ContentAlignment.MiddleLeft;

            // Passengers Button
            buttonCustomers.Text = "Passengers";
            buttonCustomers.Size = new System.Drawing.Size(156, 51);
            buttonCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomers.TextAlign = ContentAlignment.MiddleRight;

            // Users Button
            buttonUsers.Text = "Users";
            buttonUsers.Size = new System.Drawing.Size(107, 51);
            buttonUsers.ImageAlign = ContentAlignment.MiddleLeft;

            // Logout Button
            buttonLogout.Text = "Logout";
            buttonLogout.Size = new System.Drawing.Size(121, 51);
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;

            // Settings Button
            buttonSettings.Text = "Settings";
            buttonSettings.Size = new System.Drawing.Size(127, 51);
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;

            // Activity Log Button
            buttonSystemRecords.Text = "Activity Log";
            buttonSystemRecords.Size = new System.Drawing.Size(158, 51);
            buttonSystemRecords.ImageAlign = ContentAlignment.MiddleLeft;

            // About Button
            buttonAbout.Text = "About";
            buttonAbout.Size = new System.Drawing.Size(117, 51);
            buttonAbout.ImageAlign = ContentAlignment.MiddleLeft;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyArabicLayout()
        {
            SuspendLayout();

            // Form
            Size = new System.Drawing.Size(1280, 720);
            RightToLeft = RightToLeft.Yes;
            BackColor = System.Drawing.Color.White;
            Font = new System.Drawing.Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // flowLayoutPanel
            flowLayoutPanel1.Size = new System.Drawing.Size(1264, 71);

            // Buttons (Arabic Layout)
            // Home Button
            buttonHome.Text = "الرئيسية";
            buttonHome.Size = new System.Drawing.Size(133, 51);
            buttonHome.ImageAlign = ContentAlignment.MiddleRight;
            buttonHome.TextAlign = ContentAlignment.MiddleLeft;

            // Buses Button
            buttonBusEnrollment.Text = "الباصات";
            buttonBusEnrollment.Size = new System.Drawing.Size(139, 51);
            buttonBusEnrollment.ImageAlign = ContentAlignment.MiddleRight;
            buttonBusEnrollment.TextAlign = ContentAlignment.MiddleLeft;

            // Passengers Button
            buttonCustomers.Text = "الركاب";
            buttonCustomers.Size = new System.Drawing.Size(141, 51);
            buttonCustomers.ImageAlign = ContentAlignment.MiddleRight;
            buttonCustomers.TextAlign = ContentAlignment.MiddleLeft;

            // Users Button
            buttonUsers.Text = "المستخدمون";
            buttonUsers.Size = new System.Drawing.Size(163, 51);
            buttonUsers.ImageAlign = ContentAlignment.MiddleRight;
            buttonUsers.TextAlign = ContentAlignment.MiddleLeft;

            // Logout Button
            buttonLogout.Text = "تسجيل الخروج";
            buttonLogout.Size = new System.Drawing.Size(173, 51);
            buttonLogout.ImageAlign = ContentAlignment.MiddleRight;
            buttonLogout.TextAlign = ContentAlignment.MiddleLeft;

            // Settings Button
            buttonSettings.Text = "الإعدادات";
            buttonSettings.Size = new System.Drawing.Size(136, 51);
            buttonSettings.ImageAlign = ContentAlignment.MiddleRight;
            buttonSettings.TextAlign = ContentAlignment.MiddleLeft;

            // System Records Button
            buttonSystemRecords.Text = "سجل الحركة";
            buttonSystemRecords.Size = new System.Drawing.Size(157, 51);
            buttonSystemRecords.ImageAlign = ContentAlignment.MiddleRight;
            buttonSystemRecords.TextAlign = ContentAlignment.MiddleLeft;

            // About Button
            buttonAbout.Text = "عن البرنامج";
            buttonAbout.Size = new System.Drawing.Size(155, 51);
            buttonAbout.ImageAlign = ContentAlignment.MiddleLeft;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // Form
            RightToLeft = RightToLeft.No;

            // Toolbar
            flowLayoutPanel1.RightToLeft = RightToLeft.No;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            Size = new System.Drawing.Size(1280, 720);

            // Home Button
            buttonHome.Text = "Главная";
            buttonHome.Size = new System.Drawing.Size(133, 51);
            buttonHome.TextAlign = ContentAlignment.MiddleCenter;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;

            // Buses Button
            buttonBusEnrollment.Text = "Автобусы";
            buttonBusEnrollment.Size = new System.Drawing.Size(150, 51);
            buttonBusEnrollment.TextAlign = ContentAlignment.MiddleCenter;
            buttonBusEnrollment.ImageAlign = ContentAlignment.MiddleLeft;

            // Passengers Button
            buttonCustomers.Text = "Пассажиры";
            buttonCustomers.Size = new System.Drawing.Size(163, 51);
            buttonCustomers.TextAlign = ContentAlignment.MiddleCenter;
            buttonCustomers.ImageAlign = ContentAlignment.MiddleLeft;

            // Users Button
            buttonUsers.Text = "Пользователи";
            buttonUsers.Size = new System.Drawing.Size(183, 51);
            buttonUsers.TextAlign = ContentAlignment.MiddleCenter;
            buttonUsers.ImageAlign = ContentAlignment.MiddleLeft;

            // Logout Button
            buttonLogout.Text = "Выход";
            buttonLogout.Size = new System.Drawing.Size(119, 51);
            buttonLogout.TextAlign = ContentAlignment.MiddleCenter;
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;

            // Settings Button
            buttonSettings.Text = "Настройки";
            buttonSettings.Size = new System.Drawing.Size(150, 51);
            buttonSettings.TextAlign = ContentAlignment.MiddleCenter;
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;

            // System Records Button
            buttonSystemRecords.Text = "Журнал действий";
            buttonSystemRecords.Size = new System.Drawing.Size(215, 51);
            buttonSystemRecords.TextAlign = ContentAlignment.MiddleCenter;
            buttonSystemRecords.ImageAlign = ContentAlignment.MiddleLeft;

            // About Program Button
            buttonAbout.Text = "О программе";
            buttonAbout.Size = new System.Drawing.Size(174, 51);
            buttonAbout.TextAlign = ContentAlignment.MiddleCenter;
            buttonAbout.ImageAlign = ContentAlignment.MiddleLeft;

            ResumeLayout();
            PerformLayout();
        }

        #endregion
    }
}
