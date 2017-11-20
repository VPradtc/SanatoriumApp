using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Auth;
using Core.Domain.Auth.Roles;

namespace SanatoriumApp.DAL.Users
{
    public class UsersGetByIdSqlStoredProcedureQuery : SqlStoredProcedureQuery<int, User>
    {
        public UsersGetByIdSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Users.GetById;

        public override SqlParameter[] CreateSqlParameters(int args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = args },
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
                Salary = reader.StructField<decimal>("Salary"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
