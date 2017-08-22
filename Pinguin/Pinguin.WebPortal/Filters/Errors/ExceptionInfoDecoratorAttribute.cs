using System;
using System.Web;
using System.Web.Http.Filters;
using Core.Logging;

namespace Pinguin.WebPortal.Filters.Errors
{
    public class ExceptionInfoDecoratorAttribute : ExceptionFilterAttribute
    {
        private readonly IApplicationLogger _logger;

        public ExceptionInfoDecoratorAttribute(IApplicationLogger logger) : base()
        {
            _logger = logger;
        }

        public override void OnException(HttpActionExecutedContext ctx)
        {
            _logger.Error("An error occurred:\r\n Exception: {Exception}\r\nRequest: {Request}", ctx.Exception, HttpContext.Current.Request);

            base.OnException(ctx);
        }
    }
}
