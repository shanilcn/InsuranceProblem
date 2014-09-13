using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InsuranceProblem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Insurance Problem SPA",
                url: "InsuranceProblem/{*x}",
                defaults: new { controller = "InsuranceProblem", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "InsuranceProblem", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
