namespace MethodFermaFactorization
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
            n_TextBox = new TextBox();
            Factorize_Button = new Button();
            label1 = new Label();
            label2 = new Label();
            a_TextBox = new TextBox();
            b_TextBox = new TextBox();
            SuspendLayout();
            // 
            // n_TextBox
            // 
            n_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            n_TextBox.Location = new Point(12, 12);
            n_TextBox.Multiline = true;
            n_TextBox.Name = "n_TextBox";
            n_TextBox.Size = new Size(192, 61);
            n_TextBox.TabIndex = 0;
            // 
            // Factorize_Button
            // 
            Factorize_Button.Location = new Point(12, 79);
            Factorize_Button.Name = "Factorize_Button";
            Factorize_Button.Size = new Size(192, 39);
            Factorize_Button.TabIndex = 1;
            Factorize_Button.Text = "Разложить на множители";
            Factorize_Button.UseVisualStyleBackColor = true;
            Factorize_Button.Click += Factorize_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(51, 30);
            label1.TabIndex = 2;
            label1.Text = "a = ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 165);
            label2.Name = "label2";
            label2.Size = new Size(53, 30);
            label2.TabIndex = 3;
            label2.Text = "b = ";
            // 
            // a_TextBox
            // 
            a_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            a_TextBox.Location = new Point(58, 121);
            a_TextBox.Multiline = true;
            a_TextBox.Name = "a_TextBox";
            a_TextBox.Size = new Size(146, 40);
            a_TextBox.TabIndex = 4;
            // 
            // b_TextBox
            // 
            b_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            b_TextBox.Location = new Point(58, 165);
            b_TextBox.Multiline = true;
            b_TextBox.Name = "b_TextBox";
            b_TextBox.Size = new Size(146, 40);
            b_TextBox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 229);
            Controls.Add(b_TextBox);
            Controls.Add(a_TextBox);
            Controls.Add(Factorize_Button);
            Controls.Add(n_TextBox);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox n_TextBox;
        private Button Factorize_Button;
        private Label label1;
        private Label label2;
        private TextBox a_TextBox;
        private TextBox b_TextBox;
    }
}