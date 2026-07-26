using System.Data;
using TakeTicket.Application.Common.Interfaces;
using TakeTicket.Application.Common.Security;
using TakeTicket.Infrastructure.Helper;
using TakeTicket.Infrastructure.Validation;
using TakeTicket.Domain;
using TakeTicket.Data;
using TakeTicket.Shared.Common.Logging;
using TakeTicket.Shared.Localization;

namespace TakeTicket.Gui.UsersGui
{
    public partial class AddUserForm : Form
    {
        // Variables
        private int ID;
        private bool firstStart = false;
        private Users users;
        private readonly IDataHelper<Users> dataHelper;
        private readonly IDataHelper<UsersRoles> dataHelperUsersRoles;
        private readonly LoadingGui.LoadingForm loadingForm;
        private readonly IDataHelper<SystemRecords> dataHelperSystemRecords;
        private readonly IUserService userService;
        private Dictionary<string, bool> ListOfRoles = new Dictionary<string, bool>();
        public event Func<Task> OnUserSaved;

        public AddUserForm(UsersUserControl _usersUserControl,
            IDataHelper<Users> dataHelper,
            IDataHelper<SystemRecords> dataHelperSystemRecords,
            IDataHelper<UsersRoles> dataHelperUsersRoles,
            IUserService userService)
        {
            InitializeComponent();

            ApplyLocalization();
            ApplyLayout();

            this.dataHelper = dataHelper;
            this.dataHelperUsersRoles = dataHelperUsersRoles;
            this.dataHelperSystemRecords = dataHelperSystemRecords;
            this.userService = userService;

            loadingForm = new LoadingGui.LoadingForm();
        }

        #region Evints
        private async void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            loadingForm.Show();

