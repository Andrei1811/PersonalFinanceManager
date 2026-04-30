using PersonalFinanceManager.Models;

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
        }

        public AddTransactionForm(TransactionListItem transactionToEdit)
        {
            InitializeComponent();
            _isEditMode = true;
            // Store the transaction being edited so we can pre-fill the form fields
            _transactionToEdit = transactionToEdit;
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