using System.Data.Entity;
using System.Linq;
using SolidR.Core.Domain;

namespace HowShop.Core.Infra.SaveChangesHandlers
{
    public class AuditSaveChangesHandler : ISaveChangesHandler
    {
        public void HandleSaveChanges(HowShopContext db)
        {
            var entitiesBeingCreated = db.ChangeTracker.Entries<IAuditable>()
                    .Where(p => p.State == EntityState.Added)
                    .Select(p => p.Entity);

            foreach (var entityBeingCreated in entitiesBeingCreated)
            {
                entityBeingCreated.Audit.BeingCreated();
            }

            var entitiesBeingUpdated = db.ChangeTracker.Entries<IAuditable>()
                    .Where(p => p.State == EntityState.Modified)
                    .Select(p => p.Entity);

            foreach (var entityBeingUpdated in entitiesBeingUpdated)
            {
                entityBeingUpdated.Audit.BeingUpdated();
            }
        }
    }
}
