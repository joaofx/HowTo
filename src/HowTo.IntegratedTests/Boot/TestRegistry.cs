using System.Data.Entity;
using HowShop.Core.Concerns;
using HowShop.Core.Infra;
using SolidR.TestSupport;
using StructureMap;

namespace HowTo.IntegratedTests.Boot
{
    public class TestRegistry : Registry
    {
        public TestRegistry()
        {
            For<IDatabaseCleaner>().Use<RespawnDatabaseCleaner>();
            For<IUserSession>().Use<TestUserSession>();
            For<DbContext>().Use<HowShopContext>();
        }
    }
}
