using System.Web.Http;
using Microsoft.Practices.Unity;
using WebApiArcgisApiDemo.Models;
using WebApiArcgisApiDemo.Models.DB1;


namespace WebApiArcgisApiDemo
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // The default concrete implementation of IDAO is DB1DAO and 
            // it is created as a singleton object
            container.RegisterType<IDAO, DB1DAO>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}