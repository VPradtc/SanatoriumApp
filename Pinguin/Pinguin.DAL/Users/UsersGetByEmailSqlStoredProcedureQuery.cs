using System;
using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Auth;
using Core.Domain.Auth.Roles;

namespace Pinguin.DAL.Users
{
    public class UsersGetByEmailSqlStoredProcedureQuery : SqlStoredProcedureQuery<string, User>
    {
        public UsersGetByEmailSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Users.GetByEmail;

        public override SqlParameter[] CreateSqlParameters(string args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Email", SqlDbType.NVarChar, 256) { Value = args },
            };
        }

        protected override User Map(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.StructField<int>("Id"),
                FirstName = reader.Field<string>("FirstName"),
                LastName = reader.Field<string>("LastName"),
                Email = reader.Field<string>("Email"),
                RoleId = (RoleIdentifier)reader.StructField<int>("RoleId"),
                ApiPasswordHash = reader.Field<string>("ApiPasswordHash"),
                ApiPasswordSalt = reader.Field<string>("ApiPasswordSalt"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
