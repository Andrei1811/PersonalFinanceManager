using System.Drawing;
using System.Drawing.Drawing2D;
using PersonalFinanceManager.Services;

namespace PersonalFinanceManager.Forms
{
    public partial class AddCategoryForm : Form
    {
        private readonly CategoryService _categoryService;
        public string? NewCategoryName { get; private set; }
        public string? NewCategoryType { get; private set; }

        public AddCategoryForm()
        {
            InitializeComponent();

            _categoryService = new CategoryService();

            cmbCategoryType.Items.Clear();
            cmbCategoryType.Items.Add("Income");
            cmbCategoryType.Items.Add("Expense");
            cmbCategoryType.SelectedIndex = 0;

            ApplyUiStyling();
        }

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(10, 95, 120);

            lblAddCategoryTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblAddCategoryTitle.ForeColor = Color.White;
            lblAddCategoryTitle.BackColor = Color.Transparent;

            lblCategoryType.ForeColor = Color.White;
            lblCategoryType.BackColor = Color.Transparent;
            lblCategoryName.ForeColor = Color.White;
            lblCategoryName.BackColor = Color.Transparent;

            cmbCategoryType.Font = new Font("Segoe UI", 10F);
            cmbCategoryType.BackColor = Color.FromArgb(245, 245, 245);
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.BackColor = Color.FromArgb(245, 245, 245);

            StylePrimaryButton(btnSaveCategory, "Salvează");
            StyleSecondaryButton(btnCancelCategory, "Anulează");
        }

        private static void StylePrimaryButton(Button button, string text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.FromArgb(0, 120, 215);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI Semibold", 10F);
            button.Text = text;
        }

        private static void StyleSecondaryButton(Button button, string text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(0, 120, 215);
            button.Font = new Font("Segoe UI Semibold", 10F);
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

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            string selectedType = cmbCategoryType.SelectedItem?.ToString() ?? "";

            bool success = _categoryService.AddCategory(
                txtCategoryName.Text,
                selectedType,
                out string message);

            MessageBox.Show(message);

            if (success)
            {
                NewCategoryName = txtCategoryName.Text.Trim();
                NewCategoryType = selectedType;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancelCategory_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}