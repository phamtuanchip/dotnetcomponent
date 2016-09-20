using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MVC01
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^[0-9]+$" }

            );
            config.Routes.MapHttpRoute(
            name: "ApiByName",
            routeTemplate: "api/{controller}/{action}/{name}",
            defaults: null,
            constraints: new { name = @"^[a-z]+$" }
        );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Get" }
            );

        }
    }
}
