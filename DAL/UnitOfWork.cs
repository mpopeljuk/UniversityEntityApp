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

        private GenericRepository<Group> groupRepo;
        private GenericRepository<Subject> subjectRepo;
        private GenericRepository<Student> studentRepo;
        private GroupToSubjectRepository gtsRep;

        private GenericRepository<Role> roleRepo;
        private GenericRepository<User> userRepo;

        public UnitOfWork()
        {
            context = new UniversityContext();

            groupRepo = new GenericRepository<Group>(context);
            subjectRepo = new GenericRepository<Subject>(context);
            studentRepo = new GenericRepository<Student>(context);
            gtsRep = new GroupToSubjectRepository(context);

            roleRepo = new GenericRepository<Role>(context);
            userRepo = new GenericRepository<User>(context);
        }

        public GenericRepository<Group> GroupRep
        {
            get
            {
                if (groupRepo == null) groupRepo = new GenericRepository<Group>(context);
                return groupRepo;
            }
        }

        public GenericRepository<Subject> SubjectRep
        {
            get
            {
                if (subjectRepo == null) subjectRepo = new GenericRepository<Subject>(context);
                return subjectRepo;
            }
        }

        public GenericRepository<Student> StudentRep
        {
            get
            {
                if (studentRepo == null) studentRepo = new GenericRepository<Student>(context);
                return studentRepo;
            }
        }

        public GroupToSubjectRepository GroupToSubjectRep
        {
            get
            {
                return gtsRep;
            }
        }

        public GenericRepository<Role> RoleRepo
        {
            get
            {
                return roleRepo;
            }
        }

        public GenericRepository<User> UserRepo
        {
            get
            {
                return userRepo;
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
