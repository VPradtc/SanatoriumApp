using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Domain.Common;
using SanatoriumApp.Domain.MedicalProcedures;
using SanatoriumApp.Services.Auth.MedicalProcedures;
using SanatoriumApp.WebPortal.Controllers.Core;

namespace SanatoriumApp.WebPortal.Controllers
{
    [Authorize]
    public class MedicalProcedureController : BaseApiController
    {
        private readonly IMedicalProcedureService _medicalProcedureService;

        public MedicalProcedureController(IMedicalProcedureService medicalProcedureService)
        {
            _medicalProcedureService = medicalProcedureService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var entity = await _medicalProcedureService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByPage([FromUri]KendoGridRequest request)
        {
            var grid = await _medicalProcedureService.GetByPage(request);

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(MedicalProcedure request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _medicalProcedureService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(MedicalProcedure request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _medicalProcedureService.Update(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete([FromBody]int id)
        {
            await _medicalProcedureService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
