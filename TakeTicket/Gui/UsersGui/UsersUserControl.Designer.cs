namespace TakeTicket.Gui.UsersGui
{
    partial class UsersUserControl
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            flowLayoutPanelToolbar = new FlowLayoutPanel();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            flowLayoutPanelExportContainer = new FlowLayoutPanel();
            panelExportButton = new Panel();
            buttonExport = new Button();
            panelExportFormats = new Panel();
            buttonExportAsXlsx = new Button();
            buttonExportAsPdf = new Button();
            buttonExportAsDocx = new Button();
            buttonRefrech = new Button();
            panelSearch = new Panel();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            dataGridViewUsers = new DataGridView();
            comboBoxPageNumber = new ComboBox();
            timerExportDelay = new System.Windows.Forms.Timer(components);
            flowLayoutPanelToolbar.SuspendLayout();
            flowLayoutPanelExportContainer.SuspendLayout();
            panelExportButton.SuspendLayout();
            panelExportFormats.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelToolbar
            // 
            flowLayoutPanelToolbar.AutoScroll = true;
            flowLayoutPanelToolbar.BackColor = SystemColors.Control;
            flowLayoutPanelToolbar.Controls.Add(buttonAdd);
            flowLayoutPanelToolbar.Controls.Add(buttonEdit);
            flowLayoutPanelToolbar.Controls.Add(buttonDelete);
            flowLayoutPanelToolbar.Controls.Add(flowLayoutPanelExportContainer);
            flowLayoutPanelToolbar.Controls.Add(buttonRefrech);
            flowLayoutPanelToolbar.Controls.Add(panelSearch);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;
            flowLayoutPanelToolbar.Location = new Point(0, 0);
            flowLayoutPanelToolbar.Name = "flowLayoutPanelToolbar";
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.RightToLeft = RightToLeft.No;
            flowLayoutPanelToolbar.Size = new Size(1280, 63);
            flowLayoutPanelToolbar.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.White;
            buttonAdd.FlatAppearance.BorderColor = Color.MediumAquamarine;
            buttonAdd.FlatAppearance.BorderSize = 2;
            buttonAdd.FlatAppearance.MouseDownBackColor = Color.MediumAquamarine;
            buttonAdd.FlatAppearance.MouseOverBackColor = Color.MediumAquamarine;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Image = Properties.Resources.plus;
            buttonAdd.ImageAlign = ContentAlignment.MiddleLeft;
            buttonAdd.Location = new Point(10, 10);
            buttonAdd.Margin = new Padding(5);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(165, 42);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "    Add";
            buttonAdd.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.White;
            buttonEdit.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            buttonEdit.FlatAppearance.BorderSize = 2;
            buttonEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            buttonEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Image = Properties.Resources.icons8_edit_32px;
            buttonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            buttonEdit.Location = new Point(185, 10);
            buttonEdit.Margin = new Padding(5);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(165, 42);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "    Edit";
            buttonEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonEdit.UseVisualStyleBackColor = false;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.White;
            buttonDelete.FlatAppearance.BorderColor = Color.Red;
            buttonDelete.FlatAppearance.BorderSize = 2;
            buttonDelete.FlatAppearance.MouseDownBackColor = Color.Red;
            buttonDelete.FlatAppearance.MouseOverBackColor = Color.Red;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Image = Properties.Resources.Delete_32px;
            buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDelete.Location = new Point(360, 10);
            buttonDelete.Margin = new Padding(5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(165, 42);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "    Delete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // flowLayoutPanelExportContainer
            // 
            flowLayoutPanelExportContainer.Controls.Add(panelExportButton);
            flowLayoutPanelExportContainer.Controls.Add(panelExportFormats);
            flowLayoutPanelExportContainer.Location = new Point(533, 8);
            flowLayoutPanelExportContainer.MaximumSize = new Size(155, 79);
            flowLayoutPanelExportContainer.MinimumSize = new Size(155, 44);
            flowLayoutPanelExportContainer.Name = "flowLayoutPanelExportContainer";
            flowLayoutPanelExportContainer.Size = new Size(155, 44);
            flowLayoutPanelExportContainer.TabIndex = 10;
            // 
            // panelExportButton
            // 
            panelExportButton.Controls.Add(buttonExport);
            panelExportButton.Location = new Point(0, 0);
            panelExportButton.Margin = new Padding(0);
            panelExportButton.Name = "panelExportButton";
            panelExportButton.Size = new Size(155, 44);
            panelExportButton.TabIndex = 0;
            // 
            // buttonExport
            // 
            buttonExport.BackColor = Color.White;
            buttonExport.FlatAppearance.BorderColor = Color.LightSlateGray;
            buttonExport.FlatAppearance.BorderSize = 2;
            buttonExport.FlatAppearance.MouseDownBackColor = Color.LightSlateGray;
            buttonExport.FlatAppearance.MouseOverBackColor = Color.LightSlateGray;
            buttonExport.FlatStyle = FlatStyle.Flat;
            buttonExport.Image = Properties.Resources.export;
            buttonExport.ImageAlign = ContentAlignment.MiddleLeft;
            buttonExport.Location = new Point(0, 1);
            buttonExport.Margin = new Padding(5);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(155, 42);
            buttonExport.TabIndex = 4;
            buttonExport.Text = "     Export";
            buttonExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonExport.UseVisualStyleBackColor = false;
            buttonExport.Click += buttonExport_Click;
            // 
            // panelExportFormats
            // 
            panelExportFormats.Controls.Add(buttonExportAsXlsx);
            panelExportFormats.Controls.Add(buttonExportAsPdf);
            panelExportFormats.Controls.Add(buttonExportAsDocx);
            panelExportFormats.Location = new Point(0, 44);
            panelExportFormats.Margin = new Padding(0);
            panelExportFormats.Name = "panelExportFormats";
            panelExportFormats.Padding = new Padding(1, 0, 1, 0);
            panelExportFormats.Size = new Size(155, 35);
            panelExportFormats.TabIndex = 1;
            // 
            // buttonExportAsXlsx
            // 
            buttonExportAsXlsx.BackColor = Color.Transparent;
            buttonExportAsXlsx.FlatAppearance.BorderSize = 0;
            buttonExportAsXlsx.FlatStyle = FlatStyle.Flat;
            buttonExportAsXlsx.Image = Properties.Resources.icons8_xlsx_32;
            buttonExportAsXlsx.Location = new Point(54, 2);
            buttonExportAsXlsx.Margin = new Padding(0);
            buttonExportAsXlsx.Name = "buttonExportAsXlsx";
            buttonExportAsXlsx.Size = new Size(49, 30);
            buttonExportAsXlsx.TabIndex = 11;
            buttonExportAsXlsx.UseVisualStyleBackColor = false;
            buttonExportAsXlsx.Click += buttonAsXlsx_Click;
            // 
            // buttonExportAsPdf
            // 
            buttonExportAsPdf.BackColor = Color.Transparent;
            buttonExportAsPdf.FlatAppearance.BorderSize = 0;
            buttonExportAsPdf.FlatStyle = FlatStyle.Flat;
            buttonExportAsPdf.Image = Properties.Resources.icons8_pdf_32;
            buttonExportAsPdf.Location = new Point(102, 2);
            buttonExportAsPdf.Margin = new Padding(0);
            buttonExportAsPdf.Name = "buttonExportAsPdf";
            buttonExportAsPdf.Size = new Size(49, 30);
            buttonExportAsPdf.TabIndex = 10;
            buttonExportAsPdf.Text = "    تصدير";
            buttonExportAsPdf.UseVisualStyleBackColor = false;
            buttonExportAsPdf.Click += buttonAsPDF_Click;
            // 
            // buttonExportAsDocx
            // 
            buttonExportAsDocx.BackColor = Color.Transparent;
            buttonExportAsDocx.FlatAppearance.BorderSize = 0;
            buttonExportAsDocx.FlatStyle = FlatStyle.Flat;
            buttonExportAsDocx.Image = Properties.Resources.icons8_docx_32;
            buttonExportAsDocx.Location = new Point(6, 2);
            buttonExportAsDocx.Margin = new Padding(0);
            buttonExportAsDocx.Name = "buttonExportAsDocx";
            buttonExportAsDocx.Size = new Size(49, 30);
            buttonExportAsDocx.TabIndex = 12;
            buttonExportAsDocx.Text = "    تصدير";
            buttonExportAsDocx.UseVisualStyleBackColor = false;
            buttonExportAsDocx.Click += buttonAsDocx_Click;
            // 
            // buttonRefrech
            // 
            buttonRefrech.BackColor = Color.White;
            buttonRefrech.FlatAppearance.BorderColor = Color.Teal;
            buttonRefrech.FlatAppearance.BorderSize = 2;
            buttonRefrech.FlatAppearance.MouseDownBackColor = Color.Teal;
            buttonRefrech.FlatAppearance.MouseOverBackColor = Color.Teal;
            buttonRefrech.FlatStyle = FlatStyle.Flat;
            buttonRefrech.Image = Properties.Resources.icons8_update_32px;
            buttonRefrech.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefrech.Location = new Point(696, 10);
            buttonRefrech.Margin = new Padding(5);
            buttonRefrech.Name = "buttonRefrech";
            buttonRefrech.Size = new Size(165, 42);
            buttonRefrech.TabIndex = 3;
            buttonRefrech.Text = "    Refresh";
            buttonRefrech.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRefrech.UseVisualStyleBackColor = false;
            buttonRefrech.Click += buttonRefrech_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Location = new Point(8, 60);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(404, 44);
            panelSearch.TabIndex = 5;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.Font = new Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.Location = new Point(136, 0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(268, 44);
            textBoxSearch.TabIndex = 5;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.LightSeaGreen;
            buttonSearch.Dock = DockStyle.Left;
            buttonSearch.FlatAppearance.BorderColor = Color.LightSeaGreen;
            buttonSearch.FlatAppearance.BorderSize = 2;
            buttonSearch.FlatAppearance.MouseDownBackColor = Color.LightSeaGreen;
            buttonSearch.FlatAppearance.MouseOverBackColor = Color.LightSeaGreen;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Image = Properties.Resources.icons8_search_32px1_back;
            buttonSearch.ImageAlign = ContentAlignment.MiddleRight;
            buttonSearch.Location = new Point(0, 0);
            buttonSearch.Margin = new Padding(5);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(138, 44);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "Search      ";
            buttonSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewUsers.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(0, 63);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewUsers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewUsers.Size = new Size(1280, 657);
            dataGridViewUsers.TabIndex = 1;
            dataGridViewUsers.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBoxPageNumber
            // 
            comboBoxPageNumber.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNumber.FormattingEnabled = true;
            comboBoxPageNumber.Location = new Point(1173, 686);
            comboBoxPageNumber.Name = "comboBoxPageNumber";
            comboBoxPageNumber.Size = new Size(104, 31);
            comboBoxPageNumber.TabIndex = 2;
            comboBoxPageNumber.SelectedIndexChanged += comboBoxPageNo_SelectedIndexChanged;
            // 
            // timerExportDelay
            // 
            timerExportDelay.Interval = 1;
            timerExportDelay.Tick += timerExport_Tick;
            // 
            // UsersUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(comboBoxPageNumber);
            Controls.Add(dataGridViewUsers);
            Controls.Add(flowLayoutPanelToolbar);
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UsersUserControl";
            Size = new Size(1280, 720);
            flowLayoutPanelToolbar.ResumeLayout(false);
            flowLayoutPanelExportContainer.ResumeLayout(false);
            panelExportButton.ResumeLayout(false);
            panelExportFormats.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelToolbar;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefrech;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.ComboBox comboBoxPageNumber;
        private System.Windows.Forms.Timer timerExportDelay;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelExportContainer;
        private System.Windows.Forms.Panel panelExportButton;
        private System.Windows.Forms.Panel panelExportFormats;
        private System.Windows.Forms.Button buttonExportAsXlsx;
        private System.Windows.Forms.Button buttonExportAsPdf;
        private System.Windows.Forms.Button buttonExportAsDocx;
    }
}
