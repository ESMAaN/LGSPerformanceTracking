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
using static LGSPerformanceTracking.ucExamManager;

namespace LGSPerformanceTracking
{
    public partial class ucAssignedExams : UserControl
    {
        public int currentStudentId { get; set; }  

        public ucAssignedExams()
        {
            InitializeComponent();
            ucAssignedExams_Load(this, EventArgs.Empty);  // ← Direkt çağır

        }
        private void ucAssignedExams_Load(object sender, EventArgs e)
        {
            // Başlangıçta bu alanlar aktif olsun
            grpNumerical.Enabled = true;
            grpVerbal.Enabled = true;
        }


        private void btnAddExam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSchoolName.Text) || string.IsNullOrWhiteSpace(txtOtherExams.Text))
            {
                MessageBox.Show("Lütfen okul adı ve deneme sınavı adını giriniz.");
                return;
            }

            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            int studentId = currentStudentId;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            INSERT INTO Exams 
                (StudentID, ExamDate, ExamName, SchoolName, Math, Science, Turkish, History, Religion, English)
            VALUES 
                (@StudentID, @ExamDate, @ExamName, @SchoolName, 0, 0, 0, 0, 0, 0)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@ExamDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ExamName", txtOtherExams.Text.Trim());
                cmd.Parameters.AddWithValue("@SchoolName", txtSchoolName.Text.Trim());

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Yeni sınav başarıyla eklendi.");
            
        }



        

        private void btnNumericCalculate_Click(object sender, EventArgs e)
        {
            // Sayısal doğru ve yanlış değerlerini al
            decimal mathCorrect = nudMathCorrect.Value;
            decimal mathWrong = nudMathWrong.Value;

            decimal scienceCorrect = nudScienceCorrect.Value;
            decimal scienceWrong = nudScienceWrong.Value;

            // Net hesaplama: doğru - (yanlış / 4)
            decimal mathNet = mathCorrect - (mathWrong / 4.0m);
            decimal scienceNet = scienceCorrect - (scienceWrong / 4.0m);

            // TextBox'lara yaz
            txtNetMath.Text = mathNet.ToString("0.00");
            txtNetScience.Text = scienceNet.ToString("0.00");

            // Toplam net
            decimal totalNet = mathNet + scienceNet;
            txtNumericTotalNet.Text = totalNet.ToString("0.00");

            // Puan hesapla (40 soru üzerinden 500 puan)
            decimal score = (totalNet / 40.0m) * 500.0m;
            txtNumericScore.Text = score.ToString("0.00");
        }

        private void btnVerbalCalculate_Click(object sender, EventArgs e)
        {
            // Sözel doğru ve yanlış değerleri
            decimal turkishCorrect = nudTurkishCorrect.Value;
            decimal turkishWrong = nudTurkishWrong.Value;

            decimal historyCorrect = nudHistoryCorrect.Value;
            decimal historyWrong = nudHistoryWrong.Value;

            decimal religionCorrect = nudReligionCorrect.Value;
            decimal religionWrong = nudReligionWrong.Value;

            decimal englishCorrect = nudEnglishCorrect.Value;
            decimal englishWrong = nudEnglishWrong.Value;

            // Net hesaplama
            decimal turkishNet = turkishCorrect - (turkishWrong / 4.0m);
            decimal historyNet = historyCorrect - (historyWrong / 4.0m);
            decimal religionNet = religionCorrect - (religionWrong / 4.0m);
            decimal englishNet = englishCorrect - (englishWrong / 4.0m);

            // Netleri yaz
            txtNetTurkish.Text = turkishNet.ToString("0.00");
            txtNetHistory.Text = historyNet.ToString("0.00");
            txtNetReligion.Text = religionNet.ToString("0.00");
            txtNetEnglish.Text = englishNet.ToString("0.00");

            // Toplam net ve puan
            decimal totalNet = turkishNet + historyNet + religionNet + englishNet;
            txtVerbalTotalNet.Text = totalNet.ToString("0.00");

            // Sözel puan hesapla (60 soru üzerinden)
            decimal score = (totalNet / 60.0m) * 500.0m;
            txtVerbalScore.Text = score.ToString("0.00");
        }

        private void btnSubmitNumericResults_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumericTotalNet.Text) || string.IsNullOrWhiteSpace(txtNumericScore.Text))
            {
                MessageBox.Show("Lütfen önce sayısal hesaplamayı yapınız.");
                return;
            }



            MessageBox.Show("Sayısal başarı hesaplandı. Grafiklerde gösterime hazır.");
        }


        private void btnSubmitVerbalScore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVerbalTotalNet.Text) || string.IsNullOrWhiteSpace(txtVerbalScore.Text))
            {
                MessageBox.Show("Lütfen önce sözel hesaplamayı yapınız.");
                return;
            }

            MessageBox.Show("Sözel başarı hesaplandı. Grafiklerde gösterime hazır.");
        }


        private void txtOtherExams_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSchoolName.Text) && !string.IsNullOrWhiteSpace(txtOtherExams.Text))
            {
                grpNumerical.Enabled = true;
                grpVerbal.Enabled = true;
            }
        }

        private void AddLessonResult(int studentId, int examId, string dersAdi, int soru, int dogru, int yanlis, int bos, double net)
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
        INSERT INTO StudentLessonResults (DersAdi, Soru, Dogru, Yanlis, Bos, Net, SinavID, StudentId, ExamId, CreatedAt)
