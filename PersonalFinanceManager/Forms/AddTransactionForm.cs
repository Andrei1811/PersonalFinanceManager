using PersonalFinanceManager.Models;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PersonalFinanceManager.Forms
{
    public partial class AddTransactionForm : Form
    {
        public TransactionListItem? NewTransaction { get; private set; }

        private readonly bool _isEditMode;
        // In edit mode, this holds the transaction being edited. In add mode, it will be null.
        private readonly TransactionListItem? _transactionToEdit;
        

        public AddTransactionForm()
        {
            InitializeComponent();
            _isEditMode = false;
            ApplyUiStyling();
            
        }

        public AddTransactionForm(TransactionListItem transactionToEdit)
        {
            InitializeComponent();
            _isEditMode = true;
            // Store the transaction being edited so we can pre-fill the form fields
            _transactionToEdit = transactionToEdit;
            ApplyUiStyling();
            
        }

        

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            lblFormTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.BorderStyle = BorderStyle.None;

            var labelFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblType.Font = labelFont;
            lblType.ForeColor = Color.White;
            lblType.BackColor = Color.Transparent;
            lblTitle.Font = labelFont;
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblCategory.Font = labelFont;
            lblCategory.ForeColor = Color.White;
            lblCategory.BackColor = Color.Transparent;
            lblAmount.Font = labelFont;
            lblAmount.ForeColor = Color.White;
            lblAmount.BackColor = Color.Transparent;
            lblDate.Font = labelFont;
            lblDate.ForeColor = Color.White;
            lblDate.BackColor = Color.Transparent;

            cmbType.Font = new Font("Segoe UI", 10F);
            cmbType.BackColor = Color.FromArgb(245, 245, 245);
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.BackColor = Color.FromArgb(245, 245, 245);
            txtCategory.Font = new Font("Segoe UI", 10F);
            txtCategory.BackColor = Color.FromArgb(245, 245, 245);
            nudAmount.Font = new Font("Segoe UI", 10F);
            nudAmount.BackColor = Color.FromArgb(245, 245, 245);
            dtpDate.Font = new Font("Segoe UI", 10F);

            StylePrimaryButton(btnOk, "OK");
            StyleSecondaryButton(btnCancel, "Anulează");
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

            using (Font f = new Font("Segoe UI", 56, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(16, Color.White)))
            {
                var text = "Finanțe";
                var size = e.Graphics.MeasureString(text, f);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(text, f, sb, new PointF(ClientSize.Width - size.Width - 20, ClientSize.Height - size.Height - 40));
            }
        }

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("Income");
            cmbType.Items.Add("Expense");

            if (_isEditMode && _transactionToEdit != null)
            {
                lblFormTitle.Text = "Editează tranzacție";
                btnOk.Text = "Salvează";

                cmbType.SelectedItem = _transactionToEdit.Type;
                cmbType.Enabled = false;

                txtTitle.Text = _transactionToEdit.Title;
                txtCategory.Text = _transactionToEdit.Category;
                nudAmount.Value = _transactionToEdit.Amount;
                dtpDate.Value = DateTime.Parse(_transactionToEdit.Date);
            }
            else
            {
                lblFormTitle.Text = "Adaugă tranzacție";
                btnOk.Text = "OK";

                cmbType.Enabled = true;

                if (cmbType.Items.Count > 0)
                {
                    cmbType.SelectedIndex = 0;
                }

                nudAmount.Value = 0;
                dtpDate.Value = DateTime.Today;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Titlul este obligatoriu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Categoria este obligatorie.");
                return;
            }

            if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("Selectează tipul tranzacției.");
                return;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Suma trebuie să fie mai mare decât 0.");
                return;
            }

            int existingId = 0;

            if (_isEditMode && _transactionToEdit != null)
            {
                existingId = _transactionToEdit.Id;
            }

            NewTransaction = new TransactionListItem
            {
                Id = existingId,
                Type = cmbType.SelectedItem!.ToString()!,
                Title = txtTitle.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Amount = nudAmount.Value,
                Date = dtpDate.Value.ToString("yyyy-MM-dd")
            };

            DialogResult = DialogResult.OK;
            
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
            Close();
        }
    }
}