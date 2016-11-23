using System.Data.Entity;
using HowShop.Core.Infra;
using HowShop.Core.Infra.SaveChangesHandlers;
using SolidR.Core.FluentMigrator;
using StructureMap;

namespace HowShop.Core.Boot
{
    public class DbContextRegistry : Registry
    {
        public DbContextRegistry()
        {
            For<DbContext>().Use<HowShopContext>().ContainerScoped();
            For<IDatabaseMigrator>().Use<FluentDatabaseMigrator>();

            For<ISaveChangesHandler>().Add<DeleteOrphanSaveChangesHandler>();
            For<ISaveChangesHandler>().Add<AuditSaveChangesHandler>();
            For<ISaveChangesHandler>().Add<IntegratableSaveChangesHandler>();
        }
    }
}
