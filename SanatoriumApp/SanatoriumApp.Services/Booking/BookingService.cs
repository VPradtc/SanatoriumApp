using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings;
using SanatoriumApp.Repositories.Bookings;

namespace SanatoriumApp.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(
            IBookingRepository repository
            )
        {
            _repository = repository;
        }

        public async Task Create(Booking model)
        {
            await _repository.Create(model);
        }

        public async Task Update(Booking request)
        {
            await _repository.Update(request);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<KendoGridResponse<BookingGetByPageModel>> GetByPage(KendoGridRequest request)
        {
            var result = await _repository.GetByPage(request);
            return result;
        }

        public async Task<Booking> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return result;
        }

        public async Task<bool> IsVacant(Booking booking)
        {
            var existingBookings = await _repository.GetByOverlappingDateRange(booking);

            return !existingBookings.Any() || !existingBookings.Any(b => b.Id != booking.Id);
        }
    }
}
