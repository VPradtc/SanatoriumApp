using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Bookings;

namespace SanatoriumApp.DAL.Bookings
{
    public class BookingsGetByOverlappingDateRangeSqlStoredProcedureQuery : SqlStoredProcedureQuery<Booking, Booking>
    {
        public BookingsGetByOverlappingDateRangeSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Bookings.GetByOverlappingDateRange;

        public override SqlParameter[] CreateSqlParameters(Booking args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@StartDate", SqlDbType.DateTime2) { Value = args.StartDate },
                new SqlParameter("@EndDate", SqlDbType.DateTime2) { Value = args.EndDate },
                new SqlParameter("@RoomId", SqlDbType.Int) { Value = args.RoomId },
            };
        }

        protected override Booking Map(SqlDataReader reader)
        {
            return new Booking
            {
                Id = reader.StructField<int>("Id"),
                StartDate = reader.UtcDateTimeField("StartDate").Value,
                EndDate = reader.UtcDateTimeField("EndDate").Value,
                RoomId = reader.StructField<int>("RoomId"),
                ClientId = reader.StructField<int>("ClientId"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
