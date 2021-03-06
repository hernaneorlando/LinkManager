using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskLinker.Model;
using TaskLinker.Persistence;

namespace TaskLinker.Presenter
{
    public class TrayMenuPresenter
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public TrayMenuPresenter(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
            CheckRegistryRunValue();
        }

        public async Task<IList<Group>> GetMenuList() => await _menuItemRepository
                .GetAllMenuItems();

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
