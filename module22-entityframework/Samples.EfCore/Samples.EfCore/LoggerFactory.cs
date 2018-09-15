using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Samples.EfCore
{
    class LoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger();
        }

        public void Dispose() { }

        private class Logger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state) => new Scope();

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                if (logLevel == LogLevel.Information)
                    Debug.WriteLine(state);
            }

            class Scope : IDisposable
            {
                public void Dispose() { }
            }
        }
    }
}
