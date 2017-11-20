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
                    "id", user.Id.ToString()
                },
                {
                    "firstName", user.FirstName
                },
                {
                    "lastName", user.LastName
                },
                {
                    "role", ((int)user.RoleId).ToString()
                },
            };

            return new AuthenticationProperties(properties);
        }
    }
}
