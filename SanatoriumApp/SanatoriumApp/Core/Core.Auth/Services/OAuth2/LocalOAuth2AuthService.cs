using System;
using System.Threading;
using Microsoft.AspNet.Identity;

namespace Core.Auth.Services.OAuth2
{
    public class LocalOAuth2AuthService : IAuthService
    {
        public int? GetUserId()
        {
            string userIdString = Thread.CurrentPrincipal.Identity.GetUserId();
            int userId;

            if (!int.TryParse(userIdString, out userId))
            {
                return null;
            }

            return userId;
        }
    }
}
