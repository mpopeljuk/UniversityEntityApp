namespace DAL.Migrations
{
    using DBModels;
    using System;
    using System.Collections.Generic;
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

            List<Group> groups = new List<Group>();
            groups.Add(new Group { Name = "541" });
            groups.Add(new Group { Name = "441" });
            groups.Add(new Group { Name = "341" });

            List<Subject> subjects = new List<Subject>();
            subjects.Add(new Subject { Name = "Math"  });
            subjects.Add(new Subject { Name = "History" });
            subjects.Add(new Subject { Name = "Physics" });

            context.Groups.AddOrUpdate( groups.ToArray() );
            context.Subjects.AddOrUpdate( subjects.ToArray() );

            context.Students.AddOrUpdate(
                new Student { FirstName = "Jack", LastName = "Daniels", Age = 35, Group = groups[0] },
                new Student { FirstName = "Bryan", LastName = "Loves", Age = 23, Group = groups[0] },
                new Student { FirstName = "Steve", LastName = "John", Age = 31, Group = groups[0] },

                new Student { FirstName = "Jacke", LastName = "Faniels", Age = 35, Group = groups[1] },
                new Student { FirstName = "Briam", LastName = "Lotes", Age = 23, Group = groups[1] },
                new Student { FirstName = "Creve", LastName = "Jofen", Age = 31, Group = groups[1] },

                new Student { FirstName = "Jideck", LastName = "Dasels", Age = 35, Group = groups[2] },
                new Student { FirstName = "Bradan", LastName = "Loges", Age = 23, Group = groups[2] },
                new Student { FirstName = "Styte", LastName = "Johser", Age = 31, Group = groups[2] }
                );

            context.GroupToSubjects.AddOrUpdate(
                new GroupToSubject { Group = groups[0], Subject = subjects[0] },
                new GroupToSubject { Group = groups[0], Subject = subjects[1] },

                new GroupToSubject { Group = groups[1], Subject = subjects[1] },
                new GroupToSubject { Group = groups[1], Subject = subjects[2] },

                new GroupToSubject { Group = groups[2], Subject = subjects[2] },
                new GroupToSubject { Group = groups[2], Subject = subjects[0] }
                );

            List<Role> roles = new List<Role>();
            roles.Add(new Role { Name = "Administrator", Description = "Godlike" });
            roles.Add(new Role { Name = "Teacher", Description = "Moderator-like" });

            context.Roles.AddOrUpdate( roles.ToArray() );

            context.Users.AddOrUpdate(
                new User { Login = "admin", Password = "admin", Email = "admin@example.com", Roles = roles[0] },
                new User { Login = "teacher", Password = "teacher", Email = "teacher@example.com", Roles = roles[1] },
                new User { Login = "rektor", Password = "rektor", Email = "rektor@example.com", Roles = roles[1] }
                );
        }
    }
}
