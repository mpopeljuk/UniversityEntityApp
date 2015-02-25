using DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("University") 
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public UniversityContext(string connString) : base(connString)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<GroupToSubject> GroupToSubjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
