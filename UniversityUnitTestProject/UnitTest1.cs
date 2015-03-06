using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Implements;
using DAL;
using BLL.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniversityUnitTestProject
{
    [TestClass]
    public class CrudGroupsTableTest
    {
        private UnitOfWork uOW;
        private GroupManager manager;

        [TestInitialize]
        public void CreateUOW()
        {
            uOW = new UnitOfWork();
            manager = new GroupManager(uOW);
        }

        [TestMethod]
        public void ReadAllStudentsTest()
        {
            var list = manager.GetGroups();
            var item = list.First();

            Assert.IsNotNull(list, "Groups list is null");
            Assert.IsInstanceOfType(item, typeof(GroupDTO), "Different object type returned");
        }
    }
}
