using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Common;
using SanatoriumApp.Domain.Clients;

namespace SanatoriumApp.DAL.Clients
{
    public class ClientsGetByPageSqlStoredProcedureQuery : SqlStoredProcedureQuery<KendoGridRequest, Client>
    {
        public ClientsGetByPageSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Clients.GetByPage;

        public override SqlParameter[] CreateSqlParameters(KendoGridRequest args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Take", SqlDbType.Int) { Value = args.Take },
                new SqlParameter("@Skip", SqlDbType.Int) { Value = args.Skip },
            };
        }

        protected override Client Map(SqlDataReader reader)
        {
            return new Client
            {
                Id = reader.StructField<int>("Id"),
                FirstName = reader.Field<string>("FirstName"),
                LastName = reader.Field<string>("LastName"),
                Passport = reader.Field<string>("Passport"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
