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
            Decrypt_Button.Size = new Size(212, 50);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 450);
            Controls.Add(label3);
            Controls.Add(DecryptedText_TextBox);
            Controls.Add(label2);
            Controls.Add(Decrypt_Button);
            Controls.Add(EncryptedText_TextBox);
            Controls.Add(label1);
            Controls.Add(Encrypt_Button);
            Controls.Add(SourceText_TextBox);
            Name = "Form1";
            Text = "Form1";
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
    }
}