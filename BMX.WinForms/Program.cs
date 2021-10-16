using System;
using System.Windows.Forms;
using BMX.Engine;

namespace BMX.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameRunner.Run(Application.Run);
        }
    }
}
