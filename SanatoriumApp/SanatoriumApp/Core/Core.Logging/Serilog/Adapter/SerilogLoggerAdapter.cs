using System;
using Serilog;
using Serilog.Core;

namespace Core.Logging.Serilog.Adapter
{
    public class SerilogLoggerAdapter : IApplicationLogger
    {
        private readonly ILogger _logger;

        public SerilogLoggerAdapter(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            _logger.Debug(messageTemplate, propertyValues);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(exception, messageTemplate, propertyValues);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(messageTemplate, propertyValues);
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            _logger.Fatal(messageTemplate, propertyValues);
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            _logger.Information(messageTemplate, propertyValues);
        }

        public void Verbose(string messageTemplate, params object[] propertyValues)
        {
            _logger.Verbose(messageTemplate, propertyValues);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            _logger.Warning(messageTemplate, propertyValues);
        }
    }
}
