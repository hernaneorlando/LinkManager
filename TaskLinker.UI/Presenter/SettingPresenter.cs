using System.Collections.Generic;
using TaskLinker.Model;
using TaskLinker.Persistence;
using TaskLinker.UI.View;

namespace TaskLinker.UI.Presenter
{
    public class SettingPresenter
    {
        private readonly IMenuItemRepository _menuItemRepository;

        private ISettingView _view;

        public readonly List<Group> Groups = new List<Group>();

        public SettingPresenter(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async void AttachView(ISettingView view)
        {
            _view = view;
            Groups.Clear();
            Groups.AddRange(await _menuItemRepository.GetAllMenuItems());
        }

        public void SaveList()
        {
            _menuItemRepository.Save(Groups);
        }
    }
}
