﻿namespace Client
{
    partial class Chat
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
            SendMessage_Button = new Button();
            Message_TextBox = new TextBox();
            SuspendLayout();
            // 
            // Chat_TextBox
            // 
            Chat_TextBox.Location = new Point(28, 12);
            Chat_TextBox.Multiline = true;
            Chat_TextBox.Name = "Chat_TextBox";
            Chat_TextBox.Size = new Size(315, 386);
            Chat_TextBox.TabIndex = 0;
            // 
            // SendMessage_Button
            // 
            SendMessage_Button.Location = new Point(28, 460);
            SendMessage_Button.Name = "SendMessage_Button";
            SendMessage_Button.Size = new Size(315, 46);
            SendMessage_Button.TabIndex = 1;
            SendMessage_Button.Text = "Отправить сообщение";
            SendMessage_Button.UseVisualStyleBackColor = true;
            SendMessage_Button.Click += SendMessage_Button_Click;
            // 
            // Message_TextBox
            // 
            Message_TextBox.Location = new Point(28, 404);
            Message_TextBox.Multiline = true;
            Message_TextBox.Name = "Message_TextBox";
            Message_TextBox.Size = new Size(315, 50);
            Message_TextBox.TabIndex = 2;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 529);
            Controls.Add(Message_TextBox);
            Controls.Add(SendMessage_Button);
            Controls.Add(Chat_TextBox);
            Name = "Chat";
            Text = "Chat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Chat_TextBox;
        private Button SendMessage_Button;
        private TextBox Message_TextBox;
    }
}