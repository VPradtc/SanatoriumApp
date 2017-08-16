using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Core.DAL.Connections;
using Core.DAL.Execution;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedureScalar<TArgs, TResult> : SqlStoredProcedure<TArgs, TResult>
    {
        public SqlStoredProcedureScalar(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        protected sealed override async Task<TResult> ExecuteInternalAsync(SqlCommand command)
        {
            var result = await _commandInvoker.InvokeScalarCommandAsync<TResult>(command);
            return result;
        }
    }
}
