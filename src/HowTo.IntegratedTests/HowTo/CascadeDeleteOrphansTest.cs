using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.EntityFramework;
using SolidR.TestFx;

namespace HowTo.IntegratedTests.HowTo
{
    [TestFixture]
    public class CascadeDeleteOrphansTest : IntegratedTest
    {
        [Test]
        public void Should_save_encapsulated_collections()
        {
            // arrange
            using (var db = new HowShopContext())
            {
                var dublin = new Store("Dublin");
                var london = new Store("London");

                var iphone = new Product("iPhone", 499);
                iphone.AddQuantityInStock(dublin, 10);
                iphone.AddQuantityInStock(london, 20);

                db.Products.Add(iphone);
                db.SaveChanges();
            }

            // act
            using (var db = new HowShopContext())
            {
                var dublin = db.Stores.SingleOrDefault(x => x.Name == "Dublin");

                var iphone = db.Products
                    .Where(x => x.Name == "iPhone")
                    .Include(x => x.Stocks)
                    .Include(x => x.Stocks.Select(s => s.Store))
                    .SingleOrDefault();

                iphone.RemoveStock(dublin);
                iphone.Stocks.Count().ShouldBe(1);

                db.SaveChanges();
            }

            // assert
            using (var db = new HowShopContext())
            {
                db.Stocks.Count().ShouldBe(1);

                var london = db.Stores.SingleOrDefault(x => x.Name == "London");

                var iphone = db.Products
                    .Where(x => x.Name == "iPhone")
                    .Include(x => x.Stocks)
                    .Include(x => x.Stocks.Select(s => s.Store))
                    .SingleOrDefault();

                iphone.Stocks.Count().ShouldBe(1);

                iphone.Stocks.ElementAt(0).Store.Id.ShouldBe(london.Id);
                iphone.Stocks.ElementAt(0).Quantity.ShouldBe(20);
            }
        }
    }
}
