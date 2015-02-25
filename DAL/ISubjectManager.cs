using DBModels;
using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISubjectManager : IDisposable
    {
        IEnumerable<SubjectDTO> GetSubjects();
        Subject GetSubjectByID(int subjectId);
        void InsertSubject(Subject subject);
        void DeleteSubject(int subjectId);
        void UpdateSubject(Subject subject);
        int Save();
    }
}
