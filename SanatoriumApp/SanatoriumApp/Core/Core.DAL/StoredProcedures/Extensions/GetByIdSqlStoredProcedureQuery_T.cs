using System;
using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace Core.DAL.StoredProcedures.Extensions
{
    public abstract class GetByIdSqlStoredProcedureQuery<TEntity> : SqlStoredProcedureQuery<int, TEntity>
    {
        public GetByIdSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

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
