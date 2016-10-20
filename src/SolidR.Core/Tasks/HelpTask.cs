using System;
using System.Linq;
using System.Text;

namespace SolidR.Core.Tasks
{
    public class HelpTask : IShellTask
    {
        public string HelpText => "Help";

        public string Command => "help";

        public void Execute(params string[] args)
        {
            const string help = @"Nails {0}

How to use:
    solidr [task_name] [task args]

Tasks:

{1}
";
            var helpText = new StringBuilder();
            var tasks = App.Container.GetAllInstances<IShellTask>().OrderBy(x => x.Command);

            foreach (var tarefa in tasks)
            {
                helpText.Append("   ");
                helpText.Append(tarefa.Command);
                helpText.Append(Environment.NewLine);
                helpText.Append("       ");
                helpText.Append(tarefa.HelpText);
                helpText.Append(Environment.NewLine);
                helpText.Append(Environment.NewLine);
            }

            Console.Write(help, "0.1", helpText);
            //App.Log.Info(string.Format(help, FeliceCore.Version, helpText));
        }
    }
}