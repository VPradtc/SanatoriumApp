using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Auth;

namespace SanatoriumApp.DAL.RefreshTokens
{
    public class RefreshTokensCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<RefreshToken>
    {
        public RefreshTokensCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.RefreshTokens.Create;

        public override SqlParameter[] CreateSqlParameters(RefreshToken args)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Subject", SqlDbType.NVarChar, 256) { Value = args.Subject },
                new SqlParameter("@TokenValue", SqlDbType.UniqueIdentifier, 16) { Value = args.TokenValue },
                new SqlParameter("@IssuedUtc", SqlDbType.DateTime2, 8) { Value = args.IssuedUtc },
                new SqlParameter("@ExpiresUtc", SqlDbType.DateTime2, 8) { Value = args.ExpiresUtc },
                new SqlParameter("@ProtectedTicket", SqlDbType.NVarChar, 2048) { Value = args.ProtectedTicket },
            };

            return sqlParams;
        }
    }
}
