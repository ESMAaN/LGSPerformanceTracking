using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LGSPerformanceTracking
{
    public partial class Login : Form
    {
        string connStr = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=LGSTrackingDB;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Student");
            cmbRole.SelectedIndex = 0;
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ID, Role, StudentID FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // ✅ Kullanıcı bulundu
                        MessageBox.Show("Login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // ✅ Splash ekranına geçiş yap
                        string userRole = reader["Role"].ToString();
                        SplashScreen splash = new SplashScreen(userRole, username);
                        splash.Show();

                        this.Hide(); // Login ekranını kapat
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



    }
}
