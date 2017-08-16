using System;
using System.Web.Routing;

namespace Pinguin.WebPortal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
        }
    }
}
