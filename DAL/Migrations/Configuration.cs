namespace DAL.Migrations
{
    using DBModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.UniversityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Group.AddOrUpdate(
                new Group { Name = "541" },
                new Group { Name = "441" },
                new Group { Name = "341" }
                );

            context.Group.AddOrUpdate(
                new Group { Name = "Math" },
                new Group { Name = "History" },
                new Group { Name = "Physics" }
                );

            context.Student.AddOrUpdate(
                new Student { FirstName = "Jack", LastName = "Daniels", Age = 35, GroupId = 0 },
                new Student { FirstName = "Bryan", LastName = "Loves", Age = 23, GroupId = 0 },
                new Student { FirstName = "Steve", LastName = "John", Age = 31, GroupId = 0 },

                new Student { FirstName = "Jacke", LastName = "Faniels", Age = 35, GroupId = 1 },
                new Student { FirstName = "Briam", LastName = "Lotes", Age = 23, GroupId = 1 },
                new Student { FirstName = "Creve", LastName = "Jofen", Age = 31, GroupId = 1 },

                new Student { FirstName = "Jideck", LastName = "Dasels", Age = 35, GroupId = 2 },
                new Student { FirstName = "Bradan", LastName = "Loges", Age = 23, GroupId = 2 },
                new Student { FirstName = "Styte", LastName = "Johser", Age = 31, GroupId = 2 }
                );

            context.GroupToSubject.AddOrUpdate(
                new GroupToSubject {GroupId = 0, SubjectId = 0 },
                new GroupToSubject {GroupId = 0, SubjectId = 1 },

                new GroupToSubject {GroupId = 1, SubjectId = 1 },
                new GroupToSubject {GroupId = 1, SubjectId = 2 },

                new GroupToSubject {GroupId = 2, SubjectId = 1 },
                new GroupToSubject {GroupId = 2, SubjectId = 3 }
                );
        }
    }
}
