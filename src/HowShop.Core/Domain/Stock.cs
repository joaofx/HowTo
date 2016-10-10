using SolidR.Domain;

namespace HowShop.Core.Domain
{
    public class Stock : IEntity
    {
        public long Id { get; private set; }

        public Product Product { get; private set; }
        public Store Store { get; private set; }
        public int Quantity { get; private set; }

        public long ProductId { get; private set; }

        private Stock()
        {
        }

        public Stock(Product product, Store store, int quantity)
        {
            Product = product;
            Store = store;
            Quantity = quantity;
        }
    }
}