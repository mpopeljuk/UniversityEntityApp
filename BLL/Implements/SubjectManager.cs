using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implements
{
    public class SubjectManager : BaseManager, ISubjectManager
    {
        public SubjectManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<SubjectDTO> GetSubjects()
        {
            var list = uOW.SubjectRep.Get().Select(item => new SubjectDTO()
            {
                Id = item.Id,
                Name = item.Name
            });

            return list.ToList();
        }

        public SubjectDTO GetSubjectByID(int subjectId)
        {
            Subject item = uOW.SubjectRep.GetByID(subjectId);
            return new SubjectDTO() {
                Id = item.Id,
                Name = item.Name
            };
        }

        public Subject GetRawSubjectByID(int subjectId)
        {
            return uOW.SubjectRep.GetByID(subjectId);
        }

        public Subject InsertSubject(Subject subject)
        {
            uOW.SubjectRep.Insert(subject);
            uOW.Save();
            return subject;
        }

        public void DeleteSubject(int subjectId)
        {
            uOW.SubjectRep.Delete( uOW.SubjectRep.GetByID(subjectId) );
            uOW.Save();
        }

        public Subject UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
