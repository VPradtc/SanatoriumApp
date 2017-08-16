using System;
using Core.Domain.Auth;
using Microsoft.Owin.Security;

namespace Core.Auth.Services.OAuth2.Tokens
{
    public interface IIdentityTokenPropertiesFormater
    {
        AuthenticationProperties CreateProperties(User user);
    }
}
