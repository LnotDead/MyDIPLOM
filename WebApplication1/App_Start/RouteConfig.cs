using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{*id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );


            //routes.MapRoute(
            //    "StartRoute",
            //    "Views/Shared/_Layout.cshtml"
            //);

            routes.MapRoute(
                "Trenajery",
                "{controller}/{action}/{part1}/{part2}",
                new { controller = "Тренажёры", action = "Index", part1 = UrlParameter.Optional, part2 = UrlParameter.Optional }
            );
        }
    }
}
