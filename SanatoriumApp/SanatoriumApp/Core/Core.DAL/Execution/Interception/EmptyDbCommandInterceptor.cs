using System;
using System.Data;
using System.Data.SqlClient;

namespace Core.DAL.Execution.Interception
{
    public class EmptyDbCommandInterceptor : IDbCommandInterceptor
    {
        public void Intercept(SqlCommand command)
        {
            var userIdParameter = new SqlParameter("@_currentUserId", SqlDbType.Int);
            userIdParameter.Value = DBNull.Value;

            command.Parameters.Add(userIdParameter);
        }
    }
}
