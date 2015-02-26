using BLL.DTO;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class GroupManager : BaseManager, IGroupManager
    {

        public GroupManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            throw new NotImplementedException();
        }

        public Group GetGroupByID(int groupId)
        {
            throw new NotImplementedException();
        }

        public void InsertGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
