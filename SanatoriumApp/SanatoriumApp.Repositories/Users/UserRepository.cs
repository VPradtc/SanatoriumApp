using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Auth;
using Core.Domain.Common;
using SanatoriumApp.DAL.Users;
using SanatoriumApp.Domain.Users;

namespace SanatoriumApp.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersGetByEmailSqlStoredProcedureQuery _getByEmailCommand;
        private readonly UsersCreateSqlStoredProcedureCommand _createCommand;
        private readonly UsersGetByIdSqlStoredProcedureQuery _getByIdCommand;
        private readonly UsersGetByPageSqlStoredProcedureQuery _getByPageCommand;
        private readonly UsersDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly UsersUpdateSqlStoredProcedureCommand _updateCommand;
        private readonly UsersGetTotalSqlStoredProcedureScalar _getTotalCommand;
        private readonly UsersGetAllSqlStoredProcedureQuery _getAllCommand;

        public UserRepository(
            UsersGetByEmailSqlStoredProcedureQuery getByEmailCommand
            , UsersCreateSqlStoredProcedureCommand createCommand
            , UsersGetByIdSqlStoredProcedureQuery getByIdCommand
            , UsersGetByPageSqlStoredProcedureQuery getByPageCommand
            , UsersGetTotalSqlStoredProcedureScalar getTotalCommand
            , UsersDeleteSqlStoredProcedureCommand deleteCommand
            , UsersUpdateSqlStoredProcedureCommand updateCommand
            , UsersGetAllSqlStoredProcedureQuery getAllCommand
            )
        {
            _getByEmailCommand = getByEmailCommand;
            _createCommand = createCommand;
            _getByIdCommand = getByIdCommand;
            _getByPageCommand = getByPageCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _getTotalCommand = getTotalCommand;
            _getAllCommand = getAllCommand;
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

        public async Task<UserEditModel> GetById(int id)
        {
            var dbResult = await _getByIdCommand.ExecuteAsync(id);
            var dbUser = dbResult.FirstOrDefault();

            if (dbUser == null)
            {
                return null;
            }

            return new UserEditModel
            {
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                RoleId = dbUser.RoleId,
                Salary = dbUser.Salary,
            };
        }

        public async Task<KendoGridResponse<UserGetByPageModel>> GetByPage(KendoGridRequest request)
        {
            var users = await _getByPageCommand.ExecuteAsync(request);
            var total = await _getTotalCommand.ExecuteAsync();

            var result = new KendoGridResponse<UserGetByPageModel>
            {
                Data = users,
                Total = total,
            };

            return result;
        }

        public async Task Delete(int id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

        public async Task Update(UserEditModel request)
        {
            await _updateCommand.ExecuteAsync(request);
        }

        public async Task<ICollection<User>> GetAll()
        {
            var dbResult = await _getAllCommand.ExecuteAsync();
            return dbResult;
        }
    }
}
