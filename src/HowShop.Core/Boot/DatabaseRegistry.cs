using System.Data.Entity;
using HowShop.Core.Infra;
using SolidR.FluentMigrator;
using StructureMap;

namespace HowShop.Core.Boot
{
    public class DatabaseRegistry : Registry
    {
        public DatabaseRegistry()
        {
            For<DbContext>().Use<HowToContext>();
            For<IDatabaseMigrator>().Use<FluentDatabaseMigrator>();
        }
    }
}
