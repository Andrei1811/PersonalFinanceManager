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

            // Panel styling - REDUS
            pnlRegister.BackColor = Color.FromArgb(255, 255, 255);
            pnlRegister.Padding = new Padding(24);
            pnlRegister.BorderStyle = BorderStyle.None;
            pnlRegister.Size = new Size(370, 290);
            pnlRegister.Location = new Point((this.ClientSize.Width - pnlRegister.Width) / 2, (this.ClientSize.Height - pnlRegister.Height) / 2);

            // Title
            lblLoginTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoginTitle.ForeColor = Color.FromArgb(30, 30, 30);
            lblLoginTitle.Location = new Point(24, 8);

            // Username label & textbox
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            label3.Location = new Point(24, 60);
            label3.Size = new Size(320, 22);
            label3.TextAlign = ContentAlignment.BottomLeft;

            txtLoginUsername.Font = new Font("Segoe UI", 11F);
            txtLoginUsername.BackColor = Color.FromArgb(245, 245, 245);
            txtLoginUsername.BorderStyle = BorderStyle.FixedSingle;
            txtLoginUsername.Size = new Size(320, 30);
            txtLoginUsername.Location = new Point(24, 82);

            // Password label & textbox
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            label4.Location = new Point(24, 122);
            label4.Size = new Size(320, 22);
            label4.TextAlign = ContentAlignment.BottomLeft;

            txtLoginPassword.Font = new Font("Segoe UI", 11F);
            txtLoginPassword.BackColor = Color.FromArgb(245, 245, 245);
            txtLoginPassword.BorderStyle = BorderStyle.FixedSingle;
            txtLoginPassword.Size = new Size(320, 30);
            txtLoginPassword.Location = new Point(24, 144);

            // Buttons
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.BackColor = Color.FromArgb(0, 120, 215);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI Semibold", 10F);
            btnLogin.Size = new Size(140, 36);
            btnLogin.Location = new Point(24, 200);

            btnOpenRegister.FlatStyle = FlatStyle.Flat;
            btnOpenRegister.FlatAppearance.BorderSize = 1;
            btnOpenRegister.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            btnOpenRegister.BackColor = Color.White;
            btnOpenRegister.ForeColor = Color.FromArgb(0, 120, 215);
            btnOpenRegister.Font = new Font("Segoe UI Semibold", 10F);
            btnOpenRegister.Size = new Size(140, 36);
            btnOpenRegister.Location = new Point(204, 200);
            btnOpenRegister.Text = "Înregistrare";
            btnLogin.Text = "Conectare";
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