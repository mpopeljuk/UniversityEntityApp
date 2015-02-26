using BLL.DTO;
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
            throw new NotImplementedException();
        }

        public Subject GetSubjectByID(int subjectId)
        {
            throw new NotImplementedException();
        }

        public void InsertSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
