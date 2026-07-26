namespace TakeTicket.Gui.SystemRecordsGui
{
    partial class SystemRecordsUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            flowLayoutPanelToolbar = new FlowLayoutPanel();
            buttonDelete = new Button();
            buttonRefresh = new Button();
            flowLayoutPanelExportContainer = new FlowLayoutPanel();
            panelExportButton = new Panel();
            buttonExport = new Button();
            panelExportFormats = new Panel();
            buttonExportAsXlsx = new Button();
            buttonExportAsPdf = new Button();
            buttonExportAsDocx = new Button();
            panelSearch = new Panel();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            dataGridViewSystemRecords = new DataGridView();
            comboBoxPageNumber = new ComboBox();
            timerExportDelay = new System.Windows.Forms.Timer(components);
            flowLayoutPanelToolbar.SuspendLayout();
            flowLayoutPanelExportContainer.SuspendLayout();
            panelExportButton.SuspendLayout();
            panelExportFormats.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSystemRecords).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelToolbar
            // 
            flowLayoutPanelToolbar.AutoScroll = true;
            flowLayoutPanelToolbar.BackColor = SystemColors.Control;
            flowLayoutPanelToolbar.Controls.Add(buttonDelete);
            flowLayoutPanelToolbar.Controls.Add(buttonRefresh);
            flowLayoutPanelToolbar.Controls.Add(flowLayoutPanelExportContainer);
            flowLayoutPanelToolbar.Controls.Add(panelSearch);
            flowLayoutPanelToolbar.Dock = DockStyle.Top;
            flowLayoutPanelToolbar.Location = new Point(0, 0);
            flowLayoutPanelToolbar.Name = "flowLayoutPanelToolbar";
            flowLayoutPanelToolbar.Padding = new Padding(5);
            flowLayoutPanelToolbar.Size = new Size(1280, 63);
            flowLayoutPanelToolbar.TabIndex = 0;
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
            buttonDelete.Location = new Point(10, 10);
            buttonDelete.Margin = new Padding(5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(165, 42);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Delete";
            buttonDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.BackColor = Color.White;
            buttonRefresh.FlatAppearance.BorderColor = Color.Teal;
            buttonRefresh.FlatAppearance.BorderSize = 2;
            buttonRefresh.FlatAppearance.MouseDownBackColor = Color.Teal;
            buttonRefresh.FlatAppearance.MouseOverBackColor = Color.Teal;
            buttonRefresh.FlatStyle = FlatStyle.Flat;
            buttonRefresh.Image = Properties.Resources.icons8_update_32px;
            buttonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRefresh.Location = new Point(185, 10);
            buttonRefresh.Margin = new Padding(5);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(165, 42);
            buttonRefresh.TabIndex = 3;
            buttonRefresh.Text = "Refrech";
            buttonRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRefresh.UseVisualStyleBackColor = false;
            buttonRefresh.Click += buttonRefrech_Click;
            // 
            // flowLayoutPanelExportContainer
            // 
            flowLayoutPanelExportContainer.Controls.Add(panelExportButton);
            flowLayoutPanelExportContainer.Controls.Add(panelExportFormats);
            flowLayoutPanelExportContainer.Location = new Point(358, 8);
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
            buttonExport.Location = new Point(0, 1);
            buttonExport.Margin = new Padding(5);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(154, 42);
            buttonExport.TabIndex = 4;
            buttonExport.Text = "Export";
            buttonExport.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonExport.UseVisualStyleBackColor = false;
            buttonExport.Click += buttoneExport_Click;
            // 
            // panelExportFormats
            // 
            panelExportFormats.Controls.Add(buttonExportAsXlsx);
            panelExportFormats.Controls.Add(buttonExportAsPdf);
            panelExportFormats.Controls.Add(buttonExportAsDocx);
            panelExportFormats.Location = new Point(0, 43);
            panelExportFormats.Margin = new Padding(0);
            panelExportFormats.Name = "panelExportFormats";
            panelExportFormats.Padding = new Padding(1, 0, 1, 0);
            panelExportFormats.Size = new Size(155, 43);
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
            buttonExportAsDocx.UseVisualStyleBackColor = false;
            buttonExportAsDocx.Click += buttonAsDocs_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(textBoxSearch);
            panelSearch.Controls.Add(buttonSearch);
            panelSearch.Location = new Point(519, 8);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(404, 44);
            panelSearch.TabIndex = 5;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Dock = DockStyle.Right;
            textBoxSearch.Font = new Font("Arial Narrow", 24F, FontStyle.Bold);
            textBoxSearch.Location = new Point(124, 0);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(280, 44);
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
            buttonSearch.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSearch.Location = new Point(0, 0);
            buttonSearch.Margin = new Padding(5);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(125, 44);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "Search";
            buttonSearch.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // dataGridViewSystemRecords
            // 
            dataGridViewSystemRecords.AllowUserToAddRows = false;
            dataGridViewSystemRecords.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewSystemRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSystemRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSystemRecords.BackgroundColor = Color.White;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridViewSystemRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewSystemRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dataGridViewSystemRecords.DefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewSystemRecords.Dock = DockStyle.Fill;
            dataGridViewSystemRecords.Location = new Point(0, 63);
            dataGridViewSystemRecords.Name = "dataGridViewSystemRecords";
            dataGridViewSystemRecords.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dataGridViewSystemRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewSystemRecords.RowHeadersWidth = 51;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSystemRecords.RowsDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewSystemRecords.Size = new Size(1280, 657);
            dataGridViewSystemRecords.TabIndex = 1;
            dataGridViewSystemRecords.CellContentClick += dataGridView1_CellContentClick;
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
            // SystemRecordsUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(comboBoxPageNumber);
            Controls.Add(dataGridViewSystemRecords);
            Controls.Add(flowLayoutPanelToolbar);
            Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SystemRecordsUserControl";
            Size = new Size(1280, 720);
            flowLayoutPanelToolbar.ResumeLayout(false);
            flowLayoutPanelExportContainer.ResumeLayout(false);
            panelExportButton.ResumeLayout(false);
            panelExportFormats.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSystemRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelToolbar;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewSystemRecords;
        private System.Windows.Forms.ComboBox comboBoxPageNumber;
        private System.Windows.Forms.Timer timerExportDelay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelExportContainer;
        private System.Windows.Forms.Panel panelExportButton;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Panel panelExportFormats;
        private System.Windows.Forms.Button buttonExportAsXlsx;
        private System.Windows.Forms.Button buttonExportAsPdf;
        private System.Windows.Forms.Button buttonExportAsDocx;
    }
}