            try
            {
                if (await SaveData())
                {
                    if (ID == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageCollections.ShowAddNotification();
                    }
                    else
                    {
                        MessageCollections.ShowUpdateNotification();
                    }
                    if (OnUserSaved != null)
                        await OnUserSaved();

                    if (firstStart == true)
                    {
                        MessageCollections.ShowNotification(localizer.Get("RestartApplicationMessage"));
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Save User");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            loadingForm.Show();

            try
            {
                if (await SaveData())
                {
                    if (ID == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageCollections.ShowAddNotification();
                    }
                    else
                    {
                        MessageCollections.ShowUpdateNotification();
                    }

                    if (OnUserSaved != null)
                        await OnUserSaved();
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Save User");
                MessageCollections.ShowErrorServer();
            }
            finally
            {
                loadingForm.Hide();
            }
        }

        private async void AddUserForm_Load(object sender, EventArgs e)
        {
            //ApplyLayout();

            comboBoxSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxSecurityQuestion.Items.Clear();

            comboBoxSecurityQuestion.Items.Add(
                new SecurityQuestionItem
                {
                    Key = "SecurityQuestionMotherName",
                    Text = localizer.Get("SecurityQuestionMotherName")
                });

            comboBoxSecurityQuestion.Items.Add(
                new SecurityQuestionItem
                {
                    Key = "SecurityQuestionFirstSchool",
                    Text = localizer.Get("SecurityQuestionFirstSchool")
                });

            comboBoxSecurityQuestion.Items.Add(
                new SecurityQuestionItem
                {
                    Key = "SecurityQuestionBestFriend",
                    Text = localizer.Get("SecurityQuestionBestFriend")
                });

            loadingForm.Show();
            await SetFiledData();
            loadingForm.Hide();

            textBoxAnswer.Enabled = comboBoxSecurityQuestion.SelectedItem != null;

            if (firstStart == true)
            {
                buttonSave.Visible = false;
            }

            assignPermissionsByRole();
            checkBoxRoleAdmin.CheckedChanged += (s, e) =>
            {
                if (checkBoxRoleAdmin.Checked)
                    HandleRoleSelection(checkBoxRoleAdmin);
            };

            checkBoxRoleAdminAssitant.CheckedChanged += (s, e) =>
            {
                if (checkBoxRoleAdminAssitant.Checked)
                    HandleRoleSelection(checkBoxRoleAdminAssitant);
            };

            checkBoxRoleDispatcher.CheckedChanged += (s, e) =>
            {
                if (checkBoxRoleDispatcher.Checked)
                    HandleRoleSelection(checkBoxRoleDispatcher);
            };

            checkBoxRoleLineSupervisor.CheckedChanged += (s, e) =>
            {
                if (checkBoxRoleLineSupervisor.Checked)
                    HandleRoleSelection(checkBoxRoleLineSupervisor);
            };
        }

        private void AddUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (firstStart == true)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void comboBoxSecurityQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAnswer.Enabled = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region Methods

        private async Task<bool> SaveData()
        {
            // Add
            if (ID == 0)
            {
                return await AddData();
            }
            // Edit
            else
            {
                return await EditData();
            }
        }

        private async Task<bool> AddData()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxSecurityQuestion.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAnswer.Text))
                {
                    MessageBox.Show(localizer.Get("SecurityQuestionAnswerRequired"));
                    return false;
                }

                // Set Data
                users = new Users
                {
                    FullName = textBoxName.Text,
                    UserName = textBoxUserName.Text,
                    Password = PasswordHasher.Hash(textBoxPassword.Text),
                    Phone = textBoxPhoneNumber.Text,
                    Email = textBoxEmail.Text,
                    AddedDate = DateTime.Now,

                    SecurityQuestion = ((SecurityQuestionItem)comboBoxSecurityQuestion.SelectedItem).Key,
                    SecurityAnswer = PasswordHasher.Hash(textBoxAnswer.Text)
                };

                // sumbit
                var result = await dataHelper.AddAsync(users);

                if (result == 1)
                {
                    // Add Roles
                    var createdUser = await userService.GetByUserNameAsync(users.UserName);

                    if (createdUser == null)
                        return false;

                    int userId = createdUser.Id;

                    SetRoles();

                    foreach (var role in ListOfRoles)
                    {
                        await dataHelperUsersRoles.AddAsync(
                            new UsersRoles
                            {
                                UserId = userId,
                                Key = role.Key,
                                Value = role.Value
                            });
                    }

                    // Save System Records
                    SystemRecords systemRecords = new SystemRecords
                    {
                        Title = localizer.Get("AddUserTitle"),
                        UserName = Properties.Settings.Default.UserName,
                        Details = string.Format(localizer.Get("AddUserDetails"), users.UserName),
                        AddedDate = DateTime.Now
                    };

                    Logger.Audit($"User Added: Username={users.UserName}");

                    await dataHelperSystemRecords.AddAsync(systemRecords);
                    // Toast
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Add User");
                return false;
            }

        }

        private void SetRoles()
        {
            ListOfRoles.Clear();
            ListOfRoles.Add(checkBoxTabHome.Name, checkBoxTabHome.Checked);
            ListOfRoles.Add(checkBoxTabBuses.Name, checkBoxTabBuses.Checked);
            ListOfRoles.Add(checkBoxTabPassenger.Name, checkBoxTabPassenger.Checked);
            ListOfRoles.Add(checkBoxTabUsers.Name, checkBoxTabUsers.Checked);
            ListOfRoles.Add(checkBoxTabSettings.Name, checkBoxTabSettings.Checked);
            ListOfRoles.Add(checkBoxTabSystemRecords.Name, checkBoxTabSystemRecords.Checked);
            // it is well be Update with new version

            // 
            ListOfRoles.Add(checkBoxAccessBus.Name, checkBoxAccessBus.Checked);
            ListOfRoles.Add(checkBoxAccessPassenger.Name, checkBoxAccessPassenger.Checked);
            ListOfRoles.Add(checkBoxAccessUser.Name, checkBoxAccessUser.Checked);
            // it is well be Update with new version

            //
            ListOfRoles.Add(checkBoxOperationAdd.Name, checkBoxOperationAdd.Checked);
            ListOfRoles.Add(checkBoxOperationDelete.Name, checkBoxOperationDelete.Checked);
            ListOfRoles.Add(checkBoxOperationEdit.Name, checkBoxOperationEdit.Checked);
            ListOfRoles.Add(checkBoxOperationExport.Name, checkBoxOperationExport.Checked);
            ListOfRoles.Add(checkBoxOperationSearch.Name, checkBoxOperationSearch.Checked);
        }

