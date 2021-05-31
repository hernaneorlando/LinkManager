using System.Collections.Generic;
using LM.Gateway.Model;

namespace LM.Gateway.Persistence
{
    public interface IMenuItemRepository
    {
        IList<Group> GetAllMenuItems();
        void Save(IList<Group> groupsList);
    }
}
