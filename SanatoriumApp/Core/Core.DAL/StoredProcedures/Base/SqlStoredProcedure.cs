using System;
using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Execution;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedure
    {
        protected readonly IConnectionFactory _connectionFactory;
        protected readonly IDbCommandInvoker _commandInvoker;

        public abstract string Name { get; }

        public SqlStoredProcedure(IConnectionFactory connectionFactory
            , IDbCommandInvoker commandInvoker)
        {
            _connectionFactory = connectionFactory;
            _commandInvoker = commandInvoker;
        }

        protected virtual SqlCommand CreateCommand(SqlConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = this.Name;

            return command;
        }
    }
}
