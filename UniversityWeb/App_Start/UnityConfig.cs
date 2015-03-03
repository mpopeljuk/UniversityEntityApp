using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using DAL;
using BLL.Interfaces;
using BLL.Implements;
using System;
using System.Web;

namespace UniversityWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<UnitOfWork>(new PerHttpRequestLifetime());
            container.RegisterType<IStudentManager, StudentManager>();
            container.RegisterType<IGroupManager, GroupManager>();
            container.RegisterType<ISubjectManager, SubjectManager>();
            container.RegisterType<IGroupToSubjectManager, GroupToSubjectManager>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public class PerHttpRequestLifetime : LifetimeManager
        {
            // This is very important part and the reason why I believe mentioned
            // PerCallContext implementation is wrong.
            private readonly Guid _key = Guid.NewGuid();

            public override object GetValue()
            {
                return HttpContext.Current.Items[_key];
            }

            public override void SetValue(object newValue)
            {
                HttpContext.Current.Items[_key] = newValue;
            }

            public override void RemoveValue()
            {
                var obj = GetValue();
                HttpContext.Current.Items.Remove(obj);
            }
        }
    }
}