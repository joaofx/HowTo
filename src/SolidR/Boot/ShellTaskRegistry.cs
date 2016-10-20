using SolidR.Core.Tasks;
using StructureMap;

namespace SolidR.Boot
{
    public class ShellTaskRegistry : Registry
    {
        public ShellTaskRegistry()
        {
            Scan(scan =>
            {
                scan.AddAllTypesOf<IShellTask>();
                scan.WithDefaultConventions();
            });
        }
    }
}