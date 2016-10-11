using SolidR.Domain;

namespace HowShop.Core.Domain
{
    public class Discount : Entity, IEffectivable
    {
        public Effective Effective { get; private set; }
        public decimal Price { get; private set; }
        public Product Product { get; private set; }
        public long ProductId { get; private set; }

        private Discount()
        {
        }

        public Discount(Product product, decimal price, Effective effective)
        {
            Product = product;
            Price = price;
            Effective = effective;
        }
    }
}