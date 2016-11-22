using System.Collections.Generic;
using System.Linq;
using SolidR.Core.Domain;

namespace HowShop.Core.Domain
{
    public class Product : Entity, IAuditable, IIntegratableByName
    {
        protected virtual ICollection<Stock> _stocks { get; set; } = new HashSet<Stock>();

        public string Name { get; set; }
        public decimal Price { get; private set; }
        public Audit Audit { get; private set; } = new Audit();
        public Category Category { get; set; }
        public long CategoryId { get; private set; }
        public IEnumerable<Stock> Stocks => _stocks;
        public bool Sold => false;
        public string IntegrationName { get; set; }

        private Product()
        {
        }

        public Product(string name, decimal price, long categoryId = 0)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public void AddQuantityInStock(Store store, int quantity)
        {
            _stocks.Add(new Stock(this, store, quantity));
        }

        public void RemoveStock(Store store)
        {
            var internalStore = _stocks.FirstOrDefault(x => x.Store == store);
            _stocks.Remove(internalStore);
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}