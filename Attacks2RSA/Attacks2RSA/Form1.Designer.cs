namespace Attacks2RSA
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
            SourceText_TextBox = new TextBox();
            Encrypt_Button = new Button();
            label1 = new Label();
            label2 = new Label();
            Decrypt_Button = new Button();
            EncryptedText_TextBox = new TextBox();
            label3 = new Label();
            DecryptedText_TextBox = new TextBox();
            Attack_Button = new Button();
            SelectAttack_ComboBox = new ComboBox();
            ConutBits_TextBox = new TextBox();
            label4 = new Label();
            InitializationRSA_Button = new Button();
            label5 = new Label();
            p_TextBox = new TextBox();
            q_TextBox = new TextBox();
            label6 = new Label();
            n_TextBox = new TextBox();
            label7 = new Label();
            pfi_TextBox = new TextBox();
            label8 = new Label();
            e_TextBox = new TextBox();
            label9 = new Label();
            d_TextBox = new TextBox();
            label10 = new Label();
            Time_Label = new Label();
            OpenHastad_Button = new Button();
            OpenViner_Button = new Button();
            SuspendLayout();
            // 
            // SourceText_TextBox
            // 
            SourceText_TextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            SourceText_TextBox.Location = new Point(57, 91);
            SourceText_TextBox.Multiline = true;
            SourceText_TextBox.Name = "SourceText_TextBox";
            SourceText_TextBox.Size = new Size(212, 191);
            SourceText_TextBox.TabIndex = 0;
            // 
            // Encrypt_Button
            // 
            Encrypt_Button.Location = new Point(57, 288);
            Encrypt_Button.Name = "Encrypt_Button";
            Encrypt_Button.Size = new Size(212, 50);
            Encrypt_Button.TabIndex = 3;
            Encrypt_Button.Text = "Зашифровать";
            Encrypt_Button.UseVisualStyleBackColor = true;
            Encrypt_Button.Click += Encrypt_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(57, 60);
            label1.Name = "label1";
            label1.Size = new Size(212, 28);
            label1.TabIndex = 4;
            label1.Text = "Исходное сообщение";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(330, 60);
            label2.Name = "label2";
            label2.Size = new Size(276, 28);
            label2.TabIndex = 7;
            label2.Text = "Зашифрованное сообщение";
            // 
            // Decrypt_Button
            // 
            Decrypt_Button.Location = new Point(360, 288);
            Decrypt_Button.Name = "Decrypt_Button";
            Decrypt_Button.Size = new Size(118, 50);
            Decrypt_Button.TabIndex = 6;
            Decrypt_Button.Text = "Расшифровать";
            Decrypt_Button.UseVisualStyleBackColor = true;
            Decrypt_Button.Click += Decrypt_Button_Click;
            // 
            // EncryptedText_TextBox
            // 
            EncryptedText_TextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            EncryptedText_TextBox.Location = new Point(360, 91);
            EncryptedText_TextBox.Multiline = true;
            EncryptedText_TextBox.Name = "EncryptedText_TextBox";
            EncryptedText_TextBox.Size = new Size(212, 191);
            EncryptedText_TextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(631, 60);
            label3.Name = "label3";
            label3.Size = new Size(285, 28);
            label3.TabIndex = 10;
            label3.Text = "Расшифрованное сообщение";
            // 
            // DecryptedText_TextBox
            // 
            DecryptedText_TextBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            DecryptedText_TextBox.Location = new Point(671, 91);
            DecryptedText_TextBox.Multiline = true;
            DecryptedText_TextBox.Name = "DecryptedText_TextBox";
            DecryptedText_TextBox.Size = new Size(212, 191);
            DecryptedText_TextBox.TabIndex = 8;
            // 
            // Attack_Button
            // 
            Attack_Button.Location = new Point(484, 288);
            Attack_Button.Name = "Attack_Button";
            Attack_Button.Size = new Size(88, 50);
            Attack_Button.TabIndex = 13;
            Attack_Button.Text = "Декод.";
            Attack_Button.UseVisualStyleBackColor = true;
            Attack_Button.Click += Attack_Button_Click;
            // 
            // SelectAttack_ComboBox
            // 
            SelectAttack_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectAttack_ComboBox.FormattingEnabled = true;
            SelectAttack_ComboBox.Items.AddRange(new object[] { "Ро - метод Полларда", "Ро-1 - метод Полларда", "Полное возведение в степень" });
            SelectAttack_ComboBox.Location = new Point(360, 344);
            SelectAttack_ComboBox.Name = "SelectAttack_ComboBox";
            SelectAttack_ComboBox.Size = new Size(212, 23);
            SelectAttack_ComboBox.TabIndex = 14;
            // 
            // ConutBits_TextBox
            // 
            ConutBits_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ConutBits_TextBox.Location = new Point(152, 23);
            ConutBits_TextBox.Multiline = true;
            ConutBits_TextBox.Name = "ConutBits_TextBox";
            ConutBits_TextBox.Size = new Size(63, 34);
            ConutBits_TextBox.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(37, 23);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 16;
            label4.Text = "Кол-во бит:";
            // 
            // InitializationRSA_Button
            // 
            InitializationRSA_Button.Location = new Point(221, 23);
            InitializationRSA_Button.Name = "InitializationRSA_Button";
            InitializationRSA_Button.Size = new Size(75, 34);
            InitializationRSA_Button.TabIndex = 17;
            InitializationRSA_Button.Text = "OK";
            InitializationRSA_Button.UseVisualStyleBackColor = true;
            InitializationRSA_Button.Click += InitializationRSA_Button_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(57, 376);
            label5.Name = "label5";
            label5.Size = new Size(45, 25);
            label5.TabIndex = 18;
            label5.Text = "p = ";
            // 
            // p_TextBox
            // 
            p_TextBox.BackColor = SystemColors.ControlLightLight;
            p_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            p_TextBox.Location = new Point(93, 371);
            p_TextBox.Multiline = true;
            p_TextBox.Name = "p_TextBox";
            p_TextBox.Size = new Size(790, 34);
            p_TextBox.TabIndex = 19;
            // 
            // q_TextBox
            // 
            q_TextBox.BackColor = SystemColors.ControlLightLight;
            q_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            q_TextBox.Location = new Point(93, 404);
            q_TextBox.Multiline = true;
            q_TextBox.Name = "q_TextBox";
            q_TextBox.Size = new Size(790, 34);
            q_TextBox.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(57, 409);
            label6.Name = "label6";
            label6.Size = new Size(45, 25);
            label6.TabIndex = 20;
            label6.Text = "q = ";
            // 
            // n_TextBox
            // 
            n_TextBox.BackColor = SystemColors.ControlLightLight;
            n_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            n_TextBox.Location = new Point(93, 437);
            n_TextBox.Multiline = true;
            n_TextBox.Name = "n_TextBox";
            n_TextBox.Size = new Size(790, 34);
            n_TextBox.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(57, 442);
            label7.Name = "label7";
            label7.Size = new Size(44, 25);
            label7.TabIndex = 22;
            label7.Text = "n = ";
            // 
            // pfi_TextBox
            // 
            pfi_TextBox.BackColor = SystemColors.ControlLightLight;
            pfi_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            pfi_TextBox.Location = new Point(93, 470);
            pfi_TextBox.Multiline = true;
            pfi_TextBox.Name = "pfi_TextBox";
            pfi_TextBox.Size = new Size(790, 34);
            pfi_TextBox.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(57, 475);
            label8.Name = "label8";
            label8.Size = new Size(47, 25);
            label8.TabIndex = 24;
            label8.Text = "φ = ";
            // 
            // e_TextBox
            // 
            e_TextBox.BackColor = SystemColors.ControlLightLight;
            e_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            e_TextBox.Location = new Point(93, 503);
            e_TextBox.Multiline = true;
            e_TextBox.Name = "e_TextBox";
            e_TextBox.Size = new Size(790, 34);
            e_TextBox.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(57, 508);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 26;
            label9.Text = "e =  ";
            // 
            // d_TextBox
            // 
            d_TextBox.BackColor = SystemColors.ControlLightLight;
            d_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            d_TextBox.Location = new Point(93, 536);
            d_TextBox.Multiline = true;
            d_TextBox.Name = "d_TextBox";
            d_TextBox.Size = new Size(790, 34);
            d_TextBox.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(57, 541);
            label10.Name = "label10";
            label10.Size = new Size(45, 25);
            label10.TabIndex = 28;
            label10.Text = "d = ";
            // 
            // Time_Label
            // 
            Time_Label.AutoSize = true;
            Time_Label.Location = new Point(671, 288);
            Time_Label.Name = "Time_Label";
            Time_Label.Size = new Size(0, 15);
            Time_Label.TabIndex = 30;
            // 
            // OpenHastad_Button
            // 
            OpenHastad_Button.Location = new Point(850, 299);
            OpenHastad_Button.Name = "OpenHastad_Button";
            OpenHastad_Button.Size = new Size(88, 50);
            OpenHastad_Button.TabIndex = 31;
            OpenHastad_Button.Text = "Хастеда";
            OpenHastad_Button.UseVisualStyleBackColor = true;
            OpenHastad_Button.Click += OpenHastad_Button_Click;
            // 
            // OpenViner_Button
            // 
            OpenViner_Button.Location = new Point(767, 299);
            OpenViner_Button.Name = "OpenViner_Button";
            OpenViner_Button.Size = new Size(88, 50);
            OpenViner_Button.TabIndex = 32;
            OpenViner_Button.Text = "Винера";
            OpenViner_Button.UseVisualStyleBackColor = true;
            OpenViner_Button.Click += OpenViner_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 591);
            Controls.Add(OpenViner_Button);
            Controls.Add(OpenHastad_Button);
            Controls.Add(Time_Label);
            Controls.Add(d_TextBox);
            Controls.Add(label10);
            Controls.Add(e_TextBox);
            Controls.Add(pfi_TextBox);
            Controls.Add(label8);
            Controls.Add(n_TextBox);
            Controls.Add(label7);
            Controls.Add(q_TextBox);
            Controls.Add(label6);
            Controls.Add(p_TextBox);
            Controls.Add(label5);
            Controls.Add(InitializationRSA_Button);
            Controls.Add(ConutBits_TextBox);
            Controls.Add(SelectAttack_ComboBox);
            Controls.Add(Attack_Button);
            Controls.Add(label3);
            Controls.Add(DecryptedText_TextBox);
            Controls.Add(label2);
            Controls.Add(Decrypt_Button);
            Controls.Add(EncryptedText_TextBox);
            Controls.Add(label1);
            Controls.Add(Encrypt_Button);
            Controls.Add(SourceText_TextBox);
            Controls.Add(label4);
            Controls.Add(label9);
            Name = "Form1";
            Text = "Attacks2RSA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SourceText_TextBox;
        private Button Encrypt_Button;
        private Label label1;
        private Label label2;
        private Button Decrypt_Button;
        private TextBox EncryptedText_TextBox;
        private Label label3;
        private TextBox DecryptedText_TextBox;
        private Button Attack_Button;
        private ComboBox SelectAttack_ComboBox;
        private TextBox ConutBits_TextBox;
        private Label label4;
        private Button InitializationRSA_Button;
        private Label label5;
        private TextBox p_TextBox;
        private TextBox q_TextBox;
        private Label label6;
        private TextBox n_TextBox;
        private Label label7;
        private TextBox pfi_TextBox;
        private Label label8;
        private TextBox e_TextBox;
        private Label label9;
        private TextBox d_TextBox;
        private Label label10;
        private Label Time_Label;
        private Button OpenHastad_Button;
        private Button OpenViner_Button;
    }
}