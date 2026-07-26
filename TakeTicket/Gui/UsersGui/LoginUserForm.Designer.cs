namespace TakeTicket.Gui.UsersGui
{
    partial class LoginUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUserForm));
            panelMainContainer = new Panel();
            pictureBoxLoginIcon = new PictureBox();
            panelIconContainer = new Panel();
            pictureBoxIcon = new PictureBox();
            labelSubtitle = new Label();
            labelTitle = new Label();
            labelUserName = new Label();
            labelPassword = new Label();
            linkLabelForgotPassword = new LinkLabel();
            panelPassword = new Panel();
            pictureBoxPassword = new PictureBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            panelUserName = new Panel();
            pictureBoxUserName = new PictureBox();
            textBoxUserName = new TextBox();
            buttonCloseWindow = new Button();
            panelTitleBar = new Panel();
            panelMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoginIcon).BeginInit();
            panelIconContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPassword).BeginInit();
            panelUserName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserName).BeginInit();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainContainer
            // 
            panelMainContainer.BackColor = Color.White;
            panelMainContainer.Controls.Add(pictureBoxLoginIcon);
            panelMainContainer.Controls.Add(panelIconContainer);
            panelMainContainer.Controls.Add(labelSubtitle);
            panelMainContainer.Controls.Add(labelTitle);
            panelMainContainer.Controls.Add(labelUserName);
            panelMainContainer.Controls.Add(labelPassword);
            panelMainContainer.Controls.Add(linkLabelForgotPassword);
            panelMainContainer.Controls.Add(panelPassword);
            panelMainContainer.Controls.Add(buttonLogin);
            panelMainContainer.Controls.Add(panelUserName);
            panelMainContainer.Dock = DockStyle.Fill;
            panelMainContainer.Location = new Point(0, 25);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new Size(420, 495);
            panelMainContainer.TabIndex = 31;
            // 
            // pictureBoxLoginIcon
            // 
            pictureBoxLoginIcon.BackColor = Color.FromArgb(26, 86, 160);
            pictureBoxLoginIcon.Image = (Image)resources.GetObject("pictureBoxLoginIcon.Image");
            pictureBoxLoginIcon.Location = new Point(153, 436);
            pictureBoxLoginIcon.Name = "pictureBoxLoginIcon";
            pictureBoxLoginIcon.Size = new Size(21, 25);
            pictureBoxLoginIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLoginIcon.TabIndex = 0;
            pictureBoxLoginIcon.TabStop = false;
            // 
            // panelIconContainer
            // 
            panelIconContainer.BackColor = Color.Transparent;
            panelIconContainer.BackgroundImage = Properties.Resources.mega_creator;
            panelIconContainer.BackgroundImageLayout = ImageLayout.Zoom;
            panelIconContainer.Controls.Add(pictureBoxIcon);
            panelIconContainer.ForeColor = Color.FromArgb(230, 241, 251);
            panelIconContainer.Location = new Point(178, 38);
            panelIconContainer.Name = "panelIconContainer";
            panelIconContainer.Size = new Size(64, 64);
            panelIconContainer.TabIndex = 10;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxIcon.Image = Properties.Resources.icons8_bus_48;
            pictureBoxIcon.Location = new Point(15, 16);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(35, 33);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // labelSubtitle
            // 
            labelSubtitle.Font = new Font("Arial", 9.5F);
            labelSubtitle.ForeColor = Color.FromArgb(130, 140, 160);
            labelSubtitle.Location = new Point(35, 150);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(350, 22);
            labelSubtitle.TabIndex = 2;
            labelSubtitle.Text = "Please log in to continue";
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Arial", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.FromArgb(20, 30, 60);
            labelTitle.Location = new Point(37, 114);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(347, 36);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Welcome back";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelUserName.ForeColor = Color.FromArgb(61, 61, 58);
            labelUserName.Location = new Point(44, 228);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(76, 17);
            labelUserName.TabIndex = 3;
            labelUserName.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPassword.ForeColor = Color.FromArgb(61, 61, 58);
            labelPassword.Location = new Point(45, 299);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(74, 17);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            // 
            // linkLabelForgotPassword
            // 
            linkLabelForgotPassword.AutoSize = true;
            linkLabelForgotPassword.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkLabelForgotPassword.LinkColor = Color.FromArgb(26, 86, 160);
            linkLabelForgotPassword.Location = new Point(153, 394);
            linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            linkLabelForgotPassword.Size = new Size(112, 16);
            linkLabelForgotPassword.TabIndex = 3;
            linkLabelForgotPassword.TabStop = true;
            linkLabelForgotPassword.Text = "Forgot Password?";
            linkLabelForgotPassword.LinkClicked += linkLabelForgotPassword_LinkClicked;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.FromArgb(235, 244, 255);
            panelPassword.Controls.Add(pictureBoxPassword);
            panelPassword.Controls.Add(textBoxPassword);
            panelPassword.Location = new Point(44, 319);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(333, 40);
            panelPassword.TabIndex = 1;
            // 
            // pictureBoxPassword
            // 
            pictureBoxPassword.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxPassword.Image = (Image)resources.GetObject("pictureBoxPassword.Image");
            pictureBoxPassword.Location = new Point(5, 7);
            pictureBoxPassword.Name = "pictureBoxPassword";
            pictureBoxPassword.Size = new Size(25, 25);
            pictureBoxPassword.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPassword.TabIndex = 0;
            pictureBoxPassword.TabStop = false;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(235, 244, 255);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Arial", 11F);
            textBoxPassword.Location = new Point(31, 11);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(300, 17);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.Text = "●●●●●●";
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(26, 86, 160);
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(15, 55, 110);
            buttonLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 66, 130);
            buttonLogin.Font = new Font("Arial", 12.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.ImageAlign = ContentAlignment.MiddleRight;
            buttonLogin.Location = new Point(79, 425);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(260, 46);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // panelUserName
            // 
            panelUserName.BackColor = Color.FromArgb(235, 244, 255);
            panelUserName.Controls.Add(pictureBoxUserName);
            panelUserName.Controls.Add(textBoxUserName);
            panelUserName.Location = new Point(44, 248);
            panelUserName.Name = "panelUserName";
            panelUserName.Size = new Size(333, 40);
            panelUserName.TabIndex = 0;
            // 
            // pictureBoxUserName
            // 
            pictureBoxUserName.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxUserName.Image = (Image)resources.GetObject("pictureBoxUserName.Image");
            pictureBoxUserName.Location = new Point(4, 9);
            pictureBoxUserName.Name = "pictureBoxUserName";
            pictureBoxUserName.Size = new Size(25, 25);
            pictureBoxUserName.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserName.TabIndex = 0;
            pictureBoxUserName.TabStop = false;
            // 
            // textBoxUserName
            // 
            textBoxUserName.BackColor = Color.FromArgb(235, 244, 255);
            textBoxUserName.BorderStyle = BorderStyle.None;
            textBoxUserName.Font = new Font("Arial", 11F);
            textBoxUserName.Location = new Point(35, 12);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(296, 17);
            textBoxUserName.TabIndex = 4;
            // 
            // buttonCloseWindow
            // 
            buttonCloseWindow.BackColor = Color.Transparent;
            buttonCloseWindow.FlatAppearance.BorderSize = 0;
            buttonCloseWindow.FlatStyle = FlatStyle.Flat;
            buttonCloseWindow.ForeColor = Color.White;
            buttonCloseWindow.Location = new Point(395, 1);
            buttonCloseWindow.Name = "buttonCloseWindow";
            buttonCloseWindow.Size = new Size(22, 23);
            buttonCloseWindow.TabIndex = 11;
            buttonCloseWindow.Text = "X";
            buttonCloseWindow.UseVisualStyleBackColor = false;
            buttonCloseWindow.Click += buttonClose_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(26, 86, 160);
            panelTitleBar.Controls.Add(buttonCloseWindow);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(420, 25);
            panelTitleBar.TabIndex = 30;
            // 
            // LoginUserForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(420, 520);
            Controls.Add(panelMainContainer);
            Controls.Add(panelTitleBar);
            Font = new Font("Arial", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginUserForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تسجيل دخول";
            FormClosed += LoginUserForm_FormClosed;
            Load += LoginUserForm_Load;
            panelMainContainer.ResumeLayout(false);
            panelMainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLoginIcon).EndInit();
            panelIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPassword).EndInit();
            panelUserName.ResumeLayout(false);
            panelUserName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserName).EndInit();
            panelTitleBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.PictureBox pictureBoxLoginIcon;
        private System.Windows.Forms.Panel panelIconContainer;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.LinkLabel linkLabelForgotPassword;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.PictureBox pictureBoxPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelUserName;
        private System.Windows.Forms.PictureBox pictureBoxUserName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button buttonCloseWindow;
        private Label label5;
    }
}