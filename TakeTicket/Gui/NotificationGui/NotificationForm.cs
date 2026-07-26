namespace TakeTicket.Gui.NotificationGui
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();

            timerNotification.Interval = Properties.Settings.Default.HideNotificationInterval * 1000;

            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;

            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10
            );
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerNotification_Tick(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var workingArea = Screen.PrimaryScreen.WorkingArea;

            this.Location = new Point(
                workingArea.Right - this.Width - 10,
                workingArea.Bottom - this.Height - 10
            );

            timerNotification.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Opacity = 0;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            timer.Tick += (s, ev) =>
            {
                if (this.IsDisposed)
                {
                    timer.Stop();
                    return;
                }

                if (this.Opacity < 1)
                    this.Opacity += 0.1;
                else
                    timer.Stop();
            };
            timer.Start();
        }
    }
}
