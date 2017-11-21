using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Domain.Common;
using SanatoriumApp.Domain.Rooms;
using SanatoriumApp.Services.Rooms;
using SanatoriumApp.WebPortal.Controllers.Core;

namespace SanatoriumApp.WebPortal.Controllers
{
    [Authorize]
    public class RoomController : BaseApiController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            var entity = await _roomService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var entity = await _roomService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByPage([FromUri]KendoGridRequest request)
        {
            var grid = await _roomService.GetByPage(request);

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(Room request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _roomService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(Room request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _roomService.Update(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete([FromBody]int id)
        {
            await _roomService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
