using System;

namespace Core.Auth.Services.OAuth2.Users.Security.Models
{
    public class PasswordHashingResult
    {
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
