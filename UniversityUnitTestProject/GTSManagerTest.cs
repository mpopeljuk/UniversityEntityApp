using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Implements;
using System.Linq;
using DBModels;

namespace UniversityUnitTestProject
{
    [TestClass]
    public class GTSManagerTest
    {
        private GroupToSubjectManager manager;
        private int gId, sId;


        [TestInitialize]
        public void Init()
        {
            throw new NotImplementedException();

            manager = new GroupToSubjectManager(new DAL.UnitOfWork());

            GroupManager groupManager = new GroupManager(new DAL.UnitOfWork());
            SubjectManager subjectpManager = new SubjectManager(new DAL.UnitOfWork());

            gId = groupManager.GetGroups().FirstOrDefault().Id;
            sId = subjectpManager.GetSubjects().FirstOrDefault().Id;

            try
            {
                var list = manager.GetSubjectsForGroup(gId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [TestMethod]
        public void InsertGTS()
        {
            GroupToSubject item = new GroupToSubject();
        }
    }
}
