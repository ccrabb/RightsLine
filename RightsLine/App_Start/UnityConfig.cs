using Microsoft.Practices.Unity;
using System.Web.Http;
using RightsLine.Data.Facades;
using Unity.WebApi;

namespace RightsLine {
    public static class UnityConfig {
        public static void RegisterComponents() {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IUserFacade, UserFacade>(new TransientLifetimeManager());
            //container.RegisterType<IUserFacade, UserFacadeMemory>(new TransientLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}