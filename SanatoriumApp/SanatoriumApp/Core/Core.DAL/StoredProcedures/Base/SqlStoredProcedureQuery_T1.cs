using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Core.DAL.Connections;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedureQuery<TResult> : SqlStoredProcedure<ICollection<TResult>>
    {
        public SqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        protected abstract TResult Map(SqlDataReader reader);

        protected sealed override Task<ICollection<TResult>> ExecuteInternalAsync(SqlCommand command)
        {
            return _commandInvoker.InvokeReaderCommandAsync(command, this.Map);
        }
    }
}
