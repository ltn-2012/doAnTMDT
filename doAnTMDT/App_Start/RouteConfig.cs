using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace doAnTMDT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Phone", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Add Cart",
               url: "them vao gio hang",
               defaults: new { controller = "ShoppingCart", action = "AddtoCart", id = UrlParameter.Optional }
           );
        }
    }
}
