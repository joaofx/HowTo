using HowShop.Core.Infra;
using StructureMap;

namespace HowShop.Core.Boot
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            AutoMapperInitializer.Initialize();
        }
    }
}
