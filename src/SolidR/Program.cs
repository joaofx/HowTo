using System;
using FubuCore.CommandLine;
using SolidR.Core;
using SolidR.Core.Tasks;

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
                    scan.AddAllTypesOf<IShellTask>();
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
            var shellTasks = App.Container.GetAllInstances<IShellTask>();
            
            foreach (var shellTask in shellTasks)
            {
                factory.RegisterCommands(shellTask.GetType().Assembly);
            }
        }
    }
}
