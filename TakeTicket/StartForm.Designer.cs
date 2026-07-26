namespace TakeTicket
{
    partial class StartForm
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
            pictureBox1 = new System.Windows.Forms.PictureBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            label1 = new System.Windows.Forms.Label();
            labelState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.mobile_application_buying_tickets_online_600nw;
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(600, 300);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(12, 346);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(600, 29);
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            label1.Location = new System.Drawing.Point(457, 378);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(155, 18);
            label1.TabIndex = 2;
            label1.Text = "جميع الحقوق محفوظة 2024";
            // 
            // labelState
            // 
            labelState.AutoSize = true;
            labelState.ForeColor = System.Drawing.Color.Black;
            labelState.Location = new System.Drawing.Point(12, 325);
            labelState.Name = "labelState";
            labelState.Size = new System.Drawing.Size(36, 18);
            labelState.TabIndex = 2;
            labelState.Text = "البداية";
            // 
            // StartForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(624, 407);
            Controls.Add(labelState);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "StartForm";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "البداية";
            Load += StartForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelState;
    }
}