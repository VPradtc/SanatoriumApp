using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.Extensions;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Rooms;

namespace SanatoriumApp.DAL.Rooms
{
    public class RoomsGetByIdSqlStoredProcedureQuery : SqlStoredProcedureQuery<int, Room>
    {
        public RoomsGetByIdSqlStoredProcedureQuery(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Rooms.GetById;

        public override SqlParameter[] CreateSqlParameters(int args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = args },
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
