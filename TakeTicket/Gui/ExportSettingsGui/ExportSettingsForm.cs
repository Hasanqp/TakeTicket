using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.ExportSettingsGui
{
    public partial class ExportSettingsForm : Form
    {
        public ExportSettingsForm()
        {
            InitializeComponent();


        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Methdos
        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.ExportSettingsLocal.ExportSettingsFormLocalization");

        private void ApplyLocalization()
        {
            // TODO: Apply localization to all controls
        }
        #endregion
    }
}
