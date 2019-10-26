using System;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Core;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace EasyShop.Logger
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _log;

        public Log4NetLogger(string categoryName, XmlElement configuration)
        {
            var loggerRepository = LoggerManager.CreateRepository(
                Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            _log = LogManager.GetLogger(loggerRepository.Name, categoryName);

            log4net.Config.XmlConfigurator.Configure(loggerRepository, configuration);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                default: throw new ArgumentOutOfRangeException(nameof(Level), logLevel, null);

                case LogLevel.Trace:
                case LogLevel.Debug:
                    return _log.IsDebugEnabled;

                case LogLevel.Information:
                    return _log.IsInfoEnabled;

                case LogLevel.Warning:
                    return _log.IsWarnEnabled;

                case LogLevel.Error:
                    return _log.IsErrorEnabled;

                case LogLevel.Critical:
                    return _log.IsFatalEnabled;

                case LogLevel.None:
                    return false;
            }
        }

        public void Log<TState>(LogLevel level, EventId id, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(level)) return;
            if (formatter is null) throw new ArgumentNullException(nameof(formatter));

            var msg = formatter(state, exception);

            if (string.IsNullOrEmpty(msg) && exception is null) return;

            switch (level)
            {
                default: throw new ArgumentOutOfRangeException(nameof(Level), level, null);


                case LogLevel.Trace:
                case LogLevel.Debug:
                    _log.Debug(msg);
                    break;

                case LogLevel.Information:
                    _log.Info(msg);
                    break;

                case LogLevel.Warning:
                    _log.Warn(msg);
                    break;

                case LogLevel.Error:
                    _log.Error(msg ?? exception.ToString());
                    break;

                case LogLevel.Critical:
                    _log.Fatal(msg ?? exception.ToString());
                    break;

                case LogLevel.None:
                    break;
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}