namespace TakeTicket.Gui.HomeGui
{
    partial class HomeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelQuickAccess = new Panel();
            labelQuickAccessTitle = new Label();
            groupBoxgrpQuickAccess = new GroupBox();
            buttonQuickAddUser = new Button();
            buttonQuickAddBus = new Button();
            buttonQuickAddPassenger = new Button();
            labelWellcome = new Label();
            panelCompanyInfo = new Panel();
            labelCompanyName = new Label();
            pictureBoxCompanyLogo = new PictureBox();
            panelQuickAccess.SuspendLayout();
            groupBoxgrpQuickAccess.SuspendLayout();
            panelCompanyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompanyLogo).BeginInit();
            SuspendLayout();
            // 
            // panelQuickAccess
            // 
            panelQuickAccess.BackColor = Color.FromArgb(26, 86, 160);
            panelQuickAccess.Controls.Add(labelQuickAccessTitle);
            panelQuickAccess.Controls.Add(groupBoxgrpQuickAccess);
            panelQuickAccess.Dock = DockStyle.Bottom;
            panelQuickAccess.Location = new Point(0, 323);
            panelQuickAccess.Name = "panelQuickAccess";
            panelQuickAccess.Size = new Size(1048, 177);
            panelQuickAccess.TabIndex = 0;
            // 
            // labelQuickAccessTitle
            // 
            labelQuickAccessTitle.AutoSize = true;
            labelQuickAccessTitle.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelQuickAccessTitle.Location = new Point(426, 12);
            labelQuickAccessTitle.Name = "labelQuickAccessTitle";
            labelQuickAccessTitle.Size = new Size(196, 33);
            labelQuickAccessTitle.TabIndex = 2;
            labelQuickAccessTitle.Text = "Quick Access";
            // 
            // groupBoxgrpQuickAccess
            // 
            groupBoxgrpQuickAccess.Anchor = AnchorStyles.None;
            groupBoxgrpQuickAccess.Controls.Add(buttonQuickAddUser);
            groupBoxgrpQuickAccess.Controls.Add(buttonQuickAddBus);
            groupBoxgrpQuickAccess.Controls.Add(buttonQuickAddPassenger);
            groupBoxgrpQuickAccess.Location = new Point(294, 43);
            groupBoxgrpQuickAccess.Name = "groupBoxgrpQuickAccess";
            groupBoxgrpQuickAccess.Size = new Size(460, 106);
            groupBoxgrpQuickAccess.TabIndex = 1;
            groupBoxgrpQuickAccess.TabStop = false;
            groupBoxgrpQuickAccess.Text = "Add";
            // 
            // buttonQuickAddUser
            // 
            buttonQuickAddUser.BackColor = Color.White;
            buttonQuickAddUser.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonQuickAddUser.FlatAppearance.BorderSize = 2;
            buttonQuickAddUser.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonQuickAddUser.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonQuickAddUser.FlatStyle = FlatStyle.Flat;
            buttonQuickAddUser.Image = Properties.Resources.icons8_conference_foreground_selected_32px;
            buttonQuickAddUser.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddUser.Location = new Point(41, 33);
            buttonQuickAddUser.Margin = new Padding(5);
            buttonQuickAddUser.Name = "buttonQuickAddUser";
            buttonQuickAddUser.Size = new Size(102, 55);
            buttonQuickAddUser.TabIndex = 5;
            buttonQuickAddUser.Text = "User";
            buttonQuickAddUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonQuickAddUser.UseVisualStyleBackColor = false;
            buttonQuickAddUser.Click += buttonUsers_Click;
            // 
            // buttonQuickAddBus
            // 
            buttonQuickAddBus.BackColor = Color.White;
            buttonQuickAddBus.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonQuickAddBus.FlatAppearance.BorderSize = 2;
            buttonQuickAddBus.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonQuickAddBus.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonQuickAddBus.FlatStyle = FlatStyle.Flat;
            buttonQuickAddBus.Image = Properties.Resources.bus;
            buttonQuickAddBus.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddBus.Location = new Point(329, 33);
            buttonQuickAddBus.Margin = new Padding(5);
            buttonQuickAddBus.Name = "buttonQuickAddBus";
            buttonQuickAddBus.Size = new Size(91, 55);
            buttonQuickAddBus.TabIndex = 6;
            buttonQuickAddBus.Text = "Bus";
            buttonQuickAddBus.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonQuickAddBus.UseVisualStyleBackColor = false;
            buttonQuickAddBus.Click += buttonAddBus_Click;
            // 
            // buttonQuickAddPassenger
            // 
            buttonQuickAddPassenger.BackColor = Color.White;
            buttonQuickAddPassenger.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonQuickAddPassenger.FlatAppearance.BorderSize = 2;
            buttonQuickAddPassenger.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonQuickAddPassenger.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonQuickAddPassenger.FlatStyle = FlatStyle.Flat;
            buttonQuickAddPassenger.Image = Properties.Resources.passenger_quick;
            buttonQuickAddPassenger.ImageAlign = ContentAlignment.MiddleLeft;
            buttonQuickAddPassenger.Location = new Point(166, 33);
            buttonQuickAddPassenger.Margin = new Padding(5);
            buttonQuickAddPassenger.Name = "buttonQuickAddPassenger";
            buttonQuickAddPassenger.Size = new Size(140, 55);
            buttonQuickAddPassenger.TabIndex = 7;
            buttonQuickAddPassenger.Text = "Passenger";
            buttonQuickAddPassenger.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonQuickAddPassenger.UseVisualStyleBackColor = false;
            buttonQuickAddPassenger.Click += buttonAddPassenger_Click;
            // 
            // labelWellcome
            // 
            labelWellcome.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelWellcome.Location = new Point(25, 32);
            labelWellcome.Name = "labelWellcome";
            labelWellcome.Size = new Size(308, 114);
            labelWellcome.TabIndex = 3;
            labelWellcome.Text = "Wellcome again";
            labelWellcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCompanyInfo
            // 
            panelCompanyInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelCompanyInfo.Controls.Add(labelCompanyName);
            panelCompanyInfo.Controls.Add(pictureBoxCompanyLogo);
            panelCompanyInfo.Location = new Point(590, 32);
            panelCompanyInfo.Name = "panelCompanyInfo";
            panelCompanyInfo.Size = new Size(455, 114);
            panelCompanyInfo.TabIndex = 4;
            // 
            // labelCompanyName
            // 
            labelCompanyName.Dock = DockStyle.Right;
            labelCompanyName.Font = new Font("Arial Black", 18F, FontStyle.Bold);
            labelCompanyName.Location = new Point(6, 0);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(333, 114);
            labelCompanyName.TabIndex = 4;
            labelCompanyName.Text = "Enter a company name";
            labelCompanyName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxCompanyLogo
            // 
            pictureBoxCompanyLogo.Dock = DockStyle.Right;
            pictureBoxCompanyLogo.Image = Properties.Resources.photo;
            pictureBoxCompanyLogo.Location = new Point(339, 0);
            pictureBoxCompanyLogo.Name = "pictureBoxCompanyLogo";
            pictureBoxCompanyLogo.Size = new Size(116, 114);
            pictureBoxCompanyLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCompanyLogo.TabIndex = 0;
            pictureBoxCompanyLogo.TabStop = false;
            // 
            // HomeUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelCompanyInfo);
            Controls.Add(labelWellcome);
            Controls.Add(panelQuickAccess);
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            Margin = new Padding(4, 5, 4, 5);
            Name = "HomeUserControl";
            Size = new Size(1048, 500);
            Load += HomeUserControl_Load;
            panelQuickAccess.ResumeLayout(false);
            panelQuickAccess.PerformLayout();
            groupBoxgrpQuickAccess.ResumeLayout(false);
            panelCompanyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCompanyLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelQuickAccess;
        private System.Windows.Forms.GroupBox groupBoxgrpQuickAccess;
        private System.Windows.Forms.Button buttonQuickAddUser;
        private System.Windows.Forms.Button buttonQuickAddBus;
        private System.Windows.Forms.Button buttonQuickAddPassenger;
        private System.Windows.Forms.Label labelQuickAccessTitle;
        private System.Windows.Forms.Label labelWellcome;
        private System.Windows.Forms.Panel panelCompanyInfo;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.PictureBox pictureBoxCompanyLogo;
    }
}
