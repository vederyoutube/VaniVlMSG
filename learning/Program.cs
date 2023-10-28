using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace learning
{
    internal static class Program
    {
        public static LoginForm LW;
        public static RegisterForm RW;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RW = new RegisterForm();
            Application.Run(LW = new LoginForm());
        }
    }
}