        private async Task<bool> EditData()
        {
            try
            {
                var oldUser = await dataHelper.FindAsync(ID);

                if (oldUser == null)
                    return false;

                string passwordHash = oldUser.Password;

                if (!string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    passwordHash = PasswordHasher.Hash(textBoxPassword.Text);
                }

                string answerHash = oldUser.SecurityAnswer;

                if (!string.IsNullOrWhiteSpace(textBoxAnswer.Text))
                {
                    answerHash = PasswordHasher.Hash(textBoxAnswer.Text);
                }

                // Set Data
                users = new Users
                {
                    Id = ID,
                    FullName = textBoxName.Text,
                    UserName = textBoxUserName.Text,
                    Password = passwordHash,
                    Phone = textBoxPhoneNumber.Text,
                    Email = textBoxEmail.Text,
                    AddedDate = oldUser.AddedDate,

                    SecurityQuestion = (comboBoxSecurityQuestion.SelectedItem as SecurityQuestionItem)?.Key ?? oldUser.SecurityQuestion,
                    SecurityAnswer = answerHash
                };

                // sumbit
                var result = await dataHelper.EditAsync(users);
                if (result == 1)
                {
                    // Add Roles
                    var rolesData = await dataHelperUsersRoles.GetAllDataAsync();
                    var ListOfRolesId = rolesData.Where(x => x.UserId == ID).Select(x => x.Id).ToList();
                    // Loop int ListOfRolesId ==> Delete
                    for (int j = 0; j < ListOfRolesId.Count; j++)
                    {
                        var userid = ListOfRolesId[j];
                        await dataHelperUsersRoles.DeleteAsync(userid);
                    }

                    SetRoles();

                    // Loop into List of Roles

                    for (int i = 0; i < ListOfRoles.Count; i++)
                    {
                        UsersRoles usersRoles = new UsersRoles
                        {
                            UserId = ID,
                            Key = ListOfRoles.Keys.ToList()[i],
                            Value = ListOfRoles.Values.ToList()[i]
                        };
                        await dataHelperUsersRoles.AddAsync(usersRoles);
                    }

                    // Save System Records
                    SystemRecords systemRecords = new SystemRecords
                    {
                        Title = localizer.Get("EditUserTitle"),
                        UserName = Properties.Settings.Default.UserName,
                        Details = string.Format(localizer.Get("EditUserDetails"), users.UserName),
                        AddedDate = DateTime.Now
                    };
                    await dataHelperSystemRecords.AddAsync(systemRecords);

                    Logger.Audit($"User Updated: Username={users.UserName} / ID={ID}");
                    // Toast 
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Edit User");
                return false;
            }
        }

        private async Task SetFiledData()
        {
            if (ID > 0)
            {
                // Set Filed
                users = await dataHelper.FindAsync(ID);
                var rolesData = await dataHelperUsersRoles.GetAllDataAsync();
                var ListOfRoles = rolesData.Where(X => X.UserId == ID).ToDictionary(x => x.Key, x => x.Value);
                var rolesDict = rolesData.Where(x => x.UserId == ID).ToDictionary(x => x.Key, x => x.Value);

                if (users != null)
                {
                    textBoxName.Text = users.FullName;
                    textBoxUserName.Text = users.UserName;
                    textBoxPassword.Text = "";
                    textBoxPhoneNumber.Text = users.Phone;
                    textBoxEmail.Text = users.Email;

                    var selectedQuestion =
                        comboBoxSecurityQuestion.Items
                        .Cast<SecurityQuestionItem>()
                        .FirstOrDefault(x => x.Key == users.SecurityQuestion);

                    if (selectedQuestion != null)
                    {
                        comboBoxSecurityQuestion.SelectedItem = selectedQuestion;
                    }

                    // Set Current Roles Permissions/Tabs
                    checkBoxTabHome.Checked = rolesDict.GetValueOrDefault(checkBoxTabHome.Name);
                    checkBoxTabBuses.Checked = rolesDict.GetValueOrDefault(checkBoxTabBuses.Name);
                    checkBoxTabPassenger.Checked = rolesDict.GetValueOrDefault(checkBoxTabPassenger.Name);
                    checkBoxTabUsers.Checked = rolesDict.GetValueOrDefault(checkBoxTabUsers.Name);
                    checkBoxTabSettings.Checked = rolesDict.GetValueOrDefault(checkBoxTabSettings.Name);
                    checkBoxTabSystemRecords.Checked = rolesDict.GetValueOrDefault(checkBoxTabSystemRecords.Name);
                    // it is well be Update with next version

                    // Permissions/Quick Access
                    checkBoxAccessBus.Checked = rolesDict.GetValueOrDefault(checkBoxAccessBus.Name);
                    checkBoxAccessPassenger.Checked = rolesDict.GetValueOrDefault(checkBoxAccessPassenger.Name);
                    checkBoxAccessUser.Checked = rolesDict.GetValueOrDefault(checkBoxAccessUser.Name);
                    // it is well be Update with new version

                    // Permissions/Standard operations
                    checkBoxOperationAdd.Checked = rolesDict.GetValueOrDefault(checkBoxOperationAdd.Name);
                    checkBoxOperationDelete.Checked = rolesDict.GetValueOrDefault(checkBoxOperationDelete.Name);
                    checkBoxOperationEdit.Checked = rolesDict.GetValueOrDefault(checkBoxOperationEdit.Name);
                    checkBoxOperationExport.Checked = rolesDict.GetValueOrDefault(checkBoxOperationExport.Name);
                    checkBoxOperationSearch.Checked = rolesDict.GetValueOrDefault(checkBoxOperationSearch.Name);
                }
                else
                {
                    MessageCollections.ShowErrorServer();
                }
            }
        }

        public void SetData(int id, bool firstStart)
        {
            this.ID = id;
            this.firstStart = firstStart;
        }

        public void assignPermissionsByRole()
        {
            ResetPermissions();

            if (checkBoxRoleAdmin.Checked)
            {
                SetAdminPermissions();
            }
            else if (checkBoxRoleAdminAssitant.Checked)
            {
                SetAdminAssistantPermissions();
            }
            else if (checkBoxRoleDispatcher.Checked)
            {
                SetDispatcherPermissions();
            }
            else if (checkBoxRoleLineSupervisor.Checked)
            {
                SetLineSupervisorPermissions();
            }
        }

        private void HandleRoleSelection(CheckBox selectedCheckBox)
        {
            foreach (var control in flowLayoutPanelRoles.Controls)
            {
                if (control is CheckBox cb && cb != selectedCheckBox)
                {
                    cb.Checked = false;
                }
            }

            assignPermissionsByRole();
        }

        private void ResetPermissions()
        {
            foreach (var group in new[] { flowLayoutPanelTabs, flowLayoutPanelPermissionsQuickAccess, flowLayoutPanelPermissionsOperations })
            {
                foreach (var control in group.Controls)
                {
                    if (control is CheckBox cb)
                        cb.Checked = false;
                }
            }
        }

        private void SetAdminPermissions()
        {
            foreach (var group in new[] { flowLayoutPanelTabs, flowLayoutPanelPermissionsQuickAccess, flowLayoutPanelPermissionsOperations })
            {
                foreach (var control in group.Controls)
                {
                    if (control is CheckBox cb)
                        cb.Checked = true;
                }
            }
        }

        private void SetAdminAssistantPermissions()
        {
            checkBoxTabHome.Checked = true;
            checkBoxTabPassenger.Checked = true;
            checkBoxTabUsers.Checked = true;

            checkBoxAccessPassenger.Checked = true;
            checkBoxAccessUser.Checked = true;

            checkBoxOperationAdd.Checked = true;
            checkBoxOperationEdit.Checked = true;
            checkBoxOperationSearch.Checked = true;
        }

        private void SetDispatcherPermissions()
        {
            checkBoxTabHome.Checked = true;
            checkBoxTabBuses.Checked = true;
            checkBoxTabPassenger.Checked = true;

            checkBoxAccessBus.Checked = true;
            checkBoxAccessPassenger.Checked = true;

            checkBoxOperationAdd.Checked = true;
            checkBoxOperationEdit.Checked = true;
            checkBoxOperationSearch.Checked = true;
        }

        private void SetLineSupervisorPermissions()
        {
            checkBoxTabHome.Checked = true;
            checkBoxTabBuses.Checked = true;

            checkBoxAccessBus.Checked = true;

            checkBoxOperationSearch.Checked = true;
        }

        private bool ValidateInputs()
        {
            bool valid = true;

            valid &= Validator.Required(
                textBoxUserName,
                errorProvider,
                localizer.Get("UserNameRequired"));

            valid &= Validator.Required(
                textBoxPhoneNumber,
                errorProvider,
                localizer.Get("PhoneRequired"));

            if (ID == 0)
            {
                valid &= Validator.Required(
                    textBoxPassword,
                    errorProvider,
                    localizer.Get("PasswordRequired"));

                valid &= Validator.MinLength(
                    textBoxPassword,
                    errorProvider,
                    4,
                    localizer.Get("PasswordTooShort"));
            }

            if (ID ==0)
            {
                valid &= Validator.Required(
                comboBoxSecurityQuestion,
                errorProvider,
                localizer.Get("SecurityQuestionRequired"));

                valid &= Validator.Required(
                    textBoxAnswer,
                    errorProvider,
                    localizer.Get("AnswerRequired"));
            }

            return valid;
        }

        private readonly Localizer localizer =
            new Localizer(
                "TakeTicket.Shared.Localization.Forms.UserLocal.AddUserFormLocalization");

        private void ApplyLocalization()
        {
            this.Text =
                localizer.Get("AddUserForm.Text");

            buttonSave.Text =
                localizer.Get("buttonSave.Text");

            buttonSaveAndClose.Text =
                localizer.Get("buttonSaveAndClose.Text");

            groupBoxUserInformation.Text =
                localizer.Get("groupBoxUserInformation.Text");

            groupBoxPermissionsTabs.Text =
                localizer.Get("groupBoxPermissionsTabs.Text");

            groupBoxPermissionsQuickAccess.Text =
                localizer.Get("groupBoxPermissionsQuickAccess.Text");

            groupBoxPermissionsOperations.Text =
                localizer.Get("groupBoxPermissionsStandardOperations.Text");

            groupBoxRoles.Text =
                localizer.Get("groupBoxResponsibilityAuthorities.Text");

            groupBoxRecoveryInformation.Text =
                localizer.Get("groupBoxRecoveryInformation.Text");

            checkBoxTabHome.Text =
                localizer.Get("checkBoxHome.Text");

            checkBoxTabUsers.Text =
                localizer.Get("checkBoxUsers.Text");

            checkBoxTabBuses.Text =
                localizer.Get("checkBoxBuses.Text");

            checkBoxTabPassenger.Text =
                localizer.Get("checkBoxCustomers.Text");

            checkBoxTabSettings.Text =
                localizer.Get("checkBoxSettings.Text");

            checkBoxTabSystemRecords.Text =
                localizer.Get("checkBoxSystemRecords.Text");

            checkBoxAccessBus.Text =
                localizer.Get("checkBoxAccessBus.Text");

            checkBoxAccessPassenger.Text =
                localizer.Get("checkBoxAccessCustomer.Text");

            checkBoxAccessUser.Text =
                localizer.Get("checkBoxAccessUsers.Text");

            checkBoxOperationAdd.Text =
                localizer.Get("checkBoxAdd.Text");

            checkBoxOperationDelete.Text =
                localizer.Get("checkBoxDelete.Text");

            checkBoxOperationEdit.Text =
                localizer.Get("checkBoxEdit.Text");

            checkBoxOperationExport.Text =
                localizer.Get("checkBoxExport.Text");

            checkBoxOperationSearch.Text =
                localizer.Get("checkBoxSearch.Text");

            checkBoxRoleAdmin.Text =
                localizer.Get("checkBoxAdmin.Text");

            checkBoxRoleAdminAssitant.Text =
                localizer.Get("checkBoxAdminAssistant.Text");

            checkBoxRoleDispatcher.Text =
                localizer.Get("checkBoxDispatcher.Text");

            checkBoxRoleLineSupervisor.Text =
                localizer.Get("checkBoxLineSupervisor.Text");

            labelFullName.Text =
                localizer.Get("labelFullName.Text");

            labelUserName.Text =
                localizer.Get("labelUserName.Text");

            labelPassword.Text =
                localizer.Get("labelPassword.Text");

            labelEmailAddress.Text =
                localizer.Get("labelEmail.Text");

            labelPhoneNumber.Text =
                localizer.Get("labelPhoneNumber.Text");

            labelRecveryQuestion.Text =
                localizer.Get("labelRecveryQuestion.Text");

            labelAnswer.Text =
                localizer.Get("labelAnswer.Text");

            labelTitle.Text =
                localizer.Get("labelTitle.Text");

            labelSubtitle.Text =
                localizer.Get("labelSub.Text");
        }


        #endregion
        #region RTL
        private void ApplyLayout()
        {
            string language =
                Properties.Settings.Default.Language;

            switch (language)
            {
                case "ar":
                    ApplyArabicLayout();
                    break;

                case "ru":
                    ApplyRussianLayout();
                    break;

                default:
                    ApplyEnglishLayout();
                    break;
            }
        }

        private void ApplyArabicLayout()
        {
            RightToLeft =
                RightToLeft.Yes;

            RightToLeftLayout =
                true;

            buttonCloseWindow.Location =
                new Point(0, 0);

            // Header
            panelIconContainer.Location =
                new Point(27, 38);

            labelTitle.Location =
                new Point(84, 38);

            labelSubtitle.Location =
                new Point(84, 63);

            // GroupBoxes
            groupBoxUserInformation.Location =
                new Point(3, 102);
            // groupBoxUserInformation Components
            labelFullName.Location = new Point(275, 27);
            labelRequiredFullName.Location = new Point(262, 27);

            labelUserName.Location = new Point(270, 85);
            labelRequiredUserName.Location = new Point(256, 85);

            labelPassword.Location = new Point(277, 143);
            labelRequiredPassword.Location = new Point(263, 143);

            labelEmailAddress.Location = new Point(259, 201);

            labelPhoneNumber.Location = new Point(285, 259);
            labelRequiredPhone.Location = new Point(271, 259);

            groupBoxPermissionsTabs.Location =
                new Point(361, 102);

            groupBoxPermissionsQuickAccess.Location =
                new Point(361, 238);

            groupBoxPermissionsOperations.Location =
                new Point(361, 338);

            groupBoxRoles.Location =
                new Point(361, 446);

            groupBoxRecoveryInformation.Location =
                new Point(3, 446);

            // groupBoxRecoveryInformation Components
            labelRecveryQuestion.Location = new Point(268, 23);
            labelRequiredRecoveryQuestion.Location = new Point(254, 23);

            labelAnswer.Location = new Point(304, 75);
            labelRequiredAnswer.Location = new Point(291, 75);


            // Bottom Buttons
            buttonSave.Location =
                new Point(492, 12);

            buttonSaveAndClose.Location =
                new Point(332, 12);

            // Text Align
            textBoxName.TextAlign =
                HorizontalAlignment.Left;

            textBoxUserName.TextAlign =
                HorizontalAlignment.Left;

            textBoxPassword.TextAlign =
                HorizontalAlignment.Left;

            textBoxEmail.TextAlign =
                HorizontalAlignment.Left;

            textBoxPhoneNumber.TextAlign =
                HorizontalAlignment.Left;

            textBoxAnswer.TextAlign =
                HorizontalAlignment.Left;

            comboBoxSecurityQuestion.RightToLeft =
                RightToLeft.Yes;
        }

        private void ApplyEnglishLayout()
        {
            SuspendLayout();

            // Form
            RightToLeft = RightToLeft.No;
            RightToLeftLayout = false;
            Font = new Font("Arial Narrow", 12F);

            // Close button
            buttonCloseWindow.Anchor =
                AnchorStyles.Top | AnchorStyles.Right;

            buttonCloseWindow.Location =
                new Point(606, 0);

            // Header
            panelIconContainer.Location =
                new Point(27, 38);

            labelTitle.Location =
                new Point(84, 38);

            labelSubtitle.Location =
                new Point(84, 63);

            labelTitle.Font =
                new Font("Arial", 18F);

            labelSubtitle.Font =
                new Font("Arial", 12.75F);

            // GroupBoxes Locations
            groupBoxUserInformation.Location =
                new Point(3, 102);

            groupBoxPermissionsTabs.Location =
                new Point(361, 102);

            groupBoxPermissionsQuickAccess.Location =
                new Point(361, 238);

            groupBoxPermissionsOperations.Location =
                new Point(361, 338);

            groupBoxRoles.Location =
                new Point(361, 446);

            groupBoxRecoveryInformation.Location =
                new Point(3, 446);

            // GroupBoxes Sizes
            groupBoxUserInformation.Size =
                new Size(356, 321);

            groupBoxPermissionsTabs.Size =
                new Size(270, 114);

            groupBoxPermissionsQuickAccess.Size =
                new Size(270, 57);

            groupBoxPermissionsOperations.Size =
                new Size(270, 85);

            groupBoxRoles.Size =
                new Size(270, 126);

            groupBoxRecoveryInformation.Size =
                new Size(355, 141);

            // Panels width
            panelFullName.Width = 339;
            panelUserName.Width = 339;
            panelPassword.Width = 339;
            panelEmailAddress.Width = 339;
            panelPhoneNumber.Width = 339;

            panelRecoveryQustion.Width = 339;
            panelAnswer.Width = 339;

            // Flow panels
            flowLayoutPanelTabs.FlowDirection =
                FlowDirection.LeftToRight;

            flowLayoutPanelTabs.WrapContents = true;
            flowLayoutPanelTabs.AutoScroll = false;

            flowLayoutPanelPermissionsQuickAccess.FlowDirection =
                FlowDirection.LeftToRight;

            flowLayoutPanelPermissionsQuickAccess.WrapContents =
                true;

            flowLayoutPanelPermissionsOperations.FlowDirection =
                FlowDirection.LeftToRight;

            flowLayoutPanelPermissionsOperations.WrapContents =
                true;

            flowLayoutPanelRoles.FlowDirection =
                FlowDirection.LeftToRight;

            flowLayoutPanelRoles.WrapContents = true;
            flowLayoutPanelRoles.AutoScroll = false;

            // Buttons
            buttonSave.Location =
                new Point(15, 10);

            buttonSave.Size =
                new Size(134, 36);

            buttonSaveAndClose.Location =
                new Point(159, 10);

            buttonSaveAndClose.Size =
                new Size(150, 36);

            // Text Align
            textBoxName.TextAlign =
                HorizontalAlignment.Left;

            textBoxUserName.TextAlign =
                HorizontalAlignment.Left;

            textBoxPassword.TextAlign =
                HorizontalAlignment.Left;

            textBoxEmail.TextAlign =
                HorizontalAlignment.Left;

            textBoxPhoneNumber.TextAlign =
                HorizontalAlignment.Left;

            textBoxAnswer.TextAlign =
                HorizontalAlignment.Left;

            comboBoxSecurityQuestion.RightToLeft =
                RightToLeft.No;

            ResumeLayout();
        }

        private void ApplyRussianLayout()
        {
            SuspendLayout();

            // Form
            Width = 820;
            Height = 690;
            MinimumSize = new Size(820, 690);

            // Title
            labelTitle.Text = "Добавить / Редактировать пользователя";
            labelSubtitle.Text =
                "Введите данные пользователя и определите права доступа";

            labelTitle.Location = new Point(90, 35);
            labelSubtitle.Location = new Point(90, 68);

            // Left column
            groupBoxUserInformation.Location = new Point(15, 105);
            groupBoxUserInformation.Size = new Size(380, 330);

            groupBoxRecoveryInformation.Location = new Point(15, 445);
            groupBoxRecoveryInformation.Size = new Size(380, 160);

            // Right column
            int rightX = 410;

            groupBoxPermissionsTabs.Location = new Point(rightX, 105);
            groupBoxPermissionsTabs.Size = new Size(385, 125);

            groupBoxPermissionsQuickAccess.Location = new Point(rightX, 240);
            groupBoxPermissionsQuickAccess.Size = new Size(385, 100);

            groupBoxPermissionsOperations.Location = new Point(rightX, 350);
            groupBoxPermissionsOperations.Size = new Size(385, 120);

            groupBoxRoles.Location = new Point(rightX, 480);
            groupBoxRoles.Size = new Size(385, 125);

            // User information panels
            int inputWidth = 355;

            panelFullName.Width = inputWidth;
            panelUserName.Width = inputWidth;
            panelPassword.Width = inputWidth;
            panelEmailAddress.Width = inputWidth;
            panelPhoneNumber.Width = inputWidth;

            textBoxName.Width = inputWidth - 5;
            textBoxUserName.Width = inputWidth - 5;
            textBoxPassword.Width = inputWidth - 5;
            textBoxEmail.Width = inputWidth - 5;
            textBoxPhoneNumber.Width = inputWidth - 5;

            // Recovery section
            panelRecoveryQustion.Width = inputWidth;
            panelAnswer.Width = inputWidth;
            comboBoxSecurityQuestion.Width = inputWidth - 2;
            textBoxAnswer.Width = inputWidth - 5;

            // Fix required labels (*)
            labelRequiredFullName.Location =new Point(labelFullName.Right + 3, labelFullName.Top);
            labelRequiredUserName.Location = new Point(labelUserName.Right + 3, labelUserName.Top);
            labelRequiredPassword.Location = new Point(labelPassword.Right + 3, labelPassword.Top);
            labelRequiredRecoveryQuestion.Location = new Point(labelRecveryQuestion.Right + 3, labelRecveryQuestion.Top);
            labelRequiredAnswer.Location = new Point(labelAnswer.Right + 3, labelAnswer.Top);
            labelRequiredPhone.Location = new Point(labelPhoneNumber.Right + 3, labelPhoneNumber.Top);

            // FlowLayout improvements
            ConfigureFlow(flowLayoutPanelTabs);
            ConfigureFlow(flowLayoutPanelPermissionsQuickAccess);
            ConfigureFlow(flowLayoutPanelPermissionsOperations);
            ConfigureFlow(flowLayoutPanelRoles);

            // Buttons panel
            panelBottomButtons.Height = 60;
            buttonSave.Location = new Point(20, 12);
            buttonSave.Size = new Size(150, 40);
            buttonSaveAndClose.Location = new Point(180, 12);
            buttonSaveAndClose.Size = new Size(230, 40);

            // Close button
            buttonCloseWindow.Location = new Point(ClientSize.Width - 35, 0);

            ResumeLayout();
        }

        private void ConfigureFlow(FlowLayoutPanel flow)
        {
            flow.Padding = new Padding(10, 5, 10, 5);
            flow.WrapContents = true;
            flow.AutoScroll = true;
        }   
        #endregion
    }
}
