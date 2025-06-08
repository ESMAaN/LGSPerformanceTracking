using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LGSPerformanceTracking
{
    public partial class ucStudentManager : UserControl
    {
        string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";
        int selectedStudentId = -1;

        public ucStudentManager()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Students";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Students (Name, Surname, School, Class) VALUES (@Name, @Surname, @School, @Class)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                cmd.Parameters.AddWithValue("@School", txtSchool.Text.Trim());
                cmd.Parameters.AddWithValue("@Class", txtClass.Text.Trim());
                conn.Open();
                cmd.ExecuteNonQuery();
                LoadStudents();
                MessageBox.Show("Öğrenci eklendi.");
                ClearFields();
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek öğrenciyi seçin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Students SET Name=@Name, Surname=@Surname, School=@School, Class=@Class WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                cmd.Parameters.AddWithValue("@School", txtSchool.Text.Trim());
                cmd.Parameters.AddWithValue("@Class", txtClass.Text.Trim());
                cmd.Parameters.AddWithValue("@ID", selectedStudentId);
                conn.Open();
                cmd.ExecuteNonQuery();
                LoadStudents();
                MessageBox.Show("Öğrenci güncellendi.");
                ClearFields();
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Lütfen silinecek öğrenciyi seçin.");
                return;
            }

            var result = MessageBox.Show("Seçilen öğrenciyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Students WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", selectedStudentId);
                conn.Open();
                cmd.ExecuteNonQuery();
                LoadStudents();
                MessageBox.Show("Öğrenci silindi.");
                ClearFields();
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["ID"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtSchool.Text = row.Cells["School"].Value.ToString();
                txtClass.Text = row.Cells["Class"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtSchool.Clear();
            txtClass.Clear();
            selectedStudentId = -1;
        }
    }
}
