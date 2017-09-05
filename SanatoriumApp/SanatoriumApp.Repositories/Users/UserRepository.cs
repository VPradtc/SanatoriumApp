using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Auth;
using Core.Domain.Common;
using SanatoriumApp.DAL.Users;
using SanatoriumApp.Domain.Users;
using SanatoriumApp.Viewmodels.Users;

namespace SanatoriumApp.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersGetByEmailSqlStoredProcedureQuery _getByEmailCommand;
        private readonly UsersCreateSqlStoredProcedureQuery _createCommand;

        public UserRepository(
            UsersGetByEmailSqlStoredProcedureQuery getByEmailCommand
            , UsersCreateSqlStoredProcedureQuery createCommand
            )
        {
            _getByEmailCommand = getByEmailCommand;
            _createCommand = createCommand;
        }

        public Task Create(User user)
        {
            return _createCommand.ExecuteAsync(user);
        }

        public async Task<User> GetByEmail(string email)
        {
            var result = await _getByEmailCommand.ExecuteAsync(email);
            return result.FirstOrDefault();
        }


        public Task<UserEditModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<KendoGridResponse<UserGetByPageModel>> GetByPage(KendoGridRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserEditModel request)
        {
            throw new NotImplementedException();
        }
    }
}
