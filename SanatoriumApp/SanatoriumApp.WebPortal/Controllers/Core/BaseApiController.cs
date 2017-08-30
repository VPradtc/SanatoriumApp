using System;
using System.Web.Http;
using SanatoriumApp.WebPortal.Filters.Errors;

namespace SanatoriumApp.WebPortal.Controllers.Core
{
    [ExceptionDetail]
    public class BaseApiController : ApiController
    {
    }
}
