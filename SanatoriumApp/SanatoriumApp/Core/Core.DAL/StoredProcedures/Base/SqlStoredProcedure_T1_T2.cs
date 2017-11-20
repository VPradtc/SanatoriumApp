using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Core.DAL.Connections;
using Core.DAL.Execution;

namespace Core.DAL.StoredProcedures.Base
{
    public abstract class SqlStoredProcedure<TArgs, TResult> : SqlStoredProcedure
    {
        public SqlStoredProcedure(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        protected abstract Task<TResult> ExecuteInternalAsync(SqlCommand command);
        public abstract SqlParameter[] CreateSqlParameters(TArgs args);

        private void SanitizeParameters(SqlParameter[] parameters)
        {
            foreach (var sqlParam in parameters)
            {
                if (sqlParam.Value == null)
                {
                    sqlParam.Value = DBNull.Value;
                }
            }
        }

        public async Task<TResult> ExecuteAsync(TArgs args)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                try
                {
                    TResult result;

                    await connection.OpenAsync();
                    using (var command = CreateCommand(connection))
                    {
                        var sqlParams = CreateSqlParameters(args);
                        SanitizeParameters(sqlParams);

                        command.Parameters.AddRange(sqlParams);

                        result = await ExecuteInternalAsync(command);
                    }

                    return result;

                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error: {0} \r\n Stack Trace: {1}", e.Message, e.StackTrace);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
