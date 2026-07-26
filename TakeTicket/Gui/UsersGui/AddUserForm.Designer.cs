namespace TakeTicket.Gui.UsersGui
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            groupBoxUserInformation = new GroupBox();
            labelRequiredPhone = new Label();
            labelRequiredPassword = new Label();
            labelRequiredUserName = new Label();
            labelRequiredFullName = new Label();
            labelPhoneNumber = new Label();
            labelEmailAddress = new Label();
            labelPassword = new Label();
            labelUserName = new Label();
            panelPhoneNumber = new Panel();
            textBoxPhoneNumber = new TextBox();
            labelFullName = new Label();
            panelEmailAddress = new Panel();
            textBoxEmail = new TextBox();
            panelPassword = new Panel();
            textBoxPassword = new TextBox();
            panelUserName = new Panel();
            textBoxUserName = new TextBox();
            panelFullName = new Panel();
            textBoxName = new TextBox();
            buttonSaveAndClose = new Button();
            buttonSave = new Button();
            panelBottomButtons = new Panel();
            groupBoxPermissionsTabs = new GroupBox();
            flowLayoutPanelTabs = new FlowLayoutPanel();
            checkBoxTabHome = new CheckBox();
            checkBoxTabBuses = new CheckBox();
            checkBoxTabPassenger = new CheckBox();
            checkBoxTabUsers = new CheckBox();
            checkBoxTabSettings = new CheckBox();
            checkBoxTabSystemRecords = new CheckBox();
            groupBoxPermissionsQuickAccess = new GroupBox();
            flowLayoutPanelPermissionsQuickAccess = new FlowLayoutPanel();
            checkBoxAccessBus = new CheckBox();
            checkBoxAccessPassenger = new CheckBox();
            checkBoxAccessUser = new CheckBox();
            groupBoxPermissionsOperations = new GroupBox();
            flowLayoutPanelPermissionsOperations = new FlowLayoutPanel();
            checkBoxOperationAdd = new CheckBox();
            checkBoxOperationDelete = new CheckBox();
            checkBoxOperationEdit = new CheckBox();
            checkBoxOperationExport = new CheckBox();
            checkBoxOperationSearch = new CheckBox();
            groupBoxRoles = new GroupBox();
            flowLayoutPanelRoles = new FlowLayoutPanel();
            checkBoxRoleAdmin = new CheckBox();
            checkBoxRoleAdminAssitant = new CheckBox();
            checkBoxRoleDispatcher = new CheckBox();
            checkBoxRoleLineSupervisor = new CheckBox();
            groupBoxRecoveryInformation = new GroupBox();
            panelAnswer = new Panel();
            textBoxAnswer = new TextBox();
            labelRequiredAnswer = new Label();
            panelRecoveryQustion = new Panel();
            comboBoxSecurityQuestion = new ComboBox();
            labelAnswer = new Label();
            labelRequiredRecoveryQuestion = new Label();
            labelRecveryQuestion = new Label();
            labelTitle = new Label();
            labelSubtitle = new Label();
            panelIconContainer = new Panel();
            pictureBoxIcon = new PictureBox();
            panelTitleBar = new Panel();
            buttonCloseWindow = new Button();
            errorProvider = new ErrorProvider(components);
            groupBoxUserInformation.SuspendLayout();
            panelPhoneNumber.SuspendLayout();
            panelEmailAddress.SuspendLayout();
            panelPassword.SuspendLayout();
            panelUserName.SuspendLayout();
            panelFullName.SuspendLayout();
            panelBottomButtons.SuspendLayout();
            groupBoxPermissionsTabs.SuspendLayout();
            flowLayoutPanelTabs.SuspendLayout();
            groupBoxPermissionsQuickAccess.SuspendLayout();
            flowLayoutPanelPermissionsQuickAccess.SuspendLayout();
            groupBoxPermissionsOperations.SuspendLayout();
            flowLayoutPanelPermissionsOperations.SuspendLayout();
            groupBoxRoles.SuspendLayout();
            flowLayoutPanelRoles.SuspendLayout();
            groupBoxRecoveryInformation.SuspendLayout();
            panelAnswer.SuspendLayout();
            panelRecoveryQustion.SuspendLayout();
            panelIconContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // groupBoxUserInformation
            // 
            groupBoxUserInformation.Controls.Add(labelRequiredPhone);
            groupBoxUserInformation.Controls.Add(labelRequiredPassword);
            groupBoxUserInformation.Controls.Add(labelRequiredUserName);
            groupBoxUserInformation.Controls.Add(labelRequiredFullName);
            groupBoxUserInformation.Controls.Add(labelPhoneNumber);
            groupBoxUserInformation.Controls.Add(labelEmailAddress);
            groupBoxUserInformation.Controls.Add(labelPassword);
            groupBoxUserInformation.Controls.Add(labelUserName);
            groupBoxUserInformation.Controls.Add(panelPhoneNumber);
            groupBoxUserInformation.Controls.Add(labelFullName);
            groupBoxUserInformation.Controls.Add(panelEmailAddress);
            groupBoxUserInformation.Controls.Add(panelPassword);
            groupBoxUserInformation.Controls.Add(panelUserName);
            groupBoxUserInformation.Controls.Add(panelFullName);
            groupBoxUserInformation.ForeColor = Color.FromArgb(83, 105, 208);
            groupBoxUserInformation.Location = new Point(3, 102);
            groupBoxUserInformation.Name = "groupBoxUserInformation";
            groupBoxUserInformation.Size = new Size(356, 321);
            groupBoxUserInformation.TabIndex = 0;
            groupBoxUserInformation.TabStop = false;
            groupBoxUserInformation.Text = "👤 User Information";
            // 
            // labelRequiredPhone
            // 
            labelRequiredPhone.AutoSize = true;
            labelRequiredPhone.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredPhone.ForeColor = Color.Red;
            labelRequiredPhone.Location = new Point(111, 259);
            labelRequiredPhone.Name = "labelRequiredPhone";
            labelRequiredPhone.Size = new Size(14, 17);
            labelRequiredPhone.TabIndex = 36;
            labelRequiredPhone.Text = "*";
            // 
            // labelRequiredPassword
            // 
            labelRequiredPassword.AutoSize = true;
            labelRequiredPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredPassword.ForeColor = Color.Red;
            labelRequiredPassword.Location = new Point(81, 143);
            labelRequiredPassword.Name = "labelRequiredPassword";
            labelRequiredPassword.Size = new Size(14, 17);
            labelRequiredPassword.TabIndex = 36;
            labelRequiredPassword.Text = "*";
            // 
            // labelRequiredUserName
            // 
            labelRequiredUserName.AutoSize = true;
            labelRequiredUserName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredUserName.ForeColor = Color.Red;
            labelRequiredUserName.Location = new Point(81, 85);
            labelRequiredUserName.Name = "labelRequiredUserName";
            labelRequiredUserName.Size = new Size(14, 17);
            labelRequiredUserName.TabIndex = 36;
            labelRequiredUserName.Text = "*";
            // 
            // labelRequiredFullName
            // 
            labelRequiredFullName.AutoSize = true;
            labelRequiredFullName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredFullName.ForeColor = Color.Red;
            labelRequiredFullName.Location = new Point(81, 27);
            labelRequiredFullName.Name = "labelRequiredFullName";
            labelRequiredFullName.Size = new Size(14, 17);
            labelRequiredFullName.TabIndex = 36;
            labelRequiredFullName.Text = "*";
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPhoneNumber.ForeColor = Color.Black;
            labelPhoneNumber.Location = new Point(7, 258);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(106, 17);
            labelPhoneNumber.TabIndex = 37;
            labelPhoneNumber.Text = "Phone Number";
            // 
            // labelEmailAddress
            // 
            labelEmailAddress.AutoSize = true;
            labelEmailAddress.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelEmailAddress.ForeColor = Color.Black;
            labelEmailAddress.Location = new Point(7, 200);
            labelEmailAddress.Name = "labelEmailAddress";
            labelEmailAddress.Size = new Size(102, 17);
            labelEmailAddress.TabIndex = 37;
            labelEmailAddress.Text = "Email Address";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPassword.ForeColor = Color.Black;
            labelPassword.Location = new Point(6, 143);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(74, 17);
            labelPassword.TabIndex = 37;
            labelPassword.Text = "Password";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelUserName.ForeColor = Color.Black;
            labelUserName.Location = new Point(6, 81);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(76, 17);
            labelUserName.TabIndex = 37;
            labelUserName.Text = "Username";
            // 
            // panelPhoneNumber
            // 
            panelPhoneNumber.BackColor = Color.FromArgb(235, 244, 255);
            panelPhoneNumber.Controls.Add(textBoxPhoneNumber);
            panelPhoneNumber.Location = new Point(8, 278);
            panelPhoneNumber.Name = "panelPhoneNumber";
            panelPhoneNumber.Size = new Size(339, 32);
            panelPhoneNumber.TabIndex = 33;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.BackColor = Color.FromArgb(235, 244, 255);
            textBoxPhoneNumber.BorderStyle = BorderStyle.None;
            textBoxPhoneNumber.Location = new Point(1, 6);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(337, 19);
            textBoxPhoneNumber.TabIndex = 4;
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelFullName.ForeColor = Color.Black;
            labelFullName.Location = new Point(6, 26);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(74, 17);
            labelFullName.TabIndex = 37;
            labelFullName.Text = "Full Name";
            // 
            // panelEmailAddress
            // 
            panelEmailAddress.BackColor = Color.FromArgb(235, 244, 255);
            panelEmailAddress.Controls.Add(textBoxEmail);
            panelEmailAddress.Location = new Point(8, 220);
            panelEmailAddress.Name = "panelEmailAddress";
            panelEmailAddress.Size = new Size(339, 32);
            panelEmailAddress.TabIndex = 33;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = Color.FromArgb(235, 244, 255);
            textBoxEmail.BorderStyle = BorderStyle.None;
            textBoxEmail.Location = new Point(1, 6);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(337, 19);
            textBoxEmail.TabIndex = 3;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.FromArgb(235, 244, 255);
            panelPassword.Controls.Add(textBoxPassword);
            panelPassword.Location = new Point(6, 162);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(339, 32);
            panelPassword.TabIndex = 33;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BackColor = Color.FromArgb(235, 244, 255);
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Location = new Point(1, 7);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(337, 19);
            textBoxPassword.TabIndex = 2;
            // 
            // panelUserName
            // 
            panelUserName.BackColor = Color.FromArgb(235, 244, 255);
            panelUserName.Controls.Add(textBoxUserName);
            panelUserName.Location = new Point(4, 104);
            panelUserName.Name = "panelUserName";
            panelUserName.Size = new Size(339, 32);
            panelUserName.TabIndex = 33;
            // 
            // textBoxUserName
            // 
            textBoxUserName.BackColor = Color.FromArgb(235, 244, 255);
            textBoxUserName.BorderStyle = BorderStyle.None;
            textBoxUserName.Location = new Point(1, 6);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(337, 19);
            textBoxUserName.TabIndex = 1;
            // 
            // panelFullName
            // 
            panelFullName.BackColor = Color.FromArgb(235, 244, 255);
            panelFullName.Controls.Add(textBoxName);
            panelFullName.Location = new Point(4, 46);
            panelFullName.Name = "panelFullName";
            panelFullName.Size = new Size(339, 32);
            panelFullName.TabIndex = 33;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.FromArgb(235, 244, 255);
            textBoxName.BorderStyle = BorderStyle.None;
            textBoxName.Location = new Point(1, 5);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(337, 19);
            textBoxName.TabIndex = 0;
            // 
            // buttonSaveAndClose
            // 
            buttonSaveAndClose.BackColor = Color.White;
            buttonSaveAndClose.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            buttonSaveAndClose.FlatAppearance.BorderSize = 2;
            buttonSaveAndClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            buttonSaveAndClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            buttonSaveAndClose.FlatStyle = FlatStyle.Flat;
            buttonSaveAndClose.Image = Properties.Resources.icons8_save_32px;
            buttonSaveAndClose.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSaveAndClose.Location = new Point(159, 10);
            buttonSaveAndClose.Margin = new Padding(5);
            buttonSaveAndClose.Name = "buttonSaveAndClose";
            buttonSaveAndClose.Size = new Size(150, 36);
            buttonSaveAndClose.TabIndex = 24;
            buttonSaveAndClose.Text = "      Save and Close        ";
            buttonSaveAndClose.UseVisualStyleBackColor = false;
            buttonSaveAndClose.Click += buttonSaveAndClose_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.White;
            buttonSave.FlatAppearance.BorderColor = Color.Gray;
            buttonSave.FlatAppearance.BorderSize = 2;
            buttonSave.FlatAppearance.MouseDownBackColor = Color.Gray;
            buttonSave.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Image = Properties.Resources.icons8_save_32px_1;
            buttonSave.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSave.Location = new Point(15, 10);
            buttonSave.Margin = new Padding(5);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(134, 36);
            buttonSave.TabIndex = 25;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // panelBottomButtons
            // 
            panelBottomButtons.BackColor = Color.FromArgb(245, 244, 237);
            panelBottomButtons.Controls.Add(buttonSaveAndClose);
            panelBottomButtons.Controls.Add(buttonSave);
            panelBottomButtons.Dock = DockStyle.Bottom;
            panelBottomButtons.Location = new Point(0, 585);
            panelBottomButtons.Name = "panelBottomButtons";
            panelBottomButtons.Size = new Size(655, 53);
            panelBottomButtons.TabIndex = 5;
            // 
            // groupBoxPermissionsTabs
            // 
            groupBoxPermissionsTabs.Controls.Add(flowLayoutPanelTabs);
            groupBoxPermissionsTabs.ForeColor = Color.FromArgb(83, 105, 208);
            groupBoxPermissionsTabs.Location = new Point(361, 102);
            groupBoxPermissionsTabs.Name = "groupBoxPermissionsTabs";
            groupBoxPermissionsTabs.Size = new Size(292, 114);
            groupBoxPermissionsTabs.TabIndex = 6;
            groupBoxPermissionsTabs.TabStop = false;
            groupBoxPermissionsTabs.Text = "📋 Permissions / Tabs";
            // 
            // flowLayoutPanelTabs
            // 
            flowLayoutPanelTabs.Controls.Add(checkBoxTabHome);
            flowLayoutPanelTabs.Controls.Add(checkBoxTabBuses);
            flowLayoutPanelTabs.Controls.Add(checkBoxTabPassenger);
            flowLayoutPanelTabs.Controls.Add(checkBoxTabUsers);
            flowLayoutPanelTabs.Controls.Add(checkBoxTabSettings);
            flowLayoutPanelTabs.Controls.Add(checkBoxTabSystemRecords);
            flowLayoutPanelTabs.Dock = DockStyle.Fill;
            flowLayoutPanelTabs.Location = new Point(3, 22);
            flowLayoutPanelTabs.Name = "flowLayoutPanelTabs";
            flowLayoutPanelTabs.Size = new Size(286, 89);
            flowLayoutPanelTabs.TabIndex = 0;
            // 
            // checkBoxTabHome
            // 
            checkBoxTabHome.AutoSize = true;
            checkBoxTabHome.Checked = true;
            checkBoxTabHome.CheckState = CheckState.Checked;
            checkBoxTabHome.ForeColor = Color.Black;
            checkBoxTabHome.Location = new Point(3, 3);
            checkBoxTabHome.Name = "checkBoxTabHome";
            checkBoxTabHome.Size = new Size(64, 24);
            checkBoxTabHome.TabIndex = 7;
            checkBoxTabHome.Text = "Home";
            checkBoxTabHome.UseVisualStyleBackColor = true;
            // 
            // checkBoxTabBuses
            // 
            checkBoxTabBuses.AutoSize = true;
            checkBoxTabBuses.ForeColor = Color.Black;
            checkBoxTabBuses.Location = new Point(73, 3);
            checkBoxTabBuses.Name = "checkBoxTabBuses";
            checkBoxTabBuses.Size = new Size(66, 24);
            checkBoxTabBuses.TabIndex = 8;
            checkBoxTabBuses.Text = "Buses";
            checkBoxTabBuses.UseVisualStyleBackColor = true;
            // 
            // checkBoxTabPassenger
            // 
            checkBoxTabPassenger.AutoSize = true;
            checkBoxTabPassenger.ForeColor = Color.Black;
            checkBoxTabPassenger.Location = new Point(145, 3);
            checkBoxTabPassenger.Name = "checkBoxTabPassenger";
            checkBoxTabPassenger.Size = new Size(100, 24);
            checkBoxTabPassenger.TabIndex = 9;
            checkBoxTabPassenger.Text = "Passengers";
            checkBoxTabPassenger.UseVisualStyleBackColor = true;
            // 
            // checkBoxTabUsers
            // 
            checkBoxTabUsers.AutoSize = true;
            checkBoxTabUsers.ForeColor = Color.Black;
            checkBoxTabUsers.Location = new Point(3, 33);
            checkBoxTabUsers.Name = "checkBoxTabUsers";
            checkBoxTabUsers.Size = new Size(63, 24);
            checkBoxTabUsers.TabIndex = 10;
            checkBoxTabUsers.Text = "Users";
            checkBoxTabUsers.UseVisualStyleBackColor = true;
            // 
            // checkBoxTabSettings
            // 
            checkBoxTabSettings.AutoSize = true;
            checkBoxTabSettings.ForeColor = Color.Black;
            checkBoxTabSettings.Location = new Point(72, 33);
            checkBoxTabSettings.Name = "checkBoxTabSettings";
            checkBoxTabSettings.Size = new Size(76, 24);
            checkBoxTabSettings.TabIndex = 12;
            checkBoxTabSettings.Text = "Settings";
            checkBoxTabSettings.UseVisualStyleBackColor = true;
            // 
            // checkBoxTabSystemRecords
            // 
            checkBoxTabSystemRecords.AutoSize = true;
            checkBoxTabSystemRecords.ForeColor = Color.Black;
            checkBoxTabSystemRecords.Location = new Point(154, 33);
            checkBoxTabSystemRecords.Name = "checkBoxTabSystemRecords";
            checkBoxTabSystemRecords.Size = new Size(128, 24);
            checkBoxTabSystemRecords.TabIndex = 13;
            checkBoxTabSystemRecords.Text = "System Records";
            checkBoxTabSystemRecords.UseVisualStyleBackColor = true;
            // 
            // groupBoxPermissionsQuickAccess
            // 
            groupBoxPermissionsQuickAccess.Controls.Add(flowLayoutPanelPermissionsQuickAccess);
            groupBoxPermissionsQuickAccess.ForeColor = Color.FromArgb(83, 105, 208);
            groupBoxPermissionsQuickAccess.Location = new Point(361, 238);
            groupBoxPermissionsQuickAccess.Name = "groupBoxPermissionsQuickAccess";
            groupBoxPermissionsQuickAccess.Size = new Size(292, 57);
            groupBoxPermissionsQuickAccess.TabIndex = 6;
            groupBoxPermissionsQuickAccess.TabStop = false;
            groupBoxPermissionsQuickAccess.Text = "🎯 Permissions / Quick Access";
            // 
            // flowLayoutPanelPermissionsQuickAccess
            // 
            flowLayoutPanelPermissionsQuickAccess.Controls.Add(checkBoxAccessBus);
            flowLayoutPanelPermissionsQuickAccess.Controls.Add(checkBoxAccessPassenger);
            flowLayoutPanelPermissionsQuickAccess.Controls.Add(checkBoxAccessUser);
            flowLayoutPanelPermissionsQuickAccess.Dock = DockStyle.Fill;
            flowLayoutPanelPermissionsQuickAccess.Location = new Point(3, 22);
            flowLayoutPanelPermissionsQuickAccess.Name = "flowLayoutPanelPermissionsQuickAccess";
            flowLayoutPanelPermissionsQuickAccess.Size = new Size(286, 32);
            flowLayoutPanelPermissionsQuickAccess.TabIndex = 0;
            // 
            // checkBoxAccessBus
            // 
            checkBoxAccessBus.AutoSize = true;
            checkBoxAccessBus.ForeColor = Color.Black;
            checkBoxAccessBus.Location = new Point(3, 3);
            checkBoxAccessBus.Name = "checkBoxAccessBus";
            checkBoxAccessBus.Size = new Size(51, 24);
            checkBoxAccessBus.TabIndex = 14;
            checkBoxAccessBus.Text = "Bus";
            checkBoxAccessBus.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessPassenger
            // 
            checkBoxAccessPassenger.AutoSize = true;
            checkBoxAccessPassenger.ForeColor = Color.Black;
            checkBoxAccessPassenger.Location = new Point(60, 3);
            checkBoxAccessPassenger.Name = "checkBoxAccessPassenger";
            checkBoxAccessPassenger.Size = new Size(93, 24);
            checkBoxAccessPassenger.TabIndex = 15;
            checkBoxAccessPassenger.Text = "Passenger";
            checkBoxAccessPassenger.UseVisualStyleBackColor = true;
            // 
            // checkBoxAccessUser
            // 
            checkBoxAccessUser.AutoSize = true;
            checkBoxAccessUser.ForeColor = Color.Black;
            checkBoxAccessUser.Location = new Point(159, 3);
            checkBoxAccessUser.Name = "checkBoxAccessUser";
            checkBoxAccessUser.Size = new Size(56, 24);
            checkBoxAccessUser.TabIndex = 15;
            checkBoxAccessUser.Text = "User";
            checkBoxAccessUser.UseVisualStyleBackColor = true;
            // 
            // groupBoxPermissionsOperations
            // 
            groupBoxPermissionsOperations.Controls.Add(flowLayoutPanelPermissionsOperations);
            groupBoxPermissionsOperations.ForeColor = Color.FromArgb(83, 105, 208);
            groupBoxPermissionsOperations.Location = new Point(361, 338);
            groupBoxPermissionsOperations.Name = "groupBoxPermissionsOperations";
            groupBoxPermissionsOperations.Size = new Size(289, 85);
            groupBoxPermissionsOperations.TabIndex = 6;
            groupBoxPermissionsOperations.TabStop = false;
            groupBoxPermissionsOperations.Text = "✨ Permissions / Standard Operations";
            // 
            // flowLayoutPanelPermissionsOperations
            // 
            flowLayoutPanelPermissionsOperations.Controls.Add(checkBoxOperationAdd);
            flowLayoutPanelPermissionsOperations.Controls.Add(checkBoxOperationDelete);
            flowLayoutPanelPermissionsOperations.Controls.Add(checkBoxOperationEdit);
            flowLayoutPanelPermissionsOperations.Controls.Add(checkBoxOperationExport);
            flowLayoutPanelPermissionsOperations.Controls.Add(checkBoxOperationSearch);
            flowLayoutPanelPermissionsOperations.Dock = DockStyle.Fill;
            flowLayoutPanelPermissionsOperations.Location = new Point(3, 22);
            flowLayoutPanelPermissionsOperations.Name = "flowLayoutPanelPermissionsOperations";
            flowLayoutPanelPermissionsOperations.Size = new Size(283, 60);
            flowLayoutPanelPermissionsOperations.TabIndex = 0;
            // 
            // checkBoxOperationAdd
            // 
            checkBoxOperationAdd.AutoSize = true;
            checkBoxOperationAdd.ForeColor = Color.Black;
            checkBoxOperationAdd.Location = new Point(3, 3);
            checkBoxOperationAdd.Name = "checkBoxOperationAdd";
            checkBoxOperationAdd.Size = new Size(53, 24);
            checkBoxOperationAdd.TabIndex = 19;
            checkBoxOperationAdd.Text = "Add";
            checkBoxOperationAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxOperationDelete
            // 
            checkBoxOperationDelete.AutoSize = true;
            checkBoxOperationDelete.ForeColor = Color.Black;
            checkBoxOperationDelete.Location = new Point(62, 3);
            checkBoxOperationDelete.Name = "checkBoxOperationDelete";
            checkBoxOperationDelete.Size = new Size(67, 24);
            checkBoxOperationDelete.TabIndex = 20;
            checkBoxOperationDelete.Text = "Delete";
            checkBoxOperationDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxOperationEdit
            // 
            checkBoxOperationEdit.AutoSize = true;
            checkBoxOperationEdit.ForeColor = Color.Black;
            checkBoxOperationEdit.Location = new Point(135, 3);
            checkBoxOperationEdit.Name = "checkBoxOperationEdit";
            checkBoxOperationEdit.Size = new Size(51, 24);
            checkBoxOperationEdit.TabIndex = 21;
            checkBoxOperationEdit.Text = "Edit";
            checkBoxOperationEdit.UseVisualStyleBackColor = true;
            // 
            // checkBoxOperationExport
            // 
            checkBoxOperationExport.AutoSize = true;
            checkBoxOperationExport.ForeColor = Color.Black;
            checkBoxOperationExport.Location = new Point(192, 3);
            checkBoxOperationExport.Name = "checkBoxOperationExport";
            checkBoxOperationExport.Size = new Size(67, 24);
            checkBoxOperationExport.TabIndex = 22;
            checkBoxOperationExport.Text = "Export";
            checkBoxOperationExport.UseVisualStyleBackColor = true;
            // 
            // checkBoxOperationSearch
            // 
            checkBoxOperationSearch.AutoSize = true;
            checkBoxOperationSearch.ForeColor = Color.Black;
            checkBoxOperationSearch.Location = new Point(3, 33);
            checkBoxOperationSearch.Name = "checkBoxOperationSearch";
            checkBoxOperationSearch.Size = new Size(70, 24);
            checkBoxOperationSearch.TabIndex = 23;
            checkBoxOperationSearch.Text = "Search";
            checkBoxOperationSearch.UseVisualStyleBackColor = true;
            // 
            // groupBoxRoles
            // 
            groupBoxRoles.Controls.Add(flowLayoutPanelRoles);
            groupBoxRoles.ForeColor = Color.FromArgb(83, 105, 208);
            groupBoxRoles.Location = new Point(361, 446);
            groupBoxRoles.Name = "groupBoxRoles";
            groupBoxRoles.Size = new Size(289, 126);
            groupBoxRoles.TabIndex = 6;
            groupBoxRoles.TabStop = false;
            groupBoxRoles.Text = "💼 Roles / Authorities";
            // 
            // flowLayoutPanelRoles
            // 
            flowLayoutPanelRoles.Controls.Add(checkBoxRoleAdmin);
            flowLayoutPanelRoles.Controls.Add(checkBoxRoleAdminAssitant);
            flowLayoutPanelRoles.Controls.Add(checkBoxRoleDispatcher);
            flowLayoutPanelRoles.Controls.Add(checkBoxRoleLineSupervisor);
            flowLayoutPanelRoles.Dock = DockStyle.Fill;
            flowLayoutPanelRoles.Location = new Point(3, 22);
            flowLayoutPanelRoles.Name = "flowLayoutPanelRoles";
            flowLayoutPanelRoles.Size = new Size(283, 101);
            flowLayoutPanelRoles.TabIndex = 0;
            // 
            // checkBoxRoleAdmin
            // 
            checkBoxRoleAdmin.AutoSize = true;
            checkBoxRoleAdmin.ForeColor = Color.Black;
            checkBoxRoleAdmin.Location = new Point(3, 3);
            checkBoxRoleAdmin.Name = "checkBoxRoleAdmin";
            checkBoxRoleAdmin.Size = new Size(66, 24);
            checkBoxRoleAdmin.TabIndex = 19;
            checkBoxRoleAdmin.Text = "Admin";
            checkBoxRoleAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBoxRoleAdminAssitant
            // 
            checkBoxRoleAdminAssitant.AutoSize = true;
            checkBoxRoleAdminAssitant.ForeColor = Color.Black;
            checkBoxRoleAdminAssitant.Location = new Point(75, 3);
            checkBoxRoleAdminAssitant.Name = "checkBoxRoleAdminAssitant";
            checkBoxRoleAdminAssitant.Size = new Size(123, 24);
            checkBoxRoleAdminAssitant.TabIndex = 20;
            checkBoxRoleAdminAssitant.Text = "Admin Assistant";
            checkBoxRoleAdminAssitant.UseVisualStyleBackColor = true;
            // 
            // checkBoxRoleDispatcher
            // 
            checkBoxRoleDispatcher.AutoSize = true;
            checkBoxRoleDispatcher.ForeColor = Color.Black;
            checkBoxRoleDispatcher.Location = new Point(3, 33);
            checkBoxRoleDispatcher.Name = "checkBoxRoleDispatcher";
            checkBoxRoleDispatcher.Size = new Size(91, 24);
            checkBoxRoleDispatcher.TabIndex = 21;
            checkBoxRoleDispatcher.Text = "Dispatcher";
            checkBoxRoleDispatcher.UseVisualStyleBackColor = true;
            // 
            // checkBoxRoleLineSupervisor
            // 
            checkBoxRoleLineSupervisor.AutoSize = true;
            checkBoxRoleLineSupervisor.ForeColor = Color.Black;
            checkBoxRoleLineSupervisor.Location = new Point(100, 33);
            checkBoxRoleLineSupervisor.Name = "checkBoxRoleLineSupervisor";
            checkBoxRoleLineSupervisor.Size = new Size(122, 24);
            checkBoxRoleLineSupervisor.TabIndex = 22;
            checkBoxRoleLineSupervisor.Text = "Line Supervisor";
            checkBoxRoleLineSupervisor.UseVisualStyleBackColor = true;
            // 
            // groupBoxRecoveryInformation
            // 
            groupBoxRecoveryInformation.Controls.Add(panelAnswer);
            groupBoxRecoveryInformation.Controls.Add(labelRequiredAnswer);
            groupBoxRecoveryInformation.Controls.Add(panelRecoveryQustion);
            groupBoxRecoveryInformation.Controls.Add(labelAnswer);
            groupBoxRecoveryInformation.Controls.Add(labelRequiredRecoveryQuestion);
            groupBoxRecoveryInformation.Controls.Add(labelRecveryQuestion);
            groupBoxRecoveryInformation.ForeColor = Color.FromArgb(48, 111, 86);
            groupBoxRecoveryInformation.Location = new Point(3, 446);
            groupBoxRecoveryInformation.Name = "groupBoxRecoveryInformation";
            groupBoxRecoveryInformation.Size = new Size(355, 141);
            groupBoxRecoveryInformation.TabIndex = 6;
            groupBoxRecoveryInformation.TabStop = false;
            groupBoxRecoveryInformation.Text = "🔐 Account Recovery Info";
            // 
            // panelAnswer
            // 
            panelAnswer.BackColor = Color.FromArgb(235, 244, 255);
            panelAnswer.Controls.Add(textBoxAnswer);
            panelAnswer.Location = new Point(10, 94);
            panelAnswer.Name = "panelAnswer";
            panelAnswer.Size = new Size(339, 32);
            panelAnswer.TabIndex = 33;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.BackColor = Color.FromArgb(235, 244, 255);
            textBoxAnswer.BorderStyle = BorderStyle.None;
            textBoxAnswer.Location = new Point(1, 6);
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.Size = new Size(337, 19);
            textBoxAnswer.TabIndex = 29;
            // 
            // labelRequiredAnswer
            // 
            labelRequiredAnswer.AutoSize = true;
            labelRequiredAnswer.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredAnswer.ForeColor = Color.Red;
            labelRequiredAnswer.Location = new Point(66, 76);
            labelRequiredAnswer.Name = "labelRequiredAnswer";
            labelRequiredAnswer.Size = new Size(14, 17);
            labelRequiredAnswer.TabIndex = 36;
            labelRequiredAnswer.Text = "*";
            // 
            // panelRecoveryQustion
            // 
            panelRecoveryQustion.BackColor = Color.FromArgb(235, 244, 255);
            panelRecoveryQustion.Controls.Add(comboBoxSecurityQuestion);
            panelRecoveryQustion.Location = new Point(10, 42);
            panelRecoveryQustion.Name = "panelRecoveryQustion";
            panelRecoveryQustion.Size = new Size(339, 32);
            panelRecoveryQustion.TabIndex = 33;
            // 
            // comboBoxSecurityQuestion
            // 
            comboBoxSecurityQuestion.BackColor = Color.FromArgb(235, 244, 255);
            comboBoxSecurityQuestion.FlatStyle = FlatStyle.Flat;
            comboBoxSecurityQuestion.FormattingEnabled = true;
            comboBoxSecurityQuestion.Location = new Point(1, 2);
            comboBoxSecurityQuestion.Name = "comboBoxSecurityQuestion";
            comboBoxSecurityQuestion.Size = new Size(337, 28);
            comboBoxSecurityQuestion.TabIndex = 30;
            comboBoxSecurityQuestion.SelectedIndexChanged += comboBoxSecurityQuestion_SelectedIndexChanged;
            // 
            // labelAnswer
            // 
            labelAnswer.AutoSize = true;
            labelAnswer.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelAnswer.ForeColor = Color.Black;
            labelAnswer.Location = new Point(12, 75);
            labelAnswer.Name = "labelAnswer";
            labelAnswer.Size = new Size(57, 17);
            labelAnswer.TabIndex = 37;
            labelAnswer.Text = "Answer";
            // 
            // labelRequiredRecoveryQuestion
            // 
            labelRequiredRecoveryQuestion.AutoSize = true;
            labelRequiredRecoveryQuestion.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRequiredRecoveryQuestion.ForeColor = Color.Red;
            labelRequiredRecoveryQuestion.Location = new Point(148, 22);
            labelRequiredRecoveryQuestion.Name = "labelRequiredRecoveryQuestion";
            labelRequiredRecoveryQuestion.Size = new Size(14, 17);
            labelRequiredRecoveryQuestion.TabIndex = 36;
            labelRequiredRecoveryQuestion.Text = "*";
            // 
            // labelRecveryQuestion
            // 
            labelRecveryQuestion.AutoSize = true;
            labelRecveryQuestion.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRecveryQuestion.ForeColor = Color.Black;
            labelRecveryQuestion.Location = new Point(9, 22);
            labelRecveryQuestion.Name = "labelRecveryQuestion";
            labelRecveryQuestion.Size = new Size(133, 17);
            labelRecveryQuestion.TabIndex = 37;
            labelRecveryQuestion.Text = "Recovery Question";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(84, 38);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(175, 27);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Add / Edit User";
            // 
            // labelSubtitle
            // 
            labelSubtitle.AutoSize = true;
            labelSubtitle.Font = new Font("Arial", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSubtitle.ForeColor = Color.Black;
            labelSubtitle.Location = new Point(84, 63);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(344, 19);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Enter new user details and define permissions";
            // 
            // panelIconContainer
            // 
            panelIconContainer.BackColor = Color.Transparent;
            panelIconContainer.BackgroundImage = Properties.Resources.mega_creator;
            panelIconContainer.BackgroundImageLayout = ImageLayout.Zoom;
            panelIconContainer.Controls.Add(pictureBoxIcon);
            panelIconContainer.ForeColor = Color.FromArgb(230, 241, 251);
            panelIconContainer.Location = new Point(27, 38);
            panelIconContainer.Name = "panelIconContainer";
            panelIconContainer.Size = new Size(51, 48);
            panelIconContainer.TabIndex = 32;
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
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(26, 86, 160);
            panelTitleBar.Controls.Add(buttonCloseWindow);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(655, 25);
            panelTitleBar.TabIndex = 41;
            // 
            // buttonCloseWindow
            // 
            buttonCloseWindow.BackColor = Color.Transparent;
            buttonCloseWindow.FlatAppearance.BorderSize = 0;
            buttonCloseWindow.FlatStyle = FlatStyle.Flat;
            buttonCloseWindow.ForeColor = Color.White;
            buttonCloseWindow.Location = new Point(631, 0);
            buttonCloseWindow.Name = "buttonCloseWindow";
            buttonCloseWindow.Size = new Size(22, 23);
            buttonCloseWindow.TabIndex = 11;
            buttonCloseWindow.Text = "X";
            buttonCloseWindow.UseVisualStyleBackColor = false;
            buttonCloseWindow.Click += buttonClose_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(655, 638);
            Controls.Add(panelTitleBar);
            Controls.Add(groupBoxRecoveryInformation);
            Controls.Add(groupBoxRoles);
            Controls.Add(groupBoxPermissionsOperations);
            Controls.Add(groupBoxPermissionsQuickAccess);
            Controls.Add(groupBoxPermissionsTabs);
            Controls.Add(panelBottomButtons);
            Controls.Add(groupBoxUserInformation);
            Controls.Add(panelIconContainer);
            Controls.Add(labelTitle);
            Controls.Add(labelSubtitle);
            Font = new Font("Arial Narrow", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddUserForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += AddUserForm_FormClosed;
            Load += AddUserForm_Load;
            groupBoxUserInformation.ResumeLayout(false);
            groupBoxUserInformation.PerformLayout();
            panelPhoneNumber.ResumeLayout(false);
            panelPhoneNumber.PerformLayout();
            panelEmailAddress.ResumeLayout(false);
            panelEmailAddress.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panelUserName.ResumeLayout(false);
            panelUserName.PerformLayout();
            panelFullName.ResumeLayout(false);
            panelFullName.PerformLayout();
            panelBottomButtons.ResumeLayout(false);
            groupBoxPermissionsTabs.ResumeLayout(false);
            flowLayoutPanelTabs.ResumeLayout(false);
            flowLayoutPanelTabs.PerformLayout();
            groupBoxPermissionsQuickAccess.ResumeLayout(false);
            flowLayoutPanelPermissionsQuickAccess.ResumeLayout(false);
            flowLayoutPanelPermissionsQuickAccess.PerformLayout();
            groupBoxPermissionsOperations.ResumeLayout(false);
            flowLayoutPanelPermissionsOperations.ResumeLayout(false);
            flowLayoutPanelPermissionsOperations.PerformLayout();
            groupBoxRoles.ResumeLayout(false);
            flowLayoutPanelRoles.ResumeLayout(false);
            flowLayoutPanelRoles.PerformLayout();
            groupBoxRecoveryInformation.ResumeLayout(false);
            groupBoxRecoveryInformation.PerformLayout();
            panelAnswer.ResumeLayout(false);
            panelAnswer.PerformLayout();
            panelRecoveryQustion.ResumeLayout(false);
            panelIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUserInformation;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonSaveAndClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelBottomButtons;
        private System.Windows.Forms.GroupBox groupBoxPermissionsTabs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTabs;
        private System.Windows.Forms.CheckBox checkBoxTabHome;
        private System.Windows.Forms.CheckBox checkBoxTabUsers;
        private System.Windows.Forms.CheckBox checkBoxTabBuses;
        private System.Windows.Forms.CheckBox checkBoxTabPassenger;
        private System.Windows.Forms.CheckBox checkBoxTabSettings;
        private System.Windows.Forms.CheckBox checkBoxTabSystemRecords;
        private System.Windows.Forms.GroupBox groupBoxPermissionsQuickAccess;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPermissionsQuickAccess;
        private System.Windows.Forms.CheckBox checkBoxAccessBus;
        private System.Windows.Forms.CheckBox checkBoxAccessPassenger;
        private System.Windows.Forms.CheckBox checkBoxAccessUser;
        private System.Windows.Forms.GroupBox groupBoxPermissionsOperations;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPermissionsOperations;
        private System.Windows.Forms.CheckBox checkBoxOperationAdd;
        private System.Windows.Forms.CheckBox checkBoxOperationDelete;
        private System.Windows.Forms.CheckBox checkBoxOperationEdit;
        private System.Windows.Forms.CheckBox checkBoxOperationExport;
        private System.Windows.Forms.CheckBox checkBoxOperationSearch;
        private System.Windows.Forms.GroupBox groupBoxRoles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRoles;
        private System.Windows.Forms.CheckBox checkBoxRoleAdmin;
        private System.Windows.Forms.CheckBox checkBoxRoleAdminAssitant;
        private System.Windows.Forms.CheckBox checkBoxRoleDispatcher;
        private System.Windows.Forms.CheckBox checkBoxRoleLineSupervisor;
        private System.Windows.Forms.GroupBox groupBoxRecoveryInformation;
        private System.Windows.Forms.ComboBox comboBoxSecurityQuestion;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Panel panelIconContainer;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelRequiredFullName;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Panel panelFullName;
        private System.Windows.Forms.Label labelRequiredPassword;
        private System.Windows.Forms.Label labelRequiredUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.Panel panelUserName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelEmailAddress;
        private System.Windows.Forms.Panel panelPhoneNumber;
        private System.Windows.Forms.Panel panelEmailAddress;
        private System.Windows.Forms.Panel panelAnswer;
        private System.Windows.Forms.Label labelRequiredAnswer;
        private System.Windows.Forms.Panel panelRecoveryQustion;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Label labelRequiredRecoveryQuestion;
        private System.Windows.Forms.Label labelRecveryQuestion;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button buttonCloseWindow;
        private ErrorProvider errorProvider;
        private Label labelRequiredPhone;
    }
}