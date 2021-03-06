using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLinker.Presenter;
using TaskLinker.Properties;

namespace TaskLinker.View.Forms
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
            _trayIcon.ContextMenuStrip.Items.AddRange(await GetMenuList());
            _trayIcon.ContextMenuStrip.Items.Add("Settings", null, ShowConfig);
            _trayIcon.ContextMenuStrip.Items.Add("-");
            _trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
        }

        private async Task<ToolStripItem[]> GetMenuList()
        {
            var menuList = new List<ToolStripItem>();
            static ToolStripMenuItem selector(Model.CommandItem command) =>
                new ToolStripMenuItem(command.LinkName, null, (s, e) => Process.Start(command.CommandLine));

            var groups = await _presenter.GetMenuList();
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
