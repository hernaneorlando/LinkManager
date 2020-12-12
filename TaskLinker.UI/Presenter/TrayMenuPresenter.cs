using Microsoft.Win32;
using System;
using System.Windows.Forms;
using TaskLinker.UI.View;

namespace TaskLinker.UI.Presenter
{
    public class TrayMenuPresenter
    {
        private ITrayMenuView _view;

        public TrayMenuPresenter()
        {
            CheckRegistryRunValue();
        }

        public void AttachView(ITrayMenuView view)
        {
            _view = view;
        }

        public ToolStripItem[] GetMenuList()
        {
            return new ToolStripItem[] { };
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
