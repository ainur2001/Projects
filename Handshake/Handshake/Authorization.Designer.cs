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
            CommonKey_TextBox = new TextBox();
            DiffieHellman_Button = new Button();
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 95);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(74, 23);
            label1.Name = "label1";
            label1.Size = new Size(254, 51);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Controls.Add(CommonKey_TextBox);
            panel2.Controls.Add(DiffieHellman_Button);
            panel2.Controls.Add(EDS_Button);
            panel2.Controls.Add(SignIn_Button);
            panel2.Controls.Add(Password_TextBox);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(Login_TextBox);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 95);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(413, 441);
            panel2.TabIndex = 0;
            // 
            // CommonKey_TextBox
            // 
            CommonKey_TextBox.Location = new Point(42, 301);
            CommonKey_TextBox.Margin = new Padding(3, 4, 3, 4);
            CommonKey_TextBox.Multiline = true;
            CommonKey_TextBox.Name = "CommonKey_TextBox";
            CommonKey_TextBox.Size = new Size(333, 127);
            CommonKey_TextBox.TabIndex = 8;
            // 
            // DiffieHellman_Button
            // 
            DiffieHellman_Button.BackColor = SystemColors.ButtonShadow;
            DiffieHellman_Button.Font = new Font("Comic Sans MS", 10F, FontStyle.Bold, GraphicsUnit.Point);
            DiffieHellman_Button.Location = new Point(272, 200);
            DiffieHellman_Button.Margin = new Padding(3, 4, 3, 4);
            DiffieHellman_Button.Name = "DiffieHellman_Button";
            DiffieHellman_Button.Size = new Size(126, 93);
            DiffieHellman_Button.TabIndex = 7;
            DiffieHellman_Button.Text = "генерация общих ключей";
            DiffieHellman_Button.UseVisualStyleBackColor = false;
            DiffieHellman_Button.Click += DiffieHellman_Button_Click;
            // 
            // EDS_Button
            // 
            EDS_Button.BackColor = SystemColors.ButtonShadow;
            EDS_Button.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            EDS_Button.Location = new Point(139, 200);
            EDS_Button.Margin = new Padding(3, 4, 3, 4);
            EDS_Button.Name = "EDS_Button";
            EDS_Button.Size = new Size(126, 93);
            EDS_Button.TabIndex = 6;
            EDS_Button.Text = "ЭЦП";
            EDS_Button.UseVisualStyleBackColor = false;
            EDS_Button.Click += EDS_Button_Click;
            // 
            // SignIn_Button
            // 
            SignIn_Button.BackColor = SystemColors.ButtonShadow;
            SignIn_Button.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            SignIn_Button.Location = new Point(7, 200);
            SignIn_Button.Margin = new Padding(3, 4, 3, 4);
            SignIn_Button.Name = "SignIn_Button";
            SignIn_Button.Size = new Size(126, 93);
            SignIn_Button.TabIndex = 5;
            SignIn_Button.Text = "Войти";
            SignIn_Button.UseVisualStyleBackColor = false;
            SignIn_Button.Click += SignIn_Button_Click;
            // 
            // Password_TextBox
            // 
            Password_TextBox.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Password_TextBox.Location = new Point(157, 129);
            Password_TextBox.Margin = new Padding(3, 4, 3, 4);
            Password_TextBox.Multiline = true;
            Password_TextBox.Name = "Password_TextBox";
            Password_TextBox.PasswordChar = '*';
            Password_TextBox.Size = new Size(178, 49);
            Password_TextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(35, 129);
            label3.Name = "label3";
            label3.Size = new Size(129, 38);
            label3.TabIndex = 3;
            label3.Text = "Пароль:";
            // 
            // Login_TextBox
            // 
            Login_TextBox.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Login_TextBox.Location = new Point(157, 56);
            Login_TextBox.Margin = new Padding(3, 4, 3, 4);
            Login_TextBox.Multiline = true;
            Login_TextBox.Name = "Login_TextBox";
            Login_TextBox.Size = new Size(178, 49);
            Login_TextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(53, 56);
            label2.Name = "label2";
            label2.Size = new Size(110, 38);
            label2.TabIndex = 1;
            label2.Text = "Логин:";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 536);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Client";
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
        private Button DiffieHellman_Button;
        private TextBox CommonKey_TextBox;
    }
}