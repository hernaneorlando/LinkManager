using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using LM.UI.Presenter;
using LM.UI.View;
using LM.UI.View.Forms;

namespace LM.UI
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

            var handler = serviceProvider.GetService<ExceptionHandler>();
            Application.ThreadException += handler.ThreadException;
            AppDomain.CurrentDomain.UnhandledException += handler.UnhandledException;

            var trayMenu = (TrayMenu)serviceProvider.GetService<ITrayMenuView>();
            Application.Run(trayMenu);
        }

        private static ServiceProvider RegisterServices()
        {
            var service = new ServiceCollection();

            service.AddGatewayDependencies();

            service
                .AddSingleton<TrayMenuPresenter>()
                .AddSingleton<ITrayMenuView, TrayMenu>();

            service
                .AddSingleton<ExceptionHandler>()
                .AddTransient<IExceptionView, ExceptionForm>();

            service
                .AddSingleton<SettingPresenter>()
                .AddTransient<ISettingView, SettingsForm>();

            return service.BuildServiceProvider(true);
        }
    }
}
