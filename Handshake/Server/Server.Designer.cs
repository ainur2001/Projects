namespace Server
{
    partial class Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label7 = new Label();
            R_Login_TextBox = new TextBox();
            label8 = new Label();
            Password_Textbox = new TextBox();
            label9 = new Label();
            Registration_Button = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Chat_TextBox = new TextBox();
            SendMessage_Button = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(515, 69);
            label7.Name = "label7";
            label7.Size = new Size(158, 35);
            label7.TabIndex = 14;
            label7.Text = "Регистрация";
            // 
            // R_Login_TextBox
            // 
            R_Login_TextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            R_Login_TextBox.Location = new Point(571, 138);
            R_Login_TextBox.Multiline = true;
            R_Login_TextBox.Name = "R_Login_TextBox";
            R_Login_TextBox.Size = new Size(153, 37);
            R_Login_TextBox.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(464, 136);
            label8.Name = "label8";
            label8.Size = new Size(96, 35);
            label8.TabIndex = 16;
            label8.Text = "Логин:";
            // 
            // Password_Textbox
            // 
            Password_Textbox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Password_Textbox.Location = new Point(571, 185);
            Password_Textbox.Multiline = true;
            Password_Textbox.Name = "Password_Textbox";
            Password_Textbox.Size = new Size(153, 37);
            Password_Textbox.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(464, 182);
            label9.Name = "label9";
            label9.Size = new Size(115, 35);
            label9.TabIndex = 18;
            label9.Text = "Пароль:";
            // 
            // Registration_Button
            // 
            Registration_Button.BackColor = SystemColors.ButtonShadow;
            Registration_Button.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Registration_Button.Location = new Point(504, 241);
            Registration_Button.Name = "Registration_Button";
            Registration_Button.Size = new Size(189, 51);
            Registration_Button.TabIndex = 19;
            Registration_Button.Text = "Зарегистрировать";
            Registration_Button.UseVisualStyleBackColor = false;
            Registration_Button.Click += Registration_Button_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
            flowLayoutPanel1.Location = new Point(422, 1);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(12, 380);
            flowLayoutPanel1.TabIndex = 21;
            // 
            // Chat_TextBox
            // 
            Chat_TextBox.Location = new Point(12, 47);
            Chat_TextBox.Multiline = true;
            Chat_TextBox.Name = "Chat_TextBox";
            Chat_TextBox.ReadOnly = true;
            Chat_TextBox.ScrollBars = ScrollBars.Vertical;
            Chat_TextBox.Size = new Size(393, 245);
            Chat_TextBox.TabIndex = 22;
            // 
            // SendMessage_Button
            // 
            SendMessage_Button.Location = new Point(12, 315);
            SendMessage_Button.Name = "SendMessage_Button";
            SendMessage_Button.Size = new Size(393, 52);
            SendMessage_Button.TabIndex = 24;
            SendMessage_Button.Text = "Отправить сообщение";
            SendMessage_Button.UseVisualStyleBackColor = true;
            SendMessage_Button.Click += SendMessage_Button_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(750, 379);
            Controls.Add(SendMessage_Button);
            Controls.Add(Chat_TextBox);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Registration_Button);
            Controls.Add(Password_Textbox);
            Controls.Add(label9);
            Controls.Add(R_Login_TextBox);
            Controls.Add(label8);
            Controls.Add(label7);
            Name = "Server";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private TextBox R_Login_TextBox;
        private Label label8;
        private TextBox Password_Textbox;
        private Label label9;
        private Button Registration_Button;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox Chat_TextBox;
        private Button SendMessage_Button;
    }
}