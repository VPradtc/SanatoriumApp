using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.DAL.Rooms;
using SanatoriumApp.Domain.Rooms;

namespace SanatoriumApp.Repositories.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomsCreateSqlStoredProcedureCommand _createCommand;
        private readonly RoomsGetByIdSqlStoredProcedureQuery _getByIdCommand;
        private readonly RoomsGetByPageSqlStoredProcedureQuery _getByPageCommand;
        private readonly RoomsDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly RoomsUpdateSqlStoredProcedureCommand _updateCommand;
        private readonly RoomsGetTotalSqlStoredProcedureScalar _getTotalCommand;

        public RoomRepository(
            RoomsCreateSqlStoredProcedureCommand createCommand
            , RoomsGetByIdSqlStoredProcedureQuery getByIdCommand
            , RoomsGetByPageSqlStoredProcedureQuery getByPageCommand
            , RoomsGetTotalSqlStoredProcedureScalar getTotalCommand
            , RoomsDeleteSqlStoredProcedureCommand deleteCommand
            , RoomsUpdateSqlStoredProcedureCommand updateCommand
            )
        {
            _createCommand = createCommand;
            _getByIdCommand = getByIdCommand;
            _getByPageCommand = getByPageCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _getTotalCommand = getTotalCommand;
        }

        public Task Create(Room Room)
        {
            return _createCommand.ExecuteAsync(Room);
        }

        public async Task<Room> GetById(int id)
        {
            var dbResult = await _getByIdCommand.ExecuteAsync(id);
            return dbResult.FirstOrDefault();
        }

        public async Task<KendoGridResponse<Room>> GetByPage(KendoGridRequest request)
        {
            var records = await _getByPageCommand.ExecuteAsync(request);
            var total = await _getTotalCommand.ExecuteAsync();

            var result = new KendoGridResponse<Room>
            {
                Data = records,
                Total = total,
            };

            return result;
        }

        public async Task Delete(int id)
        {
            await _deleteCommand.ExecuteAsync(id);
        }

        public async Task Update(Room request)
        {
            await _updateCommand.ExecuteAsync(request);
        }
    }
}
