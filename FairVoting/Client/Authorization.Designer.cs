namespace Client
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
            label1 = new Label();
            Login_TextBox = new TextBox();
            Password_TextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            Enter_TextBox = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(64, 33);
            label1.Name = "label1";
            label1.Size = new Size(156, 30);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // Login_TextBox
            // 
            Login_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Login_TextBox.Location = new Point(136, 99);
            Login_TextBox.Multiline = true;
            Login_TextBox.Name = "Login_TextBox";
            Login_TextBox.Size = new Size(144, 44);
            Login_TextBox.TabIndex = 1;
            // 
            // Password_TextBox
            // 
            Password_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Password_TextBox.Location = new Point(136, 149);
            Password_TextBox.Multiline = true;
            Password_TextBox.Name = "Password_TextBox";
            Password_TextBox.PasswordChar = '*';
            Password_TextBox.Size = new Size(144, 44);
            Password_TextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(46, 113);
            label2.Name = "label2";
            label2.Size = new Size(84, 30);
            label2.TabIndex = 3;
            label2.Text = "Логин:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(30, 152);
            label3.Name = "label3";
            label3.Size = new Size(100, 30);
            label3.TabIndex = 4;
            label3.Text = "Пароль:";
            // 
            // Enter_TextBox
            // 
            Enter_TextBox.BackColor = SystemColors.ButtonShadow;
            Enter_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            Enter_TextBox.Location = new Point(64, 218);
            Enter_TextBox.Name = "Enter_TextBox";
            Enter_TextBox.Size = new Size(172, 49);
            Enter_TextBox.TabIndex = 5;
            Enter_TextBox.Text = "Войти";
            Enter_TextBox.UseVisualStyleBackColor = false;
            Enter_TextBox.Click += Enter_TextBox_Click;
            // 
            // Authorization
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(292, 319);
            Controls.Add(Enter_TextBox);
            Controls.Add(Password_TextBox);
            Controls.Add(Login_TextBox);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Authorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Login_TextBox;
        private TextBox Password_TextBox;
        private Label label2;
        private Label label3;
        private Button Enter_TextBox;
    }
}