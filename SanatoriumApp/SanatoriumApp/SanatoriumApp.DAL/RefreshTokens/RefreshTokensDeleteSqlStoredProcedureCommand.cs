using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.RefreshTokens
{
    public class RefreshTokensDeleteSqlStoredProcedureCommand : SqlStoredProcedureCommand<int>
    {
        public RefreshTokensDeleteSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.RefreshTokens.Delete;

        public override SqlParameter[] CreateSqlParameters(int args)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int, 4) { Value = args },
            };

            return sqlParams;
        }
    }
}
