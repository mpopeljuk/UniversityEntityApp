using DBModels;
using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GroupManager : IGroupManager, IDisposable
    {
        private UniversityContext context;
        private bool disposed = false;

        public GroupManager(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<NameIdPairDTO> GetNameIdPair()
        {
            var list = context.Groups.Select(item => new NameIdPairDTO()
            {
                Id = item.Id,
                Name = item.Name
            });
            return list.ToList();
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            var list = context.Groups.Select(item => new GroupDTO() {
                Id = item.Id,
                Name = item.Name
                });
            return list.ToList();
        }

        public DBModels.Group GetGroupByID(int groupId)
        {
            return context.Groups.Find(groupId);
        }

        public void InsertGroup(DBModels.Group group)
        {
            context.Groups.Add(group);
        }

        public void DeleteGroup(int groupId)
        {
            Group group = context.Groups.Find(groupId);
            context.Groups.Remove(group);
        }

        public void UpdateGroup(DBModels.Group group)
        {
            context.Entry(group).State = EntityState.Modified;
        }

        public int Save()
        {
            return context.SaveChanges();
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
