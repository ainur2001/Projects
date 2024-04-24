namespace Attacks2RSA
{
    partial class Form3
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
            GenerateOpenAndCloseKeys_Button = new Button();
            n_TextBox = new TextBox();
            label10 = new Label();
            e_TextBox = new TextBox();
            label9 = new Label();
            Message_TextBox = new TextBox();
            Encrypt_Button = new Button();
            d_TextBox = new TextBox();
            label1 = new Label();
            EncryptedText_TextBox = new TextBox();
            Decrypt_Button = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            DecryptedText_TextBox = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // GenerateOpenAndCloseKeys_Button
            // 
            GenerateOpenAndCloseKeys_Button.Location = new Point(61, 319);
            GenerateOpenAndCloseKeys_Button.Name = "GenerateOpenAndCloseKeys_Button";
            GenerateOpenAndCloseKeys_Button.Size = new Size(221, 63);
            GenerateOpenAndCloseKeys_Button.TabIndex = 0;
            GenerateOpenAndCloseKeys_Button.Text = "Сгенерировать открытый ключ";
            GenerateOpenAndCloseKeys_Button.UseVisualStyleBackColor = true;
            GenerateOpenAndCloseKeys_Button.Click += GenerateOpenAndCloseKeys_Button_Click;
            // 
            // n_TextBox
            // 
            n_TextBox.BackColor = SystemColors.ControlLightLight;
            n_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            n_TextBox.Location = new Point(61, 445);
            n_TextBox.Margin = new Padding(4, 5, 4, 5);
            n_TextBox.Multiline = true;
            n_TextBox.Name = "n_TextBox";
            n_TextBox.Size = new Size(550, 54);
            n_TextBox.TabIndex = 33;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(9, 454);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(62, 36);
            label10.TabIndex = 32;
            label10.Text = "n = ";
            // 
            // e_TextBox
            // 
            e_TextBox.BackColor = SystemColors.ControlLightLight;
            e_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            e_TextBox.Location = new Point(61, 390);
            e_TextBox.Margin = new Padding(4, 5, 4, 5);
            e_TextBox.Multiline = true;
            e_TextBox.Name = "e_TextBox";
            e_TextBox.Size = new Size(550, 54);
            e_TextBox.TabIndex = 31;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(9, 399);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(68, 36);
            label9.TabIndex = 30;
            label9.Text = "e =  ";
            // 
            // Message_TextBox
            // 
            Message_TextBox.BackColor = SystemColors.ControlLightLight;
            Message_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Message_TextBox.Location = new Point(61, 87);
            Message_TextBox.Margin = new Padding(4, 5, 4, 5);
            Message_TextBox.Multiline = true;
            Message_TextBox.Name = "Message_TextBox";
            Message_TextBox.Size = new Size(381, 130);
            Message_TextBox.TabIndex = 34;
            // 
            // Encrypt_Button
            // 
            Encrypt_Button.Location = new Point(61, 225);
            Encrypt_Button.Name = "Encrypt_Button";
            Encrypt_Button.Size = new Size(381, 63);
            Encrypt_Button.TabIndex = 35;
            Encrypt_Button.Text = "Зашифровать";
            Encrypt_Button.UseVisualStyleBackColor = true;
            Encrypt_Button.Click += Encrypt_Button_Click;
            // 
            // d_TextBox
            // 
            d_TextBox.BackColor = SystemColors.ControlLightLight;
            d_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            d_TextBox.Location = new Point(61, 500);
            d_TextBox.Margin = new Padding(4, 5, 4, 5);
            d_TextBox.Multiline = true;
            d_TextBox.Name = "d_TextBox";
            d_TextBox.Size = new Size(550, 54);
            d_TextBox.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 509);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 36);
            label1.TabIndex = 36;
            label1.Text = "d = ";
            // 
            // EncryptedText_TextBox
            // 
            EncryptedText_TextBox.BackColor = SystemColors.ControlLightLight;
            EncryptedText_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            EncryptedText_TextBox.Location = new Point(520, 87);
            EncryptedText_TextBox.Margin = new Padding(4, 5, 4, 5);
            EncryptedText_TextBox.Multiline = true;
            EncryptedText_TextBox.Name = "EncryptedText_TextBox";
            EncryptedText_TextBox.Size = new Size(381, 130);
            EncryptedText_TextBox.TabIndex = 38;
            // 
            // Decrypt_Button
            // 
            Decrypt_Button.Location = new Point(520, 225);
            Decrypt_Button.Name = "Decrypt_Button";
            Decrypt_Button.Size = new Size(381, 63);
            Decrypt_Button.TabIndex = 39;
            Decrypt_Button.Text = "Дешифровать";
            Decrypt_Button.UseVisualStyleBackColor = true;
            Decrypt_Button.Click += Decrypt_Button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(499, 41);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(412, 41);
            label2.TabIndex = 41;
            label2.Text = "Зашифрованное сообщение";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(95, 41);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(319, 41);
            label3.TabIndex = 40;
            label3.Text = "Исходное сообщение";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(939, 41);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(418, 41);
            label4.TabIndex = 43;
            label4.Text = "Дешифрованное сообщение";
            // 
            // DecryptedText_TextBox
            // 
            DecryptedText_TextBox.BackColor = SystemColors.ControlLightLight;
            DecryptedText_TextBox.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            DecryptedText_TextBox.Location = new Point(966, 87);
            DecryptedText_TextBox.Margin = new Padding(4, 5, 4, 5);
            DecryptedText_TextBox.Multiline = true;
            DecryptedText_TextBox.Name = "DecryptedText_TextBox";
            DecryptedText_TextBox.Size = new Size(381, 130);
            DecryptedText_TextBox.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(977, 244);
            label5.Name = "label5";
            label5.Size = new Size(243, 25);
            label5.TabIndex = 44;
            label5.Text = "Дешифровка произошла за:";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 589);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(DecryptedText_TextBox);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(Decrypt_Button);
            Controls.Add(EncryptedText_TextBox);
            Controls.Add(d_TextBox);
            Controls.Add(label1);
            Controls.Add(Encrypt_Button);
            Controls.Add(Message_TextBox);
            Controls.Add(n_TextBox);
            Controls.Add(label10);
            Controls.Add(e_TextBox);
            Controls.Add(label9);
            Controls.Add(GenerateOpenAndCloseKeys_Button);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenerateOpenAndCloseKeys_Button;
        private TextBox n_TextBox;
        private Label label10;
        private TextBox e_TextBox;
        private Label label9;
        private TextBox Message_TextBox;
        private Button Encrypt_Button;
        private TextBox d_TextBox;
        private Label label1;
        private TextBox EncryptedText_TextBox;
        private Button Decrypt_Button;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox DecryptedText_TextBox;
        private Label label5;
    }
}