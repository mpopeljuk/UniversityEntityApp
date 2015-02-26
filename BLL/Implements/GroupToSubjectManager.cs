using BLL.DTO;
using BLL;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class GroupToSubjectManager : BaseManager, IGroupToSubjectManager
    {
        public GroupToSubjectManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<GroupToSubjectDTO> GetSubjectsForGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupToSubjectDTO> GetGroupsForSubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public void InsertGroupToSubject(GroupToSubject gts)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroupToSubject(int groupId, int subjectId)
        {
            throw new NotImplementedException();
        }
    }
}
