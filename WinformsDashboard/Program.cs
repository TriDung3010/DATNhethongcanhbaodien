using System;
using System.Windows.Forms;
using WinformsDashboard.Forms;

namespace WinformsDashboard
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
