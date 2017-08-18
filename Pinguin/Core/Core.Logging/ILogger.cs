﻿using System;

namespace Core.Logging
{
    public interface IApplicationLogger
    {
        void Verbose(string messageTemplate, params object[] propertyValues);

        void Debug(string messageTemplate, params object[] propertyValues);

        void Information(string messageTemplate, params object[] propertyValues);

        void Warning(string messageTemplate, params object[] propertyValues);

        void Error(Exception exception, string messageTemplate, params object[] propertyValues);

        void Error(string messageTemplate, params object[] propertyValues);

        void Fatal(string messageTemplate, params object[] propertyValues);
    }
}
