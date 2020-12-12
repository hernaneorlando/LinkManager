using System;
using System.Windows.Forms;

namespace TaskLinker.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var trayMenu = new TrayMenu();
            trayMenu.InitMenu();

            Application.Run(trayMenu);
        }
    }
}
