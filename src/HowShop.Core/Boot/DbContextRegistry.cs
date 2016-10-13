using System.Data.Entity;
using HowShop.Core.Infra;
using SolidR.FluentMigrator;
using StructureMap;

namespace HowShop.Core.Boot
{
    public class DbContextRegistry : Registry
    {
        public DbContextRegistry()
        {
            For<DbContext>().Use<HowShopContext>().ContainerScoped();
            For<IDatabaseMigrator>().Use<FluentDatabaseMigrator>();
        }
    }
}
