using System;
using System.Windows.Forms;

namespace LGSPerformanceTracking
{
    public partial class SplashScreen : Form
    {
        private int progressValue = 0;

        private string _role;
        private string _username;

        // ✅ Parametreli constructor
        public SplashScreen(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            timer1.Interval = 50;
            timer1.Start();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressValue += 2;
            progressBar1.Value = Math.Min(progressValue, 100);

            if (progressBar1.Value >= 100)
            {
                timer1.Stop();

                // ✅ Splash bittikten sonra role göre form aç
                if (_role == "Admin")
                {
                    AdminDashboard adminForm = new AdminDashboard();
                    adminForm.Show();
                }
                else
                {
                    StudentDashboard studentForm = new StudentDashboard(_username);
                    studentForm.Show();
                }

                this.Close(); // Splash ekranını kapat
            }
        }
    }
}
