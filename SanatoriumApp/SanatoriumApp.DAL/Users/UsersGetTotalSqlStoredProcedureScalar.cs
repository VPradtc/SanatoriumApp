using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.Users
{
    public class UsersGetTotalSqlStoredProcedureScalar : SqlStoredProcedureScalar<int>
    {
        public UsersGetTotalSqlStoredProcedureScalar(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Users.GetTotal;
    }
}
