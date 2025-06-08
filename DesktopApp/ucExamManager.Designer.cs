namespace LGSPerformanceTracking
{
    partial class ucExamManager
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
            this.grpExamEntry = new System.Windows.Forms.GroupBox();
            this.btnSaveImported = new System.Windows.Forms.Button();
            this.btnLoadAllResults = new System.Windows.Forms.Button();
            this.dgvAllExamResults = new System.Windows.Forms.DataGridView();
            this.dgvExams = new System.Windows.Forms.DataGridView();
            this.btnImportOCR = new System.Windows.Forms.Button();
            this.btnImportPDF = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpVerbal = new System.Windows.Forms.GroupBox();
            this.numEnglish = new System.Windows.Forms.NumericUpDown();
            this.numReligion = new System.Windows.Forms.NumericUpDown();
            this.numHistory = new System.Windows.Forms.NumericUpDown();
            this.numTurkish = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpNumeric = new System.Windows.Forms.GroupBox();
            this.numScience = new System.Windows.Forms.NumericUpDown();
            this.numMath = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpExamEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllExamResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).BeginInit();
            this.grpVerbal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnglish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReligion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTurkish)).BeginInit();
            this.grpNumeric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMath)).BeginInit();
            this.SuspendLayout();
            // 
            // grpExamEntry
            // 
            this.grpExamEntry.Controls.Add(this.btnSaveImported);
            this.grpExamEntry.Controls.Add(this.btnLoadAllResults);
            this.grpExamEntry.Controls.Add(this.dgvAllExamResults);
            this.grpExamEntry.Controls.Add(this.dgvExams);
            this.grpExamEntry.Controls.Add(this.btnImportOCR);
            this.grpExamEntry.Controls.Add(this.btnImportPDF);
            this.grpExamEntry.Controls.Add(this.btnDelete);
            this.grpExamEntry.Controls.Add(this.btnUpdate);
            this.grpExamEntry.Controls.Add(this.btnSave);
            this.grpExamEntry.Controls.Add(this.grpVerbal);
            this.grpExamEntry.Controls.Add(this.grpNumeric);
            this.grpExamEntry.Controls.Add(this.dtpExamDate);
            this.grpExamEntry.Controls.Add(this.txtExamName);
            this.grpExamEntry.Controls.Add(this.cmbStudent);
            this.grpExamEntry.Controls.Add(this.label3);
            this.grpExamEntry.Controls.Add(this.label2);
            this.grpExamEntry.Controls.Add(this.label1);
            this.grpExamEntry.Location = new System.Drawing.Point(37, 32);
            this.grpExamEntry.Name = "grpExamEntry";
            this.grpExamEntry.Size = new System.Drawing.Size(912, 708);
            this.grpExamEntry.TabIndex = 0;
            this.grpExamEntry.TabStop = false;
            this.grpExamEntry.Text = "Exam Entry";
            // 
            // btnSaveImported
            // 
            this.btnSaveImported.Location = new System.Drawing.Point(733, 664);
            this.btnSaveImported.Name = "btnSaveImported";
            this.btnSaveImported.Size = new System.Drawing.Size(120, 23);
            this.btnSaveImported.TabIndex = 20;
            this.btnSaveImported.Text = "Save to database";
            this.btnSaveImported.UseVisualStyleBackColor = true;
            this.btnSaveImported.Click += new System.EventHandler(this.btnSaveImported_Click);
            // 
            // btnLoadAllResults
            // 
            this.btnLoadAllResults.Location = new System.Drawing.Point(317, 623);
            this.btnLoadAllResults.Name = "btnLoadAllResults";
            this.btnLoadAllResults.Size = new System.Drawing.Size(212, 23);
            this.btnLoadAllResults.TabIndex = 19;
            this.btnLoadAllResults.Text = "Tüm öğrencilerin sonuçlarını getir";
            this.btnLoadAllResults.UseVisualStyleBackColor = true;
            this.btnLoadAllResults.Click += new System.EventHandler(this.btnLoadAllResults_Click);
            // 
            // dgvAllExamResults
            // 
            this.dgvAllExamResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllExamResults.Location = new System.Drawing.Point(10, 450);
            this.dgvAllExamResults.Name = "dgvAllExamResults";
            this.dgvAllExamResults.Size = new System.Drawing.Size(843, 167);
            this.dgvAllExamResults.TabIndex = 18;
            // 
            // dgvExams
            // 
            this.dgvExams.AllowUserToAddRows = false;
            this.dgvExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExams.Location = new System.Drawing.Point(10, 188);
            this.dgvExams.Name = "dgvExams";
            this.dgvExams.ReadOnly = true;
            this.dgvExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExams.Size = new System.Drawing.Size(843, 172);
            this.dgvExams.TabIndex = 17;
            // 
            // btnImportOCR
            // 
            this.btnImportOCR.Location = new System.Drawing.Point(235, 664);
            this.btnImportOCR.Name = "btnImportOCR";
            this.btnImportOCR.Size = new System.Drawing.Size(133, 23);
            this.btnImportOCR.TabIndex = 16;
            this.btnImportOCR.Text = "Import from OCR";
            this.btnImportOCR.UseVisualStyleBackColor = true;
            this.btnImportOCR.Click += new System.EventHandler(this.btnImportOCR_Click);
            // 
            // btnImportPDF
            // 
            this.btnImportPDF.Location = new System.Drawing.Point(471, 664);
            this.btnImportPDF.Name = "btnImportPDF";
            this.btnImportPDF.Size = new System.Drawing.Size(144, 23);
            this.btnImportPDF.TabIndex = 15;
            this.btnImportPDF.Text = "Import from PDF";
            this.btnImportPDF.UseVisualStyleBackColor = true;
            this.btnImportPDF.Click += new System.EventHandler(this.btnImportPDF_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(516, 389);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(384, 389);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(258, 389);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpVerbal
            // 
            this.grpVerbal.Controls.Add(this.numEnglish);
            this.grpVerbal.Controls.Add(this.numReligion);
            this.grpVerbal.Controls.Add(this.numHistory);
            this.grpVerbal.Controls.Add(this.numTurkish);
            this.grpVerbal.Controls.Add(this.label9);
            this.grpVerbal.Controls.Add(this.label8);
            this.grpVerbal.Controls.Add(this.label4);
            this.grpVerbal.Controls.Add(this.label6);
            this.grpVerbal.Location = new System.Drawing.Point(653, 24);
            this.grpVerbal.Name = "grpVerbal";
            this.grpVerbal.Size = new System.Drawing.Size(200, 142);
            this.grpVerbal.TabIndex = 11;
            this.grpVerbal.TabStop = false;
            this.grpVerbal.Text = "Sözel Alan";
            // 
            // numEnglish
            // 
            this.numEnglish.Location = new System.Drawing.Point(75, 106);
            this.numEnglish.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numEnglish.Name = "numEnglish";
            this.numEnglish.Size = new System.Drawing.Size(119, 20);
            this.numEnglish.TabIndex = 12;
            // 
            // numReligion
            // 
            this.numReligion.Location = new System.Drawing.Point(75, 80);
            this.numReligion.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numReligion.Name = "numReligion";
            this.numReligion.Size = new System.Drawing.Size(119, 20);
            this.numReligion.TabIndex = 11;
            // 
            // numHistory
            // 
            this.numHistory.Location = new System.Drawing.Point(75, 54);
            this.numHistory.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHistory.Name = "numHistory";
            this.numHistory.Size = new System.Drawing.Size(119, 20);
            this.numHistory.TabIndex = 10;
            // 
            // numTurkish
            // 
            this.numTurkish.Location = new System.Drawing.Point(75, 27);
            this.numTurkish.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numTurkish.Name = "numTurkish";
            this.numTurkish.Size = new System.Drawing.Size(119, 20);
            this.numTurkish.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "İngilizce";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Din Kültürü";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Türkçe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "İnkılap";
            // 
            // grpNumeric
            // 
            this.grpNumeric.Controls.Add(this.numScience);
            this.grpNumeric.Controls.Add(this.numMath);
            this.grpNumeric.Controls.Add(this.label5);
            this.grpNumeric.Controls.Add(this.label7);
            this.grpNumeric.Location = new System.Drawing.Point(391, 24);
            this.grpNumeric.Name = "grpNumeric";
            this.grpNumeric.Size = new System.Drawing.Size(200, 142);
            this.grpNumeric.TabIndex = 10;
            this.grpNumeric.TabStop = false;
            this.grpNumeric.Text = "Sayısal Alan";
            // 
            // numScience
            // 
            this.numScience.Location = new System.Drawing.Point(70, 59);
            this.numScience.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numScience.Name = "numScience";
            this.numScience.Size = new System.Drawing.Size(119, 20);
            this.numScience.TabIndex = 8;
            // 
            // numMath
            // 
            this.numMath.Location = new System.Drawing.Point(69, 32);
            this.numMath.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMath.Name = "numMath";
            this.numMath.Size = new System.Drawing.Size(120, 20);
            this.numMath.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Matematik";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fen Bilimleri";
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.Location = new System.Drawing.Point(91, 98);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(200, 20);
            this.dtpExamDate.TabIndex = 9;
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(91, 68);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(100, 20);
            this.txtExamName.TabIndex = 8;
            // 
            // cmbStudent
            // 
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(70, 33);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(121, 21);
            this.cmbStudent.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exam Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exam Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student";
            // 
            // ucExamManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpExamEntry);
            this.Name = "ucExamManager";
            this.Size = new System.Drawing.Size(1026, 871);
            
            this.grpExamEntry.ResumeLayout(false);
            this.grpExamEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllExamResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExams)).EndInit();
            this.grpVerbal.ResumeLayout(false);
            this.grpVerbal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnglish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReligion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTurkish)).EndInit();
            this.grpNumeric.ResumeLayout(false);
            this.grpNumeric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpExamEntry;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.GroupBox grpVerbal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpNumeric;
        private System.Windows.Forms.NumericUpDown numEnglish;
        private System.Windows.Forms.NumericUpDown numReligion;
        private System.Windows.Forms.NumericUpDown numHistory;
        private System.Windows.Forms.NumericUpDown numTurkish;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numScience;
        private System.Windows.Forms.NumericUpDown numMath;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvExams;
        private System.Windows.Forms.Button btnImportOCR;
        private System.Windows.Forms.Button btnImportPDF;
        private System.Windows.Forms.Button btnLoadAllResults;
        private System.Windows.Forms.DataGridView dgvAllExamResults;
        private System.Windows.Forms.Button btnSaveImported;
    }
}
