using System.Collections.Generic;
using Core.Domain.Auth;
using Microsoft.Owin.Security;

namespace Core.Auth.Services.OAuth2.Tokens
{
    public class IdentityTokenPropertiesFormater : IIdentityTokenPropertiesFormater
    {
        public AuthenticationProperties CreateProperties(User user)
        {
            var properties = new Dictionary<string, string>
            {
                {
                    "firstName", user.FirstName
                },
                {
                    "lastName", user.LastName
                },
            };

            return new AuthenticationProperties(properties);
        }
    }
}
