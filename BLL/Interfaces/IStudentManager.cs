using BLL.DTO;
using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentManager 
    {
        IEnumerable<StudentDTO> GetStudents();
        StudentDTO GetStudentByID(int studentId);
        Student InsertStudent(Student student);
        void DeleteStudent(int studentId);
        Student UpdateStudent(Student student);
    }
}
