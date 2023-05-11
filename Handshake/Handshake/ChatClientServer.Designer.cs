namespace Client
{
    partial class ChatClientServer
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
            Chat_TextBox = new TextBox();
            Message_TextBox = new TextBox();
            SendMessage_Button = new Button();
            EDS_Button = new Button();
            CommonKey_Label = new Label();
            SuspendLayout();
            // 
            // Chat_TextBox
            // 
            Chat_TextBox.BackColor = SystemColors.ControlLightLight;
            Chat_TextBox.Location = new Point(12, 31);
            Chat_TextBox.Multiline = true;
            Chat_TextBox.Name = "Chat_TextBox";
            Chat_TextBox.ReadOnly = true;
            Chat_TextBox.ScrollBars = ScrollBars.Vertical;
            Chat_TextBox.Size = new Size(370, 346);
            Chat_TextBox.TabIndex = 0;
            // 
            // Message_TextBox
            // 
            Message_TextBox.Location = new Point(12, 383);
            Message_TextBox.Multiline = true;
            Message_TextBox.Name = "Message_TextBox";
            Message_TextBox.Size = new Size(370, 57);
            Message_TextBox.TabIndex = 1;
            // 
            // SendMessage_Button
            // 
            SendMessage_Button.Location = new Point(12, 446);
            SendMessage_Button.Name = "SendMessage_Button";
            SendMessage_Button.Size = new Size(257, 60);
            SendMessage_Button.TabIndex = 2;
            SendMessage_Button.Text = "Отправить";
            SendMessage_Button.UseVisualStyleBackColor = true;
            SendMessage_Button.Click += SendMessage_Button_Click;
            // 
            // EDS_Button
            // 
            EDS_Button.Location = new Point(275, 446);
            EDS_Button.Name = "EDS_Button";
            EDS_Button.Size = new Size(107, 60);
            EDS_Button.TabIndex = 3;
            EDS_Button.Text = "ЭЦП";
            EDS_Button.UseVisualStyleBackColor = true;
            EDS_Button.Click += EDS_Button_Click;
            // 
            // CommonKey_Label
            // 
            CommonKey_Label.AutoSize = true;
            CommonKey_Label.Location = new Point(15, 9);
            CommonKey_Label.Name = "CommonKey_Label";
            CommonKey_Label.Size = new Size(0, 15);
            CommonKey_Label.TabIndex = 4;
            // 
            // ChatClientServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 518);
            Controls.Add(CommonKey_Label);
            Controls.Add(EDS_Button);
            Controls.Add(SendMessage_Button);
            Controls.Add(Message_TextBox);
            Controls.Add(Chat_TextBox);
            Name = "ChatClientServer";
            Text = "ChatClientServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Chat_TextBox;
        private TextBox Message_TextBox;
        private Button SendMessage_Button;
        private Button EDS_Button;
        private Label CommonKey_Label;
    }
}