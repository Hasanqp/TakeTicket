using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Data.SqlServer;
using TakeTicket.Gui.SettingsGui;
using TakeTicket.Gui.UsersGui;
using TakeTicket.Shared.Localization;

namespace TakeTicket
{
    public partial class StartForm : Form
    {
        private readonly IDataHelper<Users> dataHelper;
        private readonly DBContext dbContext;
        private bool firstStart = false;

        public StartForm(IDataHelper<Users> dataHelper, DBContext dbContext)
        {
            InitializeComponent();

            ApplyLocalization();

            this.dataHelper = dataHelper;
            this.dbContext = dbContext;
            Debug.WriteLine("StartForm Created");
        }
        #region Evints
        private async void StartForm_Load(object sender, EventArgs e)
        {
            await CheckCon();
        }
        #endregion
        #region Methods
        private async Task CheckCon()
        {
            labelState.Text = localizer.Get("LabelState_Connecting");

            if (!await dbContext.Database.CanConnectAsync())
            {
                HandleConnectionError();
                return;
            }

            labelState.Text = localizer.Get("LabelState_Loading");

            var data = await dataHelper.GetAllDataAsync();

            if (data.Count > 0)
            {
                var loginForm = Program.ServiceProvider.GetRequiredService<LoginUserForm>();
                loginForm.Show();
                Hide();
            }
            else
            {
                var addUserForm = Program.ServiceProvider.GetRequiredService<AddUserForm>();
                addUserForm.SetData(0, true);

                Hide();
                addUserForm.ShowDialog();
                Close();
            }
        }

        private void HandleConnectionError()
        {
            Hide();

            var result = MessageBox.Show(
                localizer.Get("DatabaseConnectionErrorMessage"),
                localizer.Get("DatabaseConnectionErrorTitle"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var settingsForm = Program.ServiceProvider.GetRequiredService<SettingsForm>();
                settingsForm.SetFirstStart(false);
                settingsForm.Show();
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        
        private readonly Localizer localizer =
            new Localizer(
        "TakeTicket.Shared.Localization.Forms.StartForm.StartFormLocalization");

        private void ApplyLocalization()
        {
            this.Text =
                localizer.Get("FormTitle");

            label1.Text =
                localizer.Get("LabelCopyright");

            labelState.Text =
                localizer.Get("LabelState_Initial");
        }
        #endregion
    }
}
