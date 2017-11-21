using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.DAL.Bookings;
using SanatoriumApp.Domain.Bookings;

namespace SanatoriumApp.Repositories.Bookings
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingsCreateSqlStoredProcedureCommand _createCommand;
        private readonly BookingsGetByIdSqlStoredProcedureQuery _getByIdCommand;
        private readonly BookingsGetByPageSqlStoredProcedureQuery _getByPageCommand;
        private readonly BookingsDeleteSqlStoredProcedureCommand _deleteCommand;
        private readonly BookingsUpdateSqlStoredProcedureCommand _updateCommand;
        private readonly BookingsGetTotalSqlStoredProcedureScalar _getTotalCommand;
        private readonly BookingsGetByOverlappingDateRangeSqlStoredProcedureQuery _getByOverlappingDateRangeCommand;

        public BookingRepository(
            BookingsCreateSqlStoredProcedureCommand createCommand
            , BookingsGetByIdSqlStoredProcedureQuery getByIdCommand
            , BookingsGetByPageSqlStoredProcedureQuery getByPageCommand
            , BookingsGetTotalSqlStoredProcedureScalar getTotalCommand
            , BookingsDeleteSqlStoredProcedureCommand deleteCommand
            , BookingsUpdateSqlStoredProcedureCommand updateCommand
            , BookingsGetByOverlappingDateRangeSqlStoredProcedureQuery getByOverlappingDateRangeCommand
            )
        {
            _createCommand = createCommand;
            _getByIdCommand = getByIdCommand;
            _getByPageCommand = getByPageCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
            _getTotalCommand = getTotalCommand;
            _getByOverlappingDateRangeCommand = getByOverlappingDateRangeCommand;
        }

        public Task Create(Booking Booking)
        {
            return _createCommand.ExecuteAsync(Booking);
        }

        public async Task<Booking> GetById(int id)
        {
            var dbResult = await _getByIdCommand.ExecuteAsync(id);
            return dbResult.FirstOrDefault();
        }

        public async Task<KendoGridResponse<BookingGetByPageModel>> GetByPage(KendoGridRequest request)
        {
            var records = await _getByPageCommand.ExecuteAsync(request);
            var total = await _getTotalCommand.ExecuteAsync();

            var result = new KendoGridResponse<BookingGetByPageModel>
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

        public async Task Update(Booking request)
        {
            await _updateCommand.ExecuteAsync(request);
        }

        public async Task<ICollection<Booking>> GetByOverlappingDateRange(Booking booking)
        {
            var dbResult = await _getByOverlappingDateRangeCommand.ExecuteAsync(booking);
            return dbResult;
        }
    }
}
