using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Implements;
using System.Linq;
using BLL.DTO;
using DBModels;
using DAL;

namespace UniversityUnitTestProject
{
    [TestClass]
    public class StudentManagerTest
    {
        private StudentManager manager;

        [TestInitialize]
        public void Init()
        {
            manager = new StudentManager(new DAL.UnitOfWork());
        }

        [TestMethod]
        public void GetAllStudents()
        {
            var list = manager.GetStudents();

            Assert.IsNotNull(list, ".GetStudents returned null!");
        }

        [TestMethod]
        public void GetSingleStudent()
        {
            var id = manager.GetStudents().LastOrDefault().Id;
            var item = manager.GetStudentByID(id);

            Assert.IsNotNull(item, ".GetStudentByID returned null!");
            Assert.IsInstanceOfType(item, typeof(StudentDTO), 
                    "Student is not typeof StudentDTO!");
            
            Assert.IsInstanceOfType(item.Id, typeof(int), "Student Id field is not int!");
            Assert.IsInstanceOfType(item.FirstName, typeof(string),
                    "Student FirstName field is not string!");
            Assert.IsInstanceOfType(item.LastName, typeof(string),
                    "Student LastName field is not string!");
            Assert.IsInstanceOfType(item.Age, typeof(int), "Student Id field is not int!");
            Assert.IsInstanceOfType(item.GroupName, typeof(string), 
                    "Student GroupName field is not string!");
        }

        [TestMethod]
        public void GetSingleRawStudent()
        {
            var id = manager.GetStudents().LastOrDefault().Id;
            var item = manager.GetRawStudentByID(id);

            Assert.IsNotNull(item, ".GetStudentByID returned null!");
            Assert.IsInstanceOfType(item, typeof(Student), 
                    "Student is not typeof StudentDTO!");

            Assert.IsInstanceOfType(item.Id, typeof(int), "Student Id field is not int!");
            Assert.IsInstanceOfType(item.FirstName, typeof(string),
                    "Student FirstName field is not string!");
            Assert.IsInstanceOfType(item.LastName, typeof(string),
                    "Student LastName field is not string!");
            Assert.IsInstanceOfType(item.Age, typeof(int), "Student Id field is not int!");
            Assert.IsInstanceOfType(item.GroupId, typeof(int),
                    "Student GroupId field is not string!");

            Assert.IsNotNull(item.Group, "Student Group field is null!");
            Assert.IsInstanceOfType(item.Group, typeof(Group),
                    "Student Group field is not Group type!");
        }

        [TestMethod]
        public void InsertStudent()
        {
            var tempManager = new GroupManager(new UnitOfWork());

            string firstName = "UnitTestStudentFirstName";
            string lastName = "UnitTestStudentLastName";
            int age = 20;
            int groupId = tempManager.GetGroups().LastOrDefault().Id;

            var item = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                GroupId = groupId
            };

            manager.InsertStudent(item);

            Assert.IsNotNull(item, "Inserted Student is null!");
            Assert.IsNotNull(item.Id, "Inserted Student Id null");

            Assert.IsInstanceOfType(item.Id, typeof(int), "Inserted Student Id is not int");
            Assert.AreEqual(firstName, item.FirstName,
                    "Inserted Student FirstName is not as expected");
            Assert.AreEqual(lastName, item.LastName,
                    "Inserted Student LastName is not as expected");
            Assert.AreEqual(age, item.Age,
                    "Inserted Student Age is not as expected");
            Assert.AreEqual(groupId, item.GroupId,
                    "Inserted Student GroupId is not as expected");
        }

        [TestMethod]
        public void UpdateStudent()
        {
            var tempManager = new GroupManager(new UnitOfWork());

            var id = manager.GetStudents().LastOrDefault().Id;

            string firstName = "UpdateUnitTestStudentFirstName";
            string lastName = "UpdateUnitTestStudentLastName";
            int age = 35;
            int groupId = tempManager.GetGroups().FirstOrDefault().Id;

            var item = manager.GetRawStudentByID(id);
            item.FirstName = firstName;
            item.LastName = lastName;
            item.Age = age;
            item.GroupId = groupId;

            manager.UpdateStudent(item);

            Assert.IsNotNull(item, "Updated Student is null!");
            Assert.IsNotNull(item.Id, "Updated Student Id null");

            Assert.IsInstanceOfType(item.Id, typeof(int), "Updated Student Id is not int");
            Assert.AreEqual(id, item.Id, "Updated Student Id is not as expected");
            Assert.AreEqual(firstName, item.FirstName,
                    "Inserted Student FirstName is not as expected");
            Assert.AreEqual(lastName, item.LastName,
                    "Inserted Student LastName is not as expected");
            Assert.AreEqual(age, item.Age,
                    "Inserted Student Age is not as expected");
            Assert.AreEqual(groupId, item.GroupId,
                    "Inserted Student GroupId is not as expected");
        }

        [TestMethod]
        public void DeleteStudent()
        {
            int id = manager.GetStudents().LastOrDefault().Id;

            manager.DeleteStudent(id);

            var item = manager.GetRawStudentByID(id);

            Assert.IsNull(item, "Student was not deleted!");
        }

    }
}
