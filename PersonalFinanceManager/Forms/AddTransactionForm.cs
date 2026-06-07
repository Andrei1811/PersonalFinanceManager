using PersonalFinanceManager.Models;
using System.Drawing;
using System.Drawing.Drawing2D;
using PersonalFinanceManager.Data;
using System.IO;
using PersonalFinanceManager.Services;

namespace PersonalFinanceManager.Forms
{
    public partial class AddTransactionForm : Form
    {
        public TransactionListItem? NewTransaction { get; private set; }

        private readonly bool _isEditMode;
        private readonly TransactionListItem? _transactionToEdit;
        private readonly JsonDataService _dataService;
        private readonly ReceiptOcrService _receiptOcrService;

        private List<Category> _categories = new List<Category>();

        // Aici păstrăm path-ul real al bonului care se salvează în JSON.
        // Label-ul / TextBox-ul este doar pentru afișare.
        private string _receiptPath = "";
        private string _lastOcrText = "";

        // Buton creat din cod pentru ștergerea bonului atașat.
        private Button btnRemoveReceipt = new Button();
        private Button btnViewOcrText = new Button();

        public AddTransactionForm()
        {
            InitializeComponent();

            _dataService = new JsonDataService();
            _receiptOcrService = new ReceiptOcrService();

            _isEditMode = false;

            ApplyUiStyling();

            Load += AddTransactionForm_CreateRemoveReceiptButton;
            Load += AddTransactionForm_CreateViewOcrTextButton;
        }

        public AddTransactionForm(TransactionListItem transactionToEdit)
        {
            InitializeComponent();

            _dataService = new JsonDataService();
            _receiptOcrService = new ReceiptOcrService();

            _isEditMode = true;
            _transactionToEdit = transactionToEdit;

            ApplyUiStyling();

            Load += AddTransactionForm_CreateRemoveReceiptButton;
            Load += AddTransactionForm_CreateViewOcrTextButton;
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
            label1.ForeColor = Color.FromArgb(30, 30, 30);
            label1.TabStop = false;

            StylePrimaryButton(btnOk, "OK");
            StyleSecondaryButton(btnCancel, "Anulează");
            StylePrimaryButton(btnOpenAddCategory, "+");
            StylePrimaryButton(button1, "Încarcă bon");

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void AddTransactionForm_CreateRemoveReceiptButton(object? sender, EventArgs e)
        {
            if (btnRemoveReceipt.Parent != null)
            {
                return;
            }

            btnRemoveReceipt.Name = "btnRemoveReceipt";
            // Place the remove button into the first column of the buttonsLayout
            btnRemoveReceipt.Dock = DockStyle.Fill;
            StyleSecondaryButton(btnRemoveReceipt, "Șterge bon");
            btnRemoveReceipt.Click += btnRemoveReceipt_Click;

            buttonsLayout.Controls.Add(btnRemoveReceipt, 0, 0);
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
            using (LinearGradientBrush brush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(10, 95, 120),
                Color.FromArgb(2, 128, 144),
                45f))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            using (Font f = new Font("Segoe UI", 56, FontStyle.Bold, GraphicsUnit.Pixel))
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(16, Color.White)))
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

        private void AddTransactionForm_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("Income");
            cmbType.Items.Add("Expense");

            _categories = _dataService.LoadCategories();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

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
                dtpDate.Value = DateTime.Parse(_transactionToEdit.Date);

                _receiptPath = _transactionToEdit.Poza;

                if (!string.IsNullOrWhiteSpace(_receiptPath))
                {
                    label1.Text = Path.GetFileName(_receiptPath);
                }
                else
                {
                    label1.Text = "Niciun bon atașat";
                }

                if (!string.IsNullOrWhiteSpace(_receiptPath) && File.Exists(_receiptPath))
                {
                    pictureBox1.Load(_receiptPath);
                }
                else
                {
                    pictureBox1.Image = null;
                }
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

                _receiptPath = "";
                label1.Text = "Niciun bon atașat";
                pictureBox1.Image = null;
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
                Poza = _receiptPath
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

