using System;
using System.Web.Helpers;
using Core.Auth.Services.OAuth2.Users.Security.Models;

namespace Core.Auth.Services.OAuth2.Users.Security
{
    public class CryptoApplicationPasswordHasher : IApplicationPasswordHasher
    {
        private string AddSalt(string password, string salt)
        {
            var saltedPassword = password + salt;
            return saltedPassword;
        }

        public PasswordHashingResult HashPassword(string password)
        {
            var salt = Crypto.GenerateSalt();

            return HashPassword(password, salt);
        }

        public PasswordHashingResult HashPassword(string password, string salt)
        {
            var saltedPassword = AddSalt(password, salt);
            var hashedPassword = Crypto.HashPassword(saltedPassword);

            var result = new PasswordHashingResult
            {
                HashedPassword = hashedPassword,
                Salt = salt,
            };

            return result;
        }

        public bool VerifyPassword(string hashedPassword, string password, string salt)
        {
            var saltedPassword = AddSalt(password, salt);
            return Crypto.VerifyHashedPassword(hashedPassword, saltedPassword);
        }
    }
}
