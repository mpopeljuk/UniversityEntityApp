using DBModels;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Interfaces;

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
            var list = uOW.StudentRep.Get().Select(item => new StudentDTO() { 
            FirstName = item.FirstName,
            LastName = item.LastName,
            Age = item.Age,
            GroupId = item.GroupId
            });

            return list.ToList();
        }

        public StudentDTO GetStudentByID(int studentId)
        {
            Student item = uOW.StudentRep.GetByID(studentId);
            return new StudentDTO()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                GroupId = item.GroupId
            };
        }

        public Student InsertStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
