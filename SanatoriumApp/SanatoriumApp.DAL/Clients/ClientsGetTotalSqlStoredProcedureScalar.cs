using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.Clients
{
    public class ClientsGetTotalSqlStoredProcedureScalar : SqlStoredProcedureScalar<int>
    {
        public ClientsGetTotalSqlStoredProcedureScalar(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Clients.GetTotal;
    }
}
