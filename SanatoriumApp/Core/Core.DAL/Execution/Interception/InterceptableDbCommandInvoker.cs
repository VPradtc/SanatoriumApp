using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL.Execution.Interception
{
    public class InterceptableDbCommandInvoker : IDbCommandInvoker
    {
        private readonly IDbCommandInterceptor _interceptor;
        private readonly DbCommandInvoker _invoker;

        public InterceptableDbCommandInvoker(DbCommandInvoker invoker
            , IDbCommandInterceptor interceptor)
        {
            _invoker = invoker;
            _interceptor = interceptor;
        }

        public Task<int> InvokeNonQueryCommandAsync(SqlCommand command)
        {
            _interceptor.Intercept(command);
            return _invoker.InvokeNonQueryCommandAsync(command);
        }

        public Task<ICollection<TResult>> InvokeReaderCommandAsync<TResult>(SqlCommand command, Func<SqlDataReader, TResult> dataMapper)
        {
            _interceptor.Intercept(command);
            return _invoker.InvokeReaderCommandAsync(command, dataMapper);
        }

        public Task<TResult> InvokeScalarCommandAsync<TResult>(SqlCommand command)
        {
            _interceptor.Intercept(command);
            return _invoker.InvokeScalarCommandAsync<TResult>(command);
        }
    }
}
