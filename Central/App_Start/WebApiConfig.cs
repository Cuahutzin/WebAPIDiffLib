using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;

namespace Central
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap = { ["apiVersion"] = typeof(Microsoft.Web.Http.Routing.ApiVersionRouteConstraint) }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
