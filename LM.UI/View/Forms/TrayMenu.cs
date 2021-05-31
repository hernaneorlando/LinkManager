using LM.Gateway.Model;
using LM.UI.Extensions;
using LM.UI.Presenter;
using LM.UI.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace LM.UI.View.Forms
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
                Icon = Resources.MainIcon,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true,
                Text = "Link Manager"
            };

            InitMenu();
        }

        private void InitMenu()
        {
            _trayIcon.ContextMenuStrip.Items.AddRange(GetMenuList());
            _trayIcon.ContextMenuStrip.Items.Add("Settings", null, ShowConfig);
            _trayIcon.ContextMenuStrip.Items.Add("-");
            _trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
        }

        private ToolStripItem[] GetMenuList()
        {
            var menuList = new List<ToolStripItem>();
            static ToolStripMenuItem selector(CommandItem command) =>
                new ToolStripMenuItem(command.Name, command.Image.ToImage(), (s, e) => Process.Start(command.CommandLine));

            var groups = _presenter.GetMenuList();
            foreach (var group in groups)
            {
                var groupName = new ToolStripLabel
                {
                    Text = group.Name,
                    Padding = new Padding(4, 0, 0, 4)
                };

                menuList.Add(groupName);
                menuList.AddRange(group.CommandItems.Select(selector));
                menuList.Add(new ToolStripSeparator());
            }

            return menuList.ToArray();
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
