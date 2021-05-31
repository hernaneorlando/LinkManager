using System.Collections.Generic;
using System.Linq;
using LM.Gateway.Model;

namespace LM.Gateway.Persistence.Impl
{
    internal class MenuItemRepository : IMenuItemRepository
    {
        private readonly DataContext _dataContext;

        public MenuItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<Group> GetAllMenuItems()
        {
            return _dataContext.Groups
                .Query()
                .OrderBy(e => e.Name)
                .Include(e => e.CommandItems)
                .ToList();
        }

        public void Save(IList<Group> groupsList)
        {
            _dataContext.Groups.DeleteAll();
            _dataContext.CommandItems.DeleteAll();

            var commandLines = groupsList
               .SelectMany(g => g.CommandItems)
               .ToList();

            _dataContext.CommandItems.Insert(commandLines);
            _dataContext.Groups.Insert(groupsList);
        }
    }
}
