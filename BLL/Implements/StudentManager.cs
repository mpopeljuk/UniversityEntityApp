using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Interfaces;
using DBModels.DTO;
using AutoMapper;

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
            var students = uOW.StudentRep.Get();
            var result = Mapper.Map<IEnumerable<StudentDTO>>(students);

            //foreach (var s in result){
            //    var match = students.FirstOrDefault(f=>f.Id == s.Id);
            //    s.GroupName = match.Group.Name;
            //}

            return result.ToList();
        }

        public IEnumerable<Student> GetStudentsByGroupId(int groupId)
        {
            var list = uOW.StudentRep.Get().Where(item => item.GroupId == groupId);
            return list.ToList();
        }

        public StudentDTO GetStudentByID(int studentId)
        {
            var item = uOW.StudentRep.GetByID(studentId);
            return Mapper.Map<StudentDTO>(item);
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
