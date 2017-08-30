using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Core.DAL.Connections;
using Core.DAL.Execution;
using System.Collections.Generic;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedureTwoWayQuery<TArgs, TResult, TItem> : SqlStoredProcedure<TArgs, TResult>
    {
        public SqlStoredProcedureTwoWayQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        protected abstract TItem MapItem(SqlDataReader reader);
        protected abstract TResult MapResult(SqlParameterCollection parameters, ICollection<TItem> items);

        protected override async Task<TResult> ExecuteInternalAsync(SqlCommand command)
        {
            var items = await _commandInvoker.InvokeReaderCommandAsync(command, this.MapItem);

            TResult result = MapResult(command.Parameters, items);

            return result;
        }
    }
}
