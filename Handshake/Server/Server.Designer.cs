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
            this.label7 = new System.Windows.Forms.Label();
            this.R_Login_TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Password_Textbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Registration_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
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
            this.Name = "Server";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label7;
        private TextBox R_Login_TextBox;
        private Label label8;
        private TextBox Password_Textbox;
        private Label label9;
        private Button Registration_Button;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}