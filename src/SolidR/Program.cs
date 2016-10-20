using System;
using FubuCore.CommandLine;
using Import;
using SolidR.Core;

namespace SolidR
{
    public class Program
    {
        private static bool _success;

        public static int Main(string[] args)
        {
            App.Initialize(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.LookForRegistries();
                });
            });

            try
            {
                // TODO: find all assemblies that have IShellTask
                var factory = new CommandFactory();
                factory.RegisterCommands(typeof(Program).Assembly);

                var executor = new CommandExecutor(factory);
                _success = executor.Execute(args);
            }
            catch (CommandFailureException ex)
            {
                Console2.Error("Error: " + ex.Message);
                _success = false;
            }
            catch (Exception ex)
            {
                Console2.Error("Error: " + ex.Message);
                _success = false;
            }
            
            return _success ? 0 : 1;
        }
    }
}
