namespace RSA
{
    partial class Form1
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
            this.NumberBytes_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SourseText_TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Cryptogram_TextBox = new System.Windows.Forms.TextBox();
            this.DecryptedText_TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Encryption_TextBox = new System.Windows.Forms.Button();
            this.Decryption_Button = new System.Windows.Forms.Button();
            this.OpenForm2_Button = new System.Windows.Forms.Button();
            this.d_TextBox = new System.Windows.Forms.TextBox();
            this.e_TextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.fi_TextBox = new System.Windows.Forms.TextBox();
            this.n_TextBox = new System.Windows.Forms.TextBox();
            this.q_TextBox = new System.Windows.Forms.TextBox();
            this.p_TextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Generation_Button = new System.Windows.Forms.Button();
            this.time_TextBox = new System.Windows.Forms.TextBox();
            this.Hack_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumberBytes_TextBox
            // 
            this.NumberBytes_TextBox.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumberBytes_TextBox.Location = new System.Drawing.Point(66, 66);
            this.NumberBytes_TextBox.Name = "NumberBytes_TextBox";
            this.NumberBytes_TextBox.Size = new System.Drawing.Size(113, 45);
            this.NumberBytes_TextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кол-во бит";
            // 
            // SourseText_TextBox
            // 
            this.SourseText_TextBox.Location = new System.Drawing.Point(396, 142);
            this.SourseText_TextBox.Multiline = true;
            this.SourseText_TextBox.Name = "SourseText_TextBox";
            this.SourseText_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SourseText_TextBox.Size = new System.Drawing.Size(210, 138);
            this.SourseText_TextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(423, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 28);
            this.label6.TabIndex = 12;
            this.label6.Text = "Исходный текст";
            // 
            // Cryptogram_TextBox
            // 
            this.Cryptogram_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.Cryptogram_TextBox.Location = new System.Drawing.Point(612, 142);
            this.Cryptogram_TextBox.Multiline = true;
            this.Cryptogram_TextBox.Name = "Cryptogram_TextBox";
            this.Cryptogram_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Cryptogram_TextBox.Size = new System.Drawing.Size(210, 138);
            this.Cryptogram_TextBox.TabIndex = 13;
            // 
            // DecryptedText_TextBox
            // 
            this.DecryptedText_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.DecryptedText_TextBox.Location = new System.Drawing.Point(828, 142);
            this.DecryptedText_TextBox.Multiline = true;
            this.DecryptedText_TextBox.Name = "DecryptedText_TextBox";
            this.DecryptedText_TextBox.ReadOnly = true;
            this.DecryptedText_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DecryptedText_TextBox.Size = new System.Drawing.Size(210, 138);
            this.DecryptedText_TextBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(637, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Криптограмма";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(813, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(229, 28);
            this.label8.TabIndex = 16;
            this.label8.Text = "Расшифрованный текст";
            // 
            // Encryption_TextBox
            // 
            this.Encryption_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Encryption_TextBox.Location = new System.Drawing.Point(396, 286);
            this.Encryption_TextBox.Name = "Encryption_TextBox";
            this.Encryption_TextBox.Size = new System.Drawing.Size(210, 52);
            this.Encryption_TextBox.TabIndex = 17;
            this.Encryption_TextBox.Text = "Зашифровать";
            this.Encryption_TextBox.UseVisualStyleBackColor = true;
            this.Encryption_TextBox.Click += new System.EventHandler(this.Encryption_TextBox_Click);
            // 
            // Decryption_Button
            // 
            this.Decryption_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Decryption_Button.Location = new System.Drawing.Point(612, 286);
            this.Decryption_Button.Name = "Decryption_Button";
            this.Decryption_Button.Size = new System.Drawing.Size(210, 52);
            this.Decryption_Button.TabIndex = 18;
            this.Decryption_Button.Text = "Расшифровать";
            this.Decryption_Button.UseVisualStyleBackColor = true;
            this.Decryption_Button.Click += new System.EventHandler(this.Decryption_Button_Click);
            // 
            // OpenForm2_Button
            // 
            this.OpenForm2_Button.Location = new System.Drawing.Point(946, 380);
            this.OpenForm2_Button.Name = "OpenForm2_Button";
            this.OpenForm2_Button.Size = new System.Drawing.Size(107, 40);
            this.OpenForm2_Button.TabIndex = 23;
            this.OpenForm2_Button.Text = "След. форма";
            this.OpenForm2_Button.UseVisualStyleBackColor = true;
            this.OpenForm2_Button.Click += new System.EventHandler(this.OpenForm2_Click);
            // 
            // d_TextBox
            // 
            this.d_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.d_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.d_TextBox.Location = new System.Drawing.Point(167, 354);
            this.d_TextBox.Name = "d_TextBox";
            this.d_TextBox.ReadOnly = true;
            this.d_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.d_TextBox.Size = new System.Drawing.Size(93, 34);
            this.d_TextBox.TabIndex = 35;
            // 
            // e_TextBox
            // 
            this.e_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.e_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.e_TextBox.Location = new System.Drawing.Point(158, 320);
            this.e_TextBox.Name = "e_TextBox";
            this.e_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.e_TextBox.Size = new System.Drawing.Size(93, 34);
            this.e_TextBox.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(27, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 32);
            this.label11.TabIndex = 33;
            this.label11.Text = "secret exp = ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(27, 318);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 32);
            this.label12.TabIndex = 32;
            this.label12.Text = "open exp = ";
            // 
            // fi_TextBox
            // 
            this.fi_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.fi_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fi_TextBox.Location = new System.Drawing.Point(233, 286);
            this.fi_TextBox.Name = "fi_TextBox";
            this.fi_TextBox.ReadOnly = true;
            this.fi_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.fi_TextBox.Size = new System.Drawing.Size(93, 34);
            this.fi_TextBox.TabIndex = 31;
            // 
            // n_TextBox
            // 
            this.n_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.n_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n_TextBox.Location = new System.Drawing.Point(132, 257);
            this.n_TextBox.Name = "n_TextBox";
            this.n_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.n_TextBox.Size = new System.Drawing.Size(93, 34);
            this.n_TextBox.TabIndex = 30;
            // 
            // q_TextBox
            // 
            this.q_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.q_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.q_TextBox.Location = new System.Drawing.Point(71, 223);
            this.q_TextBox.Name = "q_TextBox";
            this.q_TextBox.ReadOnly = true;
            this.q_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.q_TextBox.Size = new System.Drawing.Size(93, 34);
            this.q_TextBox.TabIndex = 29;
            // 
            // p_TextBox
            // 
            this.p_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.p_TextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.p_TextBox.Location = new System.Drawing.Point(71, 189);
            this.p_TextBox.Name = "p_TextBox";
            this.p_TextBox.ReadOnly = true;
            this.p_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.p_TextBox.Size = new System.Drawing.Size(93, 34);
            this.p_TextBox.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(26, 286);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 32);
            this.label13.TabIndex = 27;
            this.label13.Text = "φ(n) = (p-1)(q-1) = ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(26, 254);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 32);
            this.label14.TabIndex = 26;
            this.label14.Text = "n = pq = ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(26, 222);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 32);
            this.label15.TabIndex = 25;
            this.label15.Text = "q = ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(26, 190);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 32);
            this.label16.TabIndex = 24;
            this.label16.Text = "p = ";
            // 
            // Generation_Button
            // 
            this.Generation_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Generation_Button.Location = new System.Drawing.Point(26, 117);
            this.Generation_Button.Name = "Generation_Button";
            this.Generation_Button.Size = new System.Drawing.Size(198, 70);
            this.Generation_Button.TabIndex = 36;
            this.Generation_Button.Text = "Сгенерировать";
            this.Generation_Button.UseVisualStyleBackColor = true;
            this.Generation_Button.Click += new System.EventHandler(this.Generation_Button_Click);
            // 
            // time_TextBox
            // 
            this.time_TextBox.Location = new System.Drawing.Point(27, 407);
            this.time_TextBox.Multiline = true;
            this.time_TextBox.Name = "time_TextBox";
            this.time_TextBox.Size = new System.Drawing.Size(233, 49);
            this.time_TextBox.TabIndex = 38;
            // 
            // Hack_Button
            // 
            this.Hack_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Hack_Button.Location = new System.Drawing.Point(612, 343);
            this.Hack_Button.Name = "Hack_Button";
            this.Hack_Button.Size = new System.Drawing.Size(210, 52);
            this.Hack_Button.TabIndex = 39;
            this.Hack_Button.Text = "Дешифровать";
            this.Hack_Button.UseVisualStyleBackColor = true;
            this.Hack_Button.Click += new System.EventHandler(this.Hack_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 468);
            this.Controls.Add(this.Hack_Button);
            this.Controls.Add(this.time_TextBox);
            this.Controls.Add(this.Generation_Button);
            this.Controls.Add(this.d_TextBox);
            this.Controls.Add(this.e_TextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.fi_TextBox);
            this.Controls.Add(this.n_TextBox);
            this.Controls.Add(this.q_TextBox);
            this.Controls.Add(this.p_TextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.OpenForm2_Button);
            this.Controls.Add(this.Decryption_Button);
            this.Controls.Add(this.Encryption_TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DecryptedText_TextBox);
            this.Controls.Add(this.Cryptogram_TextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SourseText_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberBytes_TextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox NumberBytes_TextBox;
        private Label label1;
        private TextBox SourseText_TextBox;
        private Label label6;
        private TextBox Cryptogram_TextBox;
        private TextBox DecryptedText_TextBox;
        private Label label7;
        private Label label8;
        private Button Encryption_TextBox;
        private Button Decryption_Button;
        private Button OpenForm2_Button;
        private TextBox d_TextBox;
        private TextBox e_TextBox;
        private Label label11;
        private Label label12;
        private TextBox fi_TextBox;
        private TextBox n_TextBox;
        private TextBox q_TextBox;
        private TextBox p_TextBox;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Button Generation_Button;
        private TextBox time_TextBox;
        private Button Hack_Button;
    }
}