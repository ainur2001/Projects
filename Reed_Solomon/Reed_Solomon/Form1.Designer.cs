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
            input_TextBox = new TextBox();
            encoded_TextBox = new TextBox();
            decoded_TextBox = new TextBox();
            GenerationMessage_Button = new Button();
            Encoding_Button = new Button();
            Decoding_Button = new Button();
            CountBits_TextBox = new TextBox();
            introduceError = new Button();
            SuspendLayout();
            // 
            // input_TextBox
            // 
            input_TextBox.Location = new Point(64, 57);
            input_TextBox.Multiline = true;
            input_TextBox.Name = "input_TextBox";
            input_TextBox.Size = new Size(251, 148);
            input_TextBox.TabIndex = 0;
            // 
            // encoded_TextBox
            // 
            encoded_TextBox.Location = new Point(363, 57);
            encoded_TextBox.Multiline = true;
            encoded_TextBox.Name = "encoded_TextBox";
            encoded_TextBox.Size = new Size(251, 148);
            encoded_TextBox.TabIndex = 1;
            // 
            // decoded_TextBox
            // 
            decoded_TextBox.Location = new Point(664, 57);
            decoded_TextBox.Multiline = true;
            decoded_TextBox.Name = "decoded_TextBox";
            decoded_TextBox.Size = new Size(251, 148);
            decoded_TextBox.TabIndex = 2;
            // 
            // GenerationMessage_Button
            // 
            GenerationMessage_Button.Location = new Point(64, 267);
            GenerationMessage_Button.Name = "GenerationMessage_Button";
            GenerationMessage_Button.Size = new Size(122, 46);
            GenerationMessage_Button.TabIndex = 3;
            GenerationMessage_Button.Text = "Сгенерировать сообщение";
            GenerationMessage_Button.UseVisualStyleBackColor = true;
            // 
            // Encoding_Button
            // 
            Encoding_Button.Location = new Point(192, 211);
            Encoding_Button.Name = "Encoding_Button";
            Encoding_Button.Size = new Size(122, 102);
            Encoding_Button.TabIndex = 4;
            Encoding_Button.Text = "Coding";
            Encoding_Button.UseVisualStyleBackColor = true;
            Encoding_Button.Click += encodeButton_Click;
            // 
            // Decoding_Button
            // 
            Decoding_Button.Location = new Point(363, 211);
            Decoding_Button.Name = "Decoding_Button";
            Decoding_Button.Size = new Size(122, 102);
            Decoding_Button.TabIndex = 5;
            Decoding_Button.Text = "Decoding";
            Decoding_Button.UseVisualStyleBackColor = true;
            Decoding_Button.Click += decodeButton_Click;
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
            // introduceError
            // 
            introduceError.Location = new Point(492, 211);
            introduceError.Name = "introduceError";
            introduceError.Size = new Size(122, 102);
            introduceError.TabIndex = 7;
            introduceError.Text = "Add Errors";
            introduceError.UseVisualStyleBackColor = true;
            introduceError.Click += introduceErrorButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 355);
            Controls.Add(introduceError);
            Controls.Add(CountBits_TextBox);
            Controls.Add(Decoding_Button);
            Controls.Add(Encoding_Button);
            Controls.Add(GenerationMessage_Button);
            Controls.Add(decoded_TextBox);
            Controls.Add(encoded_TextBox);
            Controls.Add(input_TextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox input_TextBox;
        private TextBox encoded_TextBox;
        private TextBox decoded_TextBox;
        private Button GenerationMessage_Button;
        private Button Encoding_Button;
        private Button Decoding_Button;
        private TextBox CountBits_TextBox;
        private Button introduceError;
    }
}