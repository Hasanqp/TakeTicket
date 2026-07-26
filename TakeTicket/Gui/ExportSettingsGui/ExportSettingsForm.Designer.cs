namespace TakeTicket.Gui.ExportSettingsGui
{
    partial class ExportSettingsForm
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
            cboExportRange = new ComboBox();
            lblExportType = new Label();
            lblPagesPerFile = new Label();
            labelRange = new Label();
            txtCustomRange = new TextBox();
            groupBoxTypeExport = new GroupBox();
            panelPagesPerFile = new Panel();
            txtPagesPerFile = new TextBox();
            labelTodo = new Label();
            panelExportType = new Panel();
            userPanel = new Panel();
            panelTitleBar = new Panel();
            labelCloseWindow = new Label();
            panelHeader = new Panel();
            labelTitle = new Label();
            labelSubtitle = new Label();
            panelIconContainer = new Panel();
            pictureBoxIcon = new PictureBox();
            grpExportType = new GroupBox();
            panelFormatExcel = new Panel();
            labelExcel = new Label();
            pictureBoxExcelIcon = new PictureBox();
            panelFormatWord = new Panel();
            labelWord = new Label();
            pictureBoxWordIcon = new PictureBox();
            panelFormatPdf = new Panel();
            labelPDF = new Label();
            pictureBoxPdfIcon = new PictureBox();
            panel5 = new Panel();
            labelCancel = new Label();
            buttonCancel = new Button();
            pictureBoxRest = new PictureBox();
            buttonRest = new Button();
            panelFormatMarkdown = new Panel();
            labelMarkdown = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel3 = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            textBox2 = new TextBox();
            label3 = new Label();
            groupBoxTypeExport.SuspendLayout();
            panelPagesPerFile.SuspendLayout();
            panelExportType.SuspendLayout();
            userPanel.SuspendLayout();
            panelTitleBar.SuspendLayout();
            panelHeader.SuspendLayout();
            panelIconContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            grpExportType.SuspendLayout();
            panelFormatExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExcelIcon).BeginInit();
            panelFormatWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWordIcon).BeginInit();
            panelFormatPdf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPdfIcon).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRest).BeginInit();
            panelFormatMarkdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // cboExportRange
            // 
            cboExportRange.BackColor = Color.FromArgb(235, 244, 255);
            cboExportRange.FormattingEnabled = true;
            cboExportRange.Items.AddRange(new object[] { "الكل", "الصفحة الحالية", "نطاق مخصص" });
            cboExportRange.Location = new Point(2, 3);
            cboExportRange.Margin = new Padding(4);
            cboExportRange.Name = "cboExportRange";
            cboExportRange.Size = new Size(183, 26);
            cboExportRange.TabIndex = 0;
            // 
            // lblExportType
            // 
            lblExportType.AutoSize = true;
            lblExportType.ForeColor = Color.Black;
            lblExportType.Location = new Point(18, 24);
            lblExportType.Margin = new Padding(4, 0, 4, 0);
            lblExportType.Name = "lblExportType";
            lblExportType.Size = new Size(94, 18);
            lblExportType.TabIndex = 2;
            lblExportType.Text = "Export type: ";
            // 
            // lblPagesPerFile
            // 
            lblPagesPerFile.AutoSize = true;
            lblPagesPerFile.ForeColor = Color.Black;
            lblPagesPerFile.Location = new Point(17, 159);
            lblPagesPerFile.Margin = new Padding(4, 0, 4, 0);
            lblPagesPerFile.Name = "lblPagesPerFile";
            lblPagesPerFile.Size = new Size(195, 18);
            lblPagesPerFile.TabIndex = 2;
            lblPagesPerFile.Text = "Count of pages in every file";
            // 
            // labelRange
            // 
            labelRange.AutoSize = true;
            labelRange.ForeColor = Color.Black;
            labelRange.Location = new Point(16, 86);
            labelRange.Margin = new Padding(4, 0, 4, 0);
            labelRange.Name = "labelRange";
            labelRange.Size = new Size(285, 18);
            labelRange.TabIndex = 2;
            labelRange.Text = "Range (when selecting a specific range)";
            // 
            // txtCustomRange
            // 
            txtCustomRange.BackColor = Color.FromArgb(235, 244, 255);
            txtCustomRange.BorderStyle = BorderStyle.None;
            txtCustomRange.Location = new Point(2, 7);
            txtCustomRange.Name = "txtCustomRange";
            txtCustomRange.Size = new Size(187, 19);
            txtCustomRange.TabIndex = 3;
            // 
            // groupBoxTypeExport
            // 
            groupBoxTypeExport.Controls.Add(panel4);
            groupBoxTypeExport.Controls.Add(label3);
            groupBoxTypeExport.Controls.Add(panel3);
            groupBoxTypeExport.Controls.Add(label2);
            groupBoxTypeExport.Controls.Add(panel2);
            groupBoxTypeExport.Controls.Add(label1);
            groupBoxTypeExport.Controls.Add(panelPagesPerFile);
            groupBoxTypeExport.Controls.Add(labelTodo);
            groupBoxTypeExport.Controls.Add(panelExportType);
            groupBoxTypeExport.Controls.Add(userPanel);
            groupBoxTypeExport.Controls.Add(lblPagesPerFile);
            groupBoxTypeExport.Controls.Add(lblExportType);
            groupBoxTypeExport.Controls.Add(labelRange);
            groupBoxTypeExport.ForeColor = Color.FromArgb(15, 110, 86);
            groupBoxTypeExport.Location = new Point(3, 109);
            groupBoxTypeExport.Name = "groupBoxTypeExport";
            groupBoxTypeExport.RightToLeft = RightToLeft.No;
            groupBoxTypeExport.Size = new Size(512, 227);
            groupBoxTypeExport.TabIndex = 4;
            groupBoxTypeExport.TabStop = false;
            groupBoxTypeExport.Text = "📄 Type Export";
            // 
            // panelPagesPerFile
            // 
            panelPagesPerFile.BackColor = Color.FromArgb(235, 244, 255);
            panelPagesPerFile.Controls.Add(txtPagesPerFile);
            panelPagesPerFile.Location = new Point(15, 179);
            panelPagesPerFile.Name = "panelPagesPerFile";
            panelPagesPerFile.Size = new Size(190, 32);
            panelPagesPerFile.TabIndex = 51;
            // 
            // txtPagesPerFile
            // 
            txtPagesPerFile.BackColor = Color.FromArgb(235, 244, 255);
            txtPagesPerFile.BorderStyle = BorderStyle.None;
            txtPagesPerFile.Location = new Point(2, 7);
            txtPagesPerFile.Name = "txtPagesPerFile";
            txtPagesPerFile.Size = new Size(185, 19);
            txtPagesPerFile.TabIndex = 3;
            // 
            // labelTodo
            // 
            labelTodo.AutoSize = true;
            labelTodo.Font = new Font("Arial", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTodo.ForeColor = Color.Black;
            labelTodo.Location = new Point(195, 11);
            labelTodo.Margin = new Padding(4, 0, 4, 0);
            labelTodo.Name = "labelTodo";
            labelTodo.Size = new Size(100, 33);
            labelTodo.TabIndex = 2;
            labelTodo.Text = "TODO";
            // 
            // panelExportType
            // 
            panelExportType.BackColor = Color.FromArgb(235, 244, 255);
            panelExportType.Controls.Add(txtCustomRange);
            panelExportType.Location = new Point(13, 106);
            panelExportType.Name = "panelExportType";
            panelExportType.Size = new Size(192, 32);
            panelExportType.TabIndex = 51;
            // 
            // userPanel
            // 
            userPanel.BackColor = Color.FromArgb(235, 244, 255);
            userPanel.Controls.Add(cboExportRange);
            userPanel.Location = new Point(15, 44);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(187, 32);
            userPanel.TabIndex = 51;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(15, 110, 86);
            panelTitleBar.Controls.Add(labelCloseWindow);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(515, 24);
            panelTitleBar.TabIndex = 5;
            // 
            // labelCloseWindow
            // 
            labelCloseWindow.AutoSize = true;
            labelCloseWindow.ForeColor = Color.White;
            labelCloseWindow.Location = new Point(493, 3);
            labelCloseWindow.Margin = new Padding(4, 0, 4, 0);
            labelCloseWindow.Name = "labelCloseWindow";
            labelCloseWindow.Size = new Size(19, 18);
            labelCloseWindow.TabIndex = 2;
            labelCloseWindow.Text = "X";
            labelCloseWindow.Click += labelClose_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelSubtitle);
            panelHeader.Controls.Add(panelIconContainer);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(515, 79);
            panelHeader.TabIndex = 6;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(61, 14);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(176, 27);
            labelTitle.TabIndex = 41;
            labelTitle.Text = "Export Settings";
            // 
            // labelSubtitle
            // 
            labelSubtitle.Font = new Font("Arial", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelSubtitle.ForeColor = Color.Black;
            labelSubtitle.Location = new Point(63, 38);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(315, 25);
            labelSubtitle.TabIndex = 42;
            labelSubtitle.Text = "Please select the range and export format";
            // 
            // panelIconContainer
            // 
            panelIconContainer.BackColor = Color.Transparent;
            panelIconContainer.BackgroundImage = Properties.Resources.mega_creator;
            panelIconContainer.BackgroundImageLayout = ImageLayout.Zoom;
            panelIconContainer.Controls.Add(pictureBoxIcon);
            panelIconContainer.ForeColor = Color.FromArgb(230, 241, 251);
            panelIconContainer.Location = new Point(6, 14);
            panelIconContainer.Name = "panelIconContainer";
            panelIconContainer.Size = new Size(51, 48);
            panelIconContainer.TabIndex = 49;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.BackColor = Color.FromArgb(230, 241, 251);
            pictureBoxIcon.Location = new Point(13, 12);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(25, 25);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 0;
            pictureBoxIcon.TabStop = false;
            // 
            // grpExportType
            // 
            grpExportType.Controls.Add(panelFormatMarkdown);
            grpExportType.Controls.Add(panelFormatExcel);
            grpExportType.Controls.Add(panelFormatWord);
            grpExportType.Controls.Add(panelFormatPdf);
            grpExportType.ForeColor = Color.FromArgb(15, 110, 86);
            grpExportType.Location = new Point(3, 337);
            grpExportType.Name = "grpExportType";
            grpExportType.RightToLeft = RightToLeft.No;
            grpExportType.Size = new Size(512, 108);
            grpExportType.TabIndex = 4;
            grpExportType.TabStop = false;
            grpExportType.Text = "📄 File Format";
            // 
            // panelFormatExcel
            // 
            panelFormatExcel.BackColor = Color.FromArgb(232, 245, 238);
            panelFormatExcel.Controls.Add(labelExcel);
            panelFormatExcel.Controls.Add(pictureBoxExcelIcon);
            panelFormatExcel.ForeColor = Color.FromArgb(172, 45, 45);
            panelFormatExcel.Location = new Point(274, 34);
            panelFormatExcel.Name = "panelFormatExcel";
            panelFormatExcel.Size = new Size(85, 64);
            panelFormatExcel.TabIndex = 3;
            // 
            // labelExcel
            // 
            labelExcel.AutoSize = true;
            labelExcel.ForeColor = Color.FromArgb(59, 109, 17);
            labelExcel.Location = new Point(17, 40);
            labelExcel.Name = "labelExcel";
            labelExcel.Size = new Size(46, 18);
            labelExcel.TabIndex = 4;
            labelExcel.Text = "Excel";
            // 
            // pictureBoxExcelIcon
            // 
            pictureBoxExcelIcon.BackColor = Color.FromArgb(232, 245, 238);
            pictureBoxExcelIcon.Location = new Point(28, 10);
            pictureBoxExcelIcon.Name = "pictureBoxExcelIcon";
            pictureBoxExcelIcon.Size = new Size(25, 25);
            pictureBoxExcelIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxExcelIcon.TabIndex = 0;
            pictureBoxExcelIcon.TabStop = false;
            // 
            // panelFormatWord
            // 
            panelFormatWord.BackColor = Color.FromArgb(232, 245, 238);
            panelFormatWord.Controls.Add(labelWord);
            panelFormatWord.Controls.Add(pictureBoxWordIcon);
            panelFormatWord.ForeColor = Color.FromArgb(172, 45, 45);
            panelFormatWord.Location = new Point(142, 34);
            panelFormatWord.Name = "panelFormatWord";
            panelFormatWord.Size = new Size(85, 64);
            panelFormatWord.TabIndex = 3;
            // 
            // labelWord
            // 
            labelWord.AutoSize = true;
            labelWord.ForeColor = Color.FromArgb(97, 121, 191);
            labelWord.Location = new Point(19, 40);
            labelWord.Name = "labelWord";
            labelWord.Size = new Size(46, 18);
            labelWord.TabIndex = 4;
            labelWord.Text = "Word";
            // 
            // pictureBoxWordIcon
            // 
            pictureBoxWordIcon.BackColor = Color.FromArgb(232, 245, 238);
            pictureBoxWordIcon.Location = new Point(28, 10);
            pictureBoxWordIcon.Name = "pictureBoxWordIcon";
            pictureBoxWordIcon.Size = new Size(25, 25);
            pictureBoxWordIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxWordIcon.TabIndex = 0;
            pictureBoxWordIcon.TabStop = false;
            // 
            // panelFormatPdf
            // 
            panelFormatPdf.BackColor = Color.FromArgb(254, 240, 240);
            panelFormatPdf.Controls.Add(labelPDF);
            panelFormatPdf.Controls.Add(pictureBoxPdfIcon);
            panelFormatPdf.ForeColor = Color.FromArgb(172, 45, 45);
            panelFormatPdf.Location = new Point(10, 34);
            panelFormatPdf.Name = "panelFormatPdf";
            panelFormatPdf.Size = new Size(85, 64);
            panelFormatPdf.TabIndex = 3;
            // 
            // labelPDF
            // 
            labelPDF.AutoSize = true;
            labelPDF.Location = new Point(21, 41);
            labelPDF.Name = "labelPDF";
            labelPDF.Size = new Size(41, 18);
            labelPDF.TabIndex = 4;
            labelPDF.Text = "PDF";
            // 
            // pictureBoxPdfIcon
            // 
            pictureBoxPdfIcon.BackColor = Color.FromArgb(254, 240, 240);
            pictureBoxPdfIcon.Location = new Point(28, 10);
            pictureBoxPdfIcon.Name = "pictureBoxPdfIcon";
            pictureBoxPdfIcon.Size = new Size(25, 25);
            pictureBoxPdfIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPdfIcon.TabIndex = 0;
            pictureBoxPdfIcon.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(245, 244, 237);
            panel5.Controls.Add(labelCancel);
            panel5.Controls.Add(buttonCancel);
            panel5.Controls.Add(pictureBoxRest);
            panel5.Controls.Add(buttonRest);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 444);
            panel5.Name = "panel5";
            panel5.Size = new Size(515, 59);
            panel5.TabIndex = 7;
            // 
            // labelCancel
            // 
            labelCancel.AutoSize = true;
            labelCancel.BackColor = Color.White;
            labelCancel.ForeColor = Color.Black;
            labelCancel.Location = new Point(371, 21);
            labelCancel.Margin = new Padding(4, 0, 4, 0);
            labelCancel.Name = "labelCancel";
            labelCancel.Size = new Size(19, 18);
            labelCancel.TabIndex = 47;
            labelCancel.Text = "X";
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.BackgroundImageLayout = ImageLayout.Stretch;
            buttonCancel.FlatAppearance.BorderColor = Color.Gray;
            buttonCancel.FlatAppearance.BorderSize = 2;
            buttonCancel.FlatAppearance.MouseDownBackColor = Color.Gray;
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.ImageAlign = ContentAlignment.MiddleLeft;
            buttonCancel.Location = new Point(346, 11);
            buttonCancel.Margin = new Padding(5);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(148, 38);
            buttonCancel.TabIndex = 46;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // pictureBoxRest
            // 
            pictureBoxRest.BackColor = Color.FromArgb(15, 110, 86);
            pictureBoxRest.Location = new Point(38, 15);
            pictureBoxRest.Name = "pictureBoxRest";
            pictureBoxRest.Size = new Size(29, 32);
            pictureBoxRest.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRest.TabIndex = 45;
            pictureBoxRest.TabStop = false;
            // 
            // buttonRest
            // 
            buttonRest.BackColor = Color.FromArgb(15, 110, 86);
            buttonRest.BackgroundImageLayout = ImageLayout.Stretch;
            buttonRest.FlatAppearance.BorderColor = Color.Gray;
            buttonRest.FlatAppearance.BorderSize = 2;
            buttonRest.FlatAppearance.MouseDownBackColor = Color.Gray;
            buttonRest.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonRest.FlatStyle = FlatStyle.Flat;
            buttonRest.Font = new Font("Arial Narrow", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonRest.ForeColor = Color.White;
            buttonRest.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRest.Location = new Point(22, 11);
            buttonRest.Margin = new Padding(5);
            buttonRest.Name = "buttonRest";
            buttonRest.Size = new Size(148, 38);
            buttonRest.TabIndex = 44;
            buttonRest.Text = "Export";
            buttonRest.UseVisualStyleBackColor = false;
            // 
            // panelFormatMarkdown
            // 
            panelFormatMarkdown.BackColor = Color.FromArgb(232, 245, 238);
            panelFormatMarkdown.Controls.Add(labelMarkdown);
            panelFormatMarkdown.Controls.Add(pictureBox1);
            panelFormatMarkdown.ForeColor = Color.FromArgb(172, 45, 45);
            panelFormatMarkdown.Location = new Point(406, 34);
            panelFormatMarkdown.Name = "panelFormatMarkdown";
            panelFormatMarkdown.Size = new Size(85, 64);
            panelFormatMarkdown.TabIndex = 4;
            // 
            // labelMarkdown
            // 
            labelMarkdown.AutoSize = true;
            labelMarkdown.ForeColor = Color.FromArgb(59, 109, 17);
            labelMarkdown.Location = new Point(3, 40);
            labelMarkdown.Name = "labelMarkdown";
            labelMarkdown.Size = new Size(80, 18);
            labelMarkdown.TabIndex = 4;
            labelMarkdown.Text = "Markdown";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(232, 245, 238);
            pictureBox1.Location = new Point(28, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(235, 244, 255);
            panel2.Controls.Add(comboBox1);
            panel2.Location = new Point(306, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(192, 32);
            panel2.TabIndex = 53;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(235, 244, 255);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "الكل", "الصفحة الحالية", "نطاق مخصص" });
            comboBox1.Location = new Point(2, 3);
            comboBox1.Margin = new Padding(4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(190, 26);
            comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(309, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 18);
            label1.TabIndex = 52;
            label1.Text = "Type Line";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(235, 244, 255);
            panel3.Controls.Add(textBox1);
            panel3.Location = new Point(306, 106);
            panel3.Name = "panel3";
            panel3.Size = new Size(192, 32);
            panel3.TabIndex = 55;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(235, 244, 255);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(2, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 19);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(309, 86);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 18);
            label2.TabIndex = 54;
            label2.Text = "Line size";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(235, 244, 255);
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(306, 179);
            panel4.Name = "panel4";
            panel4.Size = new Size(192, 32);
            panel4.TabIndex = 57;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(235, 244, 255);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(2, 7);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(187, 19);
            textBox2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(309, 159);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(46, 18);
            label3.TabIndex = 56;
            label3.Text = "Color";
            // 
            // ExportSettingsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(515, 503);
            Controls.Add(panel5);
            Controls.Add(panelHeader);
            Controls.Add(panelTitleBar);
            Controls.Add(grpExportType);
            Controls.Add(groupBoxTypeExport);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ExportSettingsForm";
            groupBoxTypeExport.ResumeLayout(false);
            groupBoxTypeExport.PerformLayout();
            panelPagesPerFile.ResumeLayout(false);
            panelPagesPerFile.PerformLayout();
            panelExportType.ResumeLayout(false);
            panelExportType.PerformLayout();
            userPanel.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelIconContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            grpExportType.ResumeLayout(false);
            panelFormatExcel.ResumeLayout(false);
            panelFormatExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxExcelIcon).EndInit();
            panelFormatWord.ResumeLayout(false);
            panelFormatWord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWordIcon).EndInit();
            panelFormatPdf.ResumeLayout(false);
            panelFormatPdf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPdfIcon).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRest).EndInit();
            panelFormatMarkdown.ResumeLayout(false);
            panelFormatMarkdown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox cboExportRange;
        private System.Windows.Forms.Label lblExportType;
        private System.Windows.Forms.Label lblPagesPerFile;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.TextBox txtCustomRange;
        private GroupBox groupBoxTypeExport;
        private Panel panelExportType;
        private Panel userPanel;
        private Panel panelPagesPerFile;
        private TextBox txtPagesPerFile;
        private Panel panelTitleBar;
        private Label labelCloseWindow;
        private Panel panelHeader;
        private GroupBox grpExportType;
        private Label label4;
        private Panel panel5;
        private Button buttonRest;
        private Button buttonCancel;
        private PictureBox pictureBoxRest;
        private Label labelCancel;
        private Label labelTitle;
        private Label labelSubtitle;
        private Panel panelIconContainer;
        private PictureBox pictureBoxIcon;
        private Label labelTodo;
        private Panel panelFormatExcel;
        private Label labelExcel;
        private PictureBox pictureBoxExcelIcon;
        private Panel panelFormatWord;
        private Label labelWord;
        private PictureBox pictureBoxWordIcon;
        private Panel panelFormatPdf;
        private Label labelPDF;
        private PictureBox pictureBoxPdfIcon;
        private Panel panel4;
        private TextBox textBox2;
        private Label label3;
        private Panel panel3;
        private TextBox textBox1;
        private Label label2;
        private Panel panel2;
        private ComboBox comboBox1;
        private Label label1;
        private Panel panelFormatMarkdown;
        private Label labelMarkdown;
        private PictureBox pictureBox1;
    }
}