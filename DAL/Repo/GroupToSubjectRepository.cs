using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class GroupToSubjectRepository
    {
        internal UniversityContext context;

        public GroupToSubjectRepository(UniversityContext _context)
        {
            context = _context;
        }

        public virtual IEnumerable<GroupToSubject> GetSubjectsForGroup(int groupId)
        {
            return context.GroupToSubjects.Where(g => g.GroupId == groupId);
        }

        public virtual IEnumerable<GroupToSubject> GetGroupsForSubject(int subjectId)
        {
            return context.GroupToSubjects.Where(g => g.SubjectId == subjectId);
        }

        public virtual GroupToSubject GetById(int groupId, int subjectId)
        {
            var item = context.GroupToSubjects.Where(g => g.GroupId == groupId).Where(g => g.SubjectId == subjectId);
            return item.FirstOrDefault();
        }

        public virtual void Insert(GroupToSubject gts)
        {
            context.GroupToSubjects.Add(gts);
        }

        public virtual void Delete(int groupId, int subjectId)
        {
            var query = from row in context.GroupToSubjects
                        where row.GroupId == groupId && row.SubjectId == subjectId
                        select row;
            context.GroupToSubjects.Remove(query.FirstOrDefault());
        }
    }
}
