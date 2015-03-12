﻿using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels.DTO;

namespace BLL.Interfaces
{
    public interface IGroupManager 
    {
        IEnumerable<GroupDTO> GetGroups();
        GroupDTO GetGroupByID(int groupId);
        Group GetRawGroupByID(int groupId);
        Group InsertGroup(Group group);
        void DeleteGroup(int groupId);
        Group UpdateGroup(Group group);
    }
}
