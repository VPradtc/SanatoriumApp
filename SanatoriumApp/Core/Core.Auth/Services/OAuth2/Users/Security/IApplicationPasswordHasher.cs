using System;
using Core.Auth.Services.OAuth2.Users.Security.Models;

namespace Core.Auth.Services.OAuth2.Users.Security
{
    public interface IApplicationPasswordHasher
    {
        PasswordHashingResult HashPassword(string password);
        PasswordHashingResult HashPassword(string password, string salt);
        bool VerifyPassword(string hashedPassword, string password, string salt);
    }
}
