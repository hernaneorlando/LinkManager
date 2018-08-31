using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using TaskLinker.Forms;
using TaskLinker.Model;
using TaskLinker.Properties;
using TaskLinker.Util;

namespace TaskLinker
{
    public class TaskLinkerRepository : ApplicationContext
    {
        private readonly NotifyIcon _trayIcon;
        private readonly SettingsForm _configWindow;

        private RepositoryViewModel _repository;

        public TaskLinkerRepository()
        {
            CheckRegistryRunValue();

            _repository = new RepositoryViewModel();
            var listMenuItem = GetMenuItemListFromRepository();
            _configWindow = new SettingsForm();
            _configWindow.FormClosed += (formSender, formEvent) => RefreshMenu();

            // Initialize Tray Icon
            _trayIcon = new NotifyIcon
            {
                Icon = Resources.ColorJigsawPuzzle,
                ContextMenu = new ContextMenu(listMenuItem.ToArray()),
                Visible = true
            };
        }

        private void CheckRegistryRunValue()
        {
            var registryRunKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            var chaveRegistro = GetType().Namespace;
            var valorRegistro = string.Format("{0}{1}.exe", AppDomain.CurrentDomain.BaseDirectory, chaveRegistro);

            var valor = registryRunKey?.GetValue(chaveRegistro);
            if (string.IsNullOrWhiteSpace(valor as string) || !valorRegistro.Equals(valor))
            {
                registryRunKey?.SetValue(chaveRegistro, valorRegistro);
            }
        }

        private List<MenuItem> GetMenuItemListFromRepository()
        {
            var listMenuItem = new List<MenuItem>();

            if (!File.Exists(TaskLinkerUtil.RepositoryFilePath))
            {
                using (var fileCreator = File.Create(TaskLinkerUtil.RepositoryFilePath))
                {
                    fileCreator.Close();
                }
            }
            else
            {
                using (var fileReader = File.OpenRead(TaskLinkerUtil.RepositoryFilePath))
                {
                    if (fileReader.Length > 0)
                    {
                        fileReader.Close();
                        using (var stream = new FileStream(TaskLinkerUtil.RepositoryFilePath, FileMode.OpenOrCreate))
                        {
                            var serializer = new XmlSerializer(typeof(RepositoryViewModel));
                            _repository = (RepositoryViewModel)serializer.Deserialize(stream);
                        }

                        _repository.Group.ForEach(group =>
                        {
                            listMenuItem.AddRange(group.UrlList.Select(url => new MenuItem(url.LinkName, (sender, e) => Process.Start(url.Url))));
                            listMenuItem.Add(new MenuItem("-"));
                        });
                    }
                }
            }

            listMenuItem.AddRange(new List<MenuItem>
            {
                new MenuItem("Settings", ShowConfig),
                new MenuItem("-"),
                new MenuItem("Exit", Exit)
            });

            return listMenuItem;
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            _configWindow.Repository = _repository;

            // If we are already showing the window, merely focus it.
            if (_configWindow.Visible)
            {
                _configWindow.Activate();
            }
            else
            {
                _configWindow.ShowDialog();
            }
        }

        private void RefreshMenu()
        {
            _trayIcon.ContextMenu = new ContextMenu(GetMenuItemListFromRepository().ToArray());
        }

        private void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
