using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GroupToSubjectRepository : IGroupToSubjectRepository, IDisposable
    {
        private UniversityContext context;
        private bool disposed = false;

        public GroupToSubjectRepository(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<DBModels.GroupToSubject> GetSubjectsForGroup(int groupId)
        {
            return context.GroupToSubject.Where(g => g.GroupId == groupId);
        }

        public IEnumerable<DBModels.GroupToSubject> GetGroupsForSubject(int subjectId)
        {
            return context.GroupToSubject.Where(g => g.SubjectId == subjectId);
        }

        public void InsertGroupToSubject(DBModels.GroupToSubject gts)
        {
            context.GroupToSubject.Add(gts);
        }

        public void DeleteGroupToSubject(int groupId, int subjectId)
        {
            var query = from row in context.GroupToSubject
                        where row.GroupId == groupId && row.SubjectId == subjectId
                        select row;
            context.GroupToSubject.Remove( query.FirstOrDefault() );
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
