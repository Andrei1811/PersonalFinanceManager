using PersonalFinanceManager.Data;
using PersonalFinanceManager.Forms;

namespace PersonalFinanceManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            new JsonDataService();

            Application.Run(new LoginForm());
        }
    }
}