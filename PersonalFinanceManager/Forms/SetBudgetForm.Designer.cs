namespace PersonalFinanceManager.Forms
{
    partial class SetBudgetForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblYear = new Label();
            lblMonth = new Label();
            lblBudget = new Label();
            nudYear = new NumericUpDown();
            nudMonth = new NumericUpDown();
            nudBudget = new NumericUpDown();
            btnSaveBudget = new Button();
            btnCancelBudget = new Button();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBudget).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(91, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Buget lunar";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(47, 102);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(32, 20);
            lblYear.TabIndex = 1;
            lblYear.Text = "An:";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(47, 153);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(43, 20);
            lblMonth.TabIndex = 2;
            lblMonth.Text = "Lună:";
            // 
            // lblBudget
            // 
            lblBudget.AutoSize = true;
            lblBudget.Location = new Point(47, 204);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(52, 20);
            lblBudget.TabIndex = 3;
            lblBudget.Text = "Buget:";
            // 
            // nudYear
            // 
            nudYear.Location = new Point(143, 100);
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(180, 27);
            nudYear.TabIndex = 4;
            nudYear.ValueChanged += nudYear_ValueChanged;
            // 
            // nudMonth
            // 
            nudMonth.Location = new Point(143, 151);
            nudMonth.Name = "nudMonth";
            nudMonth.Size = new Size(180, 27);
            nudMonth.TabIndex = 5;
            nudMonth.ValueChanged += nudMonth_ValueChanged;
            // 
            // nudBudget
            // 
            nudBudget.DecimalPlaces = 2;
            nudBudget.Location = new Point(143, 202);
            nudBudget.Name = "nudBudget";
            nudBudget.Size = new Size(180, 27);
            nudBudget.TabIndex = 6;
            // 
            // btnSaveBudget
            // 
            btnSaveBudget.Location = new Point(229, 274);
            btnSaveBudget.Name = "btnSaveBudget";
            btnSaveBudget.Size = new Size(130, 35);
            btnSaveBudget.TabIndex = 7;
            btnSaveBudget.Text = "Salvează";
            btnSaveBudget.UseVisualStyleBackColor = true;
            btnSaveBudget.Click += btnSaveBudget_Click;
            // 
            // btnCancelBudget
            // 
            btnCancelBudget.Location = new Point(47, 274);
            btnCancelBudget.Name = "btnCancelBudget";
            btnCancelBudget.Size = new Size(130, 35);
            btnCancelBudget.TabIndex = 8;
            btnCancelBudget.Text = "Anulează";
            btnCancelBudget.UseVisualStyleBackColor = true;
            btnCancelBudget.Click += btnCancelBudget_Click;
            // 
            // SetBudgetForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 350);
            Controls.Add(btnCancelBudget);
            Controls.Add(btnSaveBudget);
            Controls.Add(nudBudget);
            Controls.Add(nudMonth);
            Controls.Add(nudYear);
            Controls.Add(lblBudget);
            Controls.Add(lblMonth);
            Controls.Add(lblYear);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SetBudgetForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Setare buget lunar";
            Load += SetBudgetForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBudget).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblYear;
        private Label lblMonth;
        private Label lblBudget;
        private NumericUpDown nudYear;
        private NumericUpDown nudMonth;
        private NumericUpDown nudBudget;
        private Button btnSaveBudget;
        private Button btnCancelBudget;
    }
}