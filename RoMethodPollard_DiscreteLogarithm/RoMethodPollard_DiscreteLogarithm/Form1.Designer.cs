namespace RoMethodPollard_DiscreteLogarithm
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
            DiffiHelman_Button = new Button();
            p_TextBox = new TextBox();
            label4 = new Label();
            g_TextBox = new TextBox();
            label1 = new Label();
            a_TextBox = new TextBox();
            label2 = new Label();
            AA_TextBox = new TextBox();
            label3 = new Label();
            RoMethodPollard_Button = new Button();
            a2_TextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // DiffiHelman_Button
            // 
            DiffiHelman_Button.Location = new Point(19, 206);
            DiffiHelman_Button.Name = "DiffiHelman_Button";
            DiffiHelman_Button.Size = new Size(139, 32);
            DiffiHelman_Button.TabIndex = 0;
            DiffiHelman_Button.Text = "Диффи-Хелман";
            DiffiHelman_Button.UseVisualStyleBackColor = true;
            DiffiHelman_Button.Click += DiffiHelman_Button_Click;
            // 
            // p_TextBox
            // 
            p_TextBox.BackColor = SystemColors.ControlLightLight;
            p_TextBox.Location = new Point(58, 46);
            p_TextBox.Multiline = true;
            p_TextBox.Name = "p_TextBox";
            p_TextBox.ReadOnly = true;
            p_TextBox.ScrollBars = ScrollBars.Vertical;
            p_TextBox.Size = new Size(100, 34);
            p_TextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(19, 48);
            label4.Name = "label4";
            label4.Size = new Size(45, 25);
            label4.TabIndex = 10;
            label4.Text = "p = ";
            // 
            // g_TextBox
            // 
            g_TextBox.BackColor = SystemColors.ControlLightLight;
            g_TextBox.Location = new Point(58, 86);
            g_TextBox.Multiline = true;
            g_TextBox.Name = "g_TextBox";
            g_TextBox.ReadOnly = true;
            g_TextBox.ScrollBars = ScrollBars.Vertical;
            g_TextBox.Size = new Size(100, 34);
            g_TextBox.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(19, 88);
            label1.Name = "label1";
            label1.Size = new Size(45, 25);
            label1.TabIndex = 12;
            label1.Text = "g = ";
            // 
            // a_TextBox
            // 
            a_TextBox.BackColor = SystemColors.ControlLightLight;
            a_TextBox.Location = new Point(58, 126);
            a_TextBox.Multiline = true;
            a_TextBox.Name = "a_TextBox";
            a_TextBox.ReadOnly = true;
            a_TextBox.ScrollBars = ScrollBars.Vertical;
            a_TextBox.Size = new Size(100, 34);
            a_TextBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 128);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 14;
            label2.Text = "a = ";
            // 
            // AA_TextBox
            // 
            AA_TextBox.BackColor = SystemColors.ControlLightLight;
            AA_TextBox.Location = new Point(58, 166);
            AA_TextBox.Multiline = true;
            AA_TextBox.Name = "AA_TextBox";
            AA_TextBox.ReadOnly = true;
            AA_TextBox.ScrollBars = ScrollBars.Vertical;
            AA_TextBox.Size = new Size(100, 34);
            AA_TextBox.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(19, 168);
            label3.Name = "label3";
            label3.Size = new Size(46, 25);
            label3.TabIndex = 16;
            label3.Text = "A = ";
            // 
            // RoMethodPollard_Button
            // 
            RoMethodPollard_Button.Location = new Point(19, 244);
            RoMethodPollard_Button.Name = "RoMethodPollard_Button";
            RoMethodPollard_Button.Size = new Size(139, 41);
            RoMethodPollard_Button.TabIndex = 17;
            RoMethodPollard_Button.Text = "Ро-метод Полларда";
            RoMethodPollard_Button.UseVisualStyleBackColor = true;
            RoMethodPollard_Button.Click += RoMethodPollard_Button_Click;
            // 
            // a2_TextBox
            // 
            a2_TextBox.BackColor = SystemColors.ControlLightLight;
            a2_TextBox.Location = new Point(58, 291);
            a2_TextBox.Multiline = true;
            a2_TextBox.Name = "a2_TextBox";
            a2_TextBox.ReadOnly = true;
            a2_TextBox.ScrollBars = ScrollBars.Vertical;
            a2_TextBox.Size = new Size(100, 34);
            a2_TextBox.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(19, 293);
            label5.Name = "label5";
            label5.Size = new Size(43, 25);
            label5.TabIndex = 19;
            label5.Text = "a = ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 9);
            label6.Name = "label6";
            label6.Size = new Size(142, 25);
            label6.TabIndex = 20;
            label6.Text = "A = g^a mod(p)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(203, 357);
            Controls.Add(label6);
            Controls.Add(a2_TextBox);
            Controls.Add(label5);
            Controls.Add(RoMethodPollard_Button);
            Controls.Add(AA_TextBox);
            Controls.Add(label3);
            Controls.Add(a_TextBox);
            Controls.Add(label2);
            Controls.Add(g_TextBox);
            Controls.Add(label1);
            Controls.Add(p_TextBox);
            Controls.Add(label4);
            Controls.Add(DiffiHelman_Button);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DiffiHelman_Button;
        private TextBox p_TextBox;
        private Label label4;
        private TextBox g_TextBox;
        private Label label1;
        private TextBox a_TextBox;
        private Label label2;
        private TextBox AA_TextBox;
        private Label label3;
        private Button RoMethodPollard_Button;
        private TextBox a2_TextBox;
        private Label label5;
        private Label label6;
    }
}