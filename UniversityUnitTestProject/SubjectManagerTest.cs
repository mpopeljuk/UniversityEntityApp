using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Implements;
using System.Linq;
using DBModels;
using DBModels.DTO;

namespace UniversityUnitTestProject
{
    [TestClass]
    public class SubjectManagerTest
    {
        private SubjectManager manager;

        [TestInitialize]
        public void Init()
        {
            manager = new SubjectManager(new DAL.UnitOfWork());
        }

        [TestMethod]
        public void GetAllSubjects()
        {
            var list = manager.GetSubjects();

            Assert.IsNotNull(list, ".GetSubjects returned null!");
        }

        [TestMethod]
        public void GetSingleSubject()
        {
            var id = manager.GetSubjects().LastOrDefault().Id;
            var item = manager.GetSubjectByID(id);

            Assert.IsNotNull(item, ".GetSubjectByID returned null!");
            Assert.IsInstanceOfType(item, typeof(SubjectDTO), "Subject is not typeof SubjectDTO!");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Subject Id field is not int!");
            Assert.IsInstanceOfType(item.Name, typeof(string),
                    "Subject Name field is not string!");
        }

        [TestMethod]
        public void GetSingleRawSubject()
        {
            var id = manager.GetSubjects().LastOrDefault().Id;
            var item = manager.GetRawSubjectByID(id);

            Assert.IsNotNull(item, ".GetSubjectByID returned null!");
            Assert.IsInstanceOfType(item, typeof(Subject), "Subject is not typeof Subject!");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Subject Id field is not int!");
            Assert.IsInstanceOfType(item.Name, typeof(string),
                    "Subject Name field is not string!");
        }

        [TestMethod]
        public void InsertSubject()
        {
            int preCount = manager.GetSubjects().Count();
            string name = "UnitTestSubject";
            var item = new Subject
            {
                Name = name
            };

            manager.InsertSubject(item);
            int postCount = manager.GetSubjects().Count();

            Assert.IsNotNull(item, "Inserted Subject is null!");
            Assert.IsNotNull(item.Id, "Inserted Subject Id null");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Inserted Subject Id is not int");
            Assert.AreEqual(name, item.Name, "Inserted Subject Name is not as expected");
            Assert.AreEqual(preCount + 1, postCount, "Number of deleted rows are not 1. Its " + (postCount + preCount));
        }

        [TestMethod]
        public void UpdateSubject()
        {
            int preCount = manager.GetSubjects().Count();
            var id = manager.GetSubjects().LastOrDefault().Id;
            var item = manager.GetRawSubjectByID(id);
            string name = "UnitTestSubjectUpdate";
            item.Name = name;

            manager.UpdateSubject(item);
            int postCount = manager.GetSubjects().Count();

            Assert.IsNotNull(item, "Updated Subject is null!");
            Assert.IsNotNull(item.Id, "Updated Subject Id null");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Updated Subject Id is not int");
            Assert.AreEqual(id, item.Id, "Updated Subject Id is not as expected");
            Assert.AreEqual(name, item.Name, "Updated Subject Name is not as expected");
            Assert.AreEqual(preCount - 1, postCount, "Number of deleted rows are not 1. Its " + (postCount - preCount));
        }

        [TestMethod]
        public void DeleteSubject()
        {
            int id = manager.GetSubjects().LastOrDefault().Id;

            manager.DeleteSubject(id);

            var item = manager.GetRawSubjectByID(id);

            Assert.IsNull(item, "Subject was not deleted!");
        }

    }
}
