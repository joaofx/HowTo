using System;
using FubuCore.CommandLine;
using MediatR;
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

                    // todo: scan any fubucommand
                    scan.AddAllTypesOf(typeof(FubuCommand<Unit>));
                });
            });

            try
            {
                var factory = new CommandFactory();
                RegisterAllCommands(factory);

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

        private static void RegisterAllCommands(CommandFactory factory)
        {
            var shellTasks = App.Container.GetAllInstances(typeof(FubuCommand<Unit>));
            
            foreach (var shellTask in shellTasks)
            {
                factory.RegisterCommands(shellTask.GetType().Assembly);
            }
        }
    }
}
