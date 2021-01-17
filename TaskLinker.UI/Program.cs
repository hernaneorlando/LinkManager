using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TaskLinker.UI.Presenter;
using TaskLinker.UI.View;
using TaskLinker.UI.View.Forms;

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

            var handler = serviceProvider.GetService<ExceptionHandler>();
            Application.ThreadException += handler.ThreadException;
            AppDomain.CurrentDomain.UnhandledException += handler.UnhandledException;

            var trayMenu = (TrayMenu)serviceProvider.GetService<ITrayMenuView>();
            Application.Run(trayMenu);
        }

        private static ServiceProvider RegisterServices()
        {
            var service = new ServiceCollection();

            service.AddPersistenceDependency();

            service.AddSingleton<IExceptionView, ExceptionForm>();
            service.AddSingleton<ExceptionHandler>();

            service
                .AddSingleton<TrayMenuPresenter>()
                .AddSingleton<ITrayMenuView, TrayMenu>();

            service
                .AddSingleton<SettingPresenter>()
                .AddSingleton<ISettingView, SettingsForm>();

            service
                .AddSingleton<NewCommandLinePresenter>()
                .AddSingleton<INewCommandLineView, NewCommandLineForm>();

            return service.BuildServiceProvider(true);
        }
    }
}
