using DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class GroupRepository : IGroupRepository, IDisposable
    {
        private UniversityContext context;
        private bool disposed = false;

        public GroupRepository(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<DBModels.Group> GetGroups()
        {
            return context.Group.ToList();
        }

        public DBModels.Group GetGroupByID(int groupId)
        {
            return context.Group.Find(groupId);
        }

        public void InsertGroup(DBModels.Group group)
        {
            context.Group.Add(group);
        }

        public void DeleteGroup(int groupID)
        {
            Group group = context.Group.Find(groupID);
            context.Group.Remove(group);
        }

        public void UpdateGroup(DBModels.Group group)
        {
            context.Entry(group).State = EntityState.Modified;
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
