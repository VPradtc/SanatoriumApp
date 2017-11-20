using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Auth;

namespace SanatoriumApp.DAL.Users
{
    public class UsersCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<User>
    {
        public UsersCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Users.Create;

        public override SqlParameter[] CreateSqlParameters(User args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ApiPasswordHash", SqlDbType.NVarChar, 1024) { Value = args.ApiPasswordHash },
                new SqlParameter("@ApiPasswordSalt", SqlDbType.NVarChar, 128) { Value = args.ApiPasswordSalt },
                new SqlParameter("@Email", SqlDbType.NVarChar, 512) { Value = args.Email },
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 256) { Value = args.FirstName },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 256) { Value = args.LastName },
                new SqlParameter("@RoleId", SqlDbType.Int ) { Value = args.RoleId },
                new SqlParameter("@Salary", SqlDbType.Decimal ) { Value = args.Salary },
            };
        }
    }
}
