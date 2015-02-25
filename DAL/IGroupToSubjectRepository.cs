using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IGroupToSubjectRepository : IDisposable
    {
        IEnumerable<GroupToSubject> GetSubjectsForGroup(int groupId);
        IEnumerable<GroupToSubject> GetGroupsForSubject(int subjectId);
        void InsertGroupToSubject(GroupToSubject gts);
        void DeleteGroupToSubject(int groupId, int subjectId);
        void Save();
    }
}
