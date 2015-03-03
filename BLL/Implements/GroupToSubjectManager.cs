using BLL.DTO;
using BLL;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace BLL.Implements
{
    public class GroupToSubjectManager : BaseManager, IGroupToSubjectManager
    {
        public GroupToSubjectManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<GroupToSubject> GetSubjectsForGroup(int groupId)
        {
            var list = uOW.GroupToSubjectRep.GetSubjectsForGroup(groupId);
            return list.ToList();
        }

        public IEnumerable<GroupToSubject> GetGroupsForSubject(int subjectId)
        {
            var list = uOW.GroupToSubjectRep.GetGroupsForSubject(subjectId);
            return list.ToList();
        }

        public GroupToSubject GetGtsByID(int groupId, int subjectId)
        {
            return uOW.GroupToSubjectRep.GetById(groupId, subjectId);
        }

        public GroupToSubject InsertGroupToSubject(GroupToSubject gts)
        {
            uOW.GroupToSubjectRep.Insert(gts);
            uOW.Save();
            return gts;
        }

        public void DeleteGroupToSubject(int groupId, int subjectId)
        {
            uOW.GroupToSubjectRep.Delete(groupId, subjectId);
            uOW.Save();
        }
    }
}
