namespace SolidR.Core.Tasks
{
    public interface IShellTask
    {
        string HelpText
        {
            get;
        }

        string Command
        {
            get;
        }

        void Execute(params string[] args);
    }
}