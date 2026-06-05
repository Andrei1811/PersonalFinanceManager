namespace PersonalFinanceManager.Forms
{
    partial class ReceiptViewerForm
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
            pictureBoxReceipt = new PictureBox();
            lblReceiptPath = new Label();
            btnCloseReceipt = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReceipt).BeginInit();
            SuspendLayout();

            // 
            // pictureBoxReceipt
            // 
            pictureBoxReceipt.Location = new Point(40, 84);
            pictureBoxReceipt.Name = "pictureBoxReceipt";
            pictureBoxReceipt.Size = new Size(704, 354);
            pictureBoxReceipt.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxReceipt.TabIndex = 0;
            pictureBoxReceipt.TabStop = false;

            // 
            // lblReceiptPath
            // 
            lblReceiptPath.AutoEllipsis = true;
            lblReceiptPath.AutoSize = false;
            lblReceiptPath.Location = new Point(40, 30);
            lblReceiptPath.Name = "lblReceiptPath";
            lblReceiptPath.Size = new Size(590, 29);
            lblReceiptPath.TabIndex = 1;
            lblReceiptPath.Text = "-";

            // 
            // btnCloseReceipt
            // 
            btnCloseReceipt.Location = new Point(650, 26);
            btnCloseReceipt.Name = "btnCloseReceipt";
            btnCloseReceipt.Size = new Size(94, 29);
            btnCloseReceipt.TabIndex = 2;
            btnCloseReceipt.Text = "Închide";
            btnCloseReceipt.UseVisualStyleBackColor = true;
            btnCloseReceipt.Click += btnCloseReceipt_Click;

            // 
            // ReceiptViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCloseReceipt);
            Controls.Add(lblReceiptPath);
            Controls.Add(pictureBoxReceipt);
            Name = "ReceiptViewerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Vizualizare bon";
            Load += ReceiptViewerForm_Load;

            ((System.ComponentModel.ISupportInitialize)pictureBoxReceipt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBoxReceipt;
        private Label lblReceiptPath;
        private Button btnCloseReceipt;
    }
}