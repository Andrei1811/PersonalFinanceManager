namespace PersonalFinanceManager.Forms
{
    partial class LoginForm
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
            lblLoginTitle = new Label();
            pnlRegister = new Panel();
            btnLogin = new Button();
            btnOpenRegister = new Button();
            txtLoginPassword = new TextBox();
            label4 = new Label();
            txtLoginUsername = new TextBox();
            label3 = new Label();
            pnlRegister.SuspendLayout();
            SuspendLayout();
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoginTitle.Location = new Point(166, 16);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(167, 37);
            lblLoginTitle.TabIndex = 1;
            lblLoginTitle.Text = "Autentificare";
            // 
            // pnlRegister
            // 
            pnlRegister.BackColor = SystemColors.ButtonFace;
            pnlRegister.Controls.Add(btnLogin);
            pnlRegister.Controls.Add(btnOpenRegister);
            pnlRegister.Controls.Add(txtLoginPassword);
            pnlRegister.Controls.Add(label4);
            pnlRegister.Controls.Add(txtLoginUsername);
            pnlRegister.Controls.Add(label3);
            pnlRegister.Controls.Add(lblLoginTitle);
            pnlRegister.Location = new Point(150, 65);
            pnlRegister.Name = "pnlRegister";
            pnlRegister.Size = new Size(500, 320);
            pnlRegister.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(52, 232);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 9;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnOpenRegister
            // 
            btnOpenRegister.BackColor = SystemColors.InactiveBorder;
            btnOpenRegister.Location = new Point(329, 232);
            btnOpenRegister.Name = "btnOpenRegister";
            btnOpenRegister.Size = new Size(94, 29);
            btnOpenRegister.TabIndex = 8;
            btnOpenRegister.Text = "Înregistrare";
            btnOpenRegister.UseVisualStyleBackColor = false;
            btnOpenRegister.Click += btnOpenRegister_Click;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.BackColor = SystemColors.GradientActiveCaption;
            txtLoginPassword.ForeColor = SystemColors.WindowFrame;
            txtLoginPassword.Location = new Point(166, 152);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(167, 27);
            txtLoginPassword.TabIndex = 7;
            txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 159);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 6;
            label4.Text = "Parolă";
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.BackColor = SystemColors.GradientActiveCaption;
            txtLoginUsername.ForeColor = SystemColors.WindowFrame;
            txtLoginUsername.Location = new Point(166, 89);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(167, 27);
            txtLoginUsername.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 92);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlRegister);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            pnlRegister.ResumeLayout(false);
            pnlRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLoginTitle;
        private Panel pnlRegister;
        private Button btnLogin;
        private Button btnOpenRegister;
        private TextBox txtLoginPassword;
        private Label label4;
        private TextBox txtLoginUsername;
        private Label label3;
    }
}