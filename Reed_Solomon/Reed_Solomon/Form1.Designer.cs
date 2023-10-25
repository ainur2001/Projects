namespace Reed_Solomon
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
            SourceMessage_TextBox = new TextBox();
            EncodeMessage_TextBox = new TextBox();
            DecodeMessage_TextBox = new TextBox();
            GenerationMessage_Button = new Button();
            Encoding_Button = new Button();
            Decoding_Button = new Button();
            CountBits_TextBox = new TextBox();
            SuspendLayout();
            // 
            // SourceMessage_TextBox
            // 
            SourceMessage_TextBox.Location = new Point(64, 57);
            SourceMessage_TextBox.Multiline = true;
            SourceMessage_TextBox.Name = "SourceMessage_TextBox";
            SourceMessage_TextBox.Size = new Size(251, 148);
            SourceMessage_TextBox.TabIndex = 0;
            // 
            // EncodeMessage_TextBox
            // 
            EncodeMessage_TextBox.Location = new Point(363, 57);
            EncodeMessage_TextBox.Multiline = true;
            EncodeMessage_TextBox.Name = "EncodeMessage_TextBox";
            EncodeMessage_TextBox.Size = new Size(251, 148);
            EncodeMessage_TextBox.TabIndex = 1;
            // 
            // DecodeMessage_TextBox
            // 
            DecodeMessage_TextBox.Location = new Point(664, 57);
            DecodeMessage_TextBox.Multiline = true;
            DecodeMessage_TextBox.Name = "DecodeMessage_TextBox";
            DecodeMessage_TextBox.Size = new Size(251, 148);
            DecodeMessage_TextBox.TabIndex = 2;
            // 
            // GenerationMessage_Button
            // 
            GenerationMessage_Button.Location = new Point(64, 267);
            GenerationMessage_Button.Name = "GenerationMessage_Button";
            GenerationMessage_Button.Size = new Size(122, 46);
            GenerationMessage_Button.TabIndex = 3;
            GenerationMessage_Button.Text = "Сгенерировать сообщение";
            GenerationMessage_Button.UseVisualStyleBackColor = true;
            GenerationMessage_Button.Click += GenerationMessage_Button_Click;
            // 
            // Encoding_Button
            // 
            Encoding_Button.Location = new Point(192, 211);
            Encoding_Button.Name = "Encoding_Button";
            Encoding_Button.Size = new Size(122, 102);
            Encoding_Button.TabIndex = 4;
            Encoding_Button.Text = "Coding";
            Encoding_Button.UseVisualStyleBackColor = true;
            Encoding_Button.Click += Encoding_Button_Click;
            // 
            // Decoding_Button
            // 
            Decoding_Button.Location = new Point(363, 211);
            Decoding_Button.Name = "Decoding_Button";
            Decoding_Button.Size = new Size(251, 102);
            Decoding_Button.TabIndex = 5;
            Decoding_Button.Text = "Decoding";
            Decoding_Button.UseVisualStyleBackColor = true;
            // 
            // CountBits_TextBox
            // 
            CountBits_TextBox.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            CountBits_TextBox.Location = new Point(64, 213);
            CountBits_TextBox.Multiline = true;
            CountBits_TextBox.Name = "CountBits_TextBox";
            CountBits_TextBox.Size = new Size(122, 48);
            CountBits_TextBox.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 355);
            Controls.Add(CountBits_TextBox);
            Controls.Add(Decoding_Button);
            Controls.Add(Encoding_Button);
            Controls.Add(GenerationMessage_Button);
            Controls.Add(DecodeMessage_TextBox);
            Controls.Add(EncodeMessage_TextBox);
            Controls.Add(SourceMessage_TextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SourceMessage_TextBox;
        private TextBox EncodeMessage_TextBox;
        private TextBox DecodeMessage_TextBox;
        private Button GenerationMessage_Button;
        private Button Encoding_Button;
        private Button Decoding_Button;
        private TextBox CountBits_TextBox;
    }
}