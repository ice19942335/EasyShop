using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace EasyShop.Logger
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly string _configurationFile;

        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers = new ConcurrentDictionary<string, Log4NetLogger>();

        public Log4NetLoggerProvider(string configurationFile) => _configurationFile = configurationFile;

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, category =>
            {
                var xml = new XmlDocument();
                var fileName = _configurationFile;
                xml.Load(fileName);
                return new Log4NetLogger(category, xml["log4net"]);
            });
        }

        public void Dispose() => _loggers.Clear();
    }
}
