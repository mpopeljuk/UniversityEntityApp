using DBModels;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Implements
{
    public class StudentManager : BaseManager, IStudentManager
    {
        public StudentManager(UnitOfWork uOW)
            : base(uOW)
        {
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByID(int studentId)
        {
            throw new NotImplementedException();
        }

        public void InsertStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
