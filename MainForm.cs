using System;
using System.Drawing;
using System.Windows.Forms;
using SchoolManagement;

namespace _
{
    public class MainForm : Form
    {
        private Label lblTitle;
        private Button btnLogin, btnLogout, studentBtn, scoreBtn, teacherBTn;

        public MainForm()
        {
            // Cấu hình Form
            this.Text = "School Management";
            this.Size = new Size(600, 350);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Tiêu đề
            lblTitle = new Label()
            {
                Text = "School Management",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(150, 50)
            };

            teacherBTn = new Button() {
                
                Text = "Teacher Form",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(350, 250),
                Size = new Size(100, 50),
                FlatStyle = FlatStyle.Flat
            };

            teacherBTn.Click += BTNTeacher;


            this.Controls.Add(teacherBTn);
            

            // Nút Login
            btnLogin = new Button()
            {
                Text = "Login",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(150, 150),
                Size = new Size(100, 50),
                FlatStyle = FlatStyle.Flat
            };

   
            scoreBtn = new Button()
            {
                Text = "Score Student",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(300, 200),
                Size = new Size(100, 50),
                FlatStyle = FlatStyle.Flat
            };

            scoreBtn.Click += BtnStudentScore;

            studentBtn = new Button() 
            {
                Text = "User",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(150, 250),
                Size = new Size(100, 50),
                FlatStyle = FlatStyle.Flat

            };

            studentBtn.Click += BtnStudent;

            btnLogin.Click += BtnLogin_Click;

            // Nút Logout
            btnLogout = new Button()
            {
                Text = "Log out",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Green,
                Location = new Point(350, 150),
                Size = new Size(100, 50),
                FlatStyle = FlatStyle.Flat
            };
            btnLogout.Click += BtnLogout_Click;

            // Thêm vào Form
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnLogout);

            this.Controls.Add(studentBtn);
            this.Controls.Add(scoreBtn);

        }

        private void BTNTeacher(object? sender, EventArgs e)
        {
            new TeacherForm().ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(); // Hiện Form Login

            // MessageBox.Show("Login clicked!");

        }


        private void BtnStudentScore(object sender, EventArgs e) {
            StudentScore student= new StudentScore();
            student.ShowDialog();
        }

        private void BtnStudent(object sender, EventArgs e) {
            StudentForm student= new StudentForm();
            student.ShowDialog();
        }



        private void BtnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout clicked!");
        }

        // [STAThread]
        // static void Main()
        // {
        //     Application.EnableVisualStyles();
        //     Application.SetCompatibleTextRenderingDefault(false);
        //     Application.Run(new MainForm());
        // }
    }
}
