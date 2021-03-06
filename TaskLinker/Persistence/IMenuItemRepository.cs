using System.Collections.Generic;
using System.Threading.Tasks;
using TaskLinker.Model;

namespace TaskLinker.Persistence
{
    public interface IMenuItemRepository
    {
        Task<IList<Group>> GetAllMenuItems();
        void Save(List<Group> groupsList);
    }
}
