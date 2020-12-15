using System;
using System.Windows.Forms;
using TaskLinker.UI.Presenter;
using TaskLinker.UI.Properties;
using TaskLinker.UI.View;

namespace TaskLinker.UI
{
    public class TrayMenu : ApplicationContext, ITrayMenuView
    {
        private readonly TrayMenuPresenter _presenter;
        private readonly NotifyIcon _trayIcon;
        private readonly ISettingView _settings;

        public TrayMenu(TrayMenuPresenter presenter, ISettingView settings)
        {
            _presenter = presenter;
            _settings = settings;

            _trayIcon = new NotifyIcon
            {
                Icon = Resources.ColorJigsawPuzzle,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true
            };

            InitMenu();
        }

        private async void InitMenu()
        {
            _trayIcon.ContextMenuStrip.Items.Add("Settings", null, ShowConfig);
            _trayIcon.ContextMenuStrip.Items.Add("-");
            _trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
            _trayIcon.ContextMenuStrip.Items.AddRange(await _presenter.GetMenuList());
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            _settings.ShowConfig();
        }

        private void Exit(object sender, EventArgs e)
        {
            _trayIcon.Dispose();
            Dispose();
            Application.Exit();
        }
    }
}
