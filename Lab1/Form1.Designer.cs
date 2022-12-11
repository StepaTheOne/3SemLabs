namespace Lab1
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
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TextFunc = new System.Windows.Forms.TextBox();
            this.ResText = new System.Windows.Forms.TextBox();
            this.labelAns = new System.Windows.Forms.Label();
            this.labelFunc = new System.Windows.Forms.Label();
            this.AText = new System.Windows.Forms.TextBox();
            this.BText = new System.Windows.Forms.TextBox();
            this.EText = new System.Windows.Forms.TextBox();
            this.labelA = new System.Windows.Forms.Label();
            this.TextB = new System.Windows.Forms.Label();
            this.labelAccur = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CalculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(63, 88);
            this.chart.Name = "chart";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.LegendText = "f(x)";
            series1.Name = "function";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "local_min";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend1";
            series3.Name = "A";
            series3.ShadowColor = System.Drawing.Color.White;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.Name = "B";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(697, 350);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // TextFunc
            // 
            this.TextFunc.Location = new System.Drawing.Point(80, 62);
            this.TextFunc.Name = "TextFunc";
            this.TextFunc.Size = new System.Drawing.Size(304, 20);
            this.TextFunc.TabIndex = 1;
            // 
            // ResText
            // 
            this.ResText.Location = new System.Drawing.Point(683, 62);
            this.ResText.Name = "ResText";
            this.ResText.ReadOnly = true;
            this.ResText.Size = new System.Drawing.Size(94, 20);
            this.ResText.TabIndex = 3;
            // 
            // labelAns
            // 
            this.labelAns.AutoSize = true;
            this.labelAns.Location = new System.Drawing.Point(684, 46);
            this.labelAns.Name = "labelAns";
            this.labelAns.Size = new System.Drawing.Size(93, 13);
            this.labelAns.TabIndex = 4;
            this.labelAns.Text = "Точка минимума";
            // 
            // labelFunc
            // 
            this.labelFunc.AutoSize = true;
            this.labelFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFunc.Location = new System.Drawing.Point(150, 39);
            this.labelFunc.Name = "labelFunc";
            this.labelFunc.Size = new System.Drawing.Size(31, 20);
            this.labelFunc.TabIndex = 5;
            this.labelFunc.Text = "f(x)";
            // 
            // AText
            // 
            this.AText.Location = new System.Drawing.Point(453, 62);
            this.AText.Name = "AText";
            this.AText.Size = new System.Drawing.Size(50, 20);
            this.AText.TabIndex = 10;
            // 
            // BText
            // 
            this.BText.Location = new System.Drawing.Point(537, 62);
            this.BText.Name = "BText";
            this.BText.Size = new System.Drawing.Size(50, 20);
            this.BText.TabIndex = 11;
            // 
            // EText
            // 
            this.EText.Location = new System.Drawing.Point(617, 62);
            this.EText.Name = "EText";
            this.EText.Size = new System.Drawing.Size(50, 20);
            this.EText.TabIndex = 12;
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelA.Location = new System.Drawing.Point(467, 39);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(21, 17);
            this.labelA.TabIndex = 13;
            this.labelA.Text = "A:";
            // 
            // TextB
            // 
            this.TextB.AutoSize = true;
            this.TextB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextB.Location = new System.Drawing.Point(549, 39);
            this.TextB.Name = "TextB";
            this.TextB.Size = new System.Drawing.Size(21, 17);
            this.TextB.TabIndex = 14;
            this.TextB.Text = "B:";
            // 
            // labelAccur
            // 
            this.labelAccur.AutoSize = true;
            this.labelAccur.Location = new System.Drawing.Point(614, 46);
            this.labelAccur.Name = "labelAccur";
            this.labelAccur.Size = new System.Drawing.Size(54, 13);
            this.labelAccur.TabIndex = 15;
            this.labelAccur.Text = "Точность";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem,
            this.CalculateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.ClearToolStripMenuItem.Text = "Clear";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // CalculateToolStripMenuItem
            // 
            this.CalculateToolStripMenuItem.Name = "CalculateToolStripMenuItem";
            this.CalculateToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.CalculateToolStripMenuItem.Text = "Calculate";
            this.CalculateToolStripMenuItem.Click += new System.EventHandler(this.CalculateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAccur);
            this.Controls.Add(this.TextB);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.EText);
            this.Controls.Add(this.BText);
            this.Controls.Add(this.AText);
            this.Controls.Add(this.labelFunc);
            this.Controls.Add(this.labelAns);
            this.Controls.Add(this.ResText);
            this.Controls.Add(this.TextFunc);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab1 Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox TextFunc;
        private System.Windows.Forms.TextBox ResText;
        private System.Windows.Forms.Label labelAns;
        private System.Windows.Forms.Label labelFunc;
        private System.Windows.Forms.TextBox AText;
        private System.Windows.Forms.TextBox BText;
        private System.Windows.Forms.TextBox EText;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label TextB;
        private System.Windows.Forms.Label labelAccur;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CalculateToolStripMenuItem;
    }
}

