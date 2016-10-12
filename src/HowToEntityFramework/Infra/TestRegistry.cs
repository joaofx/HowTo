using HowShop.Core.Infra;
using SolidR.FluentMigrator;
using SolidR.TestFx;
using StructureMap;

namespace HowToEntityFramework.Infra
{
    public class TestRegistry : Registry
    {
        public TestRegistry()
        {
            For<IDatabaseMigrator>().Use<FluentDatabaseMigrator>();
            For<IDatabaseCleaner>().Use<RespawnDatabaseCleaner>();
        }
    }
}
