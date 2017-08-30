using System;

namespace Core.Logging
{
    public interface ILoggerFactory
    {
        IApplicationLogger CreateLogger(Type context);
    }
}
