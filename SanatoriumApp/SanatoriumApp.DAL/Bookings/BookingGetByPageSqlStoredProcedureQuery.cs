using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings;

namespace SanatoriumApp.DAL.Bookings
{
    public class BookingsGetByPageSqlStoredProcedureQuery : SqlStoredProcedureQuery<KendoGridRequest, BookingGetByPageModel>
    {
        public BookingsGetByPageSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Bookings.GetByPage;

        public override SqlParameter[] CreateSqlParameters(KendoGridRequest args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Take", SqlDbType.Int) { Value = args.Take },
                new SqlParameter("@Skip", SqlDbType.Int) { Value = args.Skip },
            };
        }

        protected override BookingGetByPageModel Map(SqlDataReader reader)
        {
            return new BookingGetByPageModel
            {
                Id = reader.StructField<int>("Id"),
                StartDate = reader.UtcDateTimeField("StartDate").Value,
                EndDate = reader.UtcDateTimeField("EndDate").Value,

                ClientId = reader.StructField<int>("ClientId"),
                ClientName = reader.Field<string>("ClientName"),
                RoomId = reader.StructField<int>("RoomId"),
                RoomName = reader.Field<string>("RoomName"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
