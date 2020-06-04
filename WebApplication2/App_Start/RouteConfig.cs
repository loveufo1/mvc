using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(                 //若有多數 以上面為先
                name: "Default",                  //路由名稱   可隨意
                url: "{controller}/{action}/{id}",                      //路由規則   不建議亂動 手刻會出事
                defaults: new { controller = "login", action = "login", id = UrlParameter.Optional }           //預設值  起始controller 與view
            );
        }
    }
}
