using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace Core.Auth.Services.OAuth2.Configuration
{
    public class LocalOAuth2AuthorizationServerOptions : OAuthAuthorizationServerOptions
    {
        public LocalOAuth2AuthorizationServerOptions(LocalOAuth2AuthorizationServerProvider authProvider
            , RefreshTokenProvider refreshTokenProvider)
        {
            AllowInsecureHttp = true;
            TokenEndpointPath = new PathString("/token");
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1);
            Provider = authProvider;
            RefreshTokenProvider = refreshTokenProvider;
        }
    }
}
