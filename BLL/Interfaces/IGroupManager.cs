using DBModels;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IGroupManager : IDisposable
    {
        IEnumerable<GroupDTO> GetGroups();
        Group GetGroupByID(int groupId);
        void InsertGroup(Group group);
        void DeleteGroup(int groupId);
        void UpdateGroup(Group group);
    }
}
