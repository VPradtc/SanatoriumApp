using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;

namespace Pinguin.WebPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureCors(config);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ConventionBasedWebApi",
                routeTemplate: "api/{controller}/{action}"
            );
        }

        private static void ConfigureCors(HttpConfiguration config)
        {
            var allowedOrigins = ConfigurationManager.AppSettings["webapi:AllowedOrigins"];
            var cors = new EnableCorsAttribute(allowedOrigins, "*", "*");

            config.EnableCors(cors);
        }
    }
}
