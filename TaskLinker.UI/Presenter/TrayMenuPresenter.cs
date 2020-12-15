using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLinker.Persistence;
using TaskLinker.Persistence.Impl;
using TaskLinker.UI.View;

namespace TaskLinker.UI.Presenter
{
    public class TrayMenuPresenter
    {
        private readonly IMenuItemRepository _menuItemRepository;
        //private readonly ITrayMenuView _view;

        public TrayMenuPresenter(IMenuItemRepository menuItemRepository)
        {
            //_view = view;
            _menuItemRepository = menuItemRepository;
            CheckRegistryRunValue();
        }

        //public void AttachView(ITrayMenuView view)
        //{
        //    _view = view;
        //}

        public async Task<ToolStripItem[]> GetMenuList()
        {
            var menuList = new List<ToolStripItem>();
            static ToolStripMenuItem selector(Model.Command command) =>
                new ToolStripMenuItem(command.LinkName, null, (s, e) => Process.Start(command.CommandLine));

            var groups = await _menuItemRepository.GetAllMenuItems();
            foreach (var group in groups)
            {
                menuList.AddRange(group.Commands.Select(selector));
                menuList.Add(new ToolStripMenuItem("-"));
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
