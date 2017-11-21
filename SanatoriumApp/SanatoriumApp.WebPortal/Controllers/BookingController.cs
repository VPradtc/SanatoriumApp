using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Domain.Common;
using SanatoriumApp.Domain.Bookings;
using SanatoriumApp.Services.Bookings;
using SanatoriumApp.WebPortal.Controllers.Core;

namespace SanatoriumApp.WebPortal.Controllers
{
    [Authorize]
    public class BookingController : BaseApiController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var entity = await _bookingService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByPage([FromUri]KendoGridRequest request)
        {
            var grid = await _bookingService.GetByPage(request);

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(Booking request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _bookingService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(Booking request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _bookingService.Update(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete([FromBody]int id)
        {
            await _bookingService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> IsVacant([FromUri]Booking booking)
        {
            bool isVacant = await _bookingService.IsVacant(booking);

            return Request.CreateResponse(HttpStatusCode.OK, isVacant);
        }
    }
}
