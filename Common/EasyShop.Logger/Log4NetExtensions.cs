using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace EasyShop.Logger
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string configurationFile = "log4net.config")
        {
            if (!Path.IsPathRooted(configurationFile))
            {
                var assembly = Assembly.GetEntryAssembly();
                var dir = Path.GetDirectoryName(assembly.Location);
                configurationFile = Path.Combine(dir, configurationFile);

                factory.AddProvider(new Log4NetLoggerProvider(configurationFile));
            }

            return factory;
        }
    }
}