namespace TakeTicket.Gui.UsersGui
{
    partial class RestPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestPasswordForm));
            panelTitleBar = new Panel();
            buttonCloseWindow = new Button();
            panelBottomButtons = new Panel();
            pictureBoxResetIcon = new PictureBox();
            buttonReset = new Button();
            panelMainContainer = new Panel();
            pictureBoxAccountIcon = new PictureBox();
            labelRequiredConfirmPassword = new Label();
            labelRequiredNewPassword = new Label();
            labelRequiredUserName = new Label();
            labelConfirmPassword = new Label();
            labelAccountInformation = new Label();
            labelUserName = new Label();
            panelConfirmPassword = new Panel();
            textBoxConfirmPassword = new TextBox();
            labelNewPassword = new Label();
            panelNewPassword = new Panel();
            textBoxNewPassword = new TextBox();
            panelUserName = new Panel();
            textBoxUserName = new TextBox();
            panelIconContainer = new Panel();
            pictureBoxIcon = new PictureBox();
            pictureBoxTelegramIcon = new PictureBox();
            pictureBoxGithubIcon = new PictureBox();
            pictureBoxWhatsappIcon = new PictureBox();
            pictureBoxEmailIcon = new PictureBox();
            labelSubtitle = new Label();
            labelTitle = new Label();
            panelTitleBar.SuspendLayout();
            panelBottomButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResetIcon).BeginInit();
            panelMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAccountIcon).BeginInit();
            panelConfirmPassword.SuspendLayout();
            panelNewPassword.SuspendLayout();
            panelUserName.SuspendLayout();
            panelIconContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTelegramIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGithubIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWhatsappIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmailIcon).BeginInit();
            SuspendLayout();
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(26, 86, 160);
            panelTitleBar.Controls.Add(buttonCloseWindow);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(460, 27);
            panelTitleBar.TabIndex = 0;
            // 
            // buttonCloseWindow
            // 
            buttonCloseWindow.BackColor = Color.Transparent;
            buttonCloseWindow.FlatAppearance.BorderSize = 0;
            buttonCloseWindow.FlatStyle = FlatStyle.Flat;
            buttonCloseWindow.ForeColor = Color.White;
            buttonCloseWindow.Location = new Point(435, 4);
            buttonCloseWindow.Name = "buttonCloseWindow";
            buttonCloseWindow.Size = new Size(22, 23);
            buttonCloseWindow.TabIndex = 44;
            buttonCloseWindow.Text = "X";
            buttonCloseWindow.UseVisualStyleBackColor = false;
            buttonCloseWindow.Click += buttonClose_Click;
            // 
            // panelBottomButtons
            // 
            panelBottomButtons.Controls.Add(pictureBoxResetIcon);
            panelBottomButtons.Controls.Add(buttonReset);
            panelBottomButtons.Dock = DockStyle.Bottom;
            panelBottomButtons.Location = new Point(0, 452);
            panelBottomButtons.Name = "panelBottomButtons";
            panelBottomButtons.Size = new Size(460, 48);
            panelBottomButtons.TabIndex = 1;
            // 
            // pictureBoxResetIcon
            // 
            pictureBoxResetIcon.BackColor = Color.FromArgb(83, 74, 183);
            pictureBoxResetIcon.Image = (Image)resources.GetObject("pictureBoxResetIcon.Image");
            pictureBoxResetIcon.Location = new Point(173, 13);
            pictureBoxResetIcon.Name = "pictureBoxResetIcon";
            pictureBoxResetIcon.Size = new Size(21, 25);
            pictureBoxResetIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxResetIcon.TabIndex = 39;
            pictureBoxResetIcon.TabStop = false;
            // 
            // buttonReset
            // 
            buttonReset.BackColor = Color.FromArgb(83, 74, 183);
            buttonReset.BackgroundImageLayout = ImageLayout.Stretch;
            buttonReset.FlatAppearance.BorderColor = Color.Gray;
            buttonReset.FlatAppearance.BorderSize = 2;
            buttonReset.FlatAppearance.MouseDownBackColor = Color.Gray;
            buttonReset.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonReset.FlatStyle = FlatStyle.Flat;
            buttonReset.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonReset.ForeColor = Color.White;
            buttonReset.ImageAlign = ContentAlignment.MiddleLeft;
            buttonReset.Location = new Point(157, 5);
            buttonReset.Margin = new Padding(5);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(148, 38);
            buttonReset.TabIndex = 43;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = false;
            buttonReset.Click += buttonRest_Click;
            // 
            // panelMainContainer
            // 
            panelMainContainer.Controls.Add(pictureBoxAccountIcon);
            panelMainContainer.Controls.Add(labelRequiredConfirmPassword);
            panelMainContainer.Controls.Add(labelRequiredNewPassword);
            panelMainContainer.Controls.Add(labelRequiredUserName);
            panelMainContainer.Controls.Add(labelConfirmPassword);
            panelMainContainer.Controls.Add(labelAccountInformation);
            panelMainContainer.Controls.Add(labelUserName);
            panelMainContainer.Controls.Add(panelConfirmPassword);
            panelMainContainer.Controls.Add(labelNewPassword);
            panelMainContainer.Controls.Add(panelNewPassword);
            panelMainContainer.Controls.Add(panelUserName);
            panelMainContainer.Controls.Add(panelIconContainer);
            panelMainContainer.Controls.Add(pictureBoxTelegramIcon);
            panelMainContainer.Controls.Add(pictureBoxGithubIcon);
            panelMainContainer.Controls.Add(pictureBoxWhatsappIcon);
            panelMainContainer.Controls.Add(pictureBoxEmailIcon);
            panelMainContainer.Controls.Add(labelSubtitle);
            panelMainContainer.Controls.Add(labelTitle);
            panelMainContainer.Dock = DockStyle.Fill;
            panelMainContainer.Location = new Point(0, 27);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new Size(460, 425);
            panelMainContainer.TabIndex = 2;
            // 
            // pictureBoxAccountIcon
            // 
            pictureBoxAccountIcon.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxAccountIcon.Image = (Image)resources.GetObject("pictureBoxAccountIcon.Image");
            pictureBoxAccountIcon.Location = new Point(46, 110);
            pictureBoxAccountIcon.Name = "pictureBoxAccountIcon";
            pictureBoxAccountIcon.Size = new Size(22, 22);
            pictureBoxAccountIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAccountIcon.TabIndex = 40;
            pictureBoxAccountIcon.TabStop = false;
            // 
            // labelRequiredConfirmPassword
            // 
            labelRequiredConfirmPassword.AutoSize = true;
            labelRequiredConfirmPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredConfirmPassword.ForeColor = Color.Red;
            labelRequiredConfirmPassword.Location = new Point(173, 280);
            labelRequiredConfirmPassword.Name = "labelRequiredConfirmPassword";
            labelRequiredConfirmPassword.Size = new Size(14, 17);
            labelRequiredConfirmPassword.TabIndex = 54;
            labelRequiredConfirmPassword.Text = "*";
            // 
            // labelRequiredNewPassword
            // 
            labelRequiredNewPassword.AutoSize = true;
            labelRequiredNewPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredNewPassword.ForeColor = Color.Red;
            labelRequiredNewPassword.Location = new Point(151, 211);
            labelRequiredNewPassword.Name = "labelRequiredNewPassword";
            labelRequiredNewPassword.Size = new Size(14, 17);
            labelRequiredNewPassword.TabIndex = 53;
            labelRequiredNewPassword.Text = "*";
            // 
            // labelRequiredUserName
            // 
            labelRequiredUserName.AutoSize = true;
            labelRequiredUserName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredUserName.ForeColor = Color.Red;
            labelRequiredUserName.Location = new Point(120, 146);
            labelRequiredUserName.Name = "labelRequiredUserName";
            labelRequiredUserName.Size = new Size(14, 17);
            labelRequiredUserName.TabIndex = 55;
            labelRequiredUserName.Text = "*";
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelConfirmPassword.ForeColor = Color.Black;
            labelConfirmPassword.Location = new Point(47, 280);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(130, 17);
            labelConfirmPassword.TabIndex = 58;
            labelConfirmPassword.Text = "Confirm Password";
            // 
            // labelAccountInformation
            // 
            labelAccountInformation.AutoSize = true;
            labelAccountInformation.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelAccountInformation.ForeColor = Color.FromArgb(83, 74, 183);
            labelAccountInformation.Location = new Point(74, 110);
            labelAccountInformation.Name = "labelAccountInformation";
            labelAccountInformation.Size = new Size(136, 20);
            labelAccountInformation.TabIndex = 56;
            labelAccountInformation.Text = "Account Information";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelUserName.ForeColor = Color.Black;
            labelUserName.Location = new Point(46, 146);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(76, 17);
            labelUserName.TabIndex = 57;
            labelUserName.Text = "Username";
            // 
            // panelConfirmPassword
            // 
            panelConfirmPassword.BackColor = Color.FromArgb(235, 244, 255);
            panelConfirmPassword.Controls.Add(textBoxConfirmPassword);
            panelConfirmPassword.Location = new Point(46, 300);
            panelConfirmPassword.Name = "panelConfirmPassword";
            panelConfirmPassword.Size = new Size(395, 32);
            panelConfirmPassword.TabIndex = 52;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.BackColor = Color.FromArgb(235, 244, 255);
            textBoxConfirmPassword.BorderStyle = BorderStyle.None;
            textBoxConfirmPassword.Location = new Point(1, 7);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '*';
            textBoxConfirmPassword.Size = new Size(392, 19);
            textBoxConfirmPassword.TabIndex = 1;
            // 
            // labelNewPassword
            // 
            labelNewPassword.AutoSize = true;
            labelNewPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelNewPassword.ForeColor = Color.Black;
            labelNewPassword.Location = new Point(47, 211);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(107, 17);
            labelNewPassword.TabIndex = 59;
            labelNewPassword.Text = "New Password";
            // 
            // panelNewPassword
            // 
            panelNewPassword.BackColor = Color.FromArgb(235, 244, 255);
            panelNewPassword.Controls.Add(textBoxNewPassword);
            panelNewPassword.Location = new Point(46, 231);
            panelNewPassword.Name = "panelNewPassword";
            panelNewPassword.Size = new Size(395, 32);
            panelNewPassword.TabIndex = 51;
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.BackColor = Color.FromArgb(235, 244, 255);
            textBoxNewPassword.BorderStyle = BorderStyle.None;
            textBoxNewPassword.ForeColor = SystemColors.WindowText;
            textBoxNewPassword.Location = new Point(1, 7);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPassword.Size = new Size(392, 19);
            textBoxNewPassword.TabIndex = 2;
            // 
            // panelUserName
            // 
            panelUserName.BackColor = Color.FromArgb(235, 244, 255);
            panelUserName.Controls.Add(textBoxUserName);
            panelUserName.Location = new Point(44, 166);
            panelUserName.Name = "panelUserName";
            panelUserName.Size = new Size(395, 32);
            panelUserName.TabIndex = 50;
            // 
            // textBoxUserName
            // 
            textBoxUserName.BackColor = Color.FromArgb(235, 244, 255);
            textBoxUserName.BorderStyle = BorderStyle.None;
            textBoxUserName.Location = new Point(3, 7);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(390, 19);
            textBoxUserName.TabIndex = 0;
            // 
            // panelIconContainer
            // 
            panelIconContainer.BackColor = Color.Transparent;
            panelIconContainer.BackgroundImage = Properties.Resources.mega_creator;
            panelIconContainer.BackgroundImageLayout = ImageLayout.Zoom;
            panelIconContainer.Controls.Add(pictureBoxIcon);
            panelIconContainer.ForeColor = Color.FromArgb(230, 241, 251);
            panelIconContainer.Location = new Point(21, 34);
            panelIconContainer.Name = "panelIconContainer";
            panelIconContainer.Size = new Size(51, 48);
            panelIconContainer.TabIndex = 49;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxIcon.Image = (Image)resources.GetObject("pictureBoxIcon.Image");
            pictureBoxIcon.Location = new Point(13, 12);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(25, 25);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // pictureBoxTelegramIcon
            // 
            pictureBoxTelegramIcon.Image = (Image)resources.GetObject("pictureBoxTelegramIcon.Image");
            pictureBoxTelegramIcon.Location = new Point(155, 375);
            pictureBoxTelegramIcon.Name = "pictureBoxTelegramIcon";
            pictureBoxTelegramIcon.Size = new Size(30, 30);
            pictureBoxTelegramIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxTelegramIcon.TabIndex = 45;
            pictureBoxTelegramIcon.TabStop = false;
            // 
            // pictureBoxGithubIcon
            // 
            pictureBoxGithubIcon.Image = (Image)resources.GetObject("pictureBoxGithubIcon.Image");
            pictureBoxGithubIcon.Location = new Point(197, 375);
            pictureBoxGithubIcon.Name = "pictureBoxGithubIcon";
            pictureBoxGithubIcon.Size = new Size(30, 30);
            pictureBoxGithubIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxGithubIcon.TabIndex = 46;
            pictureBoxGithubIcon.TabStop = false;
            // 
            // pictureBoxWhatsappIcon
            // 
            pictureBoxWhatsappIcon.Image = (Image)resources.GetObject("pictureBoxWhatsappIcon.Image");
            pictureBoxWhatsappIcon.Location = new Point(240, 375);
            pictureBoxWhatsappIcon.Name = "pictureBoxWhatsappIcon";
            pictureBoxWhatsappIcon.Size = new Size(30, 30);
            pictureBoxWhatsappIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxWhatsappIcon.TabIndex = 47;
            pictureBoxWhatsappIcon.TabStop = false;
            // 
            // pictureBoxEmailIcon
            // 
            pictureBoxEmailIcon.Image = (Image)resources.GetObject("pictureBoxEmailIcon.Image");
            pictureBoxEmailIcon.Location = new Point(282, 375);
            pictureBoxEmailIcon.Name = "pictureBoxEmailIcon";
            pictureBoxEmailIcon.Size = new Size(30, 30);
            pictureBoxEmailIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEmailIcon.TabIndex = 48;
            pictureBoxEmailIcon.TabStop = false;
            // 
            // labelSubtitle
            // 
            labelSubtitle.Font = new Font("Arial", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSubtitle.ForeColor = Color.Black;
            labelSubtitle.Location = new Point(78, 58);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(295, 25);
            labelSubtitle.TabIndex = 42;
            labelSubtitle.Text = "Please fill in all fields to regain access";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(78, 34);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(186, 27);
            labelTitle.TabIndex = 41;
            labelTitle.Text = "Reset Password";
            // 
            // RestPasswordForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(460, 500);
            Controls.Add(panelMainContainer);
            Controls.Add(panelBottomButtons);
            Controls.Add(panelTitleBar);
            Font = new Font("Arial", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RestPasswordForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "إستعادة الحساب";
            Load += RestPasswordForm_Load;
            panelTitleBar.ResumeLayout(false);
            panelBottomButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxResetIcon).EndInit();
            panelMainContainer.ResumeLayout(false);
            panelMainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAccountIcon).EndInit();
            panelConfirmPassword.ResumeLayout(false);
            panelConfirmPassword.PerformLayout();
            panelNewPassword.ResumeLayout(false);
            panelNewPassword.PerformLayout();
            panelUserName.ResumeLayout(false);
            panelUserName.PerformLayout();
            panelIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTelegramIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGithubIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWhatsappIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEmailIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTitleBar;
        private Button buttonCloseWindow;
        private Panel panelBottomButtons;
        private PictureBox pictureBoxResetIcon;
        private Button buttonReset;
        private Panel panelMainContainer;
        private PictureBox pictureBoxAccountIcon;
        private Label labelRequiredConfirmPassword;
        private Label labelRequiredNewPassword;
        private Label labelRequiredUserName;
        private Label labelConfirmPassword;
        private Label labelAccountInformation;
        private Label labelUserName;
        private Panel panelConfirmPassword;
        private TextBox textBoxConfirmPassword;
        private Label labelNewPassword;
        private Panel panelNewPassword;
        private TextBox textBoxNewPassword;
        private Panel panelUserName;
        private TextBox textBoxUserName;
        private Panel panelIconContainer;
        private PictureBox pictureBoxIcon;
        private PictureBox pictureBoxTelegramIcon;
        private PictureBox pictureBoxGithubIcon;
        private PictureBox pictureBoxWhatsappIcon;
        private PictureBox pictureBoxEmailIcon;
        private Label labelSubtitle;
        private Label labelTitle;
    }
}