using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class ReceiptViewerForm : Form
    {
        private readonly string _receiptPath;

        public ReceiptViewerForm(string receiptPath)
        {
            InitializeComponent();

            _receiptPath = receiptPath;

            ApplyUiStyling();
        }

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(10, 95, 120);

            lblReceiptPath.ForeColor = Color.White;
            lblReceiptPath.BackColor = Color.Transparent;
            lblReceiptPath.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            pictureBoxReceipt.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxReceipt.BackColor = Color.White;
            pictureBoxReceipt.SizeMode = PictureBoxSizeMode.Zoom;

            StylePrimaryButton(btnCloseReceipt, "Închide");
        }

        private static void StylePrimaryButton(Button button, string text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.FromArgb(0, 120, 215);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button.Text = text;
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

        private void ReceiptViewerForm_Load(object sender, EventArgs e)
        {
            lblReceiptPath.Text = _receiptPath;

            if (!string.IsNullOrWhiteSpace(_receiptPath) && File.Exists(_receiptPath))
            {
                pictureBoxReceipt.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBoxReceipt.Load(_receiptPath);
            }
            else
            {
                MessageBox.Show("Imaginea bonului nu a fost găsită.");
                Close();
            }
        }

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}