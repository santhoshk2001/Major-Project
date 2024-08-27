using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ECommerceAppDemo.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{catagoryName}",
            //    defaults: new { controller = "Home", action = "Index", catagoryName = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //name: "ProductDetails",
            //url: "Products/Details/{pid}",
            //defaults: new { controller = "Products", action = "Details" });
        }
    }
}
