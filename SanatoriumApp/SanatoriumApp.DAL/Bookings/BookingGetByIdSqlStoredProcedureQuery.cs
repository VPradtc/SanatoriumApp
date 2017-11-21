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
    public class BookingsGetByIdSqlStoredProcedureQuery : SqlStoredProcedureQuery<int, Booking>
    {
        public BookingsGetByIdSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Bookings.GetById;

        public override SqlParameter[] CreateSqlParameters(int args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = args },
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
