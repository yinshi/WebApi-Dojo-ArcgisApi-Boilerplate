using System.Web.Http;

namespace WebApiArcgisApiDemo.App_Start
{
    public static class WebApiConfig
    {
        public const string DEFAULT_ROUTE_NAME = "MyDefaultRoute";
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: DEFAULT_ROUTE_NAME,
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableSystemDiagnosticsTracing();
        }
    }
}