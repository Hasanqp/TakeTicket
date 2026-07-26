namespace TakeTicket
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonHome = new Button();
            buttonBusEnrollment = new Button();
            buttonCustomers = new Button();
            buttonUsers = new Button();
            buttonLogout = new Button();
            buttonSettings = new Button();
            buttonSystemRecords = new Button();
            buttonAbout = new Button();
            toolTip1 = new ToolTip(components);
            panelContainer = new Panel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(buttonHome);
            flowLayoutPanel1.Controls.Add(buttonBusEnrollment);
            flowLayoutPanel1.Controls.Add(buttonCustomers);
            flowLayoutPanel1.Controls.Add(buttonUsers);
            flowLayoutPanel1.Controls.Add(buttonLogout);
            flowLayoutPanel1.Controls.Add(buttonSettings);
            flowLayoutPanel1.Controls.Add(buttonSystemRecords);
            flowLayoutPanel1.Controls.Add(buttonAbout);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold);
            flowLayoutPanel1.Location = new Point(0, 610);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1264, 71);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonHome
            // 
            buttonHome.BackColor = Color.White;
            buttonHome.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonHome.FlatAppearance.BorderSize = 2;
            buttonHome.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonHome.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonHome.FlatStyle = FlatStyle.Flat;
            buttonHome.Image = Properties.Resources.icons8_home_32px;
            buttonHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHome.Location = new Point(10, 10);
            buttonHome.Margin = new Padding(5);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(120, 51);
            buttonHome.TabIndex = 0;
            buttonHome.Text = "Home";
            buttonHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonHome, "Home Page");
            buttonHome.UseVisualStyleBackColor = false;
            buttonHome.Click += buttonHome_Click;
            // 
            // buttonBusEnrollment
            // 
            buttonBusEnrollment.BackColor = Color.White;
            buttonBusEnrollment.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonBusEnrollment.FlatAppearance.BorderSize = 2;
            buttonBusEnrollment.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonBusEnrollment.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonBusEnrollment.FlatStyle = FlatStyle.Flat;
            buttonBusEnrollment.Image = Properties.Resources.bus;
            buttonBusEnrollment.ImageAlign = ContentAlignment.MiddleLeft;
            buttonBusEnrollment.Location = new Point(140, 10);
            buttonBusEnrollment.Margin = new Padding(5);
            buttonBusEnrollment.Name = "buttonBusEnrollment";
            buttonBusEnrollment.Size = new Size(120, 51);
            buttonBusEnrollment.TabIndex = 1;
            buttonBusEnrollment.Text = "Buses";
            buttonBusEnrollment.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonBusEnrollment, "Bus Registration");
            buttonBusEnrollment.UseVisualStyleBackColor = false;
            buttonBusEnrollment.Click += buttonBusEnrollment_Click;
            // 
            // buttonCustomers
            // 
            buttonCustomers.BackColor = Color.White;
            buttonCustomers.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonCustomers.FlatAppearance.BorderSize = 2;
            buttonCustomers.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonCustomers.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonCustomers.FlatStyle = FlatStyle.Flat;
            buttonCustomers.Image = Properties.Resources.ticket1;
            buttonCustomers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCustomers.Location = new Point(270, 10);
            buttonCustomers.Margin = new Padding(5);
            buttonCustomers.Name = "buttonCustomers";
            buttonCustomers.Size = new Size(156, 51);
            buttonCustomers.TabIndex = 3;
            buttonCustomers.Text = "Passengers";
            buttonCustomers.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonCustomers, "Passenger Registration");
            buttonCustomers.UseVisualStyleBackColor = false;
            buttonCustomers.Click += buttonCustomers_Click;
            // 
            // buttonUsers
            // 
            buttonUsers.BackColor = Color.White;
            buttonUsers.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonUsers.FlatAppearance.BorderSize = 2;
            buttonUsers.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonUsers.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonUsers.FlatStyle = FlatStyle.Flat;
            buttonUsers.Image = Properties.Resources.icons8_conference_foreground_selected_32px;
            buttonUsers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonUsers.Location = new Point(436, 10);
            buttonUsers.Margin = new Padding(5);
            buttonUsers.Name = "buttonUsers";
            buttonUsers.Size = new Size(107, 51);
            buttonUsers.TabIndex = 2;
            buttonUsers.Text = "Users";
            buttonUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonUsers, "User Management");
            buttonUsers.UseVisualStyleBackColor = false;
            buttonUsers.Click += buttonUsers_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.White;
            buttonLogout.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonLogout.FlatAppearance.BorderSize = 2;
            buttonLogout.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonLogout.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Image = Properties.Resources.icons8_log_out_32;
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogout.Location = new Point(553, 10);
            buttonLogout.Margin = new Padding(5);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(121, 51);
            buttonLogout.TabIndex = 4;
            buttonLogout.Text = "Logout";
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonLogout, "Sign Out");
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.BackColor = Color.White;
            buttonSettings.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonSettings.FlatAppearance.BorderSize = 2;
            buttonSettings.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonSettings.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonSettings.FlatStyle = FlatStyle.Flat;
            buttonSettings.Image = Properties.Resources.icons8_settings_32px;
            buttonSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSettings.Location = new Point(684, 10);
            buttonSettings.Margin = new Padding(5);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(127, 51);
            buttonSettings.TabIndex = 5;
            buttonSettings.Text = "Settings";
            buttonSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonSettings, "Settings Page");
            buttonSettings.UseVisualStyleBackColor = false;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonSystemRecords
            // 
            buttonSystemRecords.BackColor = Color.White;
            buttonSystemRecords.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonSystemRecords.FlatAppearance.BorderSize = 2;
            buttonSystemRecords.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonSystemRecords.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonSystemRecords.FlatStyle = FlatStyle.Flat;
            buttonSystemRecords.Image = Properties.Resources.icons8_moleskine_32px;
            buttonSystemRecords.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSystemRecords.Location = new Point(821, 10);
            buttonSystemRecords.Margin = new Padding(5);
            buttonSystemRecords.Name = "buttonSystemRecords";
            buttonSystemRecords.Size = new Size(158, 51);
            buttonSystemRecords.TabIndex = 7;
            buttonSystemRecords.Text = "Activity Log";
            buttonSystemRecords.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonSystemRecords, "System Log");
            buttonSystemRecords.UseVisualStyleBackColor = false;
            buttonSystemRecords.Click += buttonSystemRecords_Click;
            // 
            // buttonAbout
            // 
            buttonAbout.BackColor = Color.White;
            buttonAbout.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonAbout.FlatAppearance.BorderSize = 2;
            buttonAbout.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonAbout.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonAbout.FlatStyle = FlatStyle.Flat;
            buttonAbout.Image = Properties.Resources.icons8_about_32px;
            buttonAbout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAbout.Location = new Point(989, 10);
            buttonAbout.Margin = new Padding(5);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new Size(117, 51);
            buttonAbout.TabIndex = 8;
            buttonAbout.Text = "About";
            buttonAbout.TextImageRelation = TextImageRelation.ImageBeforeText;
            toolTip1.SetToolTip(buttonAbout, "About Program");
            buttonAbout.UseVisualStyleBackColor = false;
            buttonAbout.Click += buttonAbout_Click;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.White;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(1264, 610);
            panelContainer.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelContainer);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Arial Narrow", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TakeTicket";
            WindowState = FormWindowState.Maximized;
            FormClosed += Main_FormClosed;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonSystemRecords;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonBusEnrollment;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonLogout;
        public System.Windows.Forms.Panel panelContainer;
        private Label label1;
    }
}
