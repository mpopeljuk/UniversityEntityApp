using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBModels;
using DAL.Repo;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private UniversityContext context;

        private GenericRepository<Group> groupRep;
        private GenericRepository<Subject> subjectRep;
        private GenericRepository<Student> studentRep;
        private GenericRepository<GroupToSubject> gtsRep;


        public UnitOfWork()
        {
            context = new UniversityContext();

            groupRep = new GenericRepository<Group>(context);
            subjectRep = new GenericRepository<Subject>(context);
            studentRep = new GenericRepository<Student>(context);
            gtsRep = new GenericRepository<GroupToSubject>(context);
        }

        public GenericRepository<Group> GroupRep
        {
            get
            {
                return groupRep;
            }
        }

        public GenericRepository<Subject> SubjectRep
        {
            get
            {
                return subjectRep;
            }
        }

        public GenericRepository<Student> StudentRep
        {
            get
            {
                return studentRep;
            }
        }

        public GenericRepository<GroupToSubject> GtsRep
        {
            get
            {
                return gtsRep;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

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
