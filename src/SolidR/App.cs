using System;
using System.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;
using StructureMap;

namespace SolidR
{
    public class App
    {
        public static Func<DateTime> Clock = () => DateTime.Now;

        public static string ConnectionString
        {
            get
            {
                var config = ConfigurationManager.ConnectionStrings["App"];

                if (config != null)
                {
                    return config.ConnectionString;
                }

                return string.Empty;
            }
        }

        // TODO: Refactor
        public static Logger Log { get; private set; }
        public static IContainer Container { get; private set; }
        
        public static void Initialize(Action<ConfigurationExpression> callerContainerConfiguration = null)
        {
            InitializeLog();

            Container = new Container(c =>
            {
                c.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.LookForRegistries();
                });

                callerContainerConfiguration?.Invoke(c);
            });
        }

        private static void InitializeLog()
        {
            var config = new LoggingConfiguration();

            var consoleTarget = new ConsoleTarget
            {
                Layout = @"${date:format=HH\:mm\:ss} ${message}"
            };

            config.AddTarget("console", consoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));

            LogManager.Configuration = config;

            var logger = LogManager.GetLogger("App");

            logger.Fatal("Log initialized");

            Log = logger;
        }
    }
}
