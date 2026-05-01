using PersonalFinanceManager.Services;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace PersonalFinanceManager.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService;
        private bool _allowCloseWithoutExit;

        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService();

            ApplyUiStyling();
            FormClosing += RegisterForm_FormClosing;
        }

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Remove(pnlRegister);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtFullName);
            Controls.Add(label3);
            Controls.Add(txtRegisterUsername);
            Controls.Add(label4);
            Controls.Add(txtRegisterPassword);
            Controls.Add(btnBack);
            Controls.Add(btnRegister);

            int centerX = ClientSize.Width / 2;
            int y = 50;

            label1.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
            label1.AutoSize = true;
            label1.Location = new Point(centerX - 160, y);
            y += 70;

            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label2.ForeColor = Color.White;
            label2.BackColor = Color.Transparent;
            label2.Size = new Size(320, 22);
            label2.Location = new Point(centerX - 160, y);
            y += 28;

            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.BackColor = Color.FromArgb(245, 245, 245);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Size = new Size(320, 32);
            txtFullName.Location = new Point(centerX - 160, y);
            y += 48;

            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label3.ForeColor = Color.White;
            label3.BackColor = Color.Transparent;
            label3.Size = new Size(320, 22);
            label3.Location = new Point(centerX - 160, y);
            y += 28;

            txtRegisterUsername.Font = new Font("Segoe UI", 12F);
            txtRegisterUsername.BackColor = Color.FromArgb(245, 245, 245);
            txtRegisterUsername.BorderStyle = BorderStyle.FixedSingle;
            txtRegisterUsername.Size = new Size(320, 32);
            txtRegisterUsername.Location = new Point(centerX - 160, y);
            y += 48;

            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label4.ForeColor = Color.White;
            label4.BackColor = Color.Transparent;
            label4.Size = new Size(320, 22);
            label4.Location = new Point(centerX - 160, y);
            y += 28;

            txtRegisterPassword.Font = new Font("Segoe UI", 12F);
            txtRegisterPassword.BackColor = Color.FromArgb(245, 245, 245);
            txtRegisterPassword.BorderStyle = BorderStyle.FixedSingle;
            txtRegisterPassword.Size = new Size(320, 32);
            txtRegisterPassword.Location = new Point(centerX - 160, y);
            y += 56;

            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.BackColor = Color.FromArgb(0, 120, 215);
            btnBack.ForeColor = Color.White;
            btnBack.Font = new Font("Segoe UI Semibold", 11F);
            btnBack.Size = new Size(140, 38);
            btnBack.Location = new Point(centerX - 160, y);
            btnBack.Text = "Înapoi";

            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 1;
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            btnRegister.BackColor = Color.White;
            btnRegister.ForeColor = Color.FromArgb(0, 120, 215);
            btnRegister.Font = new Font("Segoe UI Semibold", 11F);
            btnRegister.Size = new Size(140, 38);
            btnRegister.Location = new Point(centerX + 40, y);
            btnRegister.Text = "Înregistrare";
        }

        private void RegisterForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_allowCloseWithoutExit && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
                return;
            }

            _allowCloseWithoutExit = false;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(10, 95, 120), Color.FromArgb(2, 128, 144), 45f))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            using (Font f = new Font("Segoe UI", 72, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(18, Color.White)))
            {
                var text = "Finanțe";
                var size = e.Graphics.MeasureString(text, f);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(text, f, sb, new PointF(ClientSize.Width - size.Width - 20, ClientSize.Height - size.Height - 60));
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool success = _authService.Register(
                txtFullName.Text,
                txtRegisterUsername.Text,
                txtRegisterPassword.Text,
                out string message);

            MessageBox.Show(message);

            if (success)
            {
                _allowCloseWithoutExit = true;
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _allowCloseWithoutExit = true;
            this.Close();
        }
    }
}