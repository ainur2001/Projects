namespace Hacker
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
            IP1_TextBox = new TextBox();
            IP2_TextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Interception_Button = new Button();
            Packets_TextBox = new TextBox();
            SuspendLayout();
            // 
            // IP1_TextBox
            // 
            IP1_TextBox.Location = new Point(33, 27);
            IP1_TextBox.Multiline = true;
            IP1_TextBox.Name = "IP1_TextBox";
            IP1_TextBox.Size = new Size(142, 32);
            IP1_TextBox.TabIndex = 0;
            // 
            // IP2_TextBox
            // 
            IP2_TextBox.Location = new Point(202, 27);
            IP2_TextBox.Multiline = true;
            IP2_TextBox.Name = "IP2_TextBox";
            IP2_TextBox.Size = new Size(142, 32);
            IP2_TextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 2;
            label1.Text = "IP1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 36);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 3;
            label2.Text = "IP2:";
            // 
            // Interception_Button
            // 
            Interception_Button.Location = new Point(33, 65);
            Interception_Button.Name = "Interception_Button";
            Interception_Button.Size = new Size(311, 38);
            Interception_Button.TabIndex = 4;
            Interception_Button.Text = "Начать перехват трафика";
            Interception_Button.UseVisualStyleBackColor = true;
            Interception_Button.Click += Interception_Button_Click;
            // 
            // Packets_TextBox
            // 
            Packets_TextBox.Location = new Point(33, 124);
            Packets_TextBox.Multiline = true;
            Packets_TextBox.Name = "Packets_TextBox";
            Packets_TextBox.Size = new Size(311, 148);
            Packets_TextBox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 367);
            Controls.Add(Packets_TextBox);
            Controls.Add(Interception_Button);
            Controls.Add(label1);
            Controls.Add(IP2_TextBox);
            Controls.Add(IP1_TextBox);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IP1_TextBox;
        private TextBox IP2_TextBox;
        private Label label1;
        private Label label2;
        private Button Interception_Button;
        private TextBox Packets_TextBox;
    }
}