using PersonalFinanceManager.Services;

namespace PersonalFinanceManager.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService;
        private bool _allowCloseWithoutExit;

        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool success = _authService.Register(
                txtFullName.Text,
                txtRegisterUsername.Text,
                txtRegisterPassword.Text,
                out string message);

            MessageBox.Show(message);

            if (success)
            {
                _allowCloseWithoutExit = true;
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _allowCloseWithoutExit = true;
            this.Close();
        }
    }
}