using DBModels;
using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGroupToSubjectManager : IDisposable
    {
        IEnumerable<GroupToSubjectDTO> GetSubjectsForGroup(int groupId);
        IEnumerable<GroupToSubjectDTO> GetGroupsForSubject(int subjectId);
        void InsertGroupToSubject(GroupToSubject gts);
        void DeleteGroupToSubject(int groupId, int subjectId);
        int Save();
    }
}
