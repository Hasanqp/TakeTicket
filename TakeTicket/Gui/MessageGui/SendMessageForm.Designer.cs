namespace TakeTicket.Gui.MessageGui
{
    partial class SendMessageForm
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
            comboBoxMessageType = new ComboBox();
            comboBoxMethod = new ComboBox();
            labelTypeMessage = new Label();
            labelSendMethod = new Label();
            labelTypeMessageStar = new Label();
            labelSendMethodStar = new Label();
            buttonSend = new Button();
            SuspendLayout();
            // 
            // comboBoxMessageType
            // 
            comboBoxMessageType.FormattingEnabled = true;
            comboBoxMessageType.Location = new Point(190, 47);
            comboBoxMessageType.Name = "comboBoxMessageType";
            comboBoxMessageType.Size = new Size(214, 28);
            comboBoxMessageType.TabIndex = 0;
            // 
            // comboBoxMethod
            // 
            comboBoxMethod.FormattingEnabled = true;
            comboBoxMethod.Location = new Point(190, 97);
            comboBoxMethod.Name = "comboBoxMethod";
            comboBoxMethod.Size = new Size(214, 28);
            comboBoxMethod.TabIndex = 0;
            // 
            // labelTypeMessage
            // 
            labelTypeMessage.AutoSize = true;
            labelTypeMessage.CausesValidation = false;
            labelTypeMessage.Location = new Point(19, 47);
            labelTypeMessage.Name = "labelTypeMessage";
            labelTypeMessage.Size = new Size(141, 20);
            labelTypeMessage.TabIndex = 1;
            labelTypeMessage.Text = "Select Message Type";
            // 
            // labelSendMethod
            // 
            labelSendMethod.AutoSize = true;
            labelSendMethod.Location = new Point(19, 100);
            labelSendMethod.Name = "labelSendMethod";
            labelSendMethod.Size = new Size(108, 20);
            labelSendMethod.TabIndex = 1;
            labelSendMethod.Text = "Sending Method";
            // 
            // labelTypeMessageStar
            // 
            labelTypeMessageStar.AutoSize = true;
            labelTypeMessageStar.ForeColor = Color.Red;
            labelTypeMessageStar.Location = new Point(166, 50);
            labelTypeMessageStar.Name = "labelTypeMessageStar";
            labelTypeMessageStar.Size = new Size(14, 20);
            labelTypeMessageStar.TabIndex = 2;
            labelTypeMessageStar.Text = "*";
            // 
            // labelSendMethodStar
            // 
            labelSendMethodStar.AutoSize = true;
            labelSendMethodStar.ForeColor = Color.Red;
            labelSendMethodStar.Location = new Point(133, 100);
            labelSendMethodStar.Name = "labelSendMethodStar";
            labelSendMethodStar.Size = new Size(14, 20);
            labelSendMethodStar.TabIndex = 2;
            labelSendMethodStar.Text = "*";
            // 
            // buttonSend
            // 
            buttonSend.BackColor = Color.White;
            buttonSend.FlatAppearance.BorderColor = Color.Gray;
            buttonSend.FlatAppearance.BorderSize = 2;
            buttonSend.FlatAppearance.MouseDownBackColor = Color.Gray;
            buttonSend.FlatAppearance.MouseOverBackColor = Color.Gray;
            buttonSend.FlatStyle = FlatStyle.Flat;
            buttonSend.Image = Properties.Resources.icons8_log_out_32;
            buttonSend.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSend.Location = new Point(103, 142);
            buttonSend.Margin = new Padding(5);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(214, 51);
            buttonSend.TabIndex = 10;
            buttonSend.Text = "Send ";
            buttonSend.UseVisualStyleBackColor = false;
            buttonSend.Click += buttonSend_Click;
            // 
            // SendMessageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CausesValidation = false;
            ClientSize = new Size(420, 220);
            Controls.Add(buttonSend);
            Controls.Add(labelSendMethodStar);
            Controls.Add(labelTypeMessageStar);
            Controls.Add(labelSendMethod);
            Controls.Add(labelTypeMessage);
            Controls.Add(comboBoxMethod);
            Controls.Add(comboBoxMessageType);
            Font = new Font("Arial Narrow", 12F);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SendMessageForm";
            RightToLeftLayout = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Send Page";
            TopMost = true;
            Load += SendMessageForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMessageType;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.Label labelTypeMessage;
        private System.Windows.Forms.Label labelSendMethod;
        private System.Windows.Forms.Label labelTypeMessageStar;
        private System.Windows.Forms.Label labelSendMethodStar;
        private System.Windows.Forms.Button buttonSend;
    }
}