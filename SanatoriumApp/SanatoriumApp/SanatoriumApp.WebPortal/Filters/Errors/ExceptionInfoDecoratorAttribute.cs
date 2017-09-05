using System;
using System.Web.Http.Filters;
using Core.Logging;

namespace SanatoriumApp.WebPortal.Filters.Errors
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
            _logger.Error(ctx.Exception, "An error has occurred.");

            base.OnException(ctx);
        }
    }
}
