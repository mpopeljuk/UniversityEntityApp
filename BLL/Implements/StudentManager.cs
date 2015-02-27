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
            var list = uOW.StudentRep.Get().Select(item => new StudentDTO()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                GroupName = item.Group.Name
            });

            return list;
        }

        public StudentDTO GetStudentByID(int studentId)
        {
            Student item = uOW.StudentRep.GetByID(studentId);
            return new StudentDTO()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                GroupName = item.Group.Name
            };
        }

        public Student GetRawStudentByID(int studentId)
        {
            return uOW.StudentRep.GetByID(studentId);
        }

        public Student InsertStudent(Student student)
        {
            uOW.StudentRep.Insert(student);
            uOW.Save();
            return student;
        }

        public void DeleteStudent(int studentId)
        {
            uOW.StudentRep.Delete(uOW.StudentRep.GetByID(studentId));
            uOW.Save();
        }

        public Student UpdateStudent(Student student)
        {
            uOW.StudentRep.Update(student);
            uOW.Save();
            return student;
        }
    }
}
