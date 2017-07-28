using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmartClinicAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ////Should match /api/My/1
            //config.Routes.MapHttpRoute(
            //    name: "DefaultDigitApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { action = "AddAdminUser" },
            //    constraints: new { id = @"^\d+$" } // id must be digits
            //);

            ////Should match /api/My/3ead6bea-4a0a-42ae-a009-853e2243cfa3
            //config.Routes.MapHttpRoute(
            //    name: "DefaultGuidApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { action = "GetByGUID" },
            //    constraints: new { id = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$" } // id must be guid
            //);

            ////Should match /api/My/everything else
            //config.Routes.MapHttpRoute(
            //    name: "DefaultStringApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { action = "GetByString" }
            //);
        }
    }
}
