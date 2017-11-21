using System.Threading.Tasks;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings;

namespace SanatoriumApp.Services.Bookings
{
    public interface IBookingService
    {
        Task Create(Booking model);

        Task Update(Booking request);

        Task Delete(int id);

        Task<KendoGridResponse<BookingGetByPageModel>> GetByPage(KendoGridRequest request);

        Task<Booking> GetById(int id);
        Task<bool> IsVacant(Booking booking);
    }
}
