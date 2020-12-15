using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                .Include(e => e.Commands)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
