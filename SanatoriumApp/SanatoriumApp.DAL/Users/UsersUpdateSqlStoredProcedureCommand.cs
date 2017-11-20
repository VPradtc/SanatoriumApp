using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Users;

namespace SanatoriumApp.DAL.Users
{
    public class UsersUpdateSqlStoredProcedureCommand : SqlStoredProcedureCommand<UserEditModel>
    {
        public UsersUpdateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Users.Update;

        public override SqlParameter[] CreateSqlParameters(UserEditModel args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int ) { Value = args.Id },
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 256) { Value = args.FirstName },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 256) { Value = args.LastName },
                new SqlParameter("@RoleId", SqlDbType.Int ) { Value = args.RoleId },
            };
        }
    }
}
