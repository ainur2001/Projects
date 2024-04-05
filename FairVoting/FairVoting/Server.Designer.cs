namespace FairVoting
{
    partial class Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            R_Login_TextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            R_Password_TextBox = new TextBox();
            Registration_Button = new Button();
            Voices_TextBox = new TextBox();
            CheckVoices_Button = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            EncryptedVoices_TextBox = new TextBox();
            ShamirVoting_Button = new Button();
            KeyAdmin1_TextBox = new TextBox();
            label4 = new Label();
            KeyAdmin2_TextBox = new TextBox();
            label5 = new Label();
            KeyAdmin3_TextBox = new TextBox();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(655, 101);
            label1.Name = "label1";
            label1.Size = new Size(183, 37);
            label1.TabIndex = 0;
            label1.Text = "Регистрация";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
            flowLayoutPanel1.Location = new Point(499, 0);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(22, 601);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // R_Login_TextBox
            // 
            R_Login_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            R_Login_TextBox.Location = new Point(714, 219);
            R_Login_TextBox.Margin = new Padding(3, 4, 3, 4);
            R_Login_TextBox.Multiline = true;
            R_Login_TextBox.Name = "R_Login_TextBox";
            R_Login_TextBox.Size = new Size(158, 47);
            R_Login_TextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(583, 223);
            label2.Name = "label2";
            label2.Size = new Size(106, 37);
            label2.TabIndex = 3;
            label2.Text = "Логин:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(583, 280);
            label3.Name = "label3";
            label3.Size = new Size(125, 37);
            label3.TabIndex = 4;
            label3.Text = "Пароль:";
            // 
            // R_Password_TextBox
            // 
            R_Password_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            R_Password_TextBox.Location = new Point(714, 280);
            R_Password_TextBox.Margin = new Padding(3, 4, 3, 4);
            R_Password_TextBox.Multiline = true;
            R_Password_TextBox.Name = "R_Password_TextBox";
            R_Password_TextBox.Size = new Size(158, 47);
            R_Password_TextBox.TabIndex = 5;
            // 
            // Registration_Button
            // 
            Registration_Button.BackColor = SystemColors.ButtonShadow;
            Registration_Button.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            Registration_Button.Location = new Point(583, 371);
            Registration_Button.Margin = new Padding(3, 4, 3, 4);
            Registration_Button.Name = "Registration_Button";
            Registration_Button.Size = new Size(290, 72);
            Registration_Button.TabIndex = 6;
            Registration_Button.Text = "Зарегистрировать";
            Registration_Button.UseVisualStyleBackColor = false;
            Registration_Button.Click += Registration_Button_Click;
            // 
            // Voices_TextBox
            // 
            Voices_TextBox.Location = new Point(27, 39);
            Voices_TextBox.Margin = new Padding(3, 4, 3, 4);
            Voices_TextBox.Multiline = true;
            Voices_TextBox.Name = "Voices_TextBox";
            Voices_TextBox.Size = new Size(428, 278);
            Voices_TextBox.TabIndex = 7;
            // 
            // CheckVoices_Button
            // 
            CheckVoices_Button.Location = new Point(27, 336);
            CheckVoices_Button.Margin = new Padding(3, 4, 3, 4);
            CheckVoices_Button.Name = "CheckVoices_Button";
            CheckVoices_Button.Size = new Size(429, 57);
            CheckVoices_Button.TabIndex = 8;
            CheckVoices_Button.Text = "Подсчитать голоса";
            CheckVoices_Button.UseVisualStyleBackColor = true;
            CheckVoices_Button.Click += CheckVoices_Button_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = SystemColors.ActiveCaptionText;
            flowLayoutPanel2.Location = new Point(2, 474);
            flowLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(979, 28);
            flowLayoutPanel2.TabIndex = 2;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // EncryptedVoices_TextBox
            // 
            EncryptedVoices_TextBox.Location = new Point(27, 515);
            EncryptedVoices_TextBox.Margin = new Padding(3, 4, 3, 4);
            EncryptedVoices_TextBox.Multiline = true;
            EncryptedVoices_TextBox.Name = "EncryptedVoices_TextBox";
            EncryptedVoices_TextBox.Size = new Size(428, 227);
            EncryptedVoices_TextBox.TabIndex = 9;
            // 
            // ShamirVoting_Button
            // 
            ShamirVoting_Button.Enabled = false;
            ShamirVoting_Button.Location = new Point(27, 1096);
            ShamirVoting_Button.Margin = new Padding(3, 4, 3, 4);
            ShamirVoting_Button.Name = "ShamirVoting_Button";
            ShamirVoting_Button.Size = new Size(429, 57);
            ShamirVoting_Button.TabIndex = 10;
            ShamirVoting_Button.Text = "Подсчитать голоса";
            ShamirVoting_Button.UseVisualStyleBackColor = true;
            ShamirVoting_Button.Click += ShamirVoting_Button_Click;
            // 
            // KeyAdmin1_TextBox
            // 
            KeyAdmin1_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            KeyAdmin1_TextBox.Location = new Point(636, 546);
            KeyAdmin1_TextBox.Margin = new Padding(3, 4, 3, 4);
            KeyAdmin1_TextBox.Multiline = true;
            KeyAdmin1_TextBox.Name = "KeyAdmin1_TextBox";
            KeyAdmin1_TextBox.Size = new Size(258, 47);
            KeyAdmin1_TextBox.TabIndex = 11;
            KeyAdmin1_TextBox.TextChanged += KeyAdmin1_TextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(531, 550);
            label4.Name = "label4";
            label4.Size = new Size(121, 37);
            label4.TabIndex = 12;
            label4.Text = "admin1:";
            // 
            // KeyAdmin2_TextBox
            // 
            KeyAdmin2_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            KeyAdmin2_TextBox.Location = new Point(636, 631);
            KeyAdmin2_TextBox.Margin = new Padding(3, 4, 3, 4);
            KeyAdmin2_TextBox.Multiline = true;
            KeyAdmin2_TextBox.Name = "KeyAdmin2_TextBox";
            KeyAdmin2_TextBox.Size = new Size(258, 47);
            KeyAdmin2_TextBox.TabIndex = 13;
            KeyAdmin2_TextBox.TextChanged += KeyAdmin2_TextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(531, 635);
            label5.Name = "label5";
            label5.Size = new Size(121, 37);
            label5.TabIndex = 14;
            label5.Text = "admin2:";
            // 
            // KeyAdmin3_TextBox
            // 
            KeyAdmin3_TextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            KeyAdmin3_TextBox.Location = new Point(636, 712);
            KeyAdmin3_TextBox.Margin = new Padding(3, 4, 3, 4);
            KeyAdmin3_TextBox.Multiline = true;
            KeyAdmin3_TextBox.Name = "KeyAdmin3_TextBox";
            KeyAdmin3_TextBox.Size = new Size(258, 47);
            KeyAdmin3_TextBox.TabIndex = 15;
            KeyAdmin3_TextBox.TextChanged += KeyAdmin3_TextBox_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(531, 716);
            label6.Name = "label6";
            label6.Size = new Size(121, 37);
            label6.TabIndex = 16;
            label6.Text = "admin3:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(911, 546);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(911, 631);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ControlDark;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(911, 708);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(55, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            pictureBox3.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(27, 765);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(429, 57);
            button1.TabIndex = 20;
            button1.Text = "Подсчитать голоса";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(978, 862);
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(KeyAdmin3_TextBox);
            Controls.Add(label6);
            Controls.Add(KeyAdmin2_TextBox);
            Controls.Add(label5);
            Controls.Add(KeyAdmin1_TextBox);
            Controls.Add(ShamirVoting_Button);
            Controls.Add(EncryptedVoices_TextBox);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(CheckVoices_Button);
            Controls.Add(Voices_TextBox);
            Controls.Add(Registration_Button);
            Controls.Add(R_Password_TextBox);
            Controls.Add(label3);
            Controls.Add(R_Login_TextBox);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Server";
            Text = "Сервер";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox R_Login_TextBox;
        private Label label2;
        private Label label3;
        private TextBox R_Password_TextBox;
        private Button Registration_Button;
        private TextBox Voices_TextBox;
        private Button CheckVoices_Button;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox EncryptedVoices_TextBox;
        private Button ShamirVoting_Button;
        private TextBox KeyAdmin1_TextBox;
        private Label label4;
        private TextBox KeyAdmin2_TextBox;
        private Label label5;
        private TextBox KeyAdmin3_TextBox;
        private Label label6;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button1;
    }
}