        private string CopyReceiptImageToStorage(string originalImagePath)
        {
            string storageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");
            string receiptsFolder = Path.Combine(storageFolder, "Receipts");

            if (!Directory.Exists(receiptsFolder))
            {
                Directory.CreateDirectory(receiptsFolder);
            }

            string extension = Path.GetExtension(originalImagePath);

            string newFileName = $"receipt_{DateTime.Now:yyyyMMdd_HHmmss_fff}{extension}";

            string destinationPath = Path.Combine(receiptsFolder, newFileName);

            File.Copy(originalImagePath, destinationPath, true);

            return destinationPath;
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
            openFileDialog1.Filter = "Imagini|*.png;*.jpg;*.jpeg;*.bmp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;

                try
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Load(selectedFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la încărcarea imaginii: " + ex.Message);
                    return;
                }

                ReceiptOcrResult ocrResult = _receiptOcrService.AnalyzeReceipt(selectedFile);
                _lastOcrText = ocrResult.RawText;

                string storedImagePath;

                try
                {
                    storedImagePath = CopyReceiptImageToStorage(selectedFile);

                    _receiptPath = storedImagePath;
                    label1.Text = Path.GetFileName(storedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la copierea imaginii în folderul aplicației: " + ex.Message);
                    return;
                }

                if (!ocrResult.Success)
                {
                    MessageBox.Show(
                        ocrResult.Message + "\n\nImaginea a fost atașată, dar formularul nu a fost completat automat.");
                    return;
                }

                DialogResult confirmResult = MessageBox.Show(
                    $"Au fost detectate următoarele date:\n\n" +
                    $"Data: {(ocrResult.Date.HasValue ? ocrResult.Date.Value.ToString("dd.MM.yyyy") : "-")}\n" +
                    $"Total: {(ocrResult.Total.HasValue ? ocrResult.Total.Value.ToString("0.00") : "-")}\n\n" +
                    $"Dorești să completez automat tranzacția?",
                    "Confirmare OCR",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                {
                    MessageBox.Show("Imaginea a fost atașată, dar câmpurile nu au fost modificate.");
                    return;
                }

                if (ocrResult.Total.HasValue)
                {
                    nudAmount.Value = ocrResult.Total.Value;
                }

                if (ocrResult.Date.HasValue)
                {
                    dtpDate.Value = ocrResult.Date.Value;
                }

                cmbType.SelectedItem = "Expense";
                LoadCategoriesForSelectedType();

                if (cmbCategory.Items.Contains("Mancare"))
                {
                    cmbCategory.SelectedItem = "Mancare";
                }

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    txtTitle.Text = "Bon fiscal";
                }

                MessageBox.Show(
                    $"Tranzacția a fost completată automat.\n\n" +
                    $"Imagine salvată intern în:\n{storedImagePath}");
            }
        }

        private void btnRemoveReceipt_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_receiptPath))
            {
                MessageBox.Show("Nu există niciun bon atașat.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Sigur vrei să ștergi bonul atașat acestei tranzacții?",
                "Ștergere bon",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            _receiptPath = "";
            pictureBox1.Image = null;
            label1.Text = "Niciun bon atașat";

            MessageBox.Show("Bonul a fost eliminat din tranzacție.");
        }

        private void AddTransactionForm_CreateViewOcrTextButton(object? sender, EventArgs e)
        {
            if (btnViewOcrText.Parent != null)
            {
                return;
            }

            btnViewOcrText.Name = "btnViewOcrText";
            btnViewOcrText.Dock = DockStyle.Fill;
            StyleSecondaryButton(btnViewOcrText, "Vezi OCR");
            btnViewOcrText.Click += btnViewOcrText_Click;

            buttonsLayout.Controls.Add(btnViewOcrText, 1, 0);
            btnViewOcrText.BringToFront();
        }

        private void btnViewOcrText_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_lastOcrText))
            {
                MessageBox.Show("Nu există text OCR disponibil. Încarcă mai întâi un bon.");
                return;
            }

            MessageBox.Show(
                _lastOcrText,
                "Text OCR extras",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}