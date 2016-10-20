using System.Web.Mvc;
using System.Web.Routing;

namespace HowShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new { controller = "AdminProduct", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapMvcAttributeRoutes();
        }
    }
}
