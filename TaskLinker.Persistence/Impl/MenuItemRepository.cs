using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskLinker.Model;

namespace TaskLinker.Persistence.Impl
{
    internal class MenuItemRepository : IMenuItemRepository
    {
        private readonly DataContext _dataContext;

        public MenuItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IList<Group>> GetAllMenuItems()
        {
            return await _dataContext.Groups
                .OrderBy(e => e.Name)
                .Include(e => e.CommandItems.OrderBy(c => c.LinkName))
                .AsNoTracking()
                .ToListAsync();
        }

        public void Save(List<Group> groupsList)
        {
            var persistedGroups = _dataContext.Groups
                .Include(e => e.CommandItems)
                .ToList();

            var toInsert = groupsList.Except(persistedGroups);
            var toDelete = persistedGroups.Except(groupsList);

            var toUpdate = persistedGroups.Except(toInsert);
            foreach (var groupToUpdate in toUpdate)
            {
                _dataContext.CommandItems.RemoveRange(groupToUpdate.CommandItems);
                var newCommands = groupsList
                    .SingleOrDefault(g => g.Id == groupToUpdate.Id)
                    .CommandItems.ToList();
                groupToUpdate.CommandItems.Clear();
                groupToUpdate.CommandItems.AddRange(newCommands);
            }

            _dataContext.Groups.AddRange(toInsert);
            _dataContext.Groups.UpdateRange(toUpdate);
            _dataContext.Groups.RemoveRange(toDelete);

            _dataContext.SaveChanges();
        }
    }
}
