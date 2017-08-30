using System.Security.Claims;
using System.Threading.Tasks;
using Core.Auth.Services.OAuth2.Tokens;
using Core.Auth.Services.OAuth2.Users;
using Core.Auth.Services.OAuth2.Users.Security.Claims;
using Core.Domain.Auth;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Core.Auth.Services.OAuth2
{
    public class LocalOAuth2AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private const int _refreshTokenLifetimeMinutes = 2 * 24 * 60;

        private readonly IAuthUserManager _userManager;
        private readonly IIdentityTokenPropertiesFormater _tokenFormatter;

        public LocalOAuth2AuthorizationServerProvider(IAuthUserManager userManager
            , IIdentityTokenPropertiesFormater tokenFormatter)
        {
            _userManager = userManager;
            _tokenFormatter = tokenFormatter;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await _userManager.GetUserByCredentials(context.UserName, context.Password);
            bool isValid = user != null;

            if (!isValid)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            context.OwinContext.Set("as:clientRefreshTokenLifeTime", _refreshTokenLifetimeMinutes);

            var identity = CreateIdentity(context, user);

            var properties = _tokenFormatter.CreateProperties(user);
            var ticket = new AuthenticationTicket(identity, properties);

            context.Validated(ticket);

            return;
        }

        private ClaimsIdentity CreateIdentity(OAuthGrantResourceOwnerCredentialsContext context, User user)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType, ClaimsIdentity.DefaultNameClaimType, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String));

            return identity;
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            context.Validated();
            return Task.FromResult(default(object));
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult(default(object));
        }
    }
}
