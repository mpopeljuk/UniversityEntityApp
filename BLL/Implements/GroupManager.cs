using BLL.DTO;
using BLL.Interfaces;
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

        public GroupManager() : base(new UnitOfWork())
        {
            // TODO: Complete member initialization
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            var list = uOW.GroupRep.Get().Select(item => new GroupDTO()
            {
                Id = item.Id,
                Name = item.Name
            });
            return list.ToList();
        }

        public GroupDTO GetGroupByID(int groupId)
        {
            Group item = uOW.GroupRep.GetByID(groupId);
            return new GroupDTO()
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public Group GetRawGroupByID(int groupId)
        {
            return uOW.GroupRep.GetByID(groupId);
        }

        public Group InsertGroup(Group group)
        {
            uOW.GroupRep.Insert(group);
            uOW.Save();
            return group;
        }

        public void DeleteGroup(int groupId)
        {
            uOW.GroupRep.Delete(uOW.GroupRep.GetByID(groupId));
            uOW.Save();
        }

        public Group UpdateGroup(Group group)
        {
            uOW.GroupRep.Update(group);
            uOW.Save();
            return group;
        }
    }
}
