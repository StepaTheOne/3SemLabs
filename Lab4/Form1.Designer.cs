namespace Lab4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBubble = new System.Windows.Forms.CheckBox();
            this.checkShaker = new System.Windows.Forms.CheckBox();
            this.checkQuick = new System.Windows.Forms.CheckBox();
            this.checkInsert = new System.Windows.Forms.CheckBox();
            this.checkBogo = new System.Windows.Forms.CheckBox();
            this.ChartBubble = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartShaker = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartQuick = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartInsert = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartBogo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TextTimerBubble = new System.Windows.Forms.TextBox();
            this.TextTimerShaker = new System.Windows.Forms.TextBox();
            this.TextTimerQuick = new System.Windows.Forms.TextBox();
            this.TextTimerInsert = new System.Windows.Forms.TextBox();
            this.TextTimerBogo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataElem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkRandom = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBubble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartShaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
            this.sortToolStripMenuItem.Text = "Sort";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.sortToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 23);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // TextLength
            // 
            this.TextLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextLength.Location = new System.Drawing.Point(119, 27);
            this.TextLength.Name = "TextLength";
            this.TextLength.Size = new System.Drawing.Size(100, 23);
            this.TextLength.TabIndex = 1;
            this.TextLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextLength_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(61, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Length";
            // 
            // checkBubble
            // 
            this.checkBubble.AutoSize = true;
            this.checkBubble.Location = new System.Drawing.Point(264, 31);
            this.checkBubble.Name = "checkBubble";
            this.checkBubble.Size = new System.Drawing.Size(59, 17);
            this.checkBubble.TabIndex = 3;
            this.checkBubble.Text = "Bubble";
            this.checkBubble.UseVisualStyleBackColor = true;
            // 
            // checkShaker
            // 
            this.checkShaker.AutoSize = true;
            this.checkShaker.Location = new System.Drawing.Point(368, 31);
            this.checkShaker.Name = "checkShaker";
            this.checkShaker.Size = new System.Drawing.Size(60, 17);
            this.checkShaker.TabIndex = 4;
            this.checkShaker.Text = "Shaker";
            this.checkShaker.UseVisualStyleBackColor = true;
            // 
            // checkQuick
            // 
            this.checkQuick.AutoSize = true;
            this.checkQuick.Location = new System.Drawing.Point(478, 31);
            this.checkQuick.Name = "checkQuick";
            this.checkQuick.Size = new System.Drawing.Size(54, 17);
            this.checkQuick.TabIndex = 5;
            this.checkQuick.Text = "Quick";
            this.checkQuick.UseVisualStyleBackColor = true;
            // 
            // checkInsert
            // 
            this.checkInsert.AutoSize = true;
            this.checkInsert.Location = new System.Drawing.Point(583, 31);
            this.checkInsert.Name = "checkInsert";
            this.checkInsert.Size = new System.Drawing.Size(52, 17);
            this.checkInsert.TabIndex = 6;
            this.checkInsert.Text = "Insert";
            this.checkInsert.UseVisualStyleBackColor = true;
            // 
            // checkBogo
            // 
            this.checkBogo.AutoSize = true;
            this.checkBogo.Location = new System.Drawing.Point(669, 31);
            this.checkBogo.Name = "checkBogo";
            this.checkBogo.Size = new System.Drawing.Size(51, 17);
            this.checkBogo.TabIndex = 7;
            this.checkBogo.Text = "Bogo";
            this.checkBogo.UseVisualStyleBackColor = true;
            // 
            // ChartBubble
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartBubble.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartBubble.Legends.Add(legend1);
            this.ChartBubble.Location = new System.Drawing.Point(327, 84);
            this.ChartBubble.Name = "ChartBubble";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartBubble.Series.Add(series1);
            this.ChartBubble.Size = new System.Drawing.Size(299, 181);
            this.ChartBubble.TabIndex = 8;
            this.ChartBubble.Text = "chart1";
            // 
            // ChartShaker
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartShaker.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartShaker.Legends.Add(legend2);
            this.ChartShaker.Location = new System.Drawing.Point(651, 84);
            this.ChartShaker.Name = "ChartShaker";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartShaker.Series.Add(series2);
            this.ChartShaker.Size = new System.Drawing.Size(299, 181);
            this.ChartShaker.TabIndex = 9;
            this.ChartShaker.Text = "chart2";
            // 
            // ChartQuick
            // 
            chartArea3.Name = "ChartArea1";
            this.ChartQuick.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ChartQuick.Legends.Add(legend3);
            this.ChartQuick.Location = new System.Drawing.Point(12, 311);
            this.ChartQuick.Name = "ChartQuick";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ChartQuick.Series.Add(series3);
            this.ChartQuick.Size = new System.Drawing.Size(299, 181);
            this.ChartQuick.TabIndex = 10;
            this.ChartQuick.Text = "chart3";
            // 
            // ChartInsert
            // 
            chartArea4.Name = "ChartArea1";
            this.ChartInsert.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ChartInsert.Legends.Add(legend4);
            this.ChartInsert.Location = new System.Drawing.Point(327, 311);
            this.ChartInsert.Name = "ChartInsert";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.ChartInsert.Series.Add(series4);
            this.ChartInsert.Size = new System.Drawing.Size(299, 181);
            this.ChartInsert.TabIndex = 11;
            this.ChartInsert.Text = "chart4";
            // 
            // ChartBogo
            // 
            chartArea5.Name = "ChartArea1";
            this.ChartBogo.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.ChartBogo.Legends.Add(legend5);
            this.ChartBogo.Location = new System.Drawing.Point(651, 311);
            this.ChartBogo.Name = "ChartBogo";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.ChartBogo.Series.Add(series5);
            this.ChartBogo.Size = new System.Drawing.Size(299, 181);
            this.ChartBogo.TabIndex = 12;
            this.ChartBogo.Text = "chart5";
            // 
            // TextTimerBubble
            // 
            this.TextTimerBubble.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTimerBubble.Location = new System.Drawing.Point(403, 55);
            this.TextTimerBubble.Name = "TextTimerBubble";
            this.TextTimerBubble.ReadOnly = true;
            this.TextTimerBubble.Size = new System.Drawing.Size(153, 23);
            this.TextTimerBubble.TabIndex = 13;
            // 
            // TextTimerShaker
            // 
            this.TextTimerShaker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTimerShaker.Location = new System.Drawing.Point(734, 55);
            this.TextTimerShaker.Name = "TextTimerShaker";
            this.TextTimerShaker.ReadOnly = true;
            this.TextTimerShaker.Size = new System.Drawing.Size(153, 23);
            this.TextTimerShaker.TabIndex = 14;
            // 
            // TextTimerQuick
            // 
            this.TextTimerQuick.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTimerQuick.Location = new System.Drawing.Point(79, 282);
            this.TextTimerQuick.Name = "TextTimerQuick";
            this.TextTimerQuick.ReadOnly = true;
            this.TextTimerQuick.Size = new System.Drawing.Size(153, 23);
            this.TextTimerQuick.TabIndex = 15;
            // 
            // TextTimerInsert
            // 
            this.TextTimerInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTimerInsert.Location = new System.Drawing.Point(403, 282);
            this.TextTimerInsert.Name = "TextTimerInsert";
            this.TextTimerInsert.ReadOnly = true;
            this.TextTimerInsert.Size = new System.Drawing.Size(153, 23);
            this.TextTimerInsert.TabIndex = 16;
            // 
            // TextTimerBogo
            // 
            this.TextTimerBogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTimerBogo.Location = new System.Drawing.Point(734, 282);
            this.TextTimerBogo.Name = "TextTimerBogo";
            this.TextTimerBogo.ReadOnly = true;
            this.TextTimerBogo.Size = new System.Drawing.Size(153, 23);
            this.TextTimerBogo.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataElem});
            this.dataGridView1.Location = new System.Drawing.Point(22, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(289, 181);
            this.dataGridView1.TabIndex = 18;
            // 
            // DataElem
            // 
            this.DataElem.Frozen = true;
            this.DataElem.HeaderText = "Element";
            this.DataElem.Name = "DataElem";
            this.DataElem.Width = 280;
            // 
            // checkRandom
            // 
            this.checkRandom.AutoSize = true;
            this.checkRandom.Location = new System.Drawing.Point(837, 32);
            this.checkRandom.Name = "checkRandom";
            this.checkRandom.Size = new System.Drawing.Size(93, 17);
            this.checkRandom.TabIndex = 19;
            this.checkRandom.Text = "Random Array";
            this.checkRandom.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 531);
            this.Controls.Add(this.checkRandom);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TextTimerBogo);
            this.Controls.Add(this.TextTimerInsert);
            this.Controls.Add(this.TextTimerQuick);
            this.Controls.Add(this.TextTimerShaker);
            this.Controls.Add(this.TextTimerBubble);
            this.Controls.Add(this.ChartBogo);
            this.Controls.Add(this.ChartInsert);
            this.Controls.Add(this.ChartQuick);
            this.Controls.Add(this.ChartShaker);
            this.Controls.Add(this.ChartBubble);
            this.Controls.Add(this.checkBogo);
            this.Controls.Add(this.checkInsert);
            this.Controls.Add(this.checkQuick);
            this.Controls.Add(this.checkShaker);
            this.Controls.Add(this.checkBubble);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextLength);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBubble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartShaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartQuick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartBogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.TextBox TextLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBubble;
        private System.Windows.Forms.CheckBox checkShaker;
        private System.Windows.Forms.CheckBox checkQuick;
        private System.Windows.Forms.CheckBox checkInsert;
        private System.Windows.Forms.CheckBox checkBogo;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartBubble;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartShaker;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartQuick;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartInsert;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartBogo;
        private System.Windows.Forms.TextBox TextTimerBubble;
        private System.Windows.Forms.TextBox TextTimerShaker;
        private System.Windows.Forms.TextBox TextTimerQuick;
        private System.Windows.Forms.TextBox TextTimerInsert;
        private System.Windows.Forms.TextBox TextTimerBogo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataElem;
        private System.Windows.Forms.CheckBox checkRandom;
    }
}

