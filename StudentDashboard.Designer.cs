namespace LGSPerformanceTracking
{
    partial class StudentDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPerformance = new System.Windows.Forms.Button();
            this.btnExamHistory = new System.Windows.Forms.Button();
            this.btnAssignedExams = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnPerformance);
            this.panelMenu.Controls.Add(this.btnExamHistory);
            this.panelMenu.Controls.Add(this.btnAssignedExams);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 450);
            this.panelMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(0, 137);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Çıkış";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPerformance
            // 
            this.btnPerformance.Location = new System.Drawing.Point(0, 92);
            this.btnPerformance.Name = "btnPerformance";
            this.btnPerformance.Size = new System.Drawing.Size(200, 23);
            this.btnPerformance.TabIndex = 2;
            this.btnPerformance.Text = "Performans Analizi";
            this.btnPerformance.UseVisualStyleBackColor = true;
            this.btnPerformance.Click += new System.EventHandler(this.btnPerformance_Click);
            // 
            // btnExamHistory
            // 
            this.btnExamHistory.Location = new System.Drawing.Point(0, 45);
            this.btnExamHistory.Name = "btnExamHistory";
            this.btnExamHistory.Size = new System.Drawing.Size(200, 23);
            this.btnExamHistory.TabIndex = 1;
            this.btnExamHistory.Text = "Deneme Geçmişi";
            this.btnExamHistory.UseVisualStyleBackColor = true;
            this.btnExamHistory.Click += new System.EventHandler(this.btnExamHistory_Click);
            // 
            // btnAssignedExams
            // 
            this.btnAssignedExams.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAssignedExams.Location = new System.Drawing.Point(0, 0);
            this.btnAssignedExams.Name = "btnAssignedExams";
            this.btnAssignedExams.Size = new System.Drawing.Size(200, 23);
            this.btnAssignedExams.TabIndex = 0;
            this.btnAssignedExams.Text = " Deneme Sınavı Ekle";
            this.btnAssignedExams.UseVisualStyleBackColor = true;
            this.btnAssignedExams.Click += new System.EventHandler(this.btnAssignedExams_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 450);
            this.mainPanel.TabIndex = 2;
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.label1);
            this.Name = "StudentDashboard";
            this.Text = "StudentDashboard";
            this.Load += new System.EventHandler(this.StudentDashboard_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPerformance;
        private System.Windows.Forms.Button btnExamHistory;
        private System.Windows.Forms.Button btnAssignedExams;
        private System.Windows.Forms.Panel mainPanel;
    }
}