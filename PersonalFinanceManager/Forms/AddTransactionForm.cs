using PersonalFinanceManager.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using PersonalFinanceManager.Data;
using System.IO;

namespace PersonalFinanceManager.Forms
{
    public partial class AddTransactionForm : Form
    {
        public TransactionListItem? NewTransaction { get; private set; }

        private readonly bool _isEditMode;
        // In edit mode, this holds the transaction being edited. In add mode, it will be null.
        private readonly TransactionListItem? _transactionToEdit;
        private readonly JsonDataService _dataService;
        private List<Category> _categories = new List<Category>();


        public AddTransactionForm()
        {
            InitializeComponent();
            _dataService = new JsonDataService();
            _isEditMode = false;
            ApplyUiStyling();

        }

        public AddTransactionForm(TransactionListItem transactionToEdit)
        {
            InitializeComponent();
            _dataService = new JsonDataService();
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

            BackColor = Color.FromArgb(10, 95, 120);

            if (mainLayout != null)
            {
                mainLayout.BackColor = Color.Transparent;
            }

            if (contentLayout != null)
            {
                contentLayout.BackColor = Color.Transparent;
            }

            if (footerLayout != null)
            {
                footerLayout.BackColor = Color.Transparent;
            }

            var cardBackColor = Color.FromArgb(245, 245, 245);

            if (leftLayout != null)
            {
                leftLayout.BackColor = cardBackColor;
            }

            if (rightLayout != null)
            {
                rightLayout.BackColor = cardBackColor;
            }

            lblFormTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            lblFormTitle.ForeColor = Color.FromArgb(0, 64, 84);
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.BorderStyle = BorderStyle.None;
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;

            var labelFont = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblType.Font = labelFont;
            lblType.ForeColor = Color.FromArgb(35, 35, 35);
            lblType.BackColor = Color.Transparent;
            lblTitle.Font = labelFont;
            lblTitle.ForeColor = Color.FromArgb(35, 35, 35);
            lblTitle.BackColor = Color.Transparent;
            lblCategory.Font = labelFont;
            lblCategory.ForeColor = Color.FromArgb(35, 35, 35);
            lblCategory.BackColor = Color.Transparent;
            lblAmount.Font = labelFont;
            lblAmount.ForeColor = Color.FromArgb(35, 35, 35);
            lblAmount.BackColor = Color.Transparent;
            lblDate.Font = labelFont;
            lblDate.ForeColor = Color.FromArgb(35, 35, 35);
            lblDate.BackColor = Color.Transparent;

            var inputFont = new Font("Segoe UI", 11F, FontStyle.Regular);
            cmbType.Font = inputFont;
            cmbType.BackColor = Color.FromArgb(245, 245, 245);
            txtTitle.Font = inputFont;
            txtTitle.BackColor = Color.FromArgb(245, 245, 245);
            nudAmount.Font = inputFont;
            nudAmount.BackColor = Color.FromArgb(245, 245, 245);
            dtpDate.Font = inputFont;
            cmbCategory.Font = inputFont;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            StylePrimaryButton(btnOk, "OK");
            StyleSecondaryButton(btnCancel, "Anulează");
            StylePrimaryButton(btnOpenAddCategory, "+");
            StylePrimaryButton(button1, "Load");

            label1.ForeColor = Color.FromArgb(30, 30, 30);
            label1.TabStop = false;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

        private static void StyleSecondaryButton(Button button, string text)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 215);
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(0, 120, 215);
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
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
            _categories = _dataService.LoadCategories();

            if (_isEditMode && _transactionToEdit != null)
            {
                lblFormTitle.Text = "Editează tranzacție";
                btnOk.Text = "Salvează";

                cmbType.SelectedItem = _transactionToEdit.Type;
                cmbType.Enabled = false;

                txtTitle.Text = _transactionToEdit.Title;
                LoadCategoriesForSelectedType();
                cmbCategory.SelectedItem = _transactionToEdit.Category;
                nudAmount.Value = _transactionToEdit.Amount;
                label1.Text = _transactionToEdit.Poza;
                try
                {
                    pictureBox1.Load(_transactionToEdit.Poza);
                }
                catch { }
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
                    LoadCategoriesForSelectedType();
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
            if (cmbCategory.SelectedItem == null)
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
                Category = cmbCategory.SelectedItem!.ToString()!,
                Amount = nudAmount.Value,
                Date = dtpDate.Value.ToString("yyyy-MM-dd"),   
                Poza = label1.Text
            };

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void LoadCategoriesForSelectedType()
        {
            if (cmbType.SelectedItem == null)
                return;

            string selectedType = cmbType.SelectedItem.ToString()!;

            List<string> categoryNames = _categories
                .Where(c => c.Type.Equals(selectedType, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Name)
                .ToList();

            cmbCategory.Items.Clear();

            foreach (string categoryName in categoryNames)
            {
                cmbCategory.Items.Add(categoryName);
            }

            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategoriesForSelectedType();
        }

        private void btnOpenAddCategory_Click(object sender, EventArgs e)
        {
            using (AddCategoryForm addCategoryForm = new AddCategoryForm())
            {
                if (addCategoryForm.ShowDialog() == DialogResult.OK)
                {
                    _categories = _dataService.LoadCategories();

                    if (!string.IsNullOrWhiteSpace(addCategoryForm.NewCategoryType))
                    {
                        cmbType.SelectedItem = addCategoryForm.NewCategoryType;
                    }

                    LoadCategoriesForSelectedType();

                    if (!string.IsNullOrWhiteSpace(addCategoryForm.NewCategoryName))
                    {
                        cmbCategory.SelectedItem = addCategoryForm.NewCategoryName;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                try
                {
                    pictureBox1.Load(selectedFile);
                    label1.Text = selectedFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea imaginii: " + ex.Message);
                }
            }
        }

        
    }
}