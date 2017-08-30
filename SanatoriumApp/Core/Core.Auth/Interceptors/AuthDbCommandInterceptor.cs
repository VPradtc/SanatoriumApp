using System;
using System.Data;
using System.Data.SqlClient;
using Core.Auth.Services;
using Core.DAL.Execution.Interception;

namespace Core.Auth.Interceptors
{
    public class AuthDbCommandInterceptor : IDbCommandInterceptor
    {
        private readonly IAuthService _authService;

        public AuthDbCommandInterceptor(IAuthService authService)
        {
            _authService = authService;
        }

        public void Intercept(SqlCommand command)
        {
            var userId = _authService.GetUserId();

            var userIdParameter = new SqlParameter("@_currentUserId", SqlDbType.Int);
            userIdParameter.Value = userId ?? (object)DBNull.Value;

            command.Parameters.Add(userIdParameter);
        }
    }
}
