﻿using DBModels;
using DBModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GroupToSubjectManager : IGroupToSubjectManager, IDisposable
    {
        private UniversityContext context;
        private bool disposed = false;

        public GroupToSubjectManager(UniversityContext _context)
        {
            context = _context;
        }

        public IEnumerable<GroupToSubjectDTO> GetSubjectsForGroup(int groupId)
        {
            var list = context.GroupToSubjects.Where(g => g.GroupId == groupId).Select(item => new GroupToSubjectDTO()
            {
                Id = item.SubjectId,
                Name = item.Subject.Name
            });
            return list.ToList();
        }

        public IEnumerable<GroupToSubjectDTO> GetGroupsForSubject(int subjectId)
        {
            var list = context.GroupToSubjects.Where(g => g.SubjectId == subjectId).Select(item => new GroupToSubjectDTO()
            {
                Id = item.GroupId,
                Name = item.Group.Name
            });
            return list.ToList();
        }

        public void InsertGroupToSubject(DBModels.GroupToSubject gts)
        {
            context.GroupToSubjects.Add(gts);
        }

        public void DeleteGroupToSubject(int groupId, int subjectId)
        {
            var query = from row in context.GroupToSubjects
                        where row.GroupId == groupId && row.SubjectId == subjectId
                        select row;
            context.GroupToSubjects.Remove( query.FirstOrDefault() );
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
