using SolidR.TestFx;
using StructureMap;

namespace HowTo.IntegratedTests.Boot
{
    public class TestRegistry : Registry
    {
        public TestRegistry()
        {
            For<IDatabaseCleaner>().Use<RespawnDatabaseCleaner>();
        }
    }
}
