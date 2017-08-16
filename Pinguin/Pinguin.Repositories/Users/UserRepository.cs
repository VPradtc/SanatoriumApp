using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Auth;
using Pinguin.DAL.Users;

namespace Pinguin.Repositories.Users
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
    }
}
