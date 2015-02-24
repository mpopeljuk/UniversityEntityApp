using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IGroupRepository : IDisposable
    {
        IEnumerable<Group> GetGroups();
        Group GetGroupByID(int groupId);
        void InsertGroup(Group group);
        void DeleteGroup(int groupId);
        void UpdateGroup(Group group);
        void Save();
    }
}
