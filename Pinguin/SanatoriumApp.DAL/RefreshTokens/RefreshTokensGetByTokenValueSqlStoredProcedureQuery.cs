using System;
using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Auth;

namespace SanatoriumApp.DAL.RefreshTokens
{
    public class RefreshTokensGetByTokenValueSqlStoredProcedureQuery : SqlStoredProcedureQuery<Guid, RefreshToken>
    {
        public RefreshTokensGetByTokenValueSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.RefreshTokens.GetByTokenValue;

        public override SqlParameter[] CreateSqlParameters(Guid args)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter("@TokenValue", SqlDbType.UniqueIdentifier, 8) { Value = args },
            };

            return sqlParams;
        }

        protected override RefreshToken Map(SqlDataReader reader)
        {
            return new RefreshToken
            {
                Id = reader.StructField<int>("Id"),
                Subject = reader.Field<string>("Subject"),
                TokenValue = reader.StructField<Guid>("TokenValue"),
                IssuedUtc = reader.StructField<DateTime>("IssuedUtc"),
                ExpiresUtc = reader.StructField<DateTime>("ExpiresUtc"),
                ProtectedTicket = reader.Field<string>("ProtectedTicket"),
            };
        }
    }
}
