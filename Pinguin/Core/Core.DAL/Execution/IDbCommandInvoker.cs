using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL.Execution
{
    public interface IDbCommandInvoker
    {
        Task<ICollection<TResult>> InvokeReaderCommandAsync<TResult>(
            SqlCommand command,
            Func<SqlDataReader, TResult> dataMapper);

        Task<int> InvokeNonQueryCommandAsync(SqlCommand command);

        Task<TResult> InvokeScalarCommandAsync<TResult>(SqlCommand command);
    }
}
