namespace Client
{
    partial class Voting
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
            Za_Button = new Button();
            Protiv_Button = new Button();
            Vozderzalsya_Button = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // Za_Button
            // 
            Za_Button.BackColor = SystemColors.ButtonShadow;
            Za_Button.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            Za_Button.Location = new Point(27, 123);
            Za_Button.Name = "Za_Button";
            Za_Button.Size = new Size(112, 63);
            Za_Button.TabIndex = 0;
            Za_Button.Text = "ЗА";
            Za_Button.UseVisualStyleBackColor = false;
            Za_Button.Click += Za_Button_Click;
            // 
            // Protiv_Button
            // 
            Protiv_Button.BackColor = SystemColors.ButtonShadow;
            Protiv_Button.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            Protiv_Button.Location = new Point(203, 123);
            Protiv_Button.Name = "Protiv_Button";
            Protiv_Button.Size = new Size(114, 63);
            Protiv_Button.TabIndex = 1;
            Protiv_Button.Text = "ПРОТИВ";
            Protiv_Button.UseVisualStyleBackColor = false;
            Protiv_Button.Click += Protiv_Button_Click;
            // 
            // Vozderzalsya_Button
            // 
            Vozderzalsya_Button.BackColor = SystemColors.ButtonShadow;
            Vozderzalsya_Button.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            Vozderzalsya_Button.Location = new Point(364, 123);
            Vozderzalsya_Button.Name = "Vozderzalsya_Button";
            Vozderzalsya_Button.Size = new Size(195, 63);
            Vozderzalsya_Button.TabIndex = 2;
            Vozderzalsya_Button.Text = "ВОЗДЕРЖАЛСЯ";
            Vozderzalsya_Button.UseVisualStyleBackColor = false;
            Vozderzalsya_Button.Click += Vozderzalsya_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(203, 49);
            label1.Name = "label1";
            label1.Size = new Size(156, 31);
            label1.TabIndex = 3;
            label1.Text = "Голосование";
            // 
            // Voting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(597, 277);
            Controls.Add(label1);
            Controls.Add(Vozderzalsya_Button);
            Controls.Add(Protiv_Button);
            Controls.Add(Za_Button);
            Name = "Voting";
            Text = "Голосование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Za_Button;
        private Button Protiv_Button;
        private Button Vozderzalsya_Button;
        private Label label1;
    }
}