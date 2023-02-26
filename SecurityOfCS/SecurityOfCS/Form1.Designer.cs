namespace SecurityOfCS
{
    partial class Registration
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Registration_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.Login_TextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 94);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(48, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.Registration_Button);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.Password_TextBox);
            this.panel3.Controls.Add(this.Login_TextBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 262);
            this.panel3.TabIndex = 1;
            // 
            // Registration_Button
            // 
            this.Registration_Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Registration_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Registration_Button.Location = new System.Drawing.Point(76, 179);
            this.Registration_Button.Name = "Registration_Button";
            this.Registration_Button.Size = new System.Drawing.Size(187, 47);
            this.Registration_Button.TabIndex = 4;
            this.Registration_Button.Text = "Зарегистрироваться";
            this.Registration_Button.UseVisualStyleBackColor = false;
            this.Registration_Button.Click += new System.EventHandler(this.Registration_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(31, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(42, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Логин:";
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Password_TextBox.Location = new System.Drawing.Point(141, 112);
            this.Password_TextBox.Multiline = true;
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(176, 39);
            this.Password_TextBox.TabIndex = 1;
            // 
            // Login_TextBox
            // 
            this.Login_TextBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Login_TextBox.Location = new System.Drawing.Point(141, 49);
            this.Login_TextBox.Multiline = true;
            this.Login_TextBox.Name = "Login_TextBox";
            this.Login_TextBox.Size = new System.Drawing.Size(176, 39);
            this.Login_TextBox.TabIndex = 0;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 356);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Registration";
            this.Text = "Регистрация";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private Button Registration_Button;
        private Label label3;
        private Label label2;
        private TextBox Password_TextBox;
        private TextBox Login_TextBox;
    }
}