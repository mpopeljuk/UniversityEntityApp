using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBModels;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private UniversityContext context;

        private GroupManager groupRep;
        private SubjectManager subjectRep;
        private StudentManager studentRep;
        private GroupToSubjectManager gtsRep;

        public UnitOfWork()
        {
            context = new UniversityContext();
            groupRep = new GroupManager(context);
            subjectRep = new SubjectManager(context);
            studentRep = new StudentManager(context);
            gtsRep = new GroupToSubjectManager(context);
        }

        public GroupManager GroupRep
        {
            get
            {
                return groupRep;
            }
        }

        public SubjectManager SubjectRep
        {
            get
            {
                return subjectRep;
            }
        }

        public StudentManager StudentRep
        {
            get
            {
                return studentRep;
            }
        }

        public GroupToSubjectManager GtsRep
        {
            get
            {
                return gtsRep;
            }
        }

    }
}
