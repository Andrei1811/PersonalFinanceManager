namespace PersonalFinanceManager.Forms
{
    partial class AddTransactionForm
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
            lblFormTitle = new Label();
            lblType = new Label();
            cmbType = new ComboBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            lblAmount = new Label();
            nudAmount = new NumericUpDown();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BorderStyle = BorderStyle.FixedSingle;
            lblFormTitle.Location = new Point(134, 9);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(132, 22);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Adauga tranzactie";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(18, 54);
            lblType.Name = "lblType";
            lblType.Size = new Size(30, 20);
            lblType.TabIndex = 1;
            lblType.Text = "Tip";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(98, 54);
            cmbType.Margin = new Padding(3, 2, 3, 2);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(223, 28);
            cmbType.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(18, 93);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Titlu";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(98, 93);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(151, 27);
            txtTitle.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 130);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(74, 20);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Categorie";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(98, 127);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(151, 27);
            txtCategory.TabIndex = 6;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(18, 165);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(46, 20);
            lblAmount.TabIndex = 7;
            lblAmount.Text = "Suma";
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Location = new Point(99, 165);
            nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(150, 27);
            nudAmount.TabIndex = 8;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(23, 202);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 9;
            lblDate.Text = "Data";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(98, 202);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 10;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(254, 263);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(23, 263);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddTransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 321);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(nudAmount);
            Controls.Add(lblAmount);
            Controls.Add(txtCategory);
            Controls.Add(lblCategory);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(lblFormTitle);
            Name = "AddTransactionForm";
            Text = "AddTransactionForm";
            Load += AddTransactionForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFormTitle;
        private Label lblType;
        private ComboBox cmbType;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblAmount;
        private NumericUpDown nudAmount;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Button btnOk;
        private Button btnCancel;
    }
}