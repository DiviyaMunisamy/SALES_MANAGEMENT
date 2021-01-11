using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SALES_MANAGEMENT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Lead", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Default2",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Opportunity", action = "Create", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "Default3",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Qourte", action = "Create", id = UrlParameter.Optional }
         );

        }
    }
}
