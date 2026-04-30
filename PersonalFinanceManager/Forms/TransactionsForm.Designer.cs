namespace PersonalFinanceManager.Forms
{
    partial class TransactionsForm
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
            lblTitle = new Label();
            lblFilterTitle = new Label();
            txtFilterTitle = new TextBox();
            lblFilterCategory = new Label();
            txtFilterCategory = new TextBox();
            dgvTransactions = new DataGridView();
            btnAddTransaction = new Button();
            btnDeleteTransaction = new Button();
            btnEditTransaction = new Button();
            btnLogout = new Button();
            lblCurrentUser = new Label();
            label2 = new Label();
            label1 = new Label();
            btnSortById = new Button();
            lblTotalIncome = new Label();
            lblTotalExpense = new Label();
            lblBalance = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(322, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(114, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Istoric tranzactii";
            // 
            // lblFilterTitle
            // 
            lblFilterTitle.AutoSize = true;
            lblFilterTitle.Location = new Point(31, 82);
            lblFilterTitle.Name = "lblFilterTitle";
            lblFilterTitle.Size = new Size(75, 20);
            lblFilterTitle.TabIndex = 1;
            lblFilterTitle.Text = "Filtru titlu:";
            // 
            // txtFilterTitle
            // 
            txtFilterTitle.Location = new Point(112, 79);
            txtFilterTitle.Name = "txtFilterTitle";
            txtFilterTitle.Size = new Size(125, 27);
            txtFilterTitle.TabIndex = 2;
            // 
            // lblFilterCategory
            // 
            lblFilterCategory.AutoSize = true;
            lblFilterCategory.Location = new Point(377, 82);
            lblFilterCategory.Name = "lblFilterCategory";
            lblFilterCategory.Size = new Size(112, 20);
            lblFilterCategory.TabIndex = 3;
            lblFilterCategory.Text = "Filtru categorie:";
            // 
            // txtFilterCategory
            // 
            txtFilterCategory.Location = new Point(495, 82);
            txtFilterCategory.Name = "txtFilterCategory";
            txtFilterCategory.Size = new Size(125, 27);
            txtFilterCategory.TabIndex = 4;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToOrderColumns = true;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.EditMode = DataGridViewEditMode.EditOnF2;
            dgvTransactions.Location = new Point(112, 131);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.RowTemplate.Height = 29;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(718, 361);
            dgvTransactions.TabIndex = 6;
            dgvTransactions.CellClick += dgvTransactions_CellClick;
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;
            dgvTransactions.CellDoubleClick += dgvTransactions_CellDoubleClick;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Location = new Point(856, 149);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(94, 29);
            btnAddTransaction.TabIndex = 9;
            btnAddTransaction.Text = "Adauga";
            btnAddTransaction.UseVisualStyleBackColor = true;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // btnDeleteTransaction
            // 
            btnDeleteTransaction.Location = new Point(856, 202);
            btnDeleteTransaction.Name = "btnDeleteTransaction";
            btnDeleteTransaction.Size = new Size(94, 29);
            btnDeleteTransaction.TabIndex = 10;
            btnDeleteTransaction.Text = "Sterge";
            btnDeleteTransaction.UseVisualStyleBackColor = true;
            btnDeleteTransaction.Click += btnDeleteTransaction_Click;
            // 
            // btnEditTransaction
            // 
            btnEditTransaction.Location = new Point(856, 259);
            btnEditTransaction.Name = "btnEditTransaction";
            btnEditTransaction.Size = new Size(94, 29);
            btnEditTransaction.TabIndex = 11;
            btnEditTransaction.Text = "Editeaza";
            btnEditTransaction.UseMnemonic = false;
            btnEditTransaction.UseVisualStyleBackColor = true;
            btnEditTransaction.Click += btnEditTransaction_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(856, 500);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Location = new Point(31, 509);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(77, 20);
            lblCurrentUser.TabIndex = 13;
            lblCurrentUser.Text = "Utilizator: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(827, 78);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(824, 49);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // btnSortById
            // 
            btnSortById.Location = new Point(670, 82);
            btnSortById.Name = "btnSortById";
            btnSortById.Size = new Size(94, 29);
            btnSortById.TabIndex = 5;
            btnSortById.Text = ">";
            btnSortById.UseVisualStyleBackColor = true;
            btnSortById.Click += btnSortById_Click_1;
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.Location = new Point(255, 509);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(110, 20);
            lblTotalIncome.TabIndex = 14;
            lblTotalIncome.Text = "Total venituri: 0";
            // 
            // lblTotalExpense
            // 
            lblTotalExpense.AutoSize = true;
            lblTotalExpense.Location = new Point(415, 509);
            lblTotalExpense.Name = "lblTotalExpense";
            lblTotalExpense.Size = new Size(121, 20);
            lblTotalExpense.TabIndex = 15;
            lblTotalExpense.Text = "Total cheltuieli: 0";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(583, 509);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(54, 20);
            lblBalance.TabIndex = 16;
            lblBalance.Text = "Sold: 0";
            // 
            // TransactionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(lblBalance);
            Controls.Add(lblTotalExpense);
            Controls.Add(lblTotalIncome);
            Controls.Add(lblCurrentUser);
            Controls.Add(btnLogout);
            Controls.Add(btnEditTransaction);
            Controls.Add(btnDeleteTransaction);
            Controls.Add(btnAddTransaction);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvTransactions);
            Controls.Add(btnSortById);
            Controls.Add(txtFilterCategory);
            Controls.Add(lblFilterCategory);
            Controls.Add(txtFilterTitle);
            Controls.Add(lblFilterTitle);
            Controls.Add(lblTitle);
            Name = "TransactionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transactions";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblFilterTitle;
        private TextBox txtFilterTitle;
        private Label lblFilterCategory;
        private TextBox txtFilterCategory;
        private DataGridView dgvTransactions;
        private Button btnAddTransaction;
        private Button btnDeleteTransaction;
        private Button btnEditTransaction;
        private Button btnLogout;
        private Label lblCurrentUser;
        private Label label2;
        private Label label1;
        private Button btnSortById;
        private Label lblTotalIncome;
        private Label lblTotalExpense;
        private Label lblBalance;
    }
}