namespace LGSPerformanceTracking
{
    partial class ucExamHistory
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvExamHistory = new System.Windows.Forms.DataGridView();
            this.btnLoadExamHistory = new System.Windows.Forms.Button();
            this.chartExamPerformance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnShowGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartExamPerformance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deneme Geçmişim:";
            // 
            // dgvExamHistory
            // 
            this.dgvExamHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExamHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamHistory.Location = new System.Drawing.Point(42, 70);
            this.dgvExamHistory.Name = "dgvExamHistory";
            this.dgvExamHistory.ReadOnly = true;
            this.dgvExamHistory.Size = new System.Drawing.Size(852, 169);
            this.dgvExamHistory.TabIndex = 1;
            // 
            // btnLoadExamHistory
            // 
            this.btnLoadExamHistory.Location = new System.Drawing.Point(196, 245);
            this.btnLoadExamHistory.Name = "btnLoadExamHistory";
            this.btnLoadExamHistory.Size = new System.Drawing.Size(218, 23);
            this.btnLoadExamHistory.TabIndex = 2;
            this.btnLoadExamHistory.Text = "Deneme Geçmişini Göster";
            this.btnLoadExamHistory.UseVisualStyleBackColor = true;
            this.btnLoadExamHistory.Click += new System.EventHandler(this.btnLoadExamHistory_Click);
            // 
            // chartExamPerformance
            // 
            legend1.Name = "Legend1";
            this.chartExamPerformance.Legends.Add(legend1);
            this.chartExamPerformance.Location = new System.Drawing.Point(42, 342);
            this.chartExamPerformance.Name = "chartExamPerformance";
            this.chartExamPerformance.Size = new System.Drawing.Size(852, 189);
            this.chartExamPerformance.TabIndex = 3;
            this.chartExamPerformance.Text = "chart1";
            // 
            // btnShowGraph
            // 
            this.btnShowGraph.Location = new System.Drawing.Point(196, 537);
            this.btnShowGraph.Name = "btnShowGraph";
            this.btnShowGraph.Size = new System.Drawing.Size(218, 23);
            this.btnShowGraph.TabIndex = 4;
            this.btnShowGraph.Text = "Grafik Olarak Göster";
            this.btnShowGraph.UseVisualStyleBackColor = true;
            this.btnShowGraph.Click += new System.EventHandler(this.btnShowGraph_Click);
            // 
            // ucExamHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowGraph);
            this.Controls.Add(this.chartExamPerformance);
            this.Controls.Add(this.btnLoadExamHistory);
            this.Controls.Add(this.dgvExamHistory);
            this.Controls.Add(this.label1);
            this.Name = "ucExamHistory";
            this.Size = new System.Drawing.Size(969, 641);
            this.Load += new System.EventHandler(this.ucExamHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartExamPerformance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvExamHistory;
        private System.Windows.Forms.Button btnLoadExamHistory;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExamPerformance;
        private System.Windows.Forms.Button btnShowGraph;
    }
}
