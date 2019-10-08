using OdeToFood.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);
        }

        protected void Application_BeginRequest() {
            Debug.WriteLine("Begin Request");
        }

        protected void Application_MapRequestHandler() {
            Debug.WriteLine("Map Handler");
        }

        protected void Application_PostMapRequestHandler() {
            Debug.WriteLine("Post Map Handler");
        }

        protected void Application_PreRequestHandlerExecute() {
            Debug.WriteLine("Pre Handler Execute");
        }

        protected void Application_PostRequestHandlerExecute() {
            Debug.WriteLine("Post Handler Execute");
        }

        protected void Application_EndRequest() {
            Debug.WriteLine("End Request");
        }
    }
}
