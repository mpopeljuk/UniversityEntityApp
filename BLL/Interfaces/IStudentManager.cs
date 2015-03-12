using DBModels;
using DBModels.DTO;
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
        IEnumerable<Student> GetStudentsByGroupId(int groupId);
        StudentDTO GetStudentByID(int studentId);
        Student GetRawStudentByID(int studentId);
        Student InsertStudent(Student student);
        void DeleteStudent(int studentId);
        Student UpdateStudent(Student student);
    }
}
