using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Core.Logging;

namespace SanatoriumApp.WebPortal.Handlers
{
    public class TraceMessageHandler : DelegatingHandler
    {
        private readonly IApplicationLogger _logger;

        public TraceMessageHandler(IApplicationLogger logger) : base()
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var correlationId = request.GetCorrelationId().ToString();

            LogRequest(request, correlationId);

            var response = await base.SendAsync(request, cancellationToken);
            var responseBody = response.Content == null
                ? null
                : await response.Content.ReadAsStringAsync();

            LogResponse(response, responseBody, correlationId);

            return response;
        }

        private void LogRequest(HttpRequestMessage request, string correlationId)
        {
            _logger.Verbose(
                "REQUEST ID: {CorrelationId}\r\n\tRequest: {@Request}"
                , correlationId
                , HttpContext.Current.Request
                );
        }

        private void LogResponse(HttpResponseMessage response, string responseBody, string correlationId)
        {
            _logger.Verbose(
                "REQUEST ID: {CorrelationId}\r\n\tResponse: {@Response}\r\n\t\r\n\tResponse Body: {ResponseBody}\r\n\t"
                , correlationId
                , HttpContext.Current.Response
                , responseBody
                );
        }
    }
}
