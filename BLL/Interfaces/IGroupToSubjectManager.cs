using DBModels;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IGroupToSubjectManager 
    {
        IEnumerable<GroupToSubjectDTO> GetSubjectsForGroup(int groupId);
        IEnumerable<GroupToSubjectDTO> GetGroupsForSubject(int subjectId);
        void InsertGroupToSubject(GroupToSubject gts);
        void DeleteGroupToSubject(int groupId, int subjectId);
    }
}
