using System.Data;
using System.Data.SqlClient;
using Core.DAL.Connections;
using Core.DAL.Dictionary;
using Core.DAL.Execution;
using Core.DAL.StoredProcedures.Base;
using SanatoriumApp.Domain.Rooms;

namespace SanatoriumApp.DAL.Rooms
{
    public class RoomsCreateSqlStoredProcedureCommand : SqlStoredProcedureCommand<Room>
    {
        public RoomsCreateSqlStoredProcedureCommand(IConnectionFactory connectionFactory, IDbCommandInvoker commandInvoker) : base(connectionFactory, commandInvoker)
        {
        }

        public override string Name => DbDictionary.SP.Rooms.Create;

        public override SqlParameter[] CreateSqlParameters(Room args)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Capacity", SqlDbType.Int) { Value = args.Capacity },
                new SqlParameter("@Name", SqlDbType.NVarChar, 128) { Value = args.Name },
                new SqlParameter("@RoomTypeId", SqlDbType.Int) { Value = (int)args.RoomTypeId },
            };
        }
    }
}
