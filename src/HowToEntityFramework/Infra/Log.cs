using NLog;
using NLog.Config;
using NLog.Targets;

namespace HowToEntityFramework.Infra
{
    public static class Log
    {
        public static Logger App { get; private set; }

        static Log()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ConsoleTarget
            {
                Layout = @"${date:format=HH\:mm\:ss} ${message}"
            };

            config.AddTarget("console", consoleTarget);

            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));

            LogManager.Configuration = config;
            App = LogManager.GetLogger("App");
        }
    }
}
