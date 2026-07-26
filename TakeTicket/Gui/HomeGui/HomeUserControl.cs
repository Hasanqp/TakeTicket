using Microsoft.Extensions.DependencyInjection;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Services;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Gui.BusEnrollmentGui;
using TakeTicket.Gui.PassengerEnrollmentGui;
using TakeTicket.Gui.UsersGui;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.HomeGui
{
    public partial class HomeUserControl : UserControl
    {
        private static HomeUserControl _HomeUserControl;
        private readonly CustomerService customerService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDataHelper<Buses> busDataHelper;
        private readonly IDataHelper<Customers> customerDataHelper;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;

        public HomeUserControl(CustomerService customerService, ICurrentUserService currentUserService,
            IDataHelper<Customers> customerDataHelper,
            IDataHelper<SystemRecords> dataHelperSystemRecords,
            IDataHelper<Buses> busesDataHelper)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            _currentUserService = currentUserService;
            this.customerDataHelper = customerDataHelper;
            this.dataHelperSystemRecords = dataHelperSystemRecords;
            this.customerService = customerService;

            SetRoles();
            SetGeneralSettings();
            SetHello();
        }

        #region Evints
        private void buttonAddBus_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<AddBusForm>();

            form.SetData(0);

            if (form.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }

        private void buttonAddPassenger_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<AddPassengerForm>();

            form.SetData(0);

            if (form.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<AddUserForm>();

            form.SetData(0, false);

            if (form.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }

        private async void HomeUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                ApplyLayout();
                await customerService.CheckUpcomingTripsAsync();
            }
            catch (Exception ex)
            {
                MessageCollections.ShowException(ex, "Check Upcoming Trips");
            }
        }
        #endregion
        #region Methods
        private void SetRoles()
        {
            if (!UsersRolesManager.GetRole("checkBoxAccessBus"))
            {
                buttonQuickAddBus.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxAccessPassenger"))
            {
                buttonQuickAddPassenger.Visible = false;
            }
            if (!UsersRolesManager.GetRole("checkBoxAccessUser"))
            {
                buttonQuickAddUser.Visible = false;
            }
            // it is well be Update with new version
        }

        private void SetGeneralSettings()
        {
            labelCompanyName.Text = Properties.Settings.Default.CompanyName;

            // Set Picture

            if (Properties.Settings.Default.CompanyLogo != string.Empty) // Check if first open
            {
                var ImageAsByte = Convert.FromBase64String(Properties.Settings.Default.CompanyLogo); // Convert string to byte

                using (MemoryStream ma = new MemoryStream(ImageAsByte))
                {
                    pictureBoxCompanyLogo.Image = Image.FromStream(ma); // Set picture
                }
            }
        }

        private void SetHello()
        {
            labelWellcome.Text = $"{localizer.Get("LabelWelcome")} {Properties.Settings.Default.UserName}";
        }

        private readonly Localizer localizer = new Localizer(
            "TakeTicket.Shared.Localization.Forms.HomeLocal.HomeUserControlLocalization");

        private void ApplyLocalization()
        {
            groupBoxgrpQuickAccess.Text =
                localizer.Get("GroupBoxQuickAdding");

            buttonQuickAddUser.Text =
                localizer.Get("ButtonAddUser");

            buttonQuickAddBus.Text =
                localizer.Get("ButtonAddBus");

            buttonQuickAddPassenger.Text =
                localizer.Get("ButtonAddPassenger");

            labelQuickAccessTitle.Text =
                localizer.Get("LabelQuickAdding");

            labelWellcome.Text =
                localizer.Get("LabelWelcome");

            labelCompanyName.Text =
                localizer.Get("LabelCompanyName");
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

        private void ApplyEnglishLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new Size(1048, 500);
            BackColor = Color.White;
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            RightToLeft = RightToLeft.No;

            // Quick Access Panel
            panelQuickAccess.Size = new Size(1048, 177);
            panelQuickAccess.Dock = DockStyle.Bottom;
            panelQuickAccess.BackColor = Color.FromArgb(26, 86, 160);

            // Quick Access Title
            labelQuickAccessTitle.Text = "Quick Access";
            labelQuickAccessTitle.Location = new Point(534, 12);
            labelQuickAccessTitle.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelQuickAccessTitle.AutoSize = true;

            // Quick Access GroupBox
            groupBoxgrpQuickAccess.Text = "Add";
            groupBoxgrpQuickAccess.Size = new Size(460, 106);
            groupBoxgrpQuickAccess.Location = new Point(294, 43);
            groupBoxgrpQuickAccess.Anchor = AnchorStyles.None;

            // Add User Button
            buttonQuickAddUser.Text = "User";
            buttonQuickAddUser.Size = new Size(102, 55);
            buttonQuickAddUser.Location = new Point(41, 33);
            buttonQuickAddUser.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddUser.TextAlign = ContentAlignment.MiddleCenter;

            // Add Passenger Button
            buttonQuickAddPassenger.Text = "Passenger";
            buttonQuickAddPassenger.Size = new Size(140, 55);
            buttonQuickAddPassenger.Location = new Point(166, 33);
            buttonQuickAddPassenger.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddPassenger.TextAlign = ContentAlignment.MiddleCenter;

            // Add Bus Button
            buttonQuickAddBus.Text = "Bus";
            buttonQuickAddBus.Size = new Size(91, 55);
            buttonQuickAddBus.Location = new Point(329, 33);
            buttonQuickAddBus.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddBus.TextAlign = ContentAlignment.MiddleCenter;

            // Welcome Label
            labelWellcome.Text = "Welcome again";
            labelWellcome.Size = new Size(308, 114);
            labelWellcome.Location = new Point(25, 32);
            labelWellcome.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelWellcome.TextAlign = ContentAlignment.MiddleCenter;

            // Company Info Panel
            panelCompanyInfo.Size = new Size(455, 114);
            panelCompanyInfo.Location = new Point(726, 16);
            panelCompanyInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Company Name Label
            labelCompanyName.Text = "Enter a company name";
            labelCompanyName.Size = new Size(333, 114);
            labelCompanyName.Dock = DockStyle.Right;
            labelCompanyName.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelCompanyName.TextAlign = ContentAlignment.MiddleCenter;

            // Company Logo
            pictureBoxCompanyLogo.Size = new Size(116, 114);
            pictureBoxCompanyLogo.Dock = DockStyle.Right;
            pictureBoxCompanyLogo.SizeMode = PictureBoxSizeMode.Zoom;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyArabicLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new Size(1048, 500);
            RightToLeft = RightToLeft.Yes;
            BackColor = Color.White;
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Quick Access Panel
            panelQuickAccess.Size = new Size(1048, 177);
            panelQuickAccess.Dock = DockStyle.Bottom;
            panelQuickAccess.BackColor = Color.FromArgb(26, 86, 160);

            // Quick Access Title
            labelQuickAccessTitle.Text = "الوصول السريع";
            labelQuickAccessTitle.Location = new Point(630, 12);
            labelQuickAccessTitle.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelQuickAccessTitle.AutoSize = true;

            // Quick Access GroupBox
            groupBoxgrpQuickAccess.Text = "إضافة";
            groupBoxgrpQuickAccess.Size = new Size(468, 106);
            groupBoxgrpQuickAccess.Location = new Point(334, 43);
            groupBoxgrpQuickAccess.Anchor = AnchorStyles.None;

            // Add User Button (Arabic)
            buttonQuickAddUser.Text = "مستخدم";
            buttonQuickAddUser.Size = new Size(102, 55);
            buttonQuickAddUser.Location = new Point(317, 30);
            buttonQuickAddUser.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickAddUser.TextAlign = ContentAlignment.MiddleRight;

            // Add Passenger Button (Arabic)
            buttonQuickAddPassenger.Text = "راكب";
            buttonQuickAddPassenger.Size = new Size(102, 55);
            buttonQuickAddPassenger.Location = new Point(178, 30);
            buttonQuickAddPassenger.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickAddPassenger.TextAlign = ContentAlignment.MiddleRight;

            // Add Bus Button (Arabic)
            buttonQuickAddBus.Text = "باص";
            buttonQuickAddBus.Size = new Size(102, 55);
            buttonQuickAddBus.Location = new Point(39, 30);
            buttonQuickAddBus.ImageAlign = ContentAlignment.MiddleRight;
            buttonQuickAddBus.TextAlign = ContentAlignment.MiddleRight;

            // Welcome Label
            labelWellcome.Text = "مرحباً بك مرة أخرى";
            labelWellcome.Size = new Size(356, 114);
            labelWellcome.Location = new Point(25, 32);
            labelWellcome.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelWellcome.TextAlign = ContentAlignment.MiddleCenter;

            // Company Info Panel
            panelCompanyInfo.Size = new Size(455, 114);
            panelCompanyInfo.Location = new Point(590, 32);
            panelCompanyInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Company Name Label
            labelCompanyName.Text = "أدخل اسم المؤسسة";
            labelCompanyName.Size = new Size(333, 114);
            labelCompanyName.Dock = DockStyle.Right;
            labelCompanyName.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelCompanyName.TextAlign = ContentAlignment.MiddleCenter;

            // Company Logo
            pictureBoxCompanyLogo.Size = new Size(116, 114);
            pictureBoxCompanyLogo.Dock = DockStyle.Right;
            pictureBoxCompanyLogo.SizeMode = PictureBoxSizeMode.Zoom;

            ResumeLayout();
            PerformLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // UserControl
            Size = new Size(1048, 500);
            RightToLeft = RightToLeft.No;
            BackColor = Color.White;
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);

            // Quick Access Panel
            panelQuickAccess.Size = new Size(1048, 177);
            panelQuickAccess.Dock = DockStyle.Bottom;
            panelQuickAccess.BackColor = Color.FromArgb(26, 86, 160);

            // Quick Access Title
            labelQuickAccessTitle.Text = "Быстрый доступ";
            labelQuickAccessTitle.Location = new Point(534, 12);
            labelQuickAccessTitle.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelQuickAccessTitle.AutoSize = true;

            // Quick Access GroupBox
            groupBoxgrpQuickAccess.Text = "Добавить";
            groupBoxgrpQuickAccess.Size = new Size(631, 106);
            groupBoxgrpQuickAccess.Location = new Point(209, 43);
            groupBoxgrpQuickAccess.Anchor = AnchorStyles.None;

            // Add User Button (Russian)
            buttonQuickAddUser.Text = "Пользователь";
            buttonQuickAddUser.Size = new Size(206, 55);
            buttonQuickAddUser.Location = new Point(39, 33);
            buttonQuickAddUser.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddUser.TextAlign = ContentAlignment.MiddleCenter;
            buttonQuickAddUser.Padding = new Padding(10, 0, 0, 0);

            // Add Passenger Button (Russian)
            buttonQuickAddPassenger.Text = "Пассажир";
            buttonQuickAddPassenger.Size = new Size(165, 55);
            buttonQuickAddPassenger.Location = new Point(255, 33);
            buttonQuickAddPassenger.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddPassenger.TextAlign = ContentAlignment.MiddleCenter;
            buttonQuickAddPassenger.Padding = new Padding(10, 0, 0, 0);

            // Add Bus Button (Russian)
            buttonQuickAddBus.Text = "Автобус";
            buttonQuickAddBus.Size = new Size(167, 55);
            buttonQuickAddBus.Location = new Point(436, 33);
            buttonQuickAddBus.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddBus.TextAlign = ContentAlignment.MiddleCenter;
            buttonQuickAddBus.Padding = new Padding(10, 0, 0, 0);

            // Welcome Label
            labelWellcome.Text = "С возвращением";
            labelWellcome.Size = new Size(338, 114);
            labelWellcome.Location = new Point(25, 32);
            labelWellcome.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelWellcome.TextAlign = ContentAlignment.MiddleCenter;

            // Company Info Panel
            panelCompanyInfo.Size = new Size(455, 114);
            panelCompanyInfo.Location = new Point(726, 16);
            panelCompanyInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Company Name Label
            labelCompanyName.Text = "Введите название компании";
            labelCompanyName.Size = new Size(333, 114);
            labelCompanyName.Dock = DockStyle.Right;
            labelCompanyName.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelCompanyName.TextAlign = ContentAlignment.MiddleCenter;

            // Company Logo
            pictureBoxCompanyLogo.Size = new Size(116, 114);
            pictureBoxCompanyLogo.Dock = DockStyle.Right;
            pictureBoxCompanyLogo.SizeMode = PictureBoxSizeMode.Zoom;

            ResumeLayout();
            PerformLayout();
        }
        #endregion
    }
}
