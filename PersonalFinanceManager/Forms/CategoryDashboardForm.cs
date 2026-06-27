using PersonalFinanceManager.Models;
using PersonalFinanceManager.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PersonalFinanceManager.Forms
{
    public partial class CategoryDashboardForm : Form
    {
        private readonly List<TransactionListItem> _transactions;
        private readonly BudgetService _budgetService;
        private readonly Label lblBudgetInfo = new Label();

        private Image? _backgroundImage;

        public CategoryDashboardForm(List<TransactionListItem> transactions)
        {
            InitializeComponent();

            _transactions = transactions;
            _budgetService = new BudgetService();

            ApplyUiStyling();
            CreateBudgetInfoLabel();
            Resize += CategoryDashboardForm_Resize;

            if (SessionManager.CurrentUser != null)
            {
                lblDashboardUser.Text = $"Utilizator: {SessionManager.CurrentUser.FullName}";
            }
            else
            {
                lblDashboardUser.Text = "Utilizator: -";
            }

            cmbDashboardTypeFilter.Items.Clear();
            cmbDashboardTypeFilter.Items.Add("Toate");
            cmbDashboardTypeFilter.Items.Add("Income");
            cmbDashboardTypeFilter.Items.Add("Expense");
            cmbDashboardTypeFilter.SelectedIndex = 0;
            cmbDashboardTypeFilter.SelectedIndexChanged += cmbDashboardTypeFilter_SelectedIndexChanged;

            InitializeDateFilters();
            LoadCategorySummary();
            LoadDashboardTotals();
        }

        private void CategoryDashboardForm_Resize(object? sender, EventArgs e)
        {
            SetBackgroundImage();
        }

        private void ApplyUiStyling()
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(10, 95, 120);
            SetBackgroundImage();

            lblDashboardTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblDashboardTitle.ForeColor = Color.White;
            lblDashboardTitle.BackColor = Color.Transparent;

            lblDashboardUser.ForeColor = Color.White;
            lblDashboardUser.BackColor = Color.Transparent;

            lblDashboardTotalIncome.ForeColor = Color.White;
            lblDashboardTotalIncome.BackColor = Color.Transparent;

            lblDashboardTotalExpense.ForeColor = Color.White;
            lblDashboardTotalExpense.BackColor = Color.Transparent;

            lblDashboardBalance.ForeColor = Color.White;
            lblDashboardBalance.BackColor = Color.Transparent;

            lblDashboardTypeFilter.ForeColor = Color.White;
            lblDashboardTypeFilter.BackColor = Color.Transparent;

            lblStartDate.ForeColor = Color.White;
            lblStartDate.BackColor = Color.Transparent;

            lblEndDate.ForeColor = Color.White;
            lblEndDate.BackColor = Color.Transparent;

            cmbDashboardTypeFilter.Font = new Font("Segoe UI", 10F);
            cmbDashboardTypeFilter.BackColor = Color.FromArgb(245, 245, 245);

            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Font = new Font("Segoe UI", 10F);

            StylePrimaryButton(btnApplyDateFilter, "Aplică perioada");
            StylePrimaryButton(btnResetDashboardFilters, "Reset filtre");
            StylePrimaryButton(btnExportCsv, "Export CSV");
            StylePrimaryButton(btnSetBudget, "Setează buget");

            dgvCategorySummary.BackgroundColor = Color.White;
            dgvCategorySummary.GridColor = Color.FromArgb(230, 230, 230);
            dgvCategorySummary.BorderStyle = BorderStyle.None;
            dgvCategorySummary.EnableHeadersVisualStyles = false;

            dgvCategorySummary.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            dgvCategorySummary.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCategorySummary.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F);

            dgvCategorySummary.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvCategorySummary.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dgvCategorySummary.DefaultCellStyle.SelectionForeColor = Color.White;
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _backgroundImage?.Dispose();
            base.OnFormClosed(e);
        }

        private List<TransactionListItem> GetFilteredTransactions()
        {
            string selectedType = cmbDashboardTypeFilter.SelectedItem?.ToString() ?? "Toate";

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            List<TransactionListItem> filteredTransactions = _transactions
                .Where(x => DateTime.Parse(x.Date).Date >= startDate)
                .Where(x => DateTime.Parse(x.Date).Date <= endDate)
                .ToList();

            if (selectedType != "Toate")
            {
                filteredTransactions = filteredTransactions
                    .Where(x => x.Type == selectedType)
                    .ToList();
            }

            return filteredTransactions;
        }
        private void LoadCategorySummary()
        {
            List<TransactionListItem> filteredTransactions = GetFilteredTransactions();

            var summary = filteredTransactions
                .GroupBy(x => new { x.Type, x.Category })
                .Select(g => new
                {
                    Tip = g.Key.Type,
                    Categorie = g.Key.Category,
                    Total = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Tip)
                .ThenBy(x => x.Categorie)
                .ToList();

            dgvCategorySummary.DataSource = null;
            dgvCategorySummary.DataSource = summary;

            dgvCategorySummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorySummary.ReadOnly = true;
            dgvCategorySummary.AllowUserToAddRows = false;
        }

        private void LoadDashboardTotals()
        {
            List<TransactionListItem> filteredTransactions = GetFilteredTransactions();

            decimal totalIncome = filteredTransactions
                .Where(x => x.Type == "Income")
                .Sum(x => x.Amount);

            decimal totalExpense = filteredTransactions
                .Where(x => x.Type == "Expense")
                .Sum(x => x.Amount);

            decimal balance = totalIncome - totalExpense;

            lblDashboardTotalIncome.Text = $"Total venituri: {totalIncome:0.00}";
            lblDashboardTotalExpense.Text = $"Total cheltuieli: {totalExpense:0.00}";
            lblDashboardBalance.Text = $"Sold: {balance:0.00}";

            LoadBudgetInfo();
        }

        private void cmbDashboardTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategorySummary();
            LoadDashboardTotals();
        }

        private void lblDashboardTotalExpense_Click(object sender, EventArgs e)
        {

        }

        private void InitializeDateFilters()
        {
            if (_transactions.Count == 0)
            {
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today;
                return;
            }

            DateTime minDate = _transactions
                .Min(x => DateTime.Parse(x.Date));

            DateTime maxDate = _transactions
                .Max(x => DateTime.Parse(x.Date));

            dtpStartDate.Value = minDate;
            dtpEndDate.Value = maxDate;
        }

        private void btnApplyDateFilter_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("Data de început nu poate fi mai mare decât data de final.");
                return;
            }

            LoadCategorySummary();
            LoadDashboardTotals();
        }

        private void btnResetDashboardFilters_Click(object sender, EventArgs e)
        {
            cmbDashboardTypeFilter.SelectedItem = "Toate";

            InitializeDateFilters();

            LoadCategorySummary();
            LoadDashboardTotals();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            List<TransactionListItem> filteredTransactions = GetFilteredTransactions();

            var summary = filteredTransactions
                .GroupBy(x => new { x.Type, x.Category })
                .Select(g => new
                {
                    Tip = g.Key.Type,
                    Categorie = g.Key.Category,
                    Total = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Tip)
                .ThenBy(x => x.Categorie)
                .ToList();

            if (summary.Count == 0)
            {
                MessageBox.Show("Nu există date de exportat.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Salvează raportul CSV";
                saveFileDialog.FileName = "raport_categorii.csv";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                List<string> lines = new List<string>();

                lines.Add("Tip,Categorie,Total");

                foreach (var item in summary)
                {
                    lines.Add($"{item.Tip},{item.Categorie},{item.Total}");
                }

                File.WriteAllLines(saveFileDialog.FileName, lines);

                MessageBox.Show("Raportul a fost exportat cu succes.");
            }
        }

        private void btnSetBudget_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Nu există utilizator autentificat.");
                return;
            }

            using (SetBudgetForm setBudgetForm = new SetBudgetForm(SessionManager.CurrentUser.Id))
            {
                if (setBudgetForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDashboardTotals();
                }
            }
        }

        private void CreateBudgetInfoLabel()
        {
            if (lblBudgetInfo.Parent != null)
            {
                return;
            }

            lblBudgetInfo.AutoSize = true;
            lblBudgetInfo.Location = new Point(72, 370);
            lblBudgetInfo.Name = "lblBudgetInfo";
            lblBudgetInfo.Font = new Font("Segoe UI Semibold", 10F);
            lblBudgetInfo.ForeColor = Color.White;
            lblBudgetInfo.BackColor = Color.Transparent;
            lblBudgetInfo.Text = "Buget lunar: -";

            Controls.Add(lblBudgetInfo);
            lblBudgetInfo.BringToFront();
        }

        private void LoadBudgetInfo()
        {
            if (SessionManager.CurrentUser == null)
            {
                lblBudgetInfo.ForeColor = Color.White;
                lblBudgetInfo.Text = "Buget lunar: utilizator neautentificat";
                return;
            }

            DateTime selectedDate = dtpEndDate.Value.Date;

            int year = selectedDate.Year;
            int month = selectedDate.Month;

            decimal budgetAmount = _budgetService.GetBudgetAmount(
                SessionManager.CurrentUser.Id,
                year,
                month);

            decimal monthlyExpense = _transactions
                .Where(x => x.Type == "Expense")
                .Where(x => DateTime.Parse(x.Date).Year == year)
                .Where(x => DateTime.Parse(x.Date).Month == month)
                .Sum(x => x.Amount);

            if (budgetAmount <= 0)
            {
                lblBudgetInfo.ForeColor = Color.White;
                lblBudgetInfo.Text =
                    $"Buget lunar ({month:00}/{year}): nesetat | Cheltuit în luna {month:00}/{year}: {monthlyExpense:0.00}";
                return;
            }

            decimal remaining = budgetAmount - monthlyExpense;

            if (remaining >= 0)
            {
                lblBudgetInfo.ForeColor = Color.LightGreen;
                lblBudgetInfo.Text =
                    $"Buget lunar ({month:00}/{year}): {budgetAmount:0.00} | Cheltuit în luna {month:00}/{year}: {monthlyExpense:0.00} | Rămas: {remaining:0.00}";
            }
            else
            {
                lblBudgetInfo.ForeColor = Color.Red;
                lblBudgetInfo.Text =
                    $"Buget lunar ({month:00}/{year}): {budgetAmount:0.00} | Cheltuit în luna {month:00}/{year}: {monthlyExpense:0.00} | Depășit cu: {Math.Abs(remaining):0.00}";
            }
        }
    }






}