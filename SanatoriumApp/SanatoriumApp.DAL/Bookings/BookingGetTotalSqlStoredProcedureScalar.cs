using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;

namespace SanatoriumApp.DAL.Bookings
{
    public class BookingsGetTotalSqlStoredProcedureScalar : SqlStoredProcedureScalar<int>
    {
        public BookingsGetTotalSqlStoredProcedureScalar(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Bookings.GetTotal;
    }
}
