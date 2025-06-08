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
    public partial class ucPerformansAnalysis : UserControl
    {
        public int currentStudentId;  // Giriş yapan öğrencinin ID'si

        public ucPerformansAnalysis()
        {
            InitializeComponent();
        }

        private void ucPerformansAnalysis_Load(object sender, EventArgs e)
        {
            LoadStatistics();                  
            cmbExamTypeFilter.Items.AddRange(new string[] { "Tüm Sınavlar", "Sayısal", "Sözel" });
            cmbExamTypeFilter.SelectedIndex = 0;
            LoadTrendChart("Tüm Sınavlar"); // cmbExamTypeFilter.SelectedIndex = 0’dan sonra
            LoadPieChart();
        }
        private void LoadStatistics()
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            SELECT  TotalNet, Score
            FROM StudentResults
            WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", currentStudentId);

                SqlDataReader reader = cmd.ExecuteReader();

                int totalExams = 0;
                double totalNumericNet = 0, totalVerbalNet = 0;
                int numericCount = 0, verbalCount = 0;
                double maxScore = double.MinValue;
                double minScore = double.MaxValue;

                while (reader.Read())
                {
                    
                    double net = Convert.ToDouble(reader["TotalNet"]);
                    double score = Convert.ToDouble(reader["Score"]);

                    totalExams++;
                    

                    if (score > maxScore) maxScore = score;
                    if (score < minScore) minScore = score;
                }

                reader.Close();

                txtTotalExams.Text = totalExams.ToString();
                txtAverageNumericNet.Text = numericCount > 0 ? (totalNumericNet / numericCount).ToString("0.00") : "0";
                txtAverageVerbalNet.Text = verbalCount > 0 ? (totalVerbalNet / verbalCount).ToString("0.00") : "0";
                txtMaxScore.Text = maxScore != double.MinValue ? maxScore.ToString("0.00") : "0";
                txtMinScore.Text = minScore != double.MaxValue ? minScore.ToString("0.00") : "0";
            }
        }
        private void cmbExamTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbExamTypeFilter.SelectedItem.ToString();
            LoadTrendChart(selectedType);  // Line & Column chart'ı güncelle
            LoadPieChart();                // Pie chart'ı güncelle
        }


        private void LoadTrendChart(string examType)
        {
            chartTrend.Series.Clear();
            chartTrend.ChartAreas.Clear();
            chartTrend.ChartAreas.Add(new ChartArea("Area1"));

            Series lineSeries = new Series("Puan")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            Series barSeries = new Series("Net")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };
            barSeries.Color = Color.CadetBlue;
            lineSeries.Color = Color.OrangeRed;
            lineSeries.BorderWidth = 3;
            barSeries["PointWidth"] = "0.5";

            
            

            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = $@"
            SELECT e.ExamName, r.TotalNet, r.Score
            FROM StudentResults r
            INNER JOIN Exams e ON e.ID = r.ExamID
            WHERE r.StudentID = @StudentID 
            ORDER BY r.CreatedAt";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", currentStudentId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string examName = reader["ExamName"].ToString();
                    double net = Convert.ToDouble(reader["TotalNet"]);
                    double score = Convert.ToDouble(reader["Score"]);

                    lineSeries.Points.AddXY(examName, score);
                    barSeries.Points.AddXY(examName, net);
                }

                chartTrend.Series.Add(lineSeries);
                chartTrend.Series.Add(barSeries);
            }
        }
        private void LoadPieChart()
        {
            chartPie.Series.Clear();
            chartPie.ChartAreas.Clear();
            chartPie.ChartAreas.Add(new ChartArea("PieArea"));

            Series pieSeries = new Series("Dağılım")
            {
                ChartType = SeriesChartType.Pie
            };

            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            SELECT TotalNet
            FROM StudentResults
            WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", currentStudentId);

                int low = 0, mid = 0, high = 0;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double net = Convert.ToDouble(reader["TotalNet"]);

                    if (net < 50) low++;
                    else if (net < 80) mid++;
                    else high++;
                }

                pieSeries.Points.AddXY("0-49 Net", low);
                pieSeries.Points.AddXY("50-79 Net", mid);
                pieSeries.Points.AddXY("80+ Net", high);

                chartPie.Series.Add(pieSeries);
            }
        }


    }
}
