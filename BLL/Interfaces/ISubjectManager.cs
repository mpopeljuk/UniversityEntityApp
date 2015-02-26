using BLL.DTO;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISubjectManager : IDisposable
    {
        IEnumerable<SubjectDTO> GetSubjects();
        Subject GetSubjectByID(int subjectId);
        void InsertSubject(Subject subject);
        void DeleteSubject(int subjectId);
        void UpdateSubject(Subject subject);
    }
}
