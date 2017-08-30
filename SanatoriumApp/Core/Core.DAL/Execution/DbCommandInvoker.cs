using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL.Execution
{
    public class DbCommandInvoker : IDbCommandInvoker
    {
        public async Task<ICollection<TResult>> InvokeReaderCommandAsync<TResult>(
            SqlCommand command,
            Func<SqlDataReader, TResult> dataMapper)
        {
            var reader = await command.ExecuteReaderAsync();

            List<TResult> items = new List<TResult>();

            using (reader)
            {
                while (reader.Read())
                {
                    var item = dataMapper.Invoke(reader);
                    items.Add(item);
                }
                return items;
            }
        }

        public Task<int> InvokeNonQueryCommandAsync(SqlCommand command)
        {
            return command.ExecuteNonQueryAsync();
        }

        public async Task<TResult> InvokeScalarCommandAsync<TResult>(SqlCommand command)
        {
            var boxedResult = await command.ExecuteScalarAsync();
            return (TResult)boxedResult;
        }
    }
}
