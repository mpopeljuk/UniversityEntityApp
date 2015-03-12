using DBModels;
using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubjectManager 
    {
        IEnumerable<SubjectDTO> GetSubjects();
        SubjectDTO GetSubjectByID(int subjectId);
        Subject GetRawSubjectByID(int subjectId);
        Subject InsertSubject(Subject subject);
        void DeleteSubject(int subjectId);
        Subject UpdateSubject(Subject subject);
    }
}
