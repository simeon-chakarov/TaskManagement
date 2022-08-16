using System.Web.Http;
using System.Web.Mvc;
using TaskManagement.Models.Application;
using Unity;
using Unity.Mvc5;

namespace TaskManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IApplicationDbContext, ApplicationDbContext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}