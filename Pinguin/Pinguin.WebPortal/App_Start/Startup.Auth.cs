using System;
using Pinguin.IOC;
using Owin;
using Microsoft.Owin.Security.OAuth;

namespace Pinguin.WebPortal
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var options = NinjectHttpContainer.Resolve<OAuthAuthorizationServerOptions>();

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
