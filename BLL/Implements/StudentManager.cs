using DBModels;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StudentManager : IStudentManager, IDisposable
    {
        private UniversityContext context;

        public StudentManager(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var list = context.Students.Select(item => new StudentDTO()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age,
                GroupId = item.GroupId
            });
            return list.ToList();
        }

        Student IStudentManager.GetStudentByID(int studentId)
        {
            return context.Students.Find(studentId);
        }

        public void InsertStudent(Student student)
        {
            context.Students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            Student student = context.Students.Find(studentId);
            context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }
    }
}
