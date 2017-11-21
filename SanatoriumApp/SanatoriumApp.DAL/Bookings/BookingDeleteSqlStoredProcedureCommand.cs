using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.Bookings
{
    public class BookingsDeleteSqlStoredProcedureCommand : SqlStoredProcedureCommand<int>
    {
        public BookingsDeleteSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Bookings.Delete;

        public override SqlParameter[] CreateSqlParameters(int args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = args },
            };
        }
    }
}
