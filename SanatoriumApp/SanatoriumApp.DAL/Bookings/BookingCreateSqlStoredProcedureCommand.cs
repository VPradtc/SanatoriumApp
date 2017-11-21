using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Bookings;

namespace SanatoriumApp.DAL.Bookings
{
    public class BookingsCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<Booking>
    {
        public BookingsCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Bookings.Create;

        public override SqlParameter[] CreateSqlParameters(Booking args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@ClientId", SqlDbType.Int) { Value = args.ClientId },
                new SqlParameter("@EndDate", SqlDbType.DateTime2) { Value = args.EndDate },
                new SqlParameter("@StartDate", SqlDbType.DateTime2) { Value = args.StartDate },
                new SqlParameter("@RoomId", SqlDbType.Int) { Value = args.RoomId },
            };
        }
    }
}
