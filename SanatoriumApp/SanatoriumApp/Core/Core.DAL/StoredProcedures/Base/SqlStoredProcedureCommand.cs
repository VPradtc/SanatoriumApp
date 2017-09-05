using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Core.DAL.Connections;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedureCommand : SqlStoredProcedure<int>
    {
        public SqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        protected sealed override async Task<int> ExecuteInternalAsync(SqlCommand command)
        {
            var returnValue = new SqlParameter()
            {
                Direction = ParameterDirection.ReturnValue,
            };
            command.Parameters.Add(returnValue);

            var rowCount = await _commandInvoker.InvokeNonQueryCommandAsync(command);

            return (int)returnValue.Value;
        }
    }
}
