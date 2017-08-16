using System;
using System.Threading.Tasks;
using Core.Auth.Services.OAuth2.Users.Security;
using Pinguin.Repositories.Users;
using Pinguin.Viewmodels.Users;

namespace Pinguin.Services.Auth.Users
{
    public class UserService : IUserService
    {
        private readonly UserCreateModelMapper _createModelMapper;
        private readonly IUserRepository _userRepository;
        private readonly IApplicationPasswordHasher _passwordHasher;

        public UserService(
            IUserRepository userRepository
            , UserCreateModelMapper createModelMapper
            , IApplicationPasswordHasher passwordHasher
            )
        {
            _userRepository = userRepository;
            _createModelMapper = createModelMapper;
            _passwordHasher = passwordHasher;
        }

        public async Task Create(UserCreateModel model)
        {
            var user = _createModelMapper.ToEntity(model);

            var hasherOutput = _passwordHasher.HashPassword(model.Password);

            user.ApiPasswordHash = hasherOutput.HashedPassword;
            user.ApiPasswordSalt = hasherOutput.Salt;

            await _userRepository.Create(user);
        }
    }
}
