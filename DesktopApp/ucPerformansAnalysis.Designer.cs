namespace LGSPerformanceTracking
{
    partial class ucPerformansAnalysis
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.grpStatistics = new System.Windows.Forms.GroupBox();
            this.txtMinScore = new System.Windows.Forms.TextBox();
            this.txtMaxScore = new System.Windows.Forms.TextBox();
            this.txtAverageVerbalNet = new System.Windows.Forms.TextBox();
            this.txtTotalExams = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAverageNumericNet = new System.Windows.Forms.TextBox();
            this.cmbExamTypeFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chartTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStatistics
            // 
            this.grpStatistics.Controls.Add(this.txtAverageNumericNet);
            this.grpStatistics.Controls.Add(this.label6);
            this.grpStatistics.Controls.Add(this.txtMinScore);
            this.grpStatistics.Controls.Add(this.txtMaxScore);
            this.grpStatistics.Controls.Add(this.txtAverageVerbalNet);
            this.grpStatistics.Controls.Add(this.txtTotalExams);
            this.grpStatistics.Controls.Add(this.label4);
            this.grpStatistics.Controls.Add(this.label3);
            this.grpStatistics.Controls.Add(this.label2);
            this.grpStatistics.Controls.Add(this.label1);
            this.grpStatistics.Location = new System.Drawing.Point(3, 43);
            this.grpStatistics.Name = "grpStatistics";
            this.grpStatistics.Size = new System.Drawing.Size(318, 241);
            this.grpStatistics.TabIndex = 0;
            this.grpStatistics.TabStop = false;
            this.grpStatistics.Text = "Özel İstatistik";
            // 
            // txtMinScore
            // 
            this.txtMinScore.Location = new System.Drawing.Point(167, 185);
            this.txtMinScore.Name = "txtMinScore";
            this.txtMinScore.ReadOnly = true;
            this.txtMinScore.Size = new System.Drawing.Size(100, 20);
            this.txtMinScore.TabIndex = 9;
            // 
            // txtMaxScore
            // 
            this.txtMaxScore.Location = new System.Drawing.Point(167, 147);
            this.txtMaxScore.Name = "txtMaxScore";
            this.txtMaxScore.ReadOnly = true;
            this.txtMaxScore.Size = new System.Drawing.Size(100, 20);
            this.txtMaxScore.TabIndex = 8;
            // 
            // txtAverageVerbalNet
            // 
            this.txtAverageVerbalNet.Location = new System.Drawing.Point(167, 107);
            this.txtAverageVerbalNet.Name = "txtAverageVerbalNet";
            this.txtAverageVerbalNet.ReadOnly = true;
            this.txtAverageVerbalNet.Size = new System.Drawing.Size(100, 20);
            this.txtAverageVerbalNet.TabIndex = 7;
            // 
            // txtTotalExams
            // 
            this.txtTotalExams.Location = new System.Drawing.Point(167, 31);
            this.txtTotalExams.Name = "txtTotalExams";
            this.txtTotalExams.ReadOnly = true;
            this.txtTotalExams.Size = new System.Drawing.Size(100, 20);
            this.txtTotalExams.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "En düşük puan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "En yüksek puan:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ortalama sayısal net:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Toplam katıldığı sınav sayısı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ortalama sözel net:";
            // 
            // txtAverageNumericNet
            // 
            this.txtAverageNumericNet.Location = new System.Drawing.Point(167, 69);
            this.txtAverageNumericNet.Name = "txtAverageNumericNet";
            this.txtAverageNumericNet.ReadOnly = true;
            this.txtAverageNumericNet.Size = new System.Drawing.Size(100, 20);
            this.txtAverageNumericNet.TabIndex = 11;
            // 
            // cmbExamTypeFilter
            // 
            this.cmbExamTypeFilter.FormattingEnabled = true;
            this.cmbExamTypeFilter.Location = new System.Drawing.Point(492, 54);
            this.cmbExamTypeFilter.Name = "cmbExamTypeFilter";
            this.cmbExamTypeFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbExamTypeFilter.TabIndex = 1;
            this.cmbExamTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbExamTypeFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sınav türünü seçiniz:";
            // 
            // chartTrend
            // 
            chartArea5.Name = "ChartArea1";
            this.chartTrend.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartTrend.Legends.Add(legend5);
            this.chartTrend.Location = new System.Drawing.Point(342, 96);
            this.chartTrend.Name = "chartTrend";
            this.chartTrend.Size = new System.Drawing.Size(334, 227);
            this.chartTrend.TabIndex = 3;
            this.chartTrend.Text = "chart1";
            // 
            // chartPie
            // 
            chartArea6.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartPie.Legends.Add(legend6);
            this.chartPie.Location = new System.Drawing.Point(398, 351);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(255, 234);
            this.chartPie.TabIndex = 4;
            this.chartPie.Text = "chart1";
            // 
            // ucPerformansAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.chartTrend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbExamTypeFilter);
            this.Controls.Add(this.grpStatistics);
            this.Name = "ucPerformansAnalysis";
            this.Size = new System.Drawing.Size(953, 639);
            this.Load += new System.EventHandler(this.ucPerformansAnalysis_Load);
            this.grpStatistics.ResumeLayout(false);
            this.grpStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.TextBox txtMinScore;
        private System.Windows.Forms.TextBox txtMaxScore;
        private System.Windows.Forms.TextBox txtAverageVerbalNet;
        private System.Windows.Forms.TextBox txtTotalExams;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAverageNumericNet;
        private System.Windows.Forms.ComboBox cmbExamTypeFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
    }
}
