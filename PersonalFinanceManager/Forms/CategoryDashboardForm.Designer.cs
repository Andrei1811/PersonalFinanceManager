namespace PersonalFinanceManager.Forms
{
    partial class CategoryDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDashboardTitle = new Label();
            lblDashboardUser = new Label();
            dgvCategorySummary = new DataGridView();
            lblDashboardTotalIncome = new Label();
            lblDashboardTotalExpense = new Label();
            lblDashboardBalance = new Label();
            cmbDashboardTypeFilter = new ComboBox();
            lblDashboardTypeFilter = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnApplyDateFilter = new Button();
            btnResetDashboardFilters = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorySummary).BeginInit();
            SuspendLayout();
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.AutoSize = true;
            lblDashboardTitle.Location = new Point(298, 9);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(166, 20);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Dashboard pe categorii";
            // 
            // lblDashboardUser
            // 
            lblDashboardUser.AutoSize = true;
            lblDashboardUser.Location = new Point(12, 421);
            lblDashboardUser.Name = "lblDashboardUser";
            lblDashboardUser.Size = new Size(83, 20);
            lblDashboardUser.TabIndex = 1;
            lblDashboardUser.Text = "Utilizator: -";
            // 
            // dgvCategorySummary
            // 
            dgvCategorySummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorySummary.Location = new Point(12, 130);
            dgvCategorySummary.Name = "dgvCategorySummary";
            dgvCategorySummary.RowHeadersWidth = 51;
            dgvCategorySummary.Size = new Size(776, 206);
            dgvCategorySummary.TabIndex = 2;
            // 
            // lblDashboardTotalIncome
            // 
            lblDashboardTotalIncome.AutoSize = true;
            lblDashboardTotalIncome.Location = new Point(72, 339);
            lblDashboardTotalIncome.Name = "lblDashboardTotalIncome";
            lblDashboardTotalIncome.Size = new Size(110, 20);
            lblDashboardTotalIncome.TabIndex = 3;
            lblDashboardTotalIncome.Text = "Total venituri: 0";
            // 
            // lblDashboardTotalExpense
            // 
            lblDashboardTotalExpense.AutoSize = true;
            lblDashboardTotalExpense.Location = new Point(343, 339);
            lblDashboardTotalExpense.Name = "lblDashboardTotalExpense";
            lblDashboardTotalExpense.Size = new Size(121, 20);
            lblDashboardTotalExpense.TabIndex = 4;
            lblDashboardTotalExpense.Text = "Total cheltuieli: 0";
            lblDashboardTotalExpense.Click += lblDashboardTotalExpense_Click;
            // 
            // lblDashboardBalance
            // 
            lblDashboardBalance.AutoSize = true;
            lblDashboardBalance.Location = new Point(596, 339);
            lblDashboardBalance.Name = "lblDashboardBalance";
            lblDashboardBalance.Size = new Size(54, 20);
            lblDashboardBalance.TabIndex = 5;
            lblDashboardBalance.Text = "Sold: 0";
            // 
            // cmbDashboardTypeFilter
            // 
            cmbDashboardTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDashboardTypeFilter.FormattingEnabled = true;
            cmbDashboardTypeFilter.Location = new Point(85, 48);
            cmbDashboardTypeFilter.Name = "cmbDashboardTypeFilter";
            cmbDashboardTypeFilter.Size = new Size(151, 28);
            cmbDashboardTypeFilter.TabIndex = 6;
            // 
            // lblDashboardTypeFilter
            // 
            lblDashboardTypeFilter.AutoSize = true;
            lblDashboardTypeFilter.Location = new Point(12, 51);
            lblDashboardTypeFilter.Name = "lblDashboardTypeFilter";
            lblDashboardTypeFilter.Size = new Size(67, 20);
            lblDashboardTypeFilter.TabIndex = 7;
            lblDashboardTypeFilter.Text = "Filtru tip:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(298, 51);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(51, 20);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "De la: ";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(286, 95);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(63, 20);
            lblEndDate.TabIndex = 9;
            lblEndDate.Text = "Pana la: ";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(355, 51);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(109, 27);
            dtpStartDate.TabIndex = 10;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(355, 90);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(109, 27);
            dtpEndDate.TabIndex = 11;
            // 
            // btnApplyDateFilter
            // 
            btnApplyDateFilter.Location = new Point(482, 67);
            btnApplyDateFilter.Name = "btnApplyDateFilter";
            btnApplyDateFilter.Size = new Size(140, 29);
            btnApplyDateFilter.TabIndex = 12;
            btnApplyDateFilter.Text = "Aplică perioada";
            btnApplyDateFilter.UseVisualStyleBackColor = true;
            btnApplyDateFilter.Click += btnApplyDateFilter_Click;
            // 
            // btnResetDashboardFilters
            // 
            btnResetDashboardFilters.Location = new Point(12, 95);
            btnResetDashboardFilters.Name = "btnResetDashboardFilters";
            btnResetDashboardFilters.Size = new Size(140, 29);
            btnResetDashboardFilters.TabIndex = 13;
            btnResetDashboardFilters.Text = "Reset filtre";
            btnResetDashboardFilters.UseVisualStyleBackColor = true;
            btnResetDashboardFilters.Click += btnResetDashboardFilters_Click;
            // 
            // CategoryDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnResetDashboardFilters);
            Controls.Add(btnApplyDateFilter);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblDashboardTypeFilter);
            Controls.Add(cmbDashboardTypeFilter);
            Controls.Add(lblDashboardBalance);
            Controls.Add(lblDashboardTotalExpense);
            Controls.Add(lblDashboardTotalIncome);
            Controls.Add(dgvCategorySummary);
            Controls.Add(lblDashboardUser);
            Controls.Add(lblDashboardTitle);
            Name = "CategoryDashboardForm";
            Text = "CategoryDashboardForm";
            ((System.ComponentModel.ISupportInitialize)dgvCategorySummary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDashboardTitle;
        private Label lblDashboardUser;
        private DataGridView dgvCategorySummary;
        private Label lblDashboardTotalIncome;
        private Label lblDashboardTotalExpense;
        private Label lblDashboardBalance;
        private ComboBox cmbDashboardTypeFilter;
        private Label lblDashboardTypeFilter;
        private Label lblStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnApplyDateFilter;
        private Button btnResetDashboardFilters;
    }
}