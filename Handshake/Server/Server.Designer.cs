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
            this.Login_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HashPW_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HashSalt_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.T_server_TextBox = new System.Windows.Forms.TextBox();
            this.T_client_TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.R_Login_TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Registration_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Login_TextBox
            // 
            this.Login_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Login_TextBox.Location = new System.Drawing.Point(109, 101);
            this.Login_TextBox.Multiline = true;
            this.Login_TextBox.Name = "Login_TextBox";
            this.Login_TextBox.ReadOnly = true;
            this.Login_TextBox.Size = new System.Drawing.Size(153, 37);
            this.Login_TextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин:";
            // 
            // HashPW_TextBox
            // 
            this.HashPW_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HashPW_TextBox.Location = new System.Drawing.Point(149, 149);
            this.HashPW_TextBox.Multiline = true;
            this.HashPW_TextBox.Name = "HashPW_TextBox";
            this.HashPW_TextBox.ReadOnly = true;
            this.HashPW_TextBox.Size = new System.Drawing.Size(147, 37);
            this.HashPW_TextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(18, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "hash(PW):";
            // 
            // HashSalt_TextBox
            // 
            this.HashSalt_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HashSalt_TextBox.Location = new System.Drawing.Point(157, 194);
            this.HashSalt_TextBox.Multiline = true;
            this.HashSalt_TextBox.Name = "HashSalt_TextBox";
            this.HashSalt_TextBox.ReadOnly = true;
            this.HashSalt_TextBox.Size = new System.Drawing.Size(139, 37);
            this.HashSalt_TextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 35);
            this.label4.TabIndex = 7;
            this.label4.Text = "hash(Salt):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(19, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 35);
            this.label2.TabIndex = 8;
            this.label2.Text = "T= ";
            // 
            // T_server_TextBox
            // 
            this.T_server_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.T_server_TextBox.Location = new System.Drawing.Point(69, 283);
            this.T_server_TextBox.Multiline = true;
            this.T_server_TextBox.Name = "T_server_TextBox";
            this.T_server_TextBox.ReadOnly = true;
            this.T_server_TextBox.Size = new System.Drawing.Size(215, 37);
            this.T_server_TextBox.TabIndex = 9;
            // 
            // T_client_TextBox
            // 
            this.T_client_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.T_client_TextBox.Location = new System.Drawing.Point(69, 237);
            this.T_client_TextBox.Multiline = true;
            this.T_client_TextBox.Name = "T_client_TextBox";
            this.T_client_TextBox.ReadOnly = true;
            this.T_client_TextBox.Size = new System.Drawing.Size(215, 37);
            this.T_client_TextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(19, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 35);
            this.label5.TabIndex = 11;
            this.label5.Text = "T\'= ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(52, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 35);
            this.label6.TabIndex = 13;
            this.label6.Text = "Аутентификация";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(515, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 35);
            this.label7.TabIndex = 14;
            this.label7.Text = "Регистрация";
            // 
            // R_Login_TextBox
            // 
            this.R_Login_TextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.R_Login_TextBox.Location = new System.Drawing.Point(571, 138);
            this.R_Login_TextBox.Multiline = true;
            this.R_Login_TextBox.Name = "R_Login_TextBox";
            this.R_Login_TextBox.Size = new System.Drawing.Size(153, 37);
            this.R_Login_TextBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(464, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 35);
            this.label8.TabIndex = 16;
            this.label8.Text = "Логин:";
            // 
            // Password_Textbox
            // 
            this.Password_Textbox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Password_Textbox.Location = new System.Drawing.Point(571, 185);
            this.Password_Textbox.Multiline = true;
            this.Password_Textbox.Name = "Password_Textbox";
            this.Password_Textbox.Size = new System.Drawing.Size(153, 37);
            this.Password_Textbox.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(464, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 35);
            this.label9.TabIndex = 18;
            this.label9.Text = "Пароль:";
            // 
            // Registration_Button
            // 
            this.Registration_Button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Registration_Button.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Registration_Button.Location = new System.Drawing.Point(504, 241);
            this.Registration_Button.Name = "Registration_Button";
            this.Registration_Button.Size = new System.Drawing.Size(189, 51);
            this.Registration_Button.TabIndex = 19;
            this.Registration_Button.Text = "Зарегистрировать";
            this.Registration_Button.UseVisualStyleBackColor = false;
            this.Registration_Button.Click += new System.EventHandler(this.Registration_Button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(422, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(12, 347);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(750, 347);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Registration_Button);
            this.Controls.Add(this.Password_Textbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.R_Login_TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.T_client_TextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.T_server_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HashSalt_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HashPW_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Login_TextBox);
            this.Controls.Add(this.label1);
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Login_TextBox;
        private Label label1;
        private TextBox HashPW_TextBox;
        private Label label3;
        private TextBox HashSalt_TextBox;
        private Label label4;
        private Label label2;
        private TextBox T_server_TextBox;
        private TextBox T_client_TextBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox R_Login_TextBox;
        private Label label8;
        private TextBox Password_Textbox;
        private Label label9;
        private Button Registration_Button;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}