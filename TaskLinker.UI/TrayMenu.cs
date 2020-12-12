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

        public TrayMenu()
        {
            _presenter = new TrayMenuPresenter();
            _trayIcon = new NotifyIcon
            {
                Icon = Resources.ColorJigsawPuzzle,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true
            };

            _settings = new SettingsForm();
        }

        public void InitMenu()
        {
            _presenter.AttachView(this);

            _trayIcon.ContextMenuStrip.Items.Add("Settings", null, ShowConfig);
            _trayIcon.ContextMenuStrip.Items.Add("-");
            _trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
            _trayIcon.ContextMenuStrip.Items.AddRange(_presenter.GetMenuList());
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            _settings.ShowConfig();
        }

        private void Exit(object sender, EventArgs e)
        {
            _trayIcon.Dispose();
            Application.Exit();
        }
    }
}
