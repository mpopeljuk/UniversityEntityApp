using BLL.DTO;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubjectManager : ISubjectManager, IDisposable
    {
        private UniversityContext context;

        public SubjectManager(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<NameIdPairDTO> GetNameIdPair()
        {
            var list = context.Subjects.Select(item => new NameIdPairDTO()
            {
                Id = item.Id,
                Name = item.Name
            });
            return list.ToList();
        }

        public IEnumerable<SubjectDTO> GetSubjects()
        {
            var list = context.Subjects.Select(item => new SubjectDTO()
            {
                Id = item.Id,
                Name = item.Name
            });
            return list.ToList();
        }

        public DBModels.Subject GetSubjectByID(int subjectId)
        {
            return context.Subjects.Find(subjectId);
        }

        public void InsertSubject(DBModels.Subject subject)
        {
            context.Subjects.Add(subject);
        }

        public void DeleteSubject(int subjectId)
        {
            Subject subject = context.Subjects.Find(subjectId);
            context.Subjects.Remove(subject);
        }

        public void UpdateSubject(DBModels.Subject subject)
        {
            context.Entry(subject).State = EntityState.Modified;
        }
    }
}
