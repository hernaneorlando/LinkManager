using System.Collections.Generic;
using System.Threading.Tasks;
using TaskLinker.Model;

namespace TaskLinker.Persistence
{
    public interface IMenuItemRepository
    {
        public Task<IList<Group>> GetAllMenuItems();
    }
}
