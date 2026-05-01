using PersonalFinanceManager.Models;
using PersonalFinanceManager.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            ClearLoginFields();
            // Apply modernized styling for the login window
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Eliminare panel, plasare controale direct pe formular
            this.Controls.Remove(pnlRegister);
            this.Controls.Add(lblLoginTitle);
            this.Controls.Add(label3);
            this.Controls.Add(txtLoginUsername);
            this.Controls.Add(label4);
            this.Controls.Add(txtLoginPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnOpenRegister);

            // Poziționare și stilizare direct pe formular
            int formWidth = this.ClientSize.Width;
            int centerX = formWidth / 2;
            int y = 60;

            lblLoginTitle.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoginTitle.ForeColor = Color.White;
            lblLoginTitle.BackColor = Color.Transparent;
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Location = new Point(centerX - 170, y);
            y += 70;

            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label3.ForeColor = Color.White;
            label3.BackColor = Color.Transparent;
            label3.Size = new Size(320, 22);
            label3.Location = new Point(centerX - 160, y);
            y += 28;

            txtLoginUsername.Font = new Font("Segoe UI", 12F);
            txtLoginUsername.BackColor = Color.FromArgb(245, 245, 245);
            txtLoginUsername.BorderStyle = BorderStyle.FixedSingle;
            txtLoginUsername.Size = new Size(320, 32);
            txtLoginUsername.Location = new Point(centerX - 160, y);
            y += 48;

            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label4.ForeColor = Color.White;
            label4.BackColor = Color.Transparent;
            label4.Size = new Size(320, 22);
            label4.Location = new Point(centerX - 160, y);
            y += 28;

            txtLoginPassword.Font = new Font("Segoe UI", 12F);
            txtLoginPassword.BackColor = Color.FromArgb(245, 245, 245);
            txtLoginPassword.BorderStyle = BorderStyle.FixedSingle;
            txtLoginPassword.Size = new Size(320, 32);
            txtLoginPassword.Location = new Point(centerX - 160, y);
            y += 56;

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI Semibold", 11F);
            btnLogin.Size = new Size(140, 38);
            btnLogin.Location = new Point(centerX - 160, y);
            btnLogin.Text = "Conectare";

            btnOpenRegister.FlatStyle = FlatStyle.Flat;
            btnOpenRegister.FlatAppearance.BorderSize = 1;
            btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            btnOpenRegister.BackColor = Color.White;
            btnOpenRegister.ForeColor = Color.FromArgb(0, 120, 215);
            btnOpenRegister.Font = new Font("Segoe UI Semibold", 11F);
            btnOpenRegister.Size = new Size(140, 38);
            btnOpenRegister.Location = new Point(centerX + 40, y);
            btnOpenRegister.Text = "Înregistrare";
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // draw gradient background and faint watermark
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(10, 95, 120), Color.FromArgb(2, 128, 144), 45f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // watermark text
            using (Font f = new Font("Segoe UI", 72, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(18, Color.White)))
            {
                var text = "Finanțe";
                var size = e.Graphics.MeasureString(text, f);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(text, f, sb, new PointF(this.ClientSize.Width - size.Width - 20, this.ClientSize.Height - size.Height - 60));
            }
        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User? user = _authService.Login(
                txtLoginUsername.Text,
                txtLoginPassword.Text,
                out string message);

            if (user == null)
            {
                MessageBox.Show(message);
                return;
            }

            SessionManager.Login(user);

            MessageBox.Show($"Bine ai venit, {user.FullName}!");

            TransactionsForm transactionsForm = new TransactionsForm();
            transactionsForm.Show();

            this.Hide();
        }

        public void ClearLoginFields()
        {
            txtLoginUsername.Text = "";
            txtLoginPassword.Text = "";
            txtLoginUsername.Focus();
        }
    }
}