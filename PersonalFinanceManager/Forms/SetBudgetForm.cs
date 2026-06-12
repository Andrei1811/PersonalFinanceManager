using System.Drawing.Drawing2D;
using PersonalFinanceManager.Services;

namespace PersonalFinanceManager.Forms
{
    public partial class SetBudgetForm : Form
    {
        private readonly BudgetService _budgetService;
        private readonly int _userId;

        private bool _isLoading = false;

        public SetBudgetForm(int userId)
        {
            InitializeComponent();

            _budgetService = new BudgetService();
            _userId = userId;

            ApplyUiStyling();
        }

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(10, 95, 120);

            lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.AutoSize = true;

            lblYear.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblYear.ForeColor = Color.White;
            lblYear.BackColor = Color.Transparent;

            lblMonth.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblMonth.ForeColor = Color.White;
            lblMonth.BackColor = Color.Transparent;

            lblBudget.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblBudget.ForeColor = Color.White;
            lblBudget.BackColor = Color.Transparent;

            nudYear.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            nudYear.BackColor = Color.FromArgb(245, 245, 245);

            nudMonth.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            nudMonth.BackColor = Color.FromArgb(245, 245, 245);

            nudBudget.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            nudBudget.BackColor = Color.FromArgb(245, 245, 245);

            StyleSecondaryButton(btnCancelBudget, "Anulează");
            StylePrimaryButton(btnSaveBudget, "Salvează");

            AcceptButton = btnSaveBudget;
            CancelButton = btnCancelBudget;
        }

        private static void StylePrimaryButton(Button button, string text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.FromArgb(0, 120, 215);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button.Text = text;
        }

        private static void StyleSecondaryButton(Button button, string text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(0, 120, 215);
            button.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button.Text = text;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(10, 95, 120),
                Color.FromArgb(2, 128, 144),
                45f))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            using (Font f = new Font("Segoe UI", 56, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(18, Color.White)))
            {
                var text = "Finanțe";
                var size = e.Graphics.MeasureString(text, f);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(
                    text,
                    f,
                    sb,
                    new PointF(ClientSize.Width - size.Width - 20, ClientSize.Height - size.Height - 40));
            }
        }

        private void SetBudgetForm_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            nudBudget.DecimalPlaces = 2;
            nudBudget.Minimum = 0;
            nudBudget.Maximum = 1000000;
            nudBudget.Increment = 10;

            nudYear.Minimum = 2000;
            nudYear.Maximum = 2100;
            nudYear.Value = DateTime.Today.Year;

            nudMonth.Minimum = 1;
            nudMonth.Maximum = 12;
            nudMonth.Value = DateTime.Today.Month;

            lblTitle.Left = (ClientSize.Width - lblTitle.Width) / 2;

            _isLoading = false;

            LoadExistingBudget();
        }

        private void LoadExistingBudget()
        {
            int year = (int)nudYear.Value;
            int month = (int)nudMonth.Value;

            decimal existingBudget = _budgetService.GetBudgetAmount(_userId, year, month);

            if (existingBudget > nudBudget.Maximum)
            {
                nudBudget.Maximum = existingBudget;
            }

            nudBudget.Value = existingBudget;
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                return;
            }

            LoadExistingBudget();
        }

        private void nudMonth_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                return;
            }

            LoadExistingBudget();
        }

        private void btnSaveBudget_Click(object sender, EventArgs e)
        {
            int year = (int)nudYear.Value;
            int month = (int)nudMonth.Value;
            decimal amount = nudBudget.Value;

            if (amount <= 0)
            {
                MessageBox.Show(
                    "Bugetul trebuie să fie mai mare decât 0.",
                    "Atenție",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _budgetService.SaveBudget(_userId, year, month, amount);

            MessageBox.Show(
                "Bugetul lunar a fost salvat cu succes.",
                "Informație",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelBudget_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}