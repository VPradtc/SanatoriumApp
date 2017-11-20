using System;
using Core.Logging.Serilog.Adapter;
using Serilog;

namespace Core.Logging.Serilog
{
    public class SerilogLoggerFactory : ILoggerFactory
    {
        private ILogger _logFactory;

        private ILogger CreateLoggerInternal(Type context)
        {
            if (_logFactory != null)
            {
                return _logFactory.ForContext(context);
            }

            return Log.ForContext(context);
        }

        public IApplicationLogger CreateLogger(Type context)
        {
            var serilogLogger = CreateLoggerInternal(context);
            var adapter = new SerilogLoggerAdapter(serilogLogger);

            return adapter;
        }

        public void SetLogFactory(ILogger logFactory)
        {
            _logFactory = logFactory;
        }
    }
}
