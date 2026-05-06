using PersonalFinanceManager.Models;
using PersonalFinanceManager.Services;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class TransactionsForm : Form
    {
        //lista de tranzactii care se incarca o singura data la deschiderea form-ului, apoi se filtreaza/sorteaza doar in memorie
        private List<TransactionListItem> _transactions = new List<TransactionListItem>();
        //serviciul pentru tranzactii, folosit pentru a incarca datele initial si pentru operatiile de adaugare/stergere/editare
        private readonly TransactionService _transactionService;

        private bool _sortAscendingByID = true;
        private bool _sortAscendingByTip = true;

        private string _currentSortColumn = "";
        private bool _allowCloseWithoutExit;
        private Image? _backgroundImage;

        public TransactionsForm()
        {
            //construim interfata, initializam serviciul de tranzactii, incarcam datele reale in lista si apoi le afisam in grid
            InitializeComponent();

            ApplyUiStyling();

            if (SessionManager.CurrentUser != null)
            {
                lblCurrentUser.Text = $"Utilizator: {SessionManager.CurrentUser.FullName}";
            }
            else
            {
                lblCurrentUser.Text = "Utilizator: -";
            }

            _transactionService = new TransactionService();

            //incarcam datele reale in lista si apoi le afisam in grid
            LoadRealTransactions();
            //dupa ce am incarcat datele reale, le afisam in grid
            RefreshGrid();

            //adaugam event handleri pentru schimbarea textului in filtre, astfel incat sa se aplice filtrele in timp real
            txtFilterTitle.TextChanged += txtFilterTitle_TextChanged;
            txtFilterCategory.TextChanged += txtFilterCategory_TextChanged;

            FormClosing += TransactionsForm_FormClosing;
            Resize += TransactionsForm_Resize;
        }

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(10, 95, 120);
            SetBackgroundImage();

            lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;

            lblFilterTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblFilterTitle.ForeColor = Color.White;
            lblFilterTitle.BackColor = Color.Transparent;

            lblFilterCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblFilterCategory.ForeColor = Color.White;
            lblFilterCategory.BackColor = Color.Transparent;

            lblCurrentUser.ForeColor = Color.White;
            lblCurrentUser.BackColor = Color.Transparent;
            lblTotalIncome.ForeColor = Color.White;
            lblTotalIncome.BackColor = Color.Transparent;
            lblTotalExpense.ForeColor = Color.White;
            lblTotalExpense.BackColor = Color.Transparent;
            lblBalance.ForeColor = Color.White;
            lblBalance.BackColor = Color.Transparent;

            label1.Visible = false;
            label2.Visible = false;

            txtFilterTitle.Font = new Font("Segoe UI", 10F);
            txtFilterTitle.BackColor = Color.FromArgb(245, 245, 245);
            txtFilterTitle.BorderStyle = BorderStyle.FixedSingle;

            txtFilterCategory.Font = new Font("Segoe UI", 10F);
            txtFilterCategory.BackColor = Color.FromArgb(245, 245, 245);
            txtFilterCategory.BorderStyle = BorderStyle.FixedSingle;

            StylePrimaryButton(btnAddTransaction, "Adaugă");
            StylePrimaryButton(btnDeleteTransaction, "Șterge");
            StylePrimaryButton(btnEditTransaction, "Editează");
            StylePrimaryButton(btnOpenDashboard, "Dashboard");
            StylePrimaryButton(btnLogout, "Logout");

            btnOpenDashboard.Size = new Size(120, btnOpenDashboard.Height);



            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.GridColor = Color.FromArgb(230, 230, 230);
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.White;
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

        private void TransactionsForm_Resize(object? sender, EventArgs e)
        {
            SetBackgroundImage();
        }

        private void TransactionsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_allowCloseWithoutExit && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
                return;
            }

            _allowCloseWithoutExit = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _backgroundImage?.Dispose();
            base.OnFormClosed(e);
        }

        //cere tranzactii de la transactionservices
        private void LoadRealTransactions()
        {
            if (SessionManager.CurrentUser != null)
            {
                _transactions = _transactionService.GetTransactionListItems(SessionManager.CurrentUser.Id);
            }
            else
            {
                _transactions = _transactionService.GetTransactionListItems();
            }
        }

        //logica de incarcare in trabel
        private void LoadTransactionsIntoGrid(List<TransactionListItem> transactions)
        {
            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = transactions;

            if (dgvTransactions.Columns["Id"] != null)
                dgvTransactions.Columns["Id"].HeaderText = "ID";

            if (dgvTransactions.Columns["Type"] != null)
                dgvTransactions.Columns["Type"].HeaderText = "Tip";

            if (dgvTransactions.Columns["Title"] != null)
                dgvTransactions.Columns["Title"].HeaderText = "Titlu";

            if (dgvTransactions.Columns["Category"] != null)
                dgvTransactions.Columns["Category"].HeaderText = "Categorie";

            if (dgvTransactions.Columns["Amount"] != null)
                dgvTransactions.Columns["Amount"].HeaderText = "Sumă";

            if (dgvTransactions.Columns["Date"] != null)
                dgvTransactions.Columns["Date"].HeaderText = "Dată";

            if (dgvTransactions.Columns["Poza"] != null)
                dgvTransactions.Columns["Poza"].Visible = false;
        }

        private List<TransactionListItem> ApplyFilters(List<TransactionListItem> originalList)
        {
            string titleFilter = txtFilterTitle.Text.Trim().ToLower();
            string categoryFilter = txtFilterCategory.Text.Trim().ToLower();

            List<TransactionListItem> filteredList = originalList
                .Where(x => x.Title.ToLower().Contains(titleFilter))
                .Where(x => x.Category.ToLower().Contains(categoryFilter))
                .ToList();

            return filteredList;
        }

        private List<TransactionListItem> ApplyIDOrder(List<TransactionListItem> list)
        {
            if (_sortAscendingByID)
                return list.OrderBy(x => x.Id).ToList();
            else
                return list.OrderByDescending(x => x.Id).ToList();
        }

        private List<TransactionListItem> ApplyTipOrder(List<TransactionListItem> list)
        {
            if (_sortAscendingByTip)
                return list.OrderBy(x => x.Type).ToList();
            else
                return list.OrderByDescending(x => x.Type).ToList();
        }

        //aplica filtrele si sortarea curenta, apoi incarca in grid
        private void RefreshGrid()
        {
            List<TransactionListItem> filteredList = ApplyFilters(_transactions);

            switch (_currentSortColumn)
            {
                case "ID":
                    filteredList = ApplyIDOrder(filteredList);
                    break;

                case "TIP":
                    filteredList = ApplyTipOrder(filteredList);
                    break;
            }

            LoadTransactionsIntoGrid(filteredList);
            UpdateSummaryLabels(filteredList);
        }

        private void UpdateSummaryLabels(List<TransactionListItem> transactions)
        {
            decimal totalIncome = transactions
                .Where(x => x.Type == "Income")
                .Sum(x => x.Amount);

            decimal totalExpense = transactions
                .Where(x => x.Type == "Expense")
                .Sum(x => x.Amount);

            decimal balance = totalIncome - totalExpense;

            lblTotalIncome.Text = $"Total venituri: {totalIncome}";
            lblTotalExpense.Text = $"Total cheltuieli: {totalExpense}";
            lblBalance.Text = $"Sold: {balance}";
        }

        //cand utilizatorul tasteaza ceva, se aplica refreshgrid ca sa se vada rezultatele in timp real
        private void txtFilterTitle_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void txtFilterCategory_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        //cand se apasa header ul unei coloane, se schimba sortarea pentru acea coloana si se aplica refreshgrid ca sa se vada rezultatele in timp real
        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        _sortAscendingByID = !_sortAscendingByID;
                        _currentSortColumn = "ID";
                        break;

                    case 1:
                        _sortAscendingByTip = !_sortAscendingByTip;
                        _currentSortColumn = "TIP";
                        break;
                }

                RefreshGrid();
                return;
            }
        }





        //logica pentru adaugare tranzactie: deschide un form de adaugare, iar daca utilizatorul a adaugat ceva, se apeleaza serviciul de tranzactii pentru a salva in baza de date, apoi se reincarca lista reala si se refresh-uieste grid-ul
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            AddTransactionForm addForm = new AddTransactionForm();

            if (addForm.ShowDialog() == DialogResult.OK && addForm.NewTransaction != null)
            {
                int userId = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.Id : 1;

                bool success = _transactionService.AddTransaction(addForm.NewTransaction, userId, out string message);

                MessageBox.Show(message);

                if (success)
                {
                    LoadRealTransactions();
                    RefreshGrid();

                }
            }
        }

        //logica pentru stergere tranzactie: verifica daca utilizatorul a selectat o tranzactie, apoi afiseaza un mesaj de confirmare cu detaliile tranzactiei, iar daca utilizatorul confirma, se apeleaza serviciul de tranzactii pentru a sterge din baza de date, apoi se reincarca lista reala si se refresh-uieste grid-ul
        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectează o tranzacție din tabel.");
                return;
            }

            DataGridViewRow selectedRow = dgvTransactions.SelectedRows[0];

            int selectedId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string selectedTitle = selectedRow.Cells["Title"].Value?.ToString() ?? "";
            string selectedType = selectedRow.Cells["Type"].Value?.ToString() ?? "";

            DialogResult result = MessageBox.Show(
                $"Sigur vrei să ștergi tranzacția?\n\nID: {selectedId}\nTitlu: {selectedTitle}\nTip: {selectedType}",
                "Confirmare ștergere",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            int userId = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.Id : 1;

            bool success = _transactionService.DeleteTransaction(selectedId, selectedType, userId, out string message);

            MessageBox.Show(message);

            if (success)
            {
                LoadRealTransactions();
                RefreshGrid();

            }
        }

        //logica pentru editare tranzactie: verifica daca utilizatorul a selectat o tranzactie, apoi deschide un form de adaugare pre-populat cu datele tranzactiei selectate, iar daca utilizatorul a editat ceva, se apeleaza serviciul de tranzactii pentru a salva in baza de date, apoi se reincarca lista reala si se refresh-uieste grid-ul
        private void btnEditTransaction_Click(object sender, EventArgs e)
        {
            OpenEditSelectedTransaction();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Sigur vrei să te deloghezi?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            SessionManager.Logout();

            LoginForm? loginForm = Application.OpenForms["LoginForm"] as LoginForm;

            if (loginForm != null)
            {
                loginForm.ClearLoginFields();
                loginForm.Show();
                loginForm.ActiveControl = loginForm.Controls["txtLoginUsername"];
            }

            _allowCloseWithoutExit = true;
            this.Close();
        }

        private void SetBackgroundImage()
        {
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0)
            {
                return;
            }

            _backgroundImage?.Dispose();

            Bitmap bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(10, 95, 120), Color.FromArgb(2, 128, 144), 45f))
            {
                graphics.FillRectangle(brush, ClientRectangle);

                using (Font f = new Font("Segoe UI", 72, FontStyle.Bold, GraphicsUnit.Pixel))
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(18, Color.White)))
                {
                    var text = "Finanțe";
                    var size = graphics.MeasureString(text, f);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.DrawString(text, f, sb, new PointF(ClientSize.Width - size.Width - 20, ClientSize.Height - size.Height - 60));
                }
            }

            _backgroundImage = bitmap;
            BackgroundImage = _backgroundImage;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnOpenDashboard_Click(object sender, EventArgs e)
        {
            CategoryDashboardForm dashboardForm = new CategoryDashboardForm(_transactions);
            dashboardForm.ShowDialog();
        }

        private void OpenEditSelectedTransaction()
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selectează o tranzacție din tabel.");
                return;
            }

            DataGridViewRow selectedRow = dgvTransactions.SelectedRows[0];

            TransactionListItem selectedTransaction = new TransactionListItem
            {
                Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                Type = selectedRow.Cells["Type"].Value?.ToString() ?? "",
                Title = selectedRow.Cells["Title"].Value?.ToString() ?? "",
                Category = selectedRow.Cells["Category"].Value?.ToString() ?? "",
                Amount = Convert.ToDecimal(selectedRow.Cells["Amount"].Value),
                Date = selectedRow.Cells["Date"].Value?.ToString() ?? "",
                Poza = selectedRow.Cells["Poza"].Value?.ToString() ?? ""
            };

            AddTransactionForm editForm = new AddTransactionForm(selectedTransaction);

            if (editForm.ShowDialog() == DialogResult.OK && editForm.NewTransaction != null)
            {
                int userId = SessionManager.CurrentUser != null ? SessionManager.CurrentUser.Id : 1;

                bool success = _transactionService.UpdateTransaction(editForm.NewTransaction, userId, out string message);

                MessageBox.Show(message);

                if (success)
                {
                    LoadRealTransactions();
                    RefreshGrid();
                }
            }
        }

        private void dgvTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            dgvTransactions.ClearSelection();
            dgvTransactions.Rows[e.RowIndex].Selected = true;

            OpenEditSelectedTransaction();
        }
    }
}