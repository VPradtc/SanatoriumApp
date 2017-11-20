using System;
using System.Threading.Tasks;
using Core.Auth.Services.OAuth2.Users;
using Core.Auth.Services.OAuth2.Users.Security;
using Core.Domain.Auth;
using SanatoriumApp.Repositories.Users;

namespace SanatoriumApp.WebPortal.Auth
{
    public class SanatoriumAppAuthUserManager : IAuthUserManager
    {
        private readonly IApplicationPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public SanatoriumAppAuthUserManager(
            IApplicationPasswordHasher passwordHasher
            , IUserRepository userRepository
            )
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByCredentials(string userName, string password)
        {
            var user = await _userRepository.GetByEmail(userName);
            if (user == null)
            {
                return null;
            }

            var isValidPassword = _passwordHasher.VerifyPassword(user.ApiPasswordHash, password, user.ApiPasswordSalt);

            if (!isValidPassword)
            {
                return null;
            }

            return user;
        }
    }
}
