using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TaskLinker.UI.Presenter;
using TaskLinker.UI.View;

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

            var serviceProvider = RegisterServices();

            var trayMenu = (TrayMenu)serviceProvider.GetService<ITrayMenuView>();
            Application.Run(trayMenu);
        }

        private static ServiceProvider RegisterServices()
        {
            var service = new ServiceCollection();

            service.AddPersistenceDependency();

            service
                .AddSingleton<SettingPresenter>()
                .AddSingleton<ISettingView, SettingsForm>();

            service
                .AddSingleton<TrayMenuPresenter>()
                .AddSingleton<ITrayMenuView, TrayMenu>();

            return service.BuildServiceProvider(true);
        }
    }
}
