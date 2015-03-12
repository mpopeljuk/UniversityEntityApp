using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Implements;
using System.Linq;
using DBModels;
using DBModels.DTO;

namespace UniversityUnitTestProject
{
    [TestClass]
    public class GroupManagerTest
    {
        private GroupManager manager;

        [TestInitialize]
        public void Init()
        {
            manager = new GroupManager(new DAL.UnitOfWork());
        }

        [TestMethod]
        public void GetAllGroups()
        {
            var list = manager.GetGroups();

            Assert.IsNotNull(list, ".GetGroups returned null!");
        }

        [TestMethod]
        public void GetSingleGroup()
        {
            var id = manager.GetGroups().LastOrDefault().Id;
            var item = manager.GetGroupByID(id);

            Assert.IsNotNull(item, ".GetGroupByID returned null!");
            Assert.IsInstanceOfType(item, typeof(GroupDTO), "Group is not typeof GroupDTO!");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Group Id field is not int!");
            Assert.IsInstanceOfType(item.Name, typeof(string),
                    "Group Name field is not string!");
        }

        [TestMethod]
        public void GetSingleRawGroup()
        {
            var id = manager.GetGroups().LastOrDefault().Id;
            var item = manager.GetRawGroupByID(id);

            Assert.IsNotNull(item, ".GetGroupByID returned null!");
            Assert.IsInstanceOfType(item, typeof(Group), "Group is not typeof Group!");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Group Id field is not int!");
            Assert.IsInstanceOfType(item.Name, typeof(string),
                    "Group Name field is not string!");
        }

        [TestMethod]
        public void InsertGroup()
        {
            string name = "UnitTestGroup";
            var item = new Group
            {
                Name = name
            };

            int preCount = manager.GetGroups().Count();

            manager.InsertGroup(item);
            int postCount = manager.GetGroups().Count();

            Assert.IsNotNull(item, "Inserted group is null!");
            Assert.IsNotNull(item.Id, "Inserted group Id null");
            Assert.AreEqual(preCount + 1, postCount, "Number of deleted rows are not 1. Its " + (postCount - preCount));
            Assert.IsInstanceOfType(item.Id, typeof(int), "Inserted group Id is not int");
            Assert.AreEqual(name, item.Name, "Inserted group Name is not as expected");
        }

        [TestMethod]
        public void UpdateGroup()
        {
            var id = manager.GetGroups().LastOrDefault().Id;
            var item = manager.GetRawGroupByID(id);

            string name = "UnitTestGroupUpdate";
            item.Name = name;

            manager.UpdateGroup(item);

            Assert.IsNotNull(item, "Updated group is null!");
            Assert.IsNotNull(item.Id, "Updated group Id null");
            Assert.IsInstanceOfType(item.Id, typeof(int), "Updated group Id is not int");
            Assert.AreEqual(id, item.Id, "Updated group Id is not as expected");
            Assert.AreEqual(name, item.Name, "Updated group Name is not as expected");
        }

        [TestMethod]
        public void DeleteGroup()
        {
            int preCount = manager.GetGroups().Count();
            int id = manager.GetGroups().LastOrDefault().Id;

            manager.DeleteGroup(id);

            var item = manager.GetRawGroupByID(id);
            int postCount = manager.GetGroups().Count();

            Assert.IsNull(item, "Group was not deleted!");
            Assert.AreEqual(preCount - 1, postCount, "Number of deleted rows are not 1. Its " + (postCount-preCount));
        }

    }
}
