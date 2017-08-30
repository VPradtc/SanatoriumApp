using System.Data.SqlClient;

namespace Core.DAL.Execution.Interception
{
    public interface IDbCommandInterceptor
    {
        void Intercept(SqlCommand command);
    }
}