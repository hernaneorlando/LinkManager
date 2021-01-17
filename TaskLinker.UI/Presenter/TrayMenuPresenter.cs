using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLinker.Persistence;

namespace TaskLinker.UI.Presenter
{
    public class TrayMenuPresenter
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public TrayMenuPresenter(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
            CheckRegistryRunValue();
        }

        public async Task<ToolStripItem[]> GetMenuList()
        {
            var menuList = new List<ToolStripItem>();
            static ToolStripMenuItem selector(Model.CommandItem command) =>
                new ToolStripMenuItem(command.LinkName, null, (s, e) => Process.Start(command.CommandLine));

            var groups = await _menuItemRepository.GetAllMenuItems();
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

        private void CheckRegistryRunValue()
        {
            var registryRunKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            var chaveRegistro = GetType().Assembly.GetName().Name;
            var valorRegistro = string.Format("{0}{1}.exe", AppDomain.CurrentDomain.BaseDirectory, chaveRegistro);

            var valor = registryRunKey?.GetValue(chaveRegistro);
            if (string.IsNullOrWhiteSpace(valor as string) || !valorRegistro.Equals(valor))
            {
                registryRunKey?.SetValue(chaveRegistro, valorRegistro);
            }
        }
    }
}
