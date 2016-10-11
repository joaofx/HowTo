using SolidR.FluentMigrator;
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
