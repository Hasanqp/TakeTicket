namespace TakeTicket.Infrastructure.Helper
{
    public class PageManager
    {
        private readonly Main main;
        public PageManager(Main main)
        {
            this.main = main;
        }

        public void LoadPage(UserControl PageUserControl)
        {
            // Load old page
            var OldPage = main.panelContainer.Controls.OfType<UserControl>().FirstOrDefault();
            if (OldPage != null)
            {
                main.panelContainer.Controls.Remove(OldPage);  // Remove Old Page
                OldPage.Dispose();
            }

            //Load New Page
            PageUserControl.Dock = DockStyle.Fill;
            main.panelContainer.Controls.Add(PageUserControl);
        }
    }
}
