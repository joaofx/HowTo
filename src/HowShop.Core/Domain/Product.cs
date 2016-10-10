using System.Collections.Generic;
using System.Linq;
using SolidR.Domain;

namespace HowShop.Core.Domain
{
    public class Product : IAuditable, IEntity
    {
        //public ICollection<Stock> Stocks { get; set; } = new HashSet<Stock>();
        protected virtual ICollection<Stock> _stocks { get; set; } = new HashSet<Stock>();

        public long Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Audit Audit { get; set; } = new Audit();
        public IEnumerable<Stock> Stocks => _stocks;

        private Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void AddQuantityInStock(Store store, int quantity)
        {
            _stocks.Add(new Stock(this, store, quantity));
        }

        public void RemoveStock(Store store)
        {
            var internalStore = _stocks.FirstOrDefault(x => x.Id == store.Id);
            _stocks.Remove(internalStore);
        }
    }
}