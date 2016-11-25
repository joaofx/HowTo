using FubuCore.Binding;
using FubuCore.Configuration;
using StructureMap;

namespace HowTo.IntegratedTests.Boot
{
    public class AppSettingProviderRegistry : Registry
    {
        public AppSettingProviderRegistry()
        {
            For<ISettingsProvider>().Use<AppSettingsProvider>();
            For<IObjectResolver>().Use(x => ObjectResolver.Basic());
        }
    }
}
