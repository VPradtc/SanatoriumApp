using System;
using System.Web.Routing;

namespace SanatoriumApp.WebPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
        }
    }
}
