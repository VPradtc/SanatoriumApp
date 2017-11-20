using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Domain.Common;
using SanatoriumApp.Domain.Clients;
using SanatoriumApp.Services.Clients;
using SanatoriumApp.WebPortal.Controllers.Core;

namespace SanatoriumApp.WebPortal.Controllers
{
    [Authorize]
    public class ClientController : BaseApiController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var entity = await _clientService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByPage([FromUri]KendoGridRequest request)
        {
            var grid = await _clientService.GetByPage(request);

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(Client request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _clientService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(Client request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _clientService.Update(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete([FromBody]int id)
        {
            await _clientService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [OverrideAuthorization]
        public async Task<HttpResponseMessage> IsUniquePassport([FromUri]string passport)
        {
            var sanitizedPassport = passport.Trim();

            var exists = await _clientService.Exists(sanitizedPassport);
            var isUnique = !exists;

            return Request.CreateResponse(HttpStatusCode.OK, isUnique);
        }
    }
}
