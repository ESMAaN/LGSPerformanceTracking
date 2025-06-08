namespace LGSPerformanceTracking
{
    partial class ucReportViewer
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
            this.reportViewerStudentReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbExams = new System.Windows.Forms.ComboBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reportViewerStudentReport
            // 
            this.reportViewerStudentReport.Location = new System.Drawing.Point(126, 98);
            this.reportViewerStudentReport.Name = "reportViewerStudentReport";
            this.reportViewerStudentReport.ServerReport.BearerToken = null;
            this.reportViewerStudentReport.Size = new System.Drawing.Size(1039, 335);
            this.reportViewerStudentReport.TabIndex = 0;
            // 
            // cmbExams
            // 
            this.cmbExams.FormattingEnabled = true;
            this.cmbExams.Location = new System.Drawing.Point(114, 32);
            this.cmbExams.Name = "cmbExams";
            this.cmbExams.Size = new System.Drawing.Size(121, 21);
            this.cmbExams.TabIndex = 1;
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(126, 69);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(97, 23);
            this.btnShowReport.TabIndex = 2;
            this.btnShowReport.Text = "Raporu Göster";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sınav Seç:";
            // 
            // ucReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.cmbExams);
            this.Controls.Add(this.reportViewerStudentReport);
            this.Name = "ucReportViewer";
            this.Size = new System.Drawing.Size(1457, 782);
            this.Load += new System.EventHandler(this.ucReportViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerStudentReport;
        private System.Windows.Forms.ComboBox cmbExams;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label label1;
    }
}
