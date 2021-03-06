using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TaskLinker.Persistence;
using TaskLinker.Persistence.Impl;
using TaskLinker.Presenter;
using TaskLinker.View;
using TaskLinker.View.Forms;

namespace TaskLinker
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

            service.AddDbContext<DataContext>(ServiceLifetime.Singleton);
            service.AddSingleton<IMenuItemRepository, MenuItemRepository>();

            var dataContext = service.BuildServiceProvider().GetService<DataContext>();
            dataContext.Database.Migrate();

            service.AddSingleton<IExceptionView, ExceptionForm>();
            service.AddSingleton<ExceptionHandler>();

            service
                .AddSingleton<TrayMenuPresenter>()
                .AddSingleton<ITrayMenuView, TrayMenu>();

            service
                .AddSingleton<SettingPresenter>()
                .AddSingleton<ISettingView, SettingsForm>();

            service
                .AddSingleton<EditPresenter>()
                .AddSingleton<IEditView, EditForm>();

            service
                .AddSingleton<NewCommandLinePresenter>()
                .AddSingleton<ICommandLineEditView, CommandLineEditForm>();

            return service.BuildServiceProvider(true);
        }
    }
}
