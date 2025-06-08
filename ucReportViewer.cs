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
using Microsoft.Reporting.WinForms;



namespace LGSPerformanceTracking
{
    public partial class ucReportViewer : UserControl
    {
        public ucReportViewer()
        {
            InitializeComponent();
        }

        private void ucReportViewer_Load(object sender, EventArgs e)
        {
            cmbExams.Items.Clear();
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ID, ExamName FROM Exams"; // İstersen WHERE StudentID ile filtrele
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbExams.Items.Add(new ComboBoxItem
                    {
                        Text = reader["ExamName"].ToString(),
                        Value = Convert.ToInt32(reader["ID"])
                    });
                }
            }
            if (cmbExams.Items.Count > 0)
                cmbExams.SelectedIndex = 0;
        }
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
        private void btnShowReport_Click(object sender, EventArgs e)
        {
            string selectedExamName = cmbExams.SelectedItem.ToString();

            var examTable = new StudentExamReportDataSet.StudentExamResultsDataTable();
            var lessonTable = new StudentExamReportDataSet.StudentLessonResultsDataTable();

            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Ana tabloyu doldur
                string examQuery = @"SELECT s.Name AS AdSoyad, e.ExamName, r.TotalNet, r.Score, r.CreatedAt, e.ID AS ExamId
                             FROM StudentResults r
                             INNER JOIN Exams e ON r.ExamID = e.ID
                             INNER JOIN Students s ON r.StudentID = s.ID
                             WHERE e.ExamName = @ExamName";
                SqlCommand cmdExam = new SqlCommand(examQuery, conn);
                cmdExam.Parameters.AddWithValue("@ExamName", selectedExamName);

                int examId = -1;
                SqlDataReader reader = cmdExam.ExecuteReader();
                if (reader.Read())
                {
                    string adSoyad = reader["AdSoyad"].ToString();
                    string sinavAdi = reader["ExamName"].ToString();
                    double net = Convert.ToDouble(reader["TotalNet"]);
                    double puan = Convert.ToDouble(reader["Score"]);
                    DateTime tarih = Convert.ToDateTime(reader["CreatedAt"]);
                    examId = Convert.ToInt32(reader["ExamId"]);
                    examTable.Rows.Add(adSoyad, sinavAdi, net, puan, tarih, examId);
                }
                reader.Close();

                // Detay tabloyu doldur
                string lessonQuery = @"SELECT DersAdi, Soru, Dogru, Yanlis, Bos, Net, Ortalama, ExamId
                               FROM StudentLessonResults
                               WHERE ExamId = @ExamID";
                SqlCommand cmdLesson = new SqlCommand(lessonQuery, conn);
                cmdLesson.Parameters.AddWithValue("@ExamID", examId);
                SqlDataReader reader2 = cmdLesson.ExecuteReader();
                while (reader2.Read())
                {
                    string dersAdi = reader2["DersAdi"].ToString();
                    int soru = Convert.ToInt32(reader2["Soru"]);
                    int dogru = Convert.ToInt32(reader2["Dogru"]);
                    int yanlis = Convert.ToInt32(reader2["Yanlis"]);
                    int bos = Convert.ToInt32(reader2["Bos"]);
                    double net = Convert.ToDouble(reader2["Net"]);
                    double ortalama = reader2["Ortalama"] == DBNull.Value ? 0 : Convert.ToDouble(reader2["Ortalama"]);
                    int exId = Convert.ToInt32(reader2["ExamId"]);

                    lessonTable.Rows.Add(dersAdi, soru, dogru, yanlis, bos, net, ortalama, exId);
                }
                reader2.Close();
            }

            // Raporu bağla ve göster
            reportViewerStudentReport.LocalReport.DataSources.Clear();
            reportViewerStudentReport.LocalReport.ReportEmbeddedResource = "LGSPerformanceTracking.studentReport.rdlc";

            reportViewerStudentReport.LocalReport.DataSources.Add(new ReportDataSource("StudentExamResultsDataSet", (DataTable)examTable));
            reportViewerStudentReport.LocalReport.DataSources.Add(new ReportDataSource("StudentLessonResults", (DataTable)lessonTable));
            reportViewerStudentReport.RefreshReport();
        }




    }
}
