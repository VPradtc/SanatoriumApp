using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Core.DAL.Connections;
using Core.DAL.Execution;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedureTwoWayCommand<TArgs, TResult> : SqlStoredProcedure<TArgs, TResult>
    {
        public SqlStoredProcedureTwoWayCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        protected abstract TResult MapResult(SqlParameterCollection parameters);

        protected override async Task<TResult> ExecuteInternalAsync(SqlCommand command)
        {
            var rowCount = await _commandInvoker.InvokeNonQueryCommandAsync(command);

            TResult result = MapResult(command.Parameters);

            return result;
        }
    }
}
