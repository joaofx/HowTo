using System;
using System.Diagnostics;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;

namespace ClassLibrary1
{
    [TestFixture]
    public class LogTest
    {
        [Test]
        public void Should_log2()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            fileTarget.FileName = "${basedir}/file.txt";
            fileTarget.Layout = "${message}";

            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;

            // Example usage
            Logger logger = LogManager.GetLogger("Example");
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");
        }

        [Test]
        public void Should_log()
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
            Debug.WriteLine("A");
            Trace.WriteLine("B");
            Console.WriteLine("C");
        }
    }
}
