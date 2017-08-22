using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Pinguin.Services.Auth.Users;
using Pinguin.Viewmodels.Users;
using Pinguin.WebPortal.Controllers.Core;

namespace Pinguin.WebPortal.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody]UserCreateModel request)
        {
            if (request == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            await _userService.Create(request);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
