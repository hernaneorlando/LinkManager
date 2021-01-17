using System;
using System.Drawing;
using System.Windows.Forms;
using TaskLinker.UI.Presenter;
using TaskLinker.UI.Properties;

namespace TaskLinker.UI.View.Forms
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
                Visible = true,
                Text = "Link Manager"
            };

            InitMenu();
        }

        private async void InitMenu()
        {
            _trayIcon.ContextMenuStrip.Items.AddRange(await _presenter.GetMenuList());
            _trayIcon.ContextMenuStrip.Items.Add("Settings", null, ShowConfig);
            _trayIcon.ContextMenuStrip.Items.Add("-");
            _trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            _settings.ShowConfig();
            _trayIcon.ContextMenuStrip.Items.Clear();
            InitMenu();
        }

        private void Exit(object sender, EventArgs e)
        {
            _trayIcon.Dispose();
            Dispose();
            Application.Exit();
        }
    }
}
