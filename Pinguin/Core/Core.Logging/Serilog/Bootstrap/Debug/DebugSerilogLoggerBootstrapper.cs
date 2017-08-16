using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Serilog;
using Serilog.Enrichers.HttpContextData;
using Serilog.Events;

namespace Core.Logging.Serilog.Bootstrap.Debug
{
    public class DebugSerilogLoggerBootstrapper : ILoggerBootstrapper
    {
        private readonly string _pathPrefix = "logs";
        private readonly string _errorMessageTemplate = "{NewLine}{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}"
                                                 + "Exception: {Exception}{NewLine}"
                                                 + "Stack Trace: {NewLine}{StackTrace}{NewLine}"
                                                 + "Host: {_Host}{NewLine}"
                                                 + "Method: {_HTTPMethod}{NewLine}"
                                                 + "URL: {_Url}{NewLine}"
                                                 + "Status Code: {_StatusCode}{NewLine}";

        private readonly SerilogLoggerFactory _logFactory;

        public DebugSerilogLoggerBootstrapper(SerilogLoggerFactory logFactory)
        {
            _logFactory = logFactory;
        }

        private HttpContextDataLogFilterSettings CreateHttpContextEnricherConfiguration()
        {
            var settings = new HttpContextDataLogFilterSettings()
            {
                AppendFullStackTrace = true,
                FormFilters = new List<HttpContextDataLogFilter>
                {
                    new HttpContextDataLogFilter { Name= "Password", ReplaceWith="", }
                },
            };

            settings.HeaderFilters = new List<HttpContextDataLogFilter>
            {
                new HttpContextDataLogFilter { Name= "Authorization", ReplaceWith="***" },
            };

            return settings;
        }

        public void Bootstrap()
        {
            var logFileDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _pathPrefix);
            var enricherConfig = CreateHttpContextEnricherConfiguration();
            var contextEnricher = new HttpContextDataEnricher(LogEventLevel.Error, enricherConfig);

            var coreLogFactory = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .Enrich.With(contextEnricher)
                .Destructure.ByTransforming<HttpRequest>(
                    r => new
                    {
                        r.RawUrl,
                        r.HttpMethod,
                        r.ContentType,
                        r.UserAgent,
                        r.QueryString,
                    })
                .Destructure.ByTransforming<HttpResponse>(
                    r => new
                    {
                        r.StatusCode,
                        r.Headers,
                    })
               .WriteTo.Trace()
               .WriteTo.RollingFile(
                    outputTemplate: _errorMessageTemplate
                    , pathFormat: Path.Combine(logFileDirectory, "errors_{Date}.txt")
                    , restrictedToMinimumLevel: LogEventLevel.Error
                    , flushToDiskInterval: TimeSpan.FromSeconds(3)
                    , retainedFileCountLimit: null
                    , buffered: true
                )
                .WriteTo.RollingFile(
                    outputTemplate: _errorMessageTemplate
                    , pathFormat: Path.Combine(logFileDirectory, "info_{Date}.txt")
                    , restrictedToMinimumLevel: LogEventLevel.Information
                    , flushToDiskInterval: TimeSpan.FromSeconds(3)
                    , retainedFileCountLimit: null
                    , buffered: true
                )
                .WriteTo.RollingFile(
                    pathFormat: Path.Combine(logFileDirectory, "trace_{Date}.txt")
                    , restrictedToMinimumLevel: LogEventLevel.Verbose
                    , flushToDiskInterval: TimeSpan.FromSeconds(3)
                    , retainedFileCountLimit: null
                    , buffered: true
                )
               .CreateLogger();

            _logFactory.SetLogFactory(coreLogFactory);
        }
    }
}
