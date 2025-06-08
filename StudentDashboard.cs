using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LGSPerformanceTracking
{
    public partial class StudentDashboard : Form
    {
        public string currentUsername;
        public int aktifOgrenciId;

        public StudentDashboard(string username)
        {
            InitializeComponent();
            currentUsername = username;
            GetStudentIdByUsername(); // ← bu fonksiyonu çağır
        }
        private void GetStudentIdByUsername()
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT StudentID FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", currentUsername);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    aktifOgrenciId = Convert.ToInt32(result);
                }
            }
        }



        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            // Öğrenci dashboard açılır açılmaz geçmiş yüklensin
            btnExamHistory_Click(null, null);
        }

        private void btnAssignedExams_Click(object sender, EventArgs e)
        {
            ucAssignedExams uc = new ucAssignedExams();
            uc.currentStudentId = aktifOgrenciId;  // Giriş yapan öğrencinin ID'si
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnExamHistory_Click(object sender, EventArgs e)
        {
            ucExamHistory uc = new ucExamHistory();
            uc.CurrentStudentId = aktifOgrenciId;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }


        private void btnPerformance_Click(object sender, EventArgs e)
        {
            ucPerformansAnalysis uc = new ucPerformansAnalysis();
            uc.currentStudentId = aktifOgrenciId;  // Giriş yapan öğrenci ID'sini geçir
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Close(); // StudentDashboard’u kapat
            }
        }
    }
}
