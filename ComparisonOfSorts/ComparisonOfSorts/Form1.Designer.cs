namespace ComparisonOfSorts
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
            TypeSort_ComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            CountData_TextBox = new TextBox();
            label3 = new Label();
            TypeData_ComboBox = new ComboBox();
            label5 = new Label();
            TimeSort_TextBox = new TextBox();
            Sort_Button = new Button();
            SuspendLayout();
            // 
            // TypeSort_ComboBox
            // 
            TypeSort_ComboBox.FormattingEnabled = true;
            TypeSort_ComboBox.Items.AddRange(new object[] { "Сортировка вставкой", "Сортировка пузырьком", "Сортировка выбором", "Сортировка Шелла", "Быстрая сортировка", "Сортировка слиянием", "Сортировка кучей", "Встроенная сортировка" });
            TypeSort_ComboBox.Location = new Point(161, 16);
            TypeSort_ComboBox.Name = "TypeSort_ComboBox";
            TypeSort_ComboBox.Size = new Size(168, 23);
            TypeSort_ComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Сортировка:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(143, 15);
            label2.TabIndex = 2;
            label2.Text = "Кол-во входных данных:";
            // 
            // CountData_TextBox
            // 
            CountData_TextBox.Location = new Point(161, 45);
            CountData_TextBox.Name = "CountData_TextBox";
            CountData_TextBox.Size = new Size(80, 23);
            CountData_TextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 4;
            label3.Text = "Тип входных данных:";
            // 
            // TypeData_ComboBox
            // 
            TypeData_ComboBox.FormattingEnabled = true;
            TypeData_ComboBox.Items.AddRange(new object[] { "массив чисел(double)", "массив чисел(int)", "массив строк(string)", "массив дат(DateTime)" });
            TypeData_ComboBox.Location = new Point(161, 73);
            TypeData_ComboBox.Name = "TypeData_ComboBox";
            TypeData_ComboBox.Size = new Size(168, 23);
            TypeData_ComboBox.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 172);
            label5.Name = "label5";
            label5.Size = new Size(113, 15);
            label5.TabIndex = 8;
            label5.Text = "Время сортировки:";
            // 
            // TimeSort_TextBox
            // 
            TimeSort_TextBox.Location = new Point(161, 169);
            TimeSort_TextBox.Name = "TimeSort_TextBox";
            TimeSort_TextBox.Size = new Size(100, 23);
            TimeSort_TextBox.TabIndex = 9;
            // 
            // Sort_Button
            // 
            Sort_Button.Location = new Point(12, 102);
            Sort_Button.Name = "Sort_Button";
            Sort_Button.Size = new Size(123, 42);
            Sort_Button.TabIndex = 10;
            Sort_Button.Text = "Сгенерировать и отсортировать";
            Sort_Button.UseVisualStyleBackColor = true;
            Sort_Button.Click += Sort_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 210);
            Controls.Add(Sort_Button);
            Controls.Add(TimeSort_TextBox);
            Controls.Add(label5);
            Controls.Add(TypeData_ComboBox);
            Controls.Add(label3);
            Controls.Add(CountData_TextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TypeSort_ComboBox);
            Name = "Form1";
            Text = "Сравнение сортировок";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TypeSort_ComboBox;
        private Label label1;
        private Label label2;
        private TextBox CountData_TextBox;
        private Label label3;
        private ComboBox TypeData_ComboBox;
        private Label label5;
        private TextBox TimeSort_TextBox;
        private Button Sort_Button;
    }
}