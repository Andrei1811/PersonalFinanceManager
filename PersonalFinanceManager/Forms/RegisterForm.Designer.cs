namespace PersonalFinanceManager.Forms
{
    partial class RegisterForm
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
            pnlRegister = new Panel();
            btnBack = new Button();
            btnRegister = new Button();
            txtRegisterPassword = new TextBox();
            label4 = new Label();
            txtRegisterUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtFullName = new TextBox();
            label1 = new Label();
            pnlRegister.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRegister
            // 
            pnlRegister.BackColor = SystemColors.ButtonFace;
            pnlRegister.Controls.Add(btnBack);
            pnlRegister.Controls.Add(btnRegister);
            pnlRegister.Controls.Add(txtRegisterPassword);
            pnlRegister.Controls.Add(label4);
            pnlRegister.Controls.Add(txtRegisterUsername);
            pnlRegister.Controls.Add(label3);
            pnlRegister.Controls.Add(label2);
            pnlRegister.Controls.Add(txtFullName);
            pnlRegister.Controls.Add(label1);
            pnlRegister.Location = new Point(123, 79);
            pnlRegister.Name = "pnlRegister";
            pnlRegister.Size = new Size(500, 320);
            pnlRegister.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ButtonFace;
            btnBack.Location = new Point(49, 246);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 9;
            btnBack.Text = "Înapoi";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.InactiveBorder;
            btnRegister.Location = new Point(342, 246);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Înregistrare";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtRegisterPassword
            // 
            txtRegisterPassword.BackColor = SystemColors.GradientActiveCaption;
            txtRegisterPassword.ForeColor = SystemColors.WindowFrame;
            txtRegisterPassword.Location = new Point(125, 187);
            txtRegisterPassword.Name = "txtRegisterPassword";
            txtRegisterPassword.Size = new Size(167, 27);
            txtRegisterPassword.TabIndex = 7;
            txtRegisterPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 194);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 6;
            label4.Text = "Parolă";
            // 
            // txtRegisterUsername
            // 
            txtRegisterUsername.BackColor = SystemColors.GradientActiveCaption;
            txtRegisterUsername.ForeColor = SystemColors.WindowFrame;
            txtRegisterUsername.Location = new Point(125, 136);
            txtRegisterUsername.Name = "txtRegisterUsername";
            txtRegisterUsername.Size = new Size(167, 27);
            txtRegisterUsername.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 139);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 88);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 3;
            label2.Text = "Nume complet";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = SystemColors.GradientActiveCaption;
            txtFullName.ForeColor = SystemColors.WindowFrame;
            txtFullName.Location = new Point(125, 85);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(167, 27);
            txtFullName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(166, 16);
            label1.Name = "label1";
            label1.Size = new Size(151, 37);
            label1.TabIndex = 1;
            label1.Text = "Înregistrare";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(782, 453);
            Controls.Add(pnlRegister);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            pnlRegister.ResumeLayout(false);
            pnlRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRegister;
        private Button btnBack;
        private Button btnRegister;
        private TextBox txtRegisterPassword;
        private Label label4;
        private TextBox txtRegisterUsername;
        private Label label3;
        private Label label2;
        private TextBox txtFullName;
        private Label label1;
    }
}