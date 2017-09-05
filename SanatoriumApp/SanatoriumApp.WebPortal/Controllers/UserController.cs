using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Domain.Common;
using SanatoriumApp.Services.Auth.Users;
using SanatoriumApp.Viewmodels.Users;
using SanatoriumApp.WebPortal.Controllers.Core;

namespace SanatoriumApp.WebPortal.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> GetById(int id)
        {
            var entity = await _userService.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetByPage([FromUri]KendoGridRequest request)
        {
            var grid = await _userService.GetByPage(request);

            return Request.CreateResponse(HttpStatusCode.OK, grid);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(UserCreateModel request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _userService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(UserEditModel request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _userService.Update(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Delete([FromBody]int id)
        {
            await _userService.Delete(id);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [OverrideAuthorization]
        public async Task<HttpResponseMessage> IsUniqueEmail([FromUri]string email)
        {
            var sanitizedEmail = email.Trim();

            var exists = await _userService.Exists(sanitizedEmail);
            var isUnique = !exists;

            return Request.CreateResponse(HttpStatusCode.OK, isUnique);
        }
    }
}
