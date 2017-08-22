using System;
using System.Web.Http;
using Pinguin.WebPortal.Filters.Errors;

namespace Pinguin.WebPortal.Controllers.Core
{
    [ExceptionDetail]
    public class BaseApiController : ApiController
    {
    }
}
