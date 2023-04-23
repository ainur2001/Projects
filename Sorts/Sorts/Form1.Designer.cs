namespace Sorts
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CountData_TextBox = new System.Windows.Forms.TextBox();
            this.TypeSort_ComboBox = new System.Windows.Forms.ComboBox();
            this.TypeData_ComboBox = new System.Windows.Forms.ComboBox();
            this.TimeSort_TextBox = new System.Windows.Forms.TextBox();
            this.Sort_Button = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DrawGraphic_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Begin_TextBox = new System.Windows.Forms.TextBox();
            this.End_TextBox = new System.Windows.Forms.TextBox();
            this.Step_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сортировка:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип входных данных:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кол-во входных данных:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(8, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Время сортировки:";
            // 
            // CountData_TextBox
            // 
            this.CountData_TextBox.Location = new System.Drawing.Point(185, 105);
            this.CountData_TextBox.Multiline = true;
            this.CountData_TextBox.Name = "CountData_TextBox";
            this.CountData_TextBox.Size = new System.Drawing.Size(104, 22);
            this.CountData_TextBox.TabIndex = 5;
            // 
            // TypeSort_ComboBox
            // 
            this.TypeSort_ComboBox.FormattingEnabled = true;
            this.TypeSort_ComboBox.Items.AddRange(new object[] {
            "Сортировка вставкой",
            "Сортировка пузырьком",
            "Сортировка выбором",
            "Сортировка Шелла",
            "Быстрая сортировка",
            "Сортировка слиянием",
            "Пирамидальная сортировка",
            "Сортировка кучей",
            "Встроенная сортировка"});
            this.TypeSort_ComboBox.Location = new System.Drawing.Point(185, 20);
            this.TypeSort_ComboBox.Name = "TypeSort_ComboBox";
            this.TypeSort_ComboBox.Size = new System.Drawing.Size(162, 21);
            this.TypeSort_ComboBox.TabIndex = 7;
            // 
            // TypeData_ComboBox
            // 
            this.TypeData_ComboBox.FormattingEnabled = true;
            this.TypeData_ComboBox.Items.AddRange(new object[] {
            "массив чисел(double)",
            "массив чисел(int)",
            "массив строк(string)",
            "массив дат(DateTime)"});
            this.TypeData_ComboBox.Location = new System.Drawing.Point(185, 66);
            this.TypeData_ComboBox.Name = "TypeData_ComboBox";
            this.TypeData_ComboBox.Size = new System.Drawing.Size(141, 21);
            this.TypeData_ComboBox.TabIndex = 8;
            // 
            // TimeSort_TextBox
            // 
            this.TimeSort_TextBox.Location = new System.Drawing.Point(185, 202);
            this.TimeSort_TextBox.Multiline = true;
            this.TimeSort_TextBox.Name = "TimeSort_TextBox";
            this.TimeSort_TextBox.Size = new System.Drawing.Size(104, 22);
            this.TimeSort_TextBox.TabIndex = 10;
            // 
            // Sort_Button
            // 
            this.Sort_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Sort_Button.Location = new System.Drawing.Point(9, 140);
            this.Sort_Button.Name = "Sort_Button";
            this.Sort_Button.Size = new System.Drawing.Size(141, 46);
            this.Sort_Button.TabIndex = 11;
            this.Sort_Button.Text = "Сгенерировать и отсортировать";
            this.Sort_Button.UseVisualStyleBackColor = true;
            this.Sort_Button.Click += new System.EventHandler(this.Sort_Button_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "кол-во элементов";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.AxisY.Title = "время(мс.)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.BorderWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(357, 21);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.EmptyPointStyle.MarkerBorderWidth = 3;
            series1.Legend = "Legend1";
            series1.LegendText = "Сортировка вставокй";
            series1.MarkerSize = 10;
            series1.Name = "SeriesInsertionSort";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.EmptyPointStyle.MarkerBorderWidth = 3;
            series2.Legend = "Legend1";
            series2.LegendText = "Сортировка пузырьком";
            series2.Name = "SeriesBubbleSort";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.EmptyPointStyle.MarkerBorderWidth = 3;
            series3.Legend = "Legend1";
            series3.LegendText = "Сортировка выбором";
            series3.Name = "SeriesSelectionSort";
            series4.BorderColor = System.Drawing.Color.Transparent;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Fuchsia;
            series4.EmptyPointStyle.MarkerBorderWidth = 3;
            series4.Legend = "Legend1";
            series4.LegendText = "Сортировка Шелла";
            series4.Name = "SeriesShellSort";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Lime;
            series5.EmptyPointStyle.MarkerBorderWidth = 3;
            series5.Legend = "Legend1";
            series5.LegendText = "Быстрая сортировка";
            series5.Name = "SeriesQuickSort";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.EmptyPointStyle.MarkerBorderWidth = 3;
            series6.Legend = "Legend1";
            series6.LegendText = "Сортировка слиянием";
            series6.Name = "SeriesMergeSort";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.EmptyPointStyle.MarkerBorderWidth = 3;
            series7.Legend = "Legend1";
            series7.LegendText = "Сортировка кучей";
            series7.Name = "SeriesHeapSort";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series8.EmptyPointStyle.MarkerBorderWidth = 3;
            series8.Legend = "Legend1";
            series8.LegendText = "Встроенная сортировка";
            series8.Name = "SeriesIncludeSort";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(675, 359);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            title1.Name = "Title1";
            title1.Text = "График t(N)";
            this.chart1.Titles.Add(title1);
            // 
            // DrawGraphic_Button
            // 
            this.DrawGraphic_Button.Location = new System.Drawing.Point(857, 386);
            this.DrawGraphic_Button.Name = "DrawGraphic_Button";
            this.DrawGraphic_Button.Size = new System.Drawing.Size(175, 49);
            this.DrawGraphic_Button.TabIndex = 13;
            this.DrawGraphic_Button.Text = "Построить график";
            this.DrawGraphic_Button.UseVisualStyleBackColor = true;
            this.DrawGraphic_Button.Click += new System.EventHandler(this.DrawGraphic_Button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(366, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "begin:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(366, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "end:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(366, 445);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "step:";
            // 
            // Begin_TextBox
            // 
            this.Begin_TextBox.Location = new System.Drawing.Point(410, 397);
            this.Begin_TextBox.Multiline = true;
            this.Begin_TextBox.Name = "Begin_TextBox";
            this.Begin_TextBox.Size = new System.Drawing.Size(92, 22);
            this.Begin_TextBox.TabIndex = 17;
            // 
            // End_TextBox
            // 
            this.End_TextBox.Location = new System.Drawing.Point(410, 421);
            this.End_TextBox.Multiline = true;
            this.End_TextBox.Name = "End_TextBox";
            this.End_TextBox.Size = new System.Drawing.Size(92, 22);
            this.End_TextBox.TabIndex = 18;
            // 
            // Step_TextBox
            // 
            this.Step_TextBox.Location = new System.Drawing.Point(410, 446);
            this.Step_TextBox.Multiline = true;
            this.Step_TextBox.Name = "Step_TextBox";
            this.Step_TextBox.Size = new System.Drawing.Size(92, 22);
            this.Step_TextBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 479);
            this.Controls.Add(this.Step_TextBox);
            this.Controls.Add(this.End_TextBox);
            this.Controls.Add(this.Begin_TextBox);
            this.Controls.Add(this.DrawGraphic_Button);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Sort_Button);
            this.Controls.Add(this.TimeSort_TextBox);
            this.Controls.Add(this.TypeData_ComboBox);
            this.Controls.Add(this.TypeSort_ComboBox);
            this.Controls.Add(this.CountData_TextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CountData_TextBox;
        private System.Windows.Forms.ComboBox TypeSort_ComboBox;
        private System.Windows.Forms.ComboBox TypeData_ComboBox;
        private System.Windows.Forms.TextBox TimeSort_TextBox;
        private System.Windows.Forms.Button Sort_Button;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button DrawGraphic_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Begin_TextBox;
        private System.Windows.Forms.TextBox End_TextBox;
        private System.Windows.Forms.TextBox Step_TextBox;
    }
}

