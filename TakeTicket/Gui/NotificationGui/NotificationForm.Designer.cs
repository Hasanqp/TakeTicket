namespace TakeTicket.Gui.NotificationGui
{
    partial class NotificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            labelTitle = new Label();
            pictureBoxNotifaction = new PictureBox();
            timerNotification = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxNotifaction).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.BackColor = Color.SteelBlue;
            labelTitle.Font = new Font("Arial", 14.25F);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(75, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(256, 77);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Here you write data info";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelTitle.Click += labelTitle_Click;
            // 
            // pictureBoxNotifaction
            // 
            pictureBoxNotifaction.BackColor = Color.Transparent;
            pictureBoxNotifaction.Dock = DockStyle.Left;
            pictureBoxNotifaction.Image = Properties.Resources.notification_bell__1_;
            pictureBoxNotifaction.Location = new Point(0, 0);
            pictureBoxNotifaction.Name = "pictureBoxNotifaction";
            pictureBoxNotifaction.Size = new Size(78, 77);
            pictureBoxNotifaction.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxNotifaction.TabIndex = 1;
            pictureBoxNotifaction.TabStop = false;
            // 
            // timerNotification
            // 
            timerNotification.Enabled = true;
            timerNotification.Interval = 2000;
            timerNotification.Tick += timerNotification_Tick;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(331, 77);
            Controls.Add(pictureBoxNotifaction);
            Controls.Add(labelTitle);
            Font = new Font("Arial", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NotificationForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBoxNotifaction).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxNotifaction;
        public System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Timer timerNotification;
    }
}