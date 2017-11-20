using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using Core.Domain.Common;
using SanatoriumApp.Domain.Rooms;

namespace SanatoriumApp.DAL.Rooms
{
    public class RoomsGetByPageSqlStoredProcedureQuery : SqlStoredProcedureQuery<KendoGridRequest, Room>
    {
        public RoomsGetByPageSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Rooms.GetByPage;

        public override SqlParameter[] CreateSqlParameters(KendoGridRequest args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Take", SqlDbType.Int) { Value = args.Take },
                new SqlParameter("@Skip", SqlDbType.Int) { Value = args.Skip },
            };
        }

        protected override Room Map(SqlDataReader reader)
        {
            return new Room
            {
                Id = reader.StructField<int>("Id"),
                Name = reader.Field<string>("Name"),
                Capacity = reader.StructField<int>("Capacity"),
                RoomTypeId = (RoomType)reader.StructField<int>("RoomTypeId"),

                CreatedBy = reader.StructField<int>("CreatedBy"),
                ModifiedBy = reader.StructField<int>("CreatedBy"),
                CreatedDate = reader.UtcDateTimeField("CreatedDate").Value,
                ModifiedDate = reader.UtcDateTimeField("ModifiedDate").Value,
            };
        }
    }
}
