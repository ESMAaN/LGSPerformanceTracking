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
using System.Windows.Forms.DataVisualization.Charting;

namespace LGSPerformanceTracking
{
    public partial class ucExamHistory : UserControl
    {
        public int CurrentStudentId { get; set; }

        public ucExamHistory()
        {
            InitializeComponent();
        }

        private void ucExamHistory_Load(object sender, EventArgs e)
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT e.ExamName, e.ExamDate, r.TotalNet, r.Score, r.CreatedAt
                             FROM StudentResults r
                             INNER JOIN Exams e ON r.ExamID = e.ID
                             WHERE r.StudentID = @StudentID
                             ORDER BY r.CreatedAt DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", CurrentStudentId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvExamHistory.DataSource = dt;
            }
        }

        private void btnLoadExamHistory_Click(object sender, EventArgs e)
        {
            LoadExamHistory();
        }
        private void LoadExamHistory()
        {
            if (CurrentStudentId == 0)
            {
                MessageBox.Show("❗CurrentStudentId değeri atanmadı (0). Öğrenci girişiyle ilişki kurulamadı.", "Hata");
                return;
            }

            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT 
                e.ExamName AS [Sınav Adı],
                
                r.TotalNet AS [Toplam Net],
                r.Score AS [Puan],
                FORMAT(r.CreatedAt, 'dd.MM.yyyy HH:mm') AS [Tarih]
            FROM StudentResults r
            INNER JOIN Exams e ON r.ExamID = e.ID
            WHERE r.StudentID = @StudentID
            ORDER BY r.CreatedAt DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", CurrentStudentId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvExamHistory.DataSource = dt;

                MessageBox.Show($"🟢 {dt.Rows.Count} kayıt yüklendi.\nAktif StudentID: {CurrentStudentId}", "Deneme Geçmişi");
            }
        }


        private void btnShowGraph_Click(object sender, EventArgs e)
        {
            chartExamPerformance.Series.Clear();
            chartExamPerformance.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("MainArea");
            chartExamPerformance.ChartAreas.Add(chartArea);

            // 1. Sütun serisi
            Series columnSeries = new Series("Puan - Sütun")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double,
                Color = Color.SkyBlue
            };

            // 2. Çizgi serisi
            Series lineSeries = new Series("Puan - Çizgi")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double,
                Color = Color.DarkBlue,
                BorderWidth = 2
            };

            // Verileri ekle
            foreach (DataGridViewRow row in dgvExamHistory.Rows)
            {
                if (row.Cells["Sınav Adı"].Value != null && row.Cells["Puan"].Value != null)
                {
                    string examName = row.Cells["Sınav Adı"].Value.ToString();
                    double score = Convert.ToDouble(row.Cells["Puan"].Value);

                    columnSeries.Points.AddXY(examName, score);
                    lineSeries.Points.AddXY(examName, score);
                }
            }

            // Serileri grafiğe ekle
            chartExamPerformance.Series.Add(columnSeries);
            chartExamPerformance.Series.Add(lineSeries);

        }


    }
}
