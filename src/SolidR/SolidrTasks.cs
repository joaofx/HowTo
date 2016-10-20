using System;
using System.Linq;
using SolidR.Core;
using SolidR.Core.Tasks;

namespace SolidR
{
    public class SolidrTasks
    {
        public void Execute(string[] args)
        {
            var tasks = App.Container.GetAllInstances<IShellTask>();
            var controller = new TaskController(new HelpTask(), tasks);

            try
            {
                controller.Execute(args);
            }
            catch (Exception exception)
            {
                App.Log.Error(exception, "Was not possible execute {0}", args.Join(" "));
            }
        }
    }
}