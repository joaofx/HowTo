namespace HowShop.Core.Infra.SaveChangesHandlers
{
    public interface ISaveChangesHandler
    {
        void HandleSaveChanges(HowShopContext db);
    }
}