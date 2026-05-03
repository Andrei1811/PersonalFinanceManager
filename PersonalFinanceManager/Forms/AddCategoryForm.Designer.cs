namespace PersonalFinanceManager.Forms
{
    partial class AddCategoryForm
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
            lblAddCategoryTitle = new Label();
            lblCategoryType = new Label();
            cmbCategoryType = new ComboBox();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            btnSaveCategory = new Button();
            btnCancelCategory = new Button();
            SuspendLayout();
            // 
            // lblAddCategoryTitle
            // 
            lblAddCategoryTitle.AutoSize = true;
            lblAddCategoryTitle.Location = new Point(102, 19);
            lblAddCategoryTitle.Name = "lblAddCategoryTitle";
            lblAddCategoryTitle.Size = new Size(128, 20);
            lblAddCategoryTitle.TabIndex = 0;
            lblAddCategoryTitle.Text = "Adaugă categorie";
            // 
            // lblCategoryType
            // 
            lblCategoryType.AutoSize = true;
            lblCategoryType.Location = new Point(50, 80);
            lblCategoryType.Name = "lblCategoryType";
            lblCategoryType.Size = new Size(37, 20);
            lblCategoryType.TabIndex = 1;
            lblCategoryType.Text = "Tip: ";
            // 
            // cmbCategoryType
            // 
            cmbCategoryType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryType.FormattingEnabled = true;
            cmbCategoryType.Location = new Point(186, 72);
            cmbCategoryType.Name = "cmbCategoryType";
            cmbCategoryType.Size = new Size(200, 28);
            cmbCategoryType.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(50, 130);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(119, 20);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Nume categorie:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(186, 127);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(200, 27);
            txtCategoryName.TabIndex = 4;
            // 
            // btnSaveCategory
            // 
            btnSaveCategory.Location = new Point(210, 200);
            btnSaveCategory.Name = "btnSaveCategory";
            btnSaveCategory.Size = new Size(94, 29);
            btnSaveCategory.TabIndex = 5;
            btnSaveCategory.Text = "Salvează";
            btnSaveCategory.UseVisualStyleBackColor = true;
            btnSaveCategory.Click += btnSaveCategory_Click;
            // 
            // btnCancelCategory
            // 
            btnCancelCategory.Location = new Point(50, 200);
            btnCancelCategory.Name = "btnCancelCategory";
            btnCancelCategory.Size = new Size(94, 29);
            btnCancelCategory.TabIndex = 6;
            btnCancelCategory.Text = "Anulează";
            btnCancelCategory.UseVisualStyleBackColor = true;
            btnCancelCategory.Click += btnCancelCategory_Click;
            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 367);
            Controls.Add(btnCancelCategory);
            Controls.Add(btnSaveCategory);
            Controls.Add(txtCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(cmbCategoryType);
            Controls.Add(lblCategoryType);
            Controls.Add(lblAddCategoryTitle);
            Name = "AddCategoryForm";
            Text = "AddCategoryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddCategoryTitle;
        private Label lblCategoryType;
        private ComboBox cmbCategoryType;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Button btnSaveCategory;
        private Button btnCancelCategory;
    }
}