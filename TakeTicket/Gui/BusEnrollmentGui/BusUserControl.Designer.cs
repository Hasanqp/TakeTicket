namespace TakeTicket.Gui.BusEnrollmentGui
{
    partial class BusUserControl
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            flowLayoutPanelDropDownContainer = new FlowLayoutPanel();
            panelExportButton = new Panel();
            buttonExport = new Button();
            panelExportFormats = new Panel();
            buttonAsXlsx = new Button();
            buttonAsPDF = new Button();
            buttonAsDocx = new Button();
            buttonRefrech = new Button();
            panelSearch = new Panel();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            panel2 = new Panel();
            pictureBoxWhatsAppViewr = new PictureBox();
            dataGridView1 = new DataGridView();
            comboBoxPageNo = new ComboBox();
            timerExport = new System.Windows.Forms.Timer(components);
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanelDropDownContainer.SuspendLayout();
            panelExportButton.SuspendLayout();
            panelExportFormats.SuspendLayout();
            panelSearch.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWhatsAppViewr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.DarkGray;
            flowLayoutPanel1.Controls.Add(buttonAdd);
            flowLayoutPanel1.Controls.Add(buttonEdit);
            flowLayoutPanel1.Controls.Add(buttonDelete);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelDropDownContainer);
            flowLayoutPanel1.Controls.Add(buttonRefrech);
            flowLayoutPanel1.Controls.Add(panelSearch);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1280, 62);
            flowLayoutPanel1.TabIndex = 0;
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
            buttonAdd.Text = "Add";
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
            buttonEdit.Size = new Size(144, 42);
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
            buttonDelete.Location = new Point(339, 10);
            buttonDelete.Margin = new Padding(5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(165, 42);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "    Delete";
            buttonDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // flowLayoutPanelDropDownContainer
            // 
            flowLayoutPanelDropDownContainer.Controls.Add(panelExportButton);
            flowLayoutPanelDropDownContainer.Controls.Add(panelExportFormats);
            flowLayoutPanelDropDownContainer.Location = new Point(512, 8);
            flowLayoutPanelDropDownContainer.MaximumSize = new Size(155, 79);
            flowLayoutPanelDropDownContainer.MinimumSize = new Size(155, 44);
            flowLayoutPanelDropDownContainer.Name = "flowLayoutPanelDropDownContainer";
            flowLayoutPanelDropDownContainer.Size = new Size(155, 44);
            flowLayoutPanelDropDownContainer.TabIndex = 10;
            // 
            // panelExportButton
            // 
            panelExportButton.Controls.Add(buttonExport);
            panelExportButton.Location = new Point(0, 0);
            panelExportButton.Margin = new Padding(0);
            panelExportButton.Name = "panelExportButton";
            panelExportButton.Size = new Size(155, 43);
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
            buttonExport.Location = new Point(1, 1);
            buttonExport.Margin = new Padding(5);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(154, 42);
            buttonExport.TabIndex = 4;
            buttonExport.Text = "    Export";
            buttonExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonExport.UseVisualStyleBackColor = false;
            buttonExport.Click += buttonExport_Click;
            // 
            // panelExportFormats
            // 
            panelExportFormats.Controls.Add(buttonAsXlsx);
            panelExportFormats.Controls.Add(buttonAsPDF);
            panelExportFormats.Controls.Add(buttonAsDocx);
            panelExportFormats.Location = new Point(0, 43);
            panelExportFormats.Margin = new Padding(0);
            panelExportFormats.Name = "panelExportFormats";
            panelExportFormats.Padding = new Padding(1, 0, 1, 0);
            panelExportFormats.Size = new Size(155, 43);
            panelExportFormats.TabIndex = 1;
            // 
            // buttonAsXlsx
            // 
            buttonAsXlsx.BackColor = Color.Transparent;
            buttonAsXlsx.FlatAppearance.BorderSize = 0;
            buttonAsXlsx.FlatStyle = FlatStyle.Flat;
            buttonAsXlsx.Image = Properties.Resources.icons8_xlsx_32;
            buttonAsXlsx.Location = new Point(54, 2);
            buttonAsXlsx.Margin = new Padding(0);
            buttonAsXlsx.Name = "buttonAsXlsx";
            buttonAsXlsx.Size = new Size(49, 30);
            buttonAsXlsx.TabIndex = 11;
            buttonAsXlsx.UseVisualStyleBackColor = false;
            buttonAsXlsx.Click += buttonAsXlsx_Click;
            // 
            // buttonAsPDF
            // 
            buttonAsPDF.BackColor = Color.Transparent;
            buttonAsPDF.FlatAppearance.BorderSize = 0;
            buttonAsPDF.FlatStyle = FlatStyle.Flat;
            buttonAsPDF.Image = Properties.Resources.icons8_pdf_32;
            buttonAsPDF.Location = new Point(102, 2);
            buttonAsPDF.Margin = new Padding(0);
            buttonAsPDF.Name = "buttonAsPDF";
            buttonAsPDF.Size = new Size(49, 30);
            buttonAsPDF.TabIndex = 10;
            buttonAsPDF.Text = "    تصدير";
            buttonAsPDF.UseVisualStyleBackColor = false;
            buttonAsPDF.Click += buttonAsPDF_Click;
            // 
            // buttonAsDocx
            // 
            buttonAsDocx.BackColor = Color.Transparent;
            buttonAsDocx.FlatAppearance.BorderSize = 0;
            buttonAsDocx.FlatStyle = FlatStyle.Flat;
            buttonAsDocx.Image = Properties.Resources.icons8_docx_32;
            buttonAsDocx.Location = new Point(6, 2);
            buttonAsDocx.Margin = new Padding(0);
            buttonAsDocx.Name = "buttonAsDocx";
            buttonAsDocx.Size = new Size(49, 30);
            buttonAsDocx.TabIndex = 12;
            buttonAsDocx.Text = "    تصدير";
            buttonAsDocx.UseVisualStyleBackColor = false;
            buttonAsDocx.Click += buttonAsDocx_Click;
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
            buttonRefrech.Location = new Point(675, 10);
            buttonRefrech.Margin = new Padding(5);
            buttonRefrech.Name = "buttonRefrech";
            buttonRefrech.Size = new Size(165, 42);
            buttonRefrech.TabIndex = 3;
            buttonRefrech.Text = "    Refrech";
            buttonRefrech.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRefrech.UseVisualStyleBackColor = false;
            buttonRefrech.Click += buttonRefrech_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Location = new Point(848, 8);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(406, 44);
            panelSearch.TabIndex = 5;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.Font = new Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.Location = new Point(138, 0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(268, 44);
            textBoxSearch.TabIndex = 5;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.Silver;
            buttonSearch.Dock = DockStyle.Left;
            buttonSearch.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 255);
            buttonSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 255);
            buttonSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Image = Properties.Resources.icons8_search_32px1_back;
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.Location = new Point(0, 0);
            buttonSearch.Margin = new Padding(5);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(138, 44);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "  Search";
            buttonSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBoxWhatsAppViewr);
            panel2.Location = new Point(8, 62);
            panel2.Margin = new Padding(3, 5, 3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(38, 42);
            panel2.TabIndex = 6;
            // 
            // pictureBoxWhatsAppViewr
            // 
            pictureBoxWhatsAppViewr.Dock = DockStyle.Fill;
            pictureBoxWhatsAppViewr.Image = Properties.Resources.icons8_message_32;
            pictureBoxWhatsAppViewr.Location = new Point(0, 0);
            pictureBoxWhatsAppViewr.Name = "pictureBoxWhatsAppViewr";
            pictureBoxWhatsAppViewr.Size = new Size(38, 42);
            pictureBoxWhatsAppViewr.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxWhatsAppViewr.TabIndex = 0;
            pictureBoxWhatsAppViewr.TabStop = false;
            pictureBoxWhatsAppViewr.Click += pictureBoxWhatsApp_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.Size = new Size(1280, 658);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBoxPageNo
            // 
            comboBoxPageNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxPageNo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPageNo.FormattingEnabled = true;
            comboBoxPageNo.Location = new Point(1173, 686);
            comboBoxPageNo.Name = "comboBoxPageNo";
            comboBoxPageNo.Size = new Size(104, 31);
            comboBoxPageNo.TabIndex = 2;
            comboBoxPageNo.SelectedIndexChanged += comboBoxPageNo_SelectedIndexChanged;
            // 
            // timerExport
            // 
            timerExport.Interval = 1;
            timerExport.Tick += timerExport_Tick;
            // 
            // BusUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(comboBoxPageNo);
            Controls.Add(dataGridView1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            Margin = new Padding(4, 5, 4, 5);
            Name = "BusUserControl";
            Size = new Size(1280, 720);
            Load += BusUserControl_Load;
            Leave += BusUserControl_Leave;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanelDropDownContainer.ResumeLayout(false);
            panelExportButton.ResumeLayout(false);
            panelExportFormats.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxWhatsAppViewr).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefrech;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxPageNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxWhatsAppViewr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDropDownContainer;
        private System.Windows.Forms.Panel panelExportButton;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelExportFormats;
        private System.Windows.Forms.Button buttonAsXlsx;
        private System.Windows.Forms.Button buttonAsPDF;
        private System.Windows.Forms.Button buttonAsDocx;
        private System.Windows.Forms.Timer timerExport;
    }
}
