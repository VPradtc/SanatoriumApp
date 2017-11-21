using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings;

namespace SanatoriumApp.Repositories.Bookings
{
    public interface IBookingRepository
    {
        Task Create(Booking Booking);

        Task<Booking> GetById(int id);

        Task<KendoGridResponse<BookingGetByPageModel>> GetByPage(KendoGridRequest request);

        Task Delete(int id);

        Task Update(Booking request);
        Task<ICollection<Booking>> GetByOverlappingDateRange(Booking booking);
    }
}
