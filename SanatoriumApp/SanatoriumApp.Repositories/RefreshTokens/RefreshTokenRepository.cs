using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Auth.Services.OAuth2.Repositories;
using Core.Domain.Auth;
using SanatoriumApp.DAL.RefreshTokens;

namespace SanatoriumApp.Repositories.Users
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly RefreshTokensCreateSqlStoredProcedureCommand _createCommand;
        private readonly RefreshTokensDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly RefreshTokensGetByTokenValueSqlStoredProcedureQuery _getByTokenValueCommand;

        public RefreshTokenRepository(
            RefreshTokensCreateSqlStoredProcedureCommand createCommand
            , RefreshTokensGetByTokenValueSqlStoredProcedureQuery getByIdCommand
            , RefreshTokensDeleteSqlStoredProcedureCommand deleteCommand
            )
        {
            _createCommand = createCommand;
            _getByTokenValueCommand = getByIdCommand;
            _deleteCommand = deleteCommand;
        }

        public Task<int> CreateAsync(RefreshToken entity)
        {
            return _createCommand.ExecuteAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exitCode = await _deleteCommand.ExecuteAsync(id);
            return exitCode == 0;
        }

        public async Task<RefreshToken> GetByValueAsync(Guid tokenId)
        {
            var queryResult = await _getByTokenValueCommand.ExecuteAsync(tokenId);
            return queryResult.FirstOrDefault();
        }
    }
}
