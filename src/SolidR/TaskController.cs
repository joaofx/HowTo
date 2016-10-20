using System.Collections.Generic;
using System.Linq;
using SolidR.Core;
using SolidR.Core.Tasks;

namespace SolidR
{
    public class TaskController
    {
        private readonly List<IShellTask> _tasks;
        private readonly IShellTask _helpTask;

        public TaskController(IShellTask helpTask, IEnumerable<IShellTask> tasks)
        {
            _tasks = tasks.Where(x => x.GetType() != typeof(HelpTask)).ToList();
            _helpTask = helpTask;
            _tasks.Add(helpTask);
        }

        public static bool Match(string command, string args)
        {
            var commandArray = command.Split(' ');
            var argsArray = args.Split(' ');

            if (commandArray.Length > argsArray.Length)
            {
                return false;
            }

            return commandArray.Where((t, x) => t != argsArray[x]).Any() == false;
        }

        public void Execute(params string[] args)
        {
            var argsText = args.Join(" ");
            var task = GetTask(argsText);

            App.Log.Debug("Executing {0}", argsText);

            if (task != null)
            {
                App.Log.Debug("Task {0}", task.GetType().FullName);
                task.Execute(args);
            }
            else
            {
                App.Log.Debug("Task was not found. Showing help");
                _helpTask.Execute("help");
            }
        }

        private IShellTask GetTask(string textoArgumentos)
        {
            return _tasks.FirstOrDefault(tarefa => Match(tarefa.Command, textoArgumentos));
        }
    }
}
