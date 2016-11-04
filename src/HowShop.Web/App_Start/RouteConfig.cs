using System.Web.Mvc;
using System.Web.Routing;

namespace HowShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // https://blogs.msdn.microsoft.com/webdev/2013/10/17/attribute-routing-in-asp-net-mvc-5/#route-prefixes
            // http://sampathloku.blogspot.ie/2013/11/attribute-routing-with-aspnet-mvc-5.html

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Default", 
                "{controller}/{action}/{id}", 
                new { controller = "AdminProduct", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
