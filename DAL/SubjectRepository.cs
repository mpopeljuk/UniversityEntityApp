using DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class SubjectRepository : ISubjectRepository, IDisposable
    {
        private UniversityContext context;
        private bool disposed = false;

        public SubjectRepository(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<DBModels.Subject> GetSubjects()
        {
            return context.Subject.ToList();
        }

        public DBModels.Subject GetSubjectByID(int subjectId)
        {
            return context.Subject.Find(subjectId);
        }

        public void InsertSubject(DBModels.Subject subject)
        {
            context.Subject.Add(subject);
        }

        public void DeleteSubject(int subjectId)
        {
            Subject subject = context.Subject.Find(subjectId);
            context.Subject.Remove(subject);
        }

        public void UpdateSubject(DBModels.Subject subject)
        {
            context.Entry(subject).State = EntityState.Modified;
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
