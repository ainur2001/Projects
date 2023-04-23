namespace Handshake
{
    partial class Authorization
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            Message_TextBox = new TextBox();
            Send_Button = new Button();
            Chat_TextBox = new TextBox();
            EDS_Button = new Button();
            SignIn_Button = new Button();
            Password_TextBox = new TextBox();
            label3 = new Label();
            Login_TextBox = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(996, 71);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(65, 17);
            label1.Name = "label1";
            label1.Size = new Size(198, 40);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Controls.Add(Message_TextBox);
            panel2.Controls.Add(Send_Button);
            panel2.Controls.Add(Chat_TextBox);
            panel2.Controls.Add(EDS_Button);
            panel2.Controls.Add(SignIn_Button);
            panel2.Controls.Add(Password_TextBox);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(Login_TextBox);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(996, 385);
            panel2.TabIndex = 0;
            // 
            // Message_TextBox
            // 
            Message_TextBox.Enabled = false;
            Message_TextBox.Location = new Point(515, 237);
            Message_TextBox.Multiline = true;
            Message_TextBox.Name = "Message_TextBox";
            Message_TextBox.ScrollBars = ScrollBars.Vertical;
            Message_TextBox.Size = new Size(405, 58);
            Message_TextBox.TabIndex = 9;
            // 
            // Send_Button
            // 
            Send_Button.BackColor = SystemColors.ButtonShadow;
            Send_Button.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Send_Button.Location = new Point(515, 301);
            Send_Button.Name = "Send_Button";
            Send_Button.Size = new Size(405, 58);
            Send_Button.TabIndex = 8;
            Send_Button.Text = "Send";
            Send_Button.UseVisualStyleBackColor = false;
            Send_Button.Click += Send_Button_Click;
            // 
            // Chat_TextBox
            // 
            Chat_TextBox.Enabled = false;
            Chat_TextBox.Location = new Point(515, 6);
            Chat_TextBox.Multiline = true;
            Chat_TextBox.Name = "Chat_TextBox";
            Chat_TextBox.ScrollBars = ScrollBars.Vertical;
            Chat_TextBox.Size = new Size(405, 225);
            Chat_TextBox.TabIndex = 1;
            // 
            // EDS_Button
            // 
            EDS_Button.BackColor = SystemColors.ButtonShadow;
            EDS_Button.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            EDS_Button.Location = new Point(204, 150);
            EDS_Button.Name = "EDS_Button";
            EDS_Button.Size = new Size(110, 70);
            EDS_Button.TabIndex = 6;
            EDS_Button.Text = "ЭЦП";
            EDS_Button.UseVisualStyleBackColor = false;
            EDS_Button.Click += EDS_Button_Click;
            // 
            // SignIn_Button
            // 
            SignIn_Button.BackColor = SystemColors.ButtonShadow;
            SignIn_Button.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            SignIn_Button.Location = new Point(46, 150);
            SignIn_Button.Name = "SignIn_Button";
            SignIn_Button.Size = new Size(110, 70);
            SignIn_Button.TabIndex = 5;
            SignIn_Button.Text = "Войти";
            SignIn_Button.UseVisualStyleBackColor = false;
            SignIn_Button.Click += SignIn_Button_Click;
            // 
            // Password_TextBox
            // 
            Password_TextBox.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Password_TextBox.Location = new Point(137, 97);
            Password_TextBox.Multiline = true;
            Password_TextBox.Name = "Password_TextBox";
            Password_TextBox.PasswordChar = '*';
            Password_TextBox.Size = new Size(156, 38);
            Password_TextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(31, 97);
            label3.Name = "label3";
            label3.Size = new Size(100, 30);
            label3.TabIndex = 3;
            label3.Text = "Пароль:";
            // 
            // Login_TextBox
            // 
            Login_TextBox.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Login_TextBox.Location = new Point(137, 42);
            Login_TextBox.Multiline = true;
            Login_TextBox.Name = "Login_TextBox";
            Login_TextBox.Size = new Size(156, 38);
            Login_TextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(46, 42);
            label2.Name = "label2";
            label2.Size = new Size(85, 30);
            label2.TabIndex = 1;
            label2.Text = "Логин:";
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(996, 456);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Authorization";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox Password_TextBox;
        private Label label3;
        private TextBox Login_TextBox;
        private Label label2;
        private Button SignIn_Button;
        private Button EDS_Button;
        private TextBox Chat_TextBox;
        private Button Send_Button;
        private TextBox Message_TextBox;
    }
}