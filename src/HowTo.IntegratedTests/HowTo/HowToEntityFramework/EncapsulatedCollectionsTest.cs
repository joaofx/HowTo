using System.Data.Entity;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;
using SolidR.Core.EntityFramework;

namespace HowTo.IntegratedTests.HowTo.HowToEntityFramework
{
    /// <summary>
    /// References:
    ///     https://gist.github.com/hazzik/c08eabc7dffdca83eb55
    ///     https://lostechies.com/jimmybogard/2014/05/09/missing-ef-feature-workarounds-encapsulated-collections/
    /// </summary>
    [TestFixture]
    public class EncapsulatedCollectionsTest : IntegratedTest
    {
        [Test]
        public void Should_save_encapsulated_collections()
        {
            var dublin = new Store("Dublin");
            var london = new Store("London");

            var iphone = new Product("iPhone", 499);
            iphone.AddQuantityInStock(dublin, 10);
            iphone.AddQuantityInStock(london, 20);
            
            using (var db = new HowShopContext())
            {
                db.Products.Add(iphone);
                db.SaveChanges();
            }

            using (var db = new HowShopContext())
            {
                var result = db.Products
                    .Where(x => x.Name == iphone.Name)
                    .Include(x => x.Stocks)
                    .Include(x => x.Stocks.Select(s => s.Store))
                    .SingleOrDefault();

                result.Stocks.Count().ShouldBe(2);

                result.Stocks.ElementAt(0).Store.Id.ShouldBe(dublin.Id);
                result.Stocks.ElementAt(0).Quantity.ShouldBe(10);

                result.Stocks.ElementAt(1).Store.Id.ShouldBe(london.Id);
                result.Stocks.ElementAt(1).Quantity.ShouldBe(20);
            }
        }
    }
}
