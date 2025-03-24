using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _
{
    public class ScoreForm: Form
    {
        private DataGridView dgvScores;
        private string connectionString = "server=localhost;database=SchoolDB;user=root;password=yourpassword";

        public ScoreForm(String id)
        {
            Console.WriteLine("Id: " + id);
            // Thiết lập Form
            this.Text = "Xem Điểm Sinh Viên";
            this.Size = new Size(600, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView
            dgvScores = new DataGridView()
            {
                Location = new Point(20, 20),
                Size = new Size(540, 250),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Thêm vào Form
            this.Controls.Add(dgvScores);
            // LoadScores();
        }

        private void LoadScores()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT s.Id, s.Name, sc.Math, sc.Physics, sc.Chemistry, sc.Total
                                 FROM Students s 
                                 LEFT JOIN Scores sc ON s.Id = sc.StudentId";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvScores.DataSource = dt;
            }
        }
    }
}
