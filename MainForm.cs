using System;
using System.Drawing;
using System.Windows.Forms;
using SchoolManagement;

namespace SchoolManagementApp
{
    public class MainForm : Form
    {
        private Label lblTitle;
        private Button btnLogin, btnLogout, btnStudent, btnScore, btnTeacher;

        public MainForm()
        {
            // Cấu hình Form
            this.Text = "School Management System";
            this.Size = new Size(700, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 244, 248); // Màu nền nhạt, hiện đại

            // Tiêu đề
            lblTitle = new Label
            {
                Text = "School Management System",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80), // Xanh đậm
                AutoSize = true,
                Location = new Point((this.ClientSize.Width - 400) / 2, 30) // Căn giữa
            };

            // Tạo bố cục cho các nút
            int buttonWidth = 140;
            int buttonHeight = 45;
            int spacing = 20;
            int startX = (this.ClientSize.Width - (buttonWidth * 3 + spacing * 2)) / 2;
            int startY = 120;

            // Nút Login
            btnLogin = new Button
            {
                Text = "Login",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 152, 219), // Xanh dương
                Location = new Point(startX, startY),
                Size = new Size(buttonWidth, buttonHeight),
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            // Nút User (Student)
            btnStudent = new Button
            {
                Text = "Student",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(46, 204, 113), // Xanh lá
                Location = new Point(startX + buttonWidth + spacing, startY),
                Size = new Size(buttonWidth, buttonHeight),
                FlatStyle = FlatStyle.Flat
            };
            btnStudent.FlatAppearance.BorderSize = 0;
            btnStudent.Click += BtnStudent;

            // Nút Score
            btnScore = new Button
            {
                Text = "Student Score",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(231, 76, 60), // Đỏ
                Location = new Point(startX + (buttonWidth + spacing) * 2, startY),
                Size = new Size(buttonWidth, buttonHeight),
                FlatStyle = FlatStyle.Flat
            };
            btnScore.FlatAppearance.BorderSize = 0;
            btnScore.Click += BtnStudentScore;

            // Nút Teacher
            btnTeacher = new Button
            {
                Text = "Teacher",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(241, 196, 15), // Vàng
                Location = new Point(startX, startY + buttonHeight + spacing),
                Size = new Size(buttonWidth, buttonHeight),
                FlatStyle = FlatStyle.Flat
            };
            btnTeacher.FlatAppearance.BorderSize = 0;
            btnTeacher.Click += BTNTeacher;

            // Nút Logout
            btnLogout = new Button
            {
                Text = "Logout",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(127, 140, 141), // Xám
                Location = new Point(startX + (buttonWidth + spacing) * 2, startY + buttonHeight + spacing),
                Size = new Size(buttonWidth, buttonHeight),
                FlatStyle = FlatStyle.Flat
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            // Thêm hiệu ứng hover cho nút
            AddButtonHoverEffects(btnLogin);
            AddButtonHoverEffects(btnStudent);
            AddButtonHoverEffects(btnScore);
            AddButtonHoverEffects(btnTeacher);
            AddButtonHoverEffects(btnLogout);

            // Thêm các điều khiển vào Form
            this.Controls.AddRange(new Control[] { lblTitle, btnLogin, btnStudent, btnScore, btnTeacher, btnLogout });

            // Đảm bảo căn giữa khi thay đổi kích thước
            this.Resize += (s, e) =>
            {
                lblTitle.Location = new Point((this.ClientSize.Width - lblTitle.Width) / 2, 30);
                startX = (this.ClientSize.Width - (buttonWidth * 3 + spacing * 2)) / 2;
                btnLogin.Location = new Point(startX, startY);
                btnStudent.Location = new Point(startX + buttonWidth + spacing, startY);
                btnScore.Location = new Point(startX + (buttonWidth + spacing) * 2, startY);
                btnTeacher.Location = new Point(startX, startY + buttonHeight + spacing);
                btnLogout.Location = new Point(startX + (buttonWidth + spacing) * 2, startY + buttonHeight + spacing);
            };
        }

        // Thêm hiệu ứng hover cho nút
        private void AddButtonHoverEffects(Button button)
        {
            button.MouseEnter += (s, e) =>
            {
                button.BackColor = ControlPaint.Light(button.BackColor, 0.2f);
            };
            button.MouseLeave += (s, e) =>
            {
                button.BackColor = button.Tag != null ? (Color)button.Tag : button.BackColor;
            };
            button.Tag = button.BackColor; // Lưu màu gốc
        }

        private void BTNTeacher(object sender, EventArgs e)
        {
            new TeacherForm().ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog();
        }

        private void BtnStudentScore(object sender, EventArgs e)
        {
            new StudentScore().ShowDialog();
        }

        private void BtnStudent(object sender, EventArgs e)
        {
            new StudentForm().ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout clicked!");
        }
    }
}
