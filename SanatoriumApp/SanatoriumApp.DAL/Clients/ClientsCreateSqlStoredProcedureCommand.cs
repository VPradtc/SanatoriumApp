using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Clients;

namespace SanatoriumApp.DAL.Clients
{
    public class ClientsCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<Client>
    {
        public ClientsCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Clients.Create;

        public override SqlParameter[] CreateSqlParameters(Client args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 128) { Value = args.FirstName },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 128) { Value = args.LastName },
                new SqlParameter("@Passport", SqlDbType.NVarChar, 128) { Value = args.Passport },
            };
        }
    }
}
