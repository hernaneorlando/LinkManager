using LM.Gateway.Model;
using LM.Gateway.Persistence;
using LM.UI.View;
using LM.UI.View.ViewItem;
using System.Collections.Generic;
using System.Linq;

namespace LM.UI.Presenter
{
    public class SettingPresenter
    {
        private readonly IMenuItemRepository _menuItemRepository;

        private ISettingView _view;

        internal List<GroupViewItem> Groups { get; }

        public SettingPresenter(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
            Groups = new List<GroupViewItem>();
        }

        internal void AttachView(ISettingView view)
        {
            _view = view;

            var groups = _menuItemRepository
                .GetAllMenuItems()
                .Select(g => new GroupViewItem(g));

            Groups.Clear();
            Groups.AddRange(groups);
        }

        internal void SaveGroups(IList<GroupViewItem> groupViewItems)
        {
            var groups = groupViewItems
                .Select(g => g.ToModel())
                .ToList();

            _menuItemRepository.Save(groups);
        }
    }
}
