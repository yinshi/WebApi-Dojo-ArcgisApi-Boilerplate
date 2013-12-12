using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiArcgisApiDemo.App_Start;

namespace WebApiArcgisApiDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Add these two lines to initialize Routes and Filters:
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            // Add unity bootstrapper initialise code
            Bootstrapper.Initialise();
            // Return JSON responses
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}