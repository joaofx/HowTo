using System.Data.Entity;
using System.Linq;
using HowShop.Core.Domain;
using SolidR.Core.Domain;

namespace HowShop.Core.Infra.SaveChangesHandlers
{
    public class DeleteOrphanSaveChangesHandler : ISaveChangesHandler
    {
        public void HandleSaveChanges(HowShopContext db)
        {
            // TODO: Think a way to do it for many entities
            foreach (var orphan in db.Stocks.Local.Where(x => x.Product == null).ToList())
            {
                db.Stocks.Remove(orphan);
            }
        }
    }
}
