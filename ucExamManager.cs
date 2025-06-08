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
using System.Globalization; // dosya başına ekle



using Tesseract;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Text.RegularExpressions;

namespace LGSPerformanceTracking
{
    public partial class ucExamManager : UserControl
    {
        string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

        public ucExamManager()
        {
            InitializeComponent();
            LoadStudents();
            LoadExams();
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void LoadStudents()
        {
            cmbStudent.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, Surname FROM Students", conn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string fullName = dr["Name"].ToString() + " " + dr["Surname"].ToString();

                    cmbStudent.Items.Add(new ComboboxItem
                    {
                        Text = fullName,
                        Value = dr["ID"]
                    });
                }

                dr.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedItem == null) return;

            var studentId = ((ComboboxItem)cmbStudent.SelectedItem).Value;
            string examName = txtExamName.Text.Trim();
            DateTime date = dtpExamDate.Value;

            int math = (int)numMath.Value;
            int science = (int)numScience.Value;
            int turkish = (int)numTurkish.Value;
            int history = (int)numHistory.Value;
            int religion = (int)numReligion.Value;
            int english = (int)numEnglish.Value;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Exams (StudentID, ExamName, ExamDate, Math, Science, Turkish, History, Religion, English) " +
                               "VALUES (@StudentID, @ExamName, @ExamDate, @Math, @Science, @Turkish, @History, @Religion, @English)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@ExamName", examName);
                cmd.Parameters.AddWithValue("@ExamDate", date);
                cmd.Parameters.AddWithValue("@Math", math);
                cmd.Parameters.AddWithValue("@Science", science);
                cmd.Parameters.AddWithValue("@Turkish", turkish);
                cmd.Parameters.AddWithValue("@History", history);
                cmd.Parameters.AddWithValue("@Religion", religion);
                cmd.Parameters.AddWithValue("@English", english);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Exam saved successfully.");
            LoadExams();

        }
        private void LoadExams()
        {
            dgvExams.Rows.Clear();
            dgvExams.Columns.Clear();
            dgvExams.Columns.Add("ExamID", "Exam ID");
            dgvExams.Columns.Add("FullName", "Student Name");
            dgvExams.Columns.Add("ExamName", "Exam Name");
            dgvExams.Columns.Add("ExamDate", "Date");
            dgvExams.Columns.Add("Math", "Math");
            dgvExams.Columns.Add("Science", "Science");
            dgvExams.Columns.Add("Turkish", "Turkish");
            dgvExams.Columns.Add("History", "History");
            dgvExams.Columns.Add("Religion", "Religion");
            dgvExams.Columns.Add("English", "English");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT e.ID AS ExamID, s.Name + ' ' + s.Surname AS FullName, " +
                               "e.ExamName, e.ExamDate, e.Math, e.Science, e.Turkish, e.History, e.Religion, e.English " +
                               "FROM Exams e JOIN Students s ON e.StudentID = s.ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvExams.Rows.Add(
                        dr["ExamID"], dr["FullName"], dr["ExamName"], dr["ExamDate"],
                        dr["Math"], dr["Science"], dr["Turkish"], dr["History"],
                        dr["Religion"], dr["English"]
                    );
                }

                dr.Close();
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçin.");
                return;
            }

            int examId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["ExamID"].Value);

            string examName = txtExamName.Text.Trim();
            DateTime examDate = dtpExamDate.Value;

            int math = (int)numMath.Value;
            int science = (int)numScience.Value;
            int turkish = (int)numTurkish.Value;
            int history = (int)numHistory.Value;
            int religion = (int)numReligion.Value;
            int english = (int)numEnglish.Value;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            UPDATE Exams
            SET ExamName = @ExamName,
                ExamDate = @ExamDate,
                Math = @Math,
                Science = @Science,
                Turkish = @Turkish,
                History = @History,
                Religion = @Religion,
                English = @English
            WHERE ID = @ExamID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ExamName", examName);
                cmd.Parameters.AddWithValue("@ExamDate", examDate);
                cmd.Parameters.AddWithValue("@Math", math);
                cmd.Parameters.AddWithValue("@Science", science);
                cmd.Parameters.AddWithValue("@Turkish", turkish);
                cmd.Parameters.AddWithValue("@History", history);
                cmd.Parameters.AddWithValue("@Religion", religion);
                cmd.Parameters.AddWithValue("@English", english);
                cmd.Parameters.AddWithValue("@ExamID", examId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Sınav başarıyla güncellendi.");
            LoadExams(); // GridView'ı yenile
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.");
                return;
            }

            int examId = Convert.ToInt32(dgvExams.SelectedRows[0].Cells["ExamID"].Value);
            // Sütun adın bu değilse "Cells[0]" yap

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1. Önce StudentLessonResults tablosundaki bağlantılı kayıtları sil (varsa)
                SqlCommand cmdLessons = new SqlCommand("DELETE FROM StudentLessonResults WHERE ExamId = @ID OR SinavID = @ID", conn);
                cmdLessons.Parameters.AddWithValue("@ID", examId);
                cmdLessons.ExecuteNonQuery();

                // 2. Sonra StudentResults tablosundaki kayıtları sil
                SqlCommand cmdResults = new SqlCommand("DELETE FROM StudentResults WHERE ExamID = @ID", conn);
                cmdResults.Parameters.AddWithValue("@ID", examId);
                cmdResults.ExecuteNonQuery();

                // 3. En son Exams tablosundan sil
                SqlCommand cmdExam = new SqlCommand("DELETE FROM Exams WHERE ID = @ID", conn);
                cmdExam.Parameters.AddWithValue("@ID", examId);
                cmdExam.ExecuteNonQuery();
            }
            MessageBox.Show("Exam başarıyla silindi!");
            LoadExams(); // tabloyu yenile

        }


        private void btnImportPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;

                using (PdfReader reader = new PdfReader(filePath))
                using (PdfDocument pdfDoc = new PdfDocument(reader))
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        sb.AppendLine(PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i)));
                    }

                    string text = sb.ToString();

                    // 🧠 Bu noktada PDF'deki veriyi parse edip DataGridView'e eklemeliyiz
                    ParseAndLoadFromPdf(text);
                }
            }
        }
        private void ParseAndLoadFromPdf(string content)
        {
            string[] lines = content.Split('\n');

            string name = "", exam = "", domain = "";
            double net = 0, score = 0;

            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.ToLower().Contains("sözel"))
                    domain = "Verbal";
                else if (trimmedLine.ToLower().Contains("sayısal"))
                    domain = "Numeric";

                if (string.IsNullOrWhiteSpace(name) && trimmedLine.StartsWith("Ad:"))
                    name = trimmedLine.Replace("Ad:", "").Trim();

                if (string.IsNullOrWhiteSpace(exam) && trimmedLine.StartsWith("Sınav:"))
                    exam = trimmedLine.Replace("Sınav:", "").Trim();

                if (net == 0 && trimmedLine.StartsWith("Net:"))
                    double.TryParse(trimmedLine.Replace("Net:", "").Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out net);

                if (score == 0 && trimmedLine.StartsWith("Puan:"))
                    double.TryParse(trimmedLine.Replace("Puan:", "").Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out score);
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(exam))
            {
                MessageBox.Show("PDF verisinden öğrenci adı veya sınav adı alınamadı.", "Hata");
                return;
            }

            int studentId = GetStudentIdByFullName(name);
            int examId = GetExamIdByName(exam);

            if (studentId == -1 || examId == -1)
            {
                MessageBox.Show($"Öğrenci veya sınav bulunamadı: {name}, {exam}", "Uyarı");
                return;
            }

            DataTable dt = dgvAllExamResults.DataSource as DataTable;
            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row["StudentID"] = studentId;
                row["ExamID"] = examId;
                row["AdSoyad"] = name;
                row["SınavAdı"] = exam;
                
                row["Net"] = net;
                row["Puan"] = score;
                row["Tarih"] = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                dt.Rows.Add(row);
            }
            SaveResultToDatabase(studentId, examId, name, exam, net, score);
        }
        private void SaveResultToDatabase(int studentId, int examId, string fullName, string examName, double net, double score)
        {
            MessageBox.Show($"SaveResultToDatabase ÇAĞRILDI:\nstudentId={studentId}\nexamId={examId}\nfullName={fullName}\nexamName={examName}\nnet={net}\nscore={score}");
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Aynı StudentID ve ExamID varsa güncelle
                string checkQuery = @"
            SELECT COUNT(*) FROM StudentResults 
            WHERE StudentID = @StudentID AND ExamID = @ExamID";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@StudentID", studentId);
                    checkCmd.Parameters.AddWithValue("@ExamID", examId);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        string updateQuery = @"
                    UPDATE StudentResults
                    SET TotalNet = @TotalNet, Score = @Score, CreatedAt = GETDATE()
                    WHERE StudentID = @StudentID AND ExamID = @ExamID";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@StudentID", studentId);
                            updateCmd.Parameters.AddWithValue("@ExamID", examId);
                            updateCmd.Parameters.AddWithValue("@TotalNet", net);
                            updateCmd.Parameters.AddWithValue("@Score", score);
                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"📘 Güncellendi: {fullName} - {examName}");
                    }
                    else
                    {
                        string insertQuery = @"
                    INSERT INTO StudentResults (StudentID, ExamID, TotalNet, Score, CreatedAt)
                    VALUES (@StudentID, @ExamID, @TotalNet, @Score, GETDATE())";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@StudentID", studentId);
                            insertCmd.Parameters.AddWithValue("@ExamID", examId);
                            insertCmd.Parameters.AddWithValue("@TotalNet", net);
                            insertCmd.Parameters.AddWithValue("@Score", score);
                            insertCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"✅ Eklendi: {fullName} - {examName}");
                    }
                }
            }
        }



        private string FixOcrLabelNoise(string raw)
        {
            return raw
                .Replace("â", "a")
                .Replace("ä", "a")
                .Replace("ê", "e")
                .Replace("ë", "e")
                .Replace("î", "i")
                .Replace("ï", "i")
                .Replace("ô", "o")
                .Replace("ö", "o")
                .Replace("û", "u")
                .Replace("ü", "u")
                .Replace("ç", "c")
                .Replace("ş", "s")
                .Replace("ğ", "g")
                .Replace("ı", "i")
                .Replace("İ", "I")
                .Replace("ö", "o")
                .Replace("ü", "u")

                // OCR bozuk etiket düzeltmeleri
                .Replace("Ad:", "Ad:")
                .Replace("Sınav:", "Sınav:")
                .Replace("Tür:", "Tür:")
                .Replace("Net:", "Net:")
                .Replace("Puan:", "Puan:");
        }


        private void ParseAndLoadToGrid(string content)
        {
            content = FixOcrLabelNoise(content); // Gerekirse temizlik

            string[] lines = content.Split('\n');

            string name = "", exam = "";
            double net = 0, score = 0;

            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();

               

                if (string.IsNullOrWhiteSpace(name))
                {
                    var match = Regex.Match(trimmedLine, @"Ad[:\s]+(.+)", RegexOptions.IgnoreCase);
                    if (match.Success) name = match.Groups[1].Value.Trim();
                }

                if (string.IsNullOrWhiteSpace(exam))
                {
                    var match = Regex.Match(trimmedLine, @"Sınav[:\s]+(.+)", RegexOptions.IgnoreCase);
                    if (match.Success) exam = match.Groups[1].Value.Trim();
                }

                if (net == 0)
                {
                    var match = Regex.Match(trimmedLine, @"Net[:\s]+([\d.,]+)", RegexOptions.IgnoreCase);
                    if (match.Success)
                        double.TryParse(match.Groups[1].Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out net);
                }

                if (score == 0)
                {
                    var match = Regex.Match(trimmedLine, @"Puan[:\s]+([\d.,]+)", RegexOptions.IgnoreCase);
                    if (match.Success)
                        double.TryParse(match.Groups[1].Value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out score);
                }
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(exam))
            {
                MessageBox.Show("OCR çıktısından öğrenci adı veya sınav adı alınamadı.\n\nOCR İçeriği:\n" + content, "Hata");
                return;
            }

            int studentId = GetStudentIdByFullName(name);
            int examId = GetExamIdByName(exam);

            if (studentId == -1 || examId == -1)
            {
                MessageBox.Show($"Öğrenci veya sınav bulunamadı: {name}, {exam}", "Uyarı");
                return;
            }

            DataTable dt = dgvAllExamResults.DataSource as DataTable;
            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row["StudentID"] = studentId;
                row["ExamID"] = examId;
                row["AdSoyad"] = name;
                row["SınavAdı"] = exam;
                
                row["Net"] = net;
                row["Puan"] = score;
                row["Tarih"] = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                dt.Rows.Add(row);
            }
        }




        private int GetStudentIdByFullName(string fullName)
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            // Boşlukları sadeleştir, küçük harfe çevir
            string normalizedFullName = string.Join(" ", fullName.Trim().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
        SELECT ID, LOWER(LTRIM(RTRIM(Name))) + ' ' + LOWER(LTRIM(RTRIM(Surname))) AS FullName
        FROM Students";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dbFullName = reader["FullName"].ToString().Trim().ToLower();
                    if (dbFullName == normalizedFullName)
                    {
                        return Convert.ToInt32(reader["ID"]);
                    }
                }
            }

            return -1; // eşleşme bulunamadı
        }


        private int GetExamIdByName(string examName)
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            SELECT ID FROM Exams
            WHERE LOWER(LTRIM(RTRIM(ExamName))) = @examName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@examName", examName.Trim().ToLower());

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }




        private void ParseExamFromText(string text)
        {
            string GetValue(string[] labels)
            {
                foreach (var label in labels)
                {
                    var line = text.Split('\n').FirstOrDefault(l => l.StartsWith(label));
                    if (line != null)
                        return line.Substring(label.Length).Trim();
                }
                return "";
            }

            try
            {
                txtExamName.Text = GetValue(new[] { "Sınav:", "Exam Name:" });
                string dateStr = GetValue(new[] { "Tarih:", "Date:" });
                if (!string.IsNullOrWhiteSpace(dateStr))
                    dtpExamDate.Value = DateTime.Parse(dateStr);
                else
                    dtpExamDate.Value = DateTime.Now;

                numMath.Value = int.TryParse(GetValue(new[] { "Math:" }), out int m) ? m : 0;
                numScience.Value = int.TryParse(GetValue(new[] { "Science:" }), out int s) ? s : 0;
                numTurkish.Value = int.TryParse(GetValue(new[] { "Turkish:" }), out int t) ? t : 0;
                numHistory.Value = int.TryParse(GetValue(new[] { "History:" }), out int h) ? h : 0;
                numReligion.Value = int.TryParse(GetValue(new[] { "Religion:" }), out int r) ? r : 0;
                numEnglish.Value = int.TryParse(GetValue(new[] { "English:" }), out int e) ? e : 0;

                string fullName = GetValue(new[] { "Ad:", "Student:" });

                foreach (var item in cmbStudent.Items)
                {
                    if (((ComboboxItem)item).Text == fullName)
                    {
                        cmbStudent.SelectedItem = item;
                        break;
                    }
                }

                MessageBox.Show("OCR verisi başarıyla aktarıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void btnImportOCR_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ocrText = "";

                try
                {
                    using (var engine = new Tesseract.TesseractEngine(@"./tessdata", "tur", Tesseract.EngineMode.Default))
                    {
                        using (var img = Tesseract.Pix.LoadFromFile(ofd.FileName))
                        using (var page = engine.Process(img))
                        {
                            ocrText = page.GetText();
                        }
                    }
                    MessageBox.Show("OCR Metni:\n" + ocrText, "OCR Debug");
                    // 🧠 Metni al, forma aktar
                    ParseExamFromText(ocrText);
                    ParseAndLoadToGrid(ocrText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("OCR Error: " + ex.Message);
                }
            }
        }

        private void btnLoadAllResults_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
    SELECT 
        r.StudentID,
        r.ExamID,
        u.Username AS KullanıcıAdı,
        s.Name + ' ' + s.Surname AS AdSoyad,
        e.ExamName AS SınavAdı,
        r.TotalNet AS Net,
        r.Score AS Puan,
        FORMAT(r.CreatedAt, 'dd.MM.yyyy HH:mm') AS Tarih
    FROM StudentResults r
    INNER JOIN Exams e ON e.ID = r.ExamID
    INNER JOIN Users u ON u.StudentID = r.StudentID
    INNER JOIN Students s ON s.ID = r.StudentID
    ORDER BY r.CreatedAt DESC;
";





                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvAllExamResults.DataSource = dt;

                // 🔒 StudentID ve ExamID’yi gizle
                if (dgvAllExamResults.Columns.Contains("StudentID"))
                    dgvAllExamResults.Columns["StudentID"].Visible = false;

                if (dgvAllExamResults.Columns.Contains("ExamID"))
                    dgvAllExamResults.Columns["ExamID"].Visible = false;

            }
        }

        private void btnSaveImported_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

            int updateCount = 0, insertCount = 0, skipCount = 0, errorCount = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                foreach (DataGridViewRow row in dgvAllExamResults.Rows)
                {
                    if (row.IsNewRow) continue;

                    string fullName = row.Cells["AdSoyad"]?.Value?.ToString().Trim();
                    string examName = row.Cells["SınavAdı"]?.Value?.ToString().Trim();
                    double net = row.Cells["Net"]?.Value != DBNull.Value ? Convert.ToDouble(row.Cells["Net"].Value) : 0;
                    double score = row.Cells["Puan"]?.Value != DBNull.Value ? Convert.ToDouble(row.Cells["Puan"].Value) : 0;

                    if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(examName))
                    {
                        skipCount++;
                        continue;
                    }

                    int studentId = GetStudentIdByFullName(fullName);
                    int examId = GetExamIdByName(examName);

                    if (studentId == -1 || examId == -1)
                    {
                        skipCount++;
                        continue;
                    }

                    try
                    {
                        // Kayıt zaten var mı kontrol et
                        string checkQuery = @"
                    SELECT COUNT(*) FROM StudentResults 
                    WHERE StudentID = @StudentID AND ExamID = @ExamID";

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@StudentID", studentId);
                            checkCmd.Parameters.AddWithValue("@ExamID", examId);

                            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (exists > 0)
                            {
                                // Güncelle
                                string updateQuery = @"
                            UPDATE StudentResults
                            SET TotalNet = @TotalNet, Score = @Score, CreatedAt = GETDATE()
                            WHERE StudentID = @StudentID AND ExamID = @ExamID";

                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@StudentID", studentId);
                                    updateCmd.Parameters.AddWithValue("@ExamID", examId);
                                    updateCmd.Parameters.AddWithValue("@TotalNet", net);
                                    updateCmd.Parameters.AddWithValue("@Score", score);
                                    updateCmd.ExecuteNonQuery();
                                }
                                updateCount++;
                                continue;
                            }
                        }

                        // Ekle
                        string insertQuery = @"
                    INSERT INTO StudentResults (StudentID, ExamID, TotalNet, Score, CreatedAt)
                    VALUES (@StudentID, @ExamID, @TotalNet, @Score, GETDATE())";

                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@StudentID", studentId);
                            insertCmd.Parameters.AddWithValue("@ExamID", examId);
                            insertCmd.Parameters.AddWithValue("@TotalNet", net);
                            insertCmd.Parameters.AddWithValue("@Score", score);
                            insertCmd.ExecuteNonQuery();
                        }
                        insertCount++;
                    }
                    catch
                    {
                        errorCount++;
                    }
                }
            }

            MessageBox.Show(
                $"Kayıtlar güncellendi!\n\nYeni eklenen: {insertCount}\nGüncellenen: {updateCount}\nAtlanan: {skipCount}\nHatalı: {errorCount}",
                "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



    }
}
