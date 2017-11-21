using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Auth.Services.OAuth2.Users.Security;
using Core.Domain.Common;
using SanatoriumApp.Domain.Users;
using SanatoriumApp.Repositories.Users;
using SanatoriumApp.Viewmodels.Common;
using SanatoriumApp.Viewmodels.Users;

namespace SanatoriumApp.Services.Auth.Users
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

        public async Task<bool> Exists(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return user != null;
        }

        public async Task Update(UserEditModel request)
        {
            await _userRepository.Update(request);
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<KendoGridResponse<UserGetByPageModel>> GetByPage(KendoGridRequest request)
        {
            var result = await _userRepository.GetByPage(request);
            return result;
        }

        public async Task<UserEditModel> GetById(int id)
        {
            var result = await _userRepository.GetById(id);
            return result;
        }

        public async Task<ICollection<DropdownModel>> GetAll()
        {
            var items = await _userRepository.GetAll();

            var result = items.Select(i => new DropdownModel
            {
                Identifier = i.Id,
                Name = i.LastName + ' ' + i.FirstName,
            }).ToList();

            return result;
        }
    }
}
