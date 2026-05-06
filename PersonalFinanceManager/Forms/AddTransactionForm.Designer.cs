
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
            lblAmount = new Label();
            nudAmount = new NumericUpDown();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            btnOk = new Button();
            btnCancel = new Button();
            cmbCategory = new ComboBox();
            btnOpenAddCategory = new Button();
            pictureBox1 = new PictureBox();
            label1 = new TextBox();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            mainLayout = new TableLayoutPanel();
            contentLayout = new TableLayoutPanel();
            leftLayout = new TableLayoutPanel();
            categoryLayout = new TableLayoutPanel();
            rightLayout = new TableLayoutPanel();
            pathLoadLayout = new TableLayoutPanel();
            footerLayout = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            mainLayout.SuspendLayout();
            contentLayout.SuspendLayout();
            leftLayout.SuspendLayout();
            categoryLayout.SuspendLayout();
            rightLayout.SuspendLayout();
            pathLoadLayout.SuspendLayout();
            footerLayout.SuspendLayout();
            SuspendLayout();
            // 
            // lblFormTitle
            // 
            lblFormTitle.Dock = DockStyle.Fill;
            lblFormTitle.Location = new Point(24, 18);
            lblFormTitle.Margin = new Padding(0, 0, 0, 10);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(952, 50);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Adaugă tranzacție";
            lblFormTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            lblType.Dock = DockStyle.Fill;
            lblType.Location = new Point(13, 10);
            lblType.Name = "lblType";
            lblType.Size = new Size(114, 44);
            lblType.TabIndex = 1;
            lblType.Text = "Tip";
            lblType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbType
            // 
            cmbType.Dock = DockStyle.Fill;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(133, 18);
            cmbType.Margin = new Padding(3, 8, 3, 8);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(363, 28);
            cmbType.TabIndex = 2;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Location = new Point(13, 54);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(114, 44);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Titlu";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTitle
            // 
            txtTitle.Dock = DockStyle.Fill;
            txtTitle.Location = new Point(133, 62);
            txtTitle.Margin = new Padding(3, 8, 3, 8);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(363, 27);
            txtTitle.TabIndex = 4;
            // 
            // lblCategory
            // 
            lblCategory.Dock = DockStyle.Fill;
            lblCategory.Location = new Point(13, 98);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(114, 44);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Categorie";
            lblCategory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAmount
            // 
            lblAmount.Dock = DockStyle.Fill;
            lblAmount.Location = new Point(13, 142);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(114, 44);
            lblAmount.TabIndex = 7;
            lblAmount.Text = "Suma";
            lblAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudAmount
            // 
            nudAmount.DecimalPlaces = 2;
            nudAmount.Dock = DockStyle.Fill;
            nudAmount.Location = new Point(133, 150);
            nudAmount.Margin = new Padding(3, 8, 3, 8);
            nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(363, 27);
            nudAmount.TabIndex = 8;
            // 
            // lblDate
            // 
            lblDate.Dock = DockStyle.Fill;
            lblDate.Location = new Point(13, 186);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(114, 44);
            lblDate.TabIndex = 9;
            lblDate.Text = "Data";
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            dtpDate.Dock = DockStyle.Fill;
            dtpDate.Location = new Point(133, 194);
            dtpDate.Margin = new Padding(3, 8, 3, 8);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(363, 27);
            dtpDate.TabIndex = 10;
            // 
            // btnOk
            // 
            btnOk.Dock = DockStyle.Fill;
            btnOk.Location = new Point(792, 12);
            btnOk.Margin = new Padding(0, 12, 0, 12);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(160, 44);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(0, 12);
            btnCancel.Margin = new Padding(0, 12, 0, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 44);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.Dock = DockStyle.Fill;
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(0, 8);
            cmbCategory.Margin = new Padding(0, 8, 8, 8);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(311, 28);
            cmbCategory.TabIndex = 13;
            // 
            // btnOpenAddCategory
            // 
            btnOpenAddCategory.Dock = DockStyle.Fill;
            btnOpenAddCategory.Location = new Point(319, 8);
            btnOpenAddCategory.Margin = new Padding(0, 8, 0, 8);
            btnOpenAddCategory.Name = "btnOpenAddCategory";
            btnOpenAddCategory.Size = new Size(44, 28);
            btnOpenAddCategory.TabIndex = 14;
            btnOpenAddCategory.Text = "+";
            btnOpenAddCategory.UseVisualStyleBackColor = true;
            btnOpenAddCategory.Click += btnOpenAddCategory_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(13, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(389, 370);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(245, 245, 245);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 3);
            label1.Margin = new Padding(0, 3, 8, 3);
            label1.Name = "label1";
            label1.ReadOnly = true;
            label1.Size = new Size(267, 27);
            label1.TabIndex = 17;
            label1.WordWrap = false;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(275, 3);
            button1.Margin = new Padding(0, 3, 0, 3);
            button1.Name = "button1";
            button1.Size = new Size(120, 34);
            button1.TabIndex = 18;
            button1.Text = "load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(lblFormTitle, 0, 0);
            mainLayout.Controls.Add(contentLayout, 0, 1);
            mainLayout.Controls.Add(footerLayout, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(24, 18, 24, 18);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            mainLayout.Size = new Size(1000, 600);
            mainLayout.TabIndex = 0;
            // 
            // contentLayout
            // 
            contentLayout.ColumnCount = 2;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            contentLayout.Controls.Add(leftLayout, 0, 0);
            contentLayout.Controls.Add(rightLayout, 1, 0);
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Location = new Point(24, 78);
            contentLayout.Margin = new Padding(0);
            contentLayout.Name = "contentLayout";
            contentLayout.RowCount = 1;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Size = new Size(952, 436);
            contentLayout.TabIndex = 1;
            // 
            // leftLayout
            // 
            leftLayout.ColumnCount = 2;
            leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftLayout.Controls.Add(lblType, 0, 0);
            leftLayout.Controls.Add(cmbType, 1, 0);
            leftLayout.Controls.Add(lblTitle, 0, 1);
            leftLayout.Controls.Add(txtTitle, 1, 1);
            leftLayout.Controls.Add(lblCategory, 0, 2);
            leftLayout.Controls.Add(categoryLayout, 1, 2);
            leftLayout.Controls.Add(lblAmount, 0, 3);
            leftLayout.Controls.Add(nudAmount, 1, 3);
            leftLayout.Controls.Add(lblDate, 0, 4);
            leftLayout.Controls.Add(dtpDate, 1, 4);
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.Location = new Point(0, 0);
            leftLayout.Margin = new Padding(0, 0, 14, 0);
            leftLayout.Name = "leftLayout";
            leftLayout.Padding = new Padding(10);
            leftLayout.RowCount = 6;
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftLayout.Size = new Size(509, 436);
            leftLayout.TabIndex = 0;
            // 
            // categoryLayout
            // 
            categoryLayout.ColumnCount = 2;
            categoryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            categoryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            categoryLayout.Controls.Add(cmbCategory, 0, 0);
            categoryLayout.Controls.Add(btnOpenAddCategory, 1, 0);
            categoryLayout.Dock = DockStyle.Fill;
            categoryLayout.Location = new Point(133, 98);
            categoryLayout.Margin = new Padding(3, 0, 3, 0);
            categoryLayout.Name = "categoryLayout";
            categoryLayout.RowCount = 1;
            categoryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            categoryLayout.Size = new Size(363, 44);
            categoryLayout.TabIndex = 6;
            // 
            // rightLayout
            // 
            rightLayout.ColumnCount = 1;
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightLayout.Controls.Add(pictureBox1, 0, 0);
            rightLayout.Controls.Add(pathLoadLayout, 0, 1);
            rightLayout.Dock = DockStyle.Fill;
            rightLayout.Location = new Point(537, 0);
            rightLayout.Margin = new Padding(14, 0, 0, 0);
            rightLayout.Name = "rightLayout";
            rightLayout.Padding = new Padding(10);
            rightLayout.RowCount = 2;
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            rightLayout.Size = new Size(415, 436);
            rightLayout.TabIndex = 1;
            // 
            // pathLoadLayout
            // 
            pathLoadLayout.ColumnCount = 2;
            pathLoadLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pathLoadLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            pathLoadLayout.Controls.Add(label1, 0, 0);
            pathLoadLayout.Controls.Add(button1, 1, 0);
            pathLoadLayout.Dock = DockStyle.Fill;
            pathLoadLayout.Location = new Point(10, 386);
            pathLoadLayout.Margin = new Padding(0);
            pathLoadLayout.Name = "pathLoadLayout";
            pathLoadLayout.RowCount = 1;
            pathLoadLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pathLoadLayout.Size = new Size(395, 40);
            pathLoadLayout.TabIndex = 16;
            // 
            // footerLayout
            // 
            footerLayout.ColumnCount = 3;
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            footerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            footerLayout.Controls.Add(btnCancel, 0, 0);
            footerLayout.Controls.Add(btnOk, 2, 0);
            footerLayout.Dock = DockStyle.Fill;
            footerLayout.Location = new Point(24, 514);
            footerLayout.Margin = new Padding(0);
            footerLayout.Name = "footerLayout";
            footerLayout.RowCount = 1;
            footerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            footerLayout.Size = new Size(952, 68);
            footerLayout.TabIndex = 2;
            // 
            // AddTransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(mainLayout);
            MinimumSize = new Size(900, 560);
            Name = "AddTransactionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddTransactionForm";
            Load += AddTransactionForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            mainLayout.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            leftLayout.ResumeLayout(false);
            leftLayout.PerformLayout();
            categoryLayout.ResumeLayout(false);
            rightLayout.ResumeLayout(false);
            pathLoadLayout.ResumeLayout(false);
            pathLoadLayout.PerformLayout();
            footerLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private Label lblFormTitle;
        private Label lblType;
        private ComboBox cmbType;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblCategory;
        private Label lblAmount;
        private NumericUpDown nudAmount;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Button btnOk;
        private Button btnCancel;
        private ComboBox cmbCategory;
        private Button btnOpenAddCategory;
        private PictureBox pictureBox1;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel contentLayout;
        private TableLayoutPanel leftLayout;
        private TableLayoutPanel categoryLayout;
        private TableLayoutPanel rightLayout;
        private TableLayoutPanel pathLoadLayout;
        private TableLayoutPanel footerLayout;
        private TextBox label1;
        private Button button1;
        private OpenFileDialog openFileDialog1;
    }
}