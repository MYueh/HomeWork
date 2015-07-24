using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HWork1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            /* Routing 自訂參數
             *     http://localhost/Products.Edit.2
             *     http://localhost/Docs/Proudcts-Edit/2
            */
            routes.MapRoute(
                name: "Custom1",
                url: "{controller}.{action}.{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = "客戶聯絡人" , id = @"\d+" }
            );
            routes.MapRoute(
                name: "Custom2",
                url: "docs/{controller}-{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = @"客戶.*" }
            );
            routes.MapRoute(
                name: "Default",
                //url: "{controller}/{action}/{id}",
                url: "{controller}/{action}/{id}/{*.any}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