VALUES (@DersAdi, @Soru, @Dogru, @Yanlis, @Bos, @Net, @SinavID, @StudentId, @ExamId, @CreatedAt)
";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DersAdi", dersAdi);
                cmd.Parameters.AddWithValue("@Soru", soru);
                cmd.Parameters.AddWithValue("@Dogru", dogru);
                cmd.Parameters.AddWithValue("@Yanlis", yanlis);
                cmd.Parameters.AddWithValue("@Bos", bos);
                cmd.Parameters.AddWithValue("@Net", net);
                cmd.Parameters.AddWithValue("@SinavID", examId); // ← Buraya DİKKAT!
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@ExamId", examId);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);


                cmd.ExecuteNonQuery();
            }
        }


        private void SubmitCombined_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSchoolName.Text) || string.IsNullOrWhiteSpace(txtOtherExams.Text))
            {
                MessageBox.Show("Lütfen Okul Adı ve Deneme Sınavı Adı giriniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNumericScore.Text) ||
                string.IsNullOrWhiteSpace(txtVerbalScore.Text) ||
                string.IsNullOrWhiteSpace(txtNumericTotalNet.Text) ||
                string.IsNullOrWhiteSpace(txtVerbalTotalNet.Text))
            {
                MessageBox.Show("Lütfen sayısal ve sözel alanları hesaplayınız.");
                return;
            }

            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
            int studentId = currentStudentId;

            double numericNet = double.Parse(txtNumericTotalNet.Text);
            double verbalNet = double.Parse(txtVerbalTotalNet.Text);
            double totalNet = numericNet + verbalNet;
            double totalScore = (totalNet / 100.0) * 500.0;

            int examId;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1. Aynı okul ve sınav adı varsa al, yoksa oluştur
                string checkQuery = @"SELECT ID FROM Exams 
                              WHERE StudentID = @StudentID AND 
                                    ExamName = @ExamName AND 
                                    SchoolName = @SchoolName";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@StudentID", studentId);
                checkCmd.Parameters.AddWithValue("@ExamName", txtOtherExams.Text.Trim());
                checkCmd.Parameters.AddWithValue("@SchoolName", txtSchoolName.Text.Trim());

                object result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    examId = Convert.ToInt32(result);
                }
                else
                {
                    string insertExam = @"INSERT INTO Exams 
                                (StudentID, ExamDate, ExamName, SchoolName, Math, Science, Turkish, History, Religion, English)
                                VALUES 
                                (@StudentID, @ExamDate, @ExamName, @SchoolName, 0, 0, 0, 0, 0, 0);
                                SELECT SCOPE_IDENTITY();";

                    SqlCommand insertCmd = new SqlCommand(insertExam, conn);
                    insertCmd.Parameters.AddWithValue("@StudentID", studentId);
                    insertCmd.Parameters.AddWithValue("@ExamDate", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@ExamName", txtOtherExams.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@SchoolName", txtSchoolName.Text.Trim());

                    examId = Convert.ToInt32(insertCmd.ExecuteScalar());
                }

                // 2. Daha önce sonuç girilmiş mi kontrol et
                string checkResult = "SELECT COUNT(*) FROM StudentResults WHERE StudentID = @StudentID AND ExamID = @ExamID";
                SqlCommand checkResultCmd = new SqlCommand(checkResult, conn);
                checkResultCmd.Parameters.AddWithValue("@StudentID", studentId);
                checkResultCmd.Parameters.AddWithValue("@ExamID", examId);

                int exists = (int)checkResultCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("Bu sınav için sonuç daha önce girilmiş.");
                    return;
                }

                // 3. Sonucu kaydet
                string insertResult = @"INSERT INTO StudentResults (StudentID, ExamID, TotalNet, Score, CreatedAt)
                                VALUES (@StudentID, @ExamID, @TotalNet, @Score, @CreatedAt)";
                SqlCommand cmd = new SqlCommand(insertResult, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@ExamID", examId);
                cmd.Parameters.AddWithValue("@TotalNet", totalNet);
                cmd.Parameters.AddWithValue("@Score", totalScore);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
            // --- Her ders için kaydet ---
            AddLessonResult(studentId, examId, "Matematik", 20, (int)nudMathCorrect.Value, (int)nudMathWrong.Value, (int)nudMathBlank.Value, double.Parse(txtNetMath.Text));
            AddLessonResult(studentId, examId, "Fen Bilimleri", 20, (int)nudScienceCorrect.Value, (int)nudScienceWrong.Value, (int)nudScienceBlank.Value, double.Parse(txtNetScience.Text));
            AddLessonResult(studentId, examId, "Türkçe", 20, (int)nudTurkishCorrect.Value, (int)nudTurkishWrong.Value, (int)nudTurkishBlank.Value, double.Parse(txtNetTurkish.Text));
            AddLessonResult(studentId, examId, "İnkılap", 10, (int)nudHistoryCorrect.Value, (int)nudHistoryWrong.Value, (int)nudHistoryBlank.Value, double.Parse(txtNetHistory.Text));
            AddLessonResult(studentId, examId, "Din Kültürü", 10, (int)nudReligionCorrect.Value, (int)nudReligionWrong.Value, (int)nudReligionBlank.Value, double.Parse(txtNetReligion.Text));
            AddLessonResult(studentId, examId, "İngilizce", 10, (int)nudEnglishCorrect.Value, (int)nudEnglishWrong.Value, (int)nudEnglishBlank.Value, double.Parse(txtNetEnglish.Text));


            MessageBox.Show("Sonuç başarıyla kaydedildi.");
        }



    }
}
