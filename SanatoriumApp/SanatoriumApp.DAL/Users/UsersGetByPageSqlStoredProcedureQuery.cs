using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Auth.Roles;
using Core.Domain.Common;
using SanatoriumApp.Domain.Users;

namespace SanatoriumApp.DAL.Users
{
    public class UsersGetByPageSqlStoredProcedureQuery : SqlStoredProcedureQuery<KendoGridRequest, UserGetByPageModel>
    {
        public UsersGetByPageSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Users.GetByPage;

        public override SqlParameter[] CreateSqlParameters(KendoGridRequest args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Take", SqlDbType.Int) { Value = args.Take },
                new SqlParameter("@Skip", SqlDbType.Int) { Value = args.Skip },
            };
        }

        protected override UserGetByPageModel Map(SqlDataReader reader)
        {
            return new UserGetByPageModel
            {
                Id = reader.StructField<int>("Id"),
                FirstName = reader.Field<string>("FirstName"),
                LastName = reader.Field<string>("LastName"),
                Email = reader.Field<string>("Email"),
                RoleId = (RoleIdentifier)reader.StructField<int>("RoleId"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
