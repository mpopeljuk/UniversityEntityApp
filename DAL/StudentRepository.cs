using DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class StudentRepository : IStudentRepository, IDisposable
    {
        private UniversityContext context;
        private bool disposed = false;

        public StudentRepository(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<DBModels.Student> GetStudents()
        {
            return context.Student.ToList();
        }

        Student IStudentRepository.GetStudentByID(int studentId)
        {
            return context.Student.Find(studentId);
        }

        public void InsertStudent(Student student)
        {
            context.Student.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            Student student = context.Student.Find(studentId);
            context.Student.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
