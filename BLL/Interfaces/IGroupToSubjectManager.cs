using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGroupToSubjectManager 
    {
        IEnumerable<GroupToSubject> GetSubjectsForGroup(int groupId);
        IEnumerable<GroupToSubject> GetGroupsForSubject(int subjectId);
        GroupToSubject GetGtsByID(int groupId, int subjectId);
        GroupToSubject InsertGroupToSubject(GroupToSubject gts);
        void DeleteGroupToSubject(int groupId, int subjectId);
    }
}
