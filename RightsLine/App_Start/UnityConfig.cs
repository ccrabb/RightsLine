using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using System.Web.Http;
using RightsLine.Data.Facades;
using Unity.WebApi;

namespace RightsLine {
    public static class UnityConfig {
        public static void RegisterComponents() {
            var container = new UnityContainer();

            if (ConfigurationManager.AppSettings["DataStore"] == "Mongo") {
                container.RegisterType<IUserFacade, UserFacade>(new TransientLifetimeManager());
            } else if (ConfigurationManager.AppSettings["DataStore"] == "Memory") {
                container.RegisterType<IUserFacade, UserFacadeMemory>(new TransientLifetimeManager());
            } else {
                throw new NotImplementedException("The selected DataStore has no implementation");
            }

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}