using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Central
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public readonly static string CentralStateKey = "CentralState";

        protected void Application_Start()
        {
            System.Web.HttpContext.Current.Cache[CentralStateKey] = new DiffLib.CentralServerState();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
