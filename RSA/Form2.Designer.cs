namespace RSA
{
    partial class Form2
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
            this.a_TextBox = new System.Windows.Forms.TextBox();
            this.x_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.n_TextBox = new System.Windows.Forms.TextBox();
            this.result_TextBox = new System.Windows.Forms.TextBox();
            this.ModPow_Button = new System.Windows.Forms.Button();
            this.AA_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BB_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PAE_Button = new System.Windows.Forms.Button();
            this.ResultPAE_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // a_TextBox
            // 
            this.a_TextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.a_TextBox.Location = new System.Drawing.Point(46, 93);
            this.a_TextBox.Name = "a_TextBox";
            this.a_TextBox.Size = new System.Drawing.Size(64, 36);
            this.a_TextBox.TabIndex = 0;
            // 
            // x_TextBox
            // 
            this.x_TextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.x_TextBox.Location = new System.Drawing.Point(104, 62);
            this.x_TextBox.Name = "x_TextBox";
            this.x_TextBox.Size = new System.Drawing.Size(62, 30);
            this.x_TextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(165, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "mod(             ) = ";
            // 
            // n_TextBox
            // 
            this.n_TextBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.n_TextBox.Location = new System.Drawing.Point(225, 93);
            this.n_TextBox.Name = "n_TextBox";
            this.n_TextBox.Size = new System.Drawing.Size(71, 36);
            this.n_TextBox.TabIndex = 3;
            // 
            // result_TextBox
            // 
            this.result_TextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.result_TextBox.Location = new System.Drawing.Point(332, 51);
            this.result_TextBox.Multiline = true;
            this.result_TextBox.Name = "result_TextBox";
            this.result_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.result_TextBox.Size = new System.Drawing.Size(189, 92);
            this.result_TextBox.TabIndex = 4;
            // 
            // ModPow_Button
            // 
            this.ModPow_Button.Location = new System.Drawing.Point(191, 158);
            this.ModPow_Button.Name = "ModPow_Button";
            this.ModPow_Button.Size = new System.Drawing.Size(137, 51);
            this.ModPow_Button.TabIndex = 5;
            this.ModPow_Button.Text = "Расчитать";
            this.ModPow_Button.UseVisualStyleBackColor = true;
            this.ModPow_Button.Click += new System.EventHandler(this.ModPow_Button_Click);
            // 
            // AA_TextBox
            // 
            this.AA_TextBox.Location = new System.Drawing.Point(181, 295);
            this.AA_TextBox.Name = "AA_TextBox";
            this.AA_TextBox.Size = new System.Drawing.Size(69, 27);
            this.AA_TextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(151, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "A*x +B*y = НОД(A,B)\r\n";
            // 
            // BB_TextBox
            // 
            this.BB_TextBox.Location = new System.Drawing.Point(286, 295);
            this.BB_TextBox.Name = "BB_TextBox";
            this.BB_TextBox.Size = new System.Drawing.Size(68, 27);
            this.BB_TextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(151, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "A=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(256, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "B=";
            // 
            // PAE_Button
            // 
            this.PAE_Button.Location = new System.Drawing.Point(191, 336);
            this.PAE_Button.Name = "PAE_Button";
            this.PAE_Button.Size = new System.Drawing.Size(137, 51);
            this.PAE_Button.TabIndex = 11;
            this.PAE_Button.Text = "Расчитать";
            this.PAE_Button.UseVisualStyleBackColor = true;
            this.PAE_Button.Click += new System.EventHandler(this.PAE_Button_Click);
            // 
            // ResultPAE_TextBox
            // 
            this.ResultPAE_TextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultPAE_TextBox.Location = new System.Drawing.Point(165, 393);
            this.ResultPAE_TextBox.Multiline = true;
            this.ResultPAE_TextBox.Name = "ResultPAE_TextBox";
            this.ResultPAE_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultPAE_TextBox.Size = new System.Drawing.Size(189, 92);
            this.ResultPAE_TextBox.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 523);
            this.Controls.Add(this.ResultPAE_TextBox);
            this.Controls.Add(this.PAE_Button);
            this.Controls.Add(this.BB_TextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AA_TextBox);
            this.Controls.Add(this.ModPow_Button);
            this.Controls.Add(this.result_TextBox);
            this.Controls.Add(this.n_TextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.x_TextBox);
            this.Controls.Add(this.a_TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox a_TextBox;
        private TextBox x_TextBox;
        private Label label1;
        private TextBox n_TextBox;
        private TextBox result_TextBox;
        private Button ModPow_Button;
        private TextBox AA_TextBox;
        private Label label2;
        private TextBox BB_TextBox;
        private Label label3;
        private Label label4;
        private Button PAE_Button;
        private TextBox ResultPAE_TextBox;
    }
}