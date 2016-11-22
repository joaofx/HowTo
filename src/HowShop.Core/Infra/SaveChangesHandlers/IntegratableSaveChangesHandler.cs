using System.Data.Entity;
using System.Linq;
using HowShop.Core.Domain;

namespace HowShop.Core.Infra.SaveChangesHandlers
{
    public class IntegratableSaveChangesHandler : ISaveChangesHandler
    {
        public void HandleSaveChanges(HowShopContext db)
        {
            var integratables = db.ChangeTracker.Entries<IIntegratableByName>()
                    .Where(p => p.State == EntityState.Added || p.State == EntityState.Modified)
                    .Select(p => p.Entity);

            foreach (var integratable in integratables)
            {
                integratable.IntegrationName = integratable.Name.Replace(" ", string.Empty);
            }
        }
    }
}
