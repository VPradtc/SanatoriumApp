using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures;
using SanatoriumApp.Services.ScheduledMedicalProcedures;
using SanatoriumApp.WebPortal.Controllers.Core;

namespace SanatoriumApp.WebPortal.Controllers
{
    [Authorize]
    public class ScheduledMedicalProcedureController : BaseApiController
    {
        private readonly IScheduledMedicalProcedureService _scheduledMedicalProcedureService;

        public ScheduledMedicalProcedureController(IScheduledMedicalProcedureService scheduledMedicalProcedureService)
        {
            _scheduledMedicalProcedureService = scheduledMedicalProcedureService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var entity = await _scheduledMedicalProcedureService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByPage([FromUri]ScheduledMedicalProcedureGetByPageRequest request)
        {
            var grid = await _scheduledMedicalProcedureService.GetByPage(request);

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(ScheduledMedicalProcedure request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _scheduledMedicalProcedureService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(ScheduledMedicalProcedure request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _scheduledMedicalProcedureService.Update(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete([FromBody]int id)
        {
            await _scheduledMedicalProcedureService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
