using AutoMapper;
using BLL.Interfaces;
using DAL;
using DBModels;
using DBModels.DTO;
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
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            var list = uOW.GroupRep.Get();
            var result = Mapper.Map<IEnumerable<GroupDTO>>(list);

            return result.ToList();
        }

        public GroupDTO GetGroupByID(int groupId)
        {
            Group item = uOW.GroupRep.GetByID(groupId);
            return Mapper.Map<GroupDTO>(item);
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
