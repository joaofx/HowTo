using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;

namespace HowTo.IntegratedTests.HowTo.HowToEntityFramework
{
    /// <summary>
    /// How? Create a private empty constructor to let EF initialize the entity on runtime
    /// </summary>
    [TestFixture]
    public class RequiredConstructorTest : IntegratedTest
    {
       [SetUp]
        public void Scenario()
        {
            using (var db = new HowShopContext())
            {
                db.Products.Add(new Product("iPhone 6", 699.99m));
                db.Products.Add(new Product("Samsung Galaxy S7", 799.99m));
                db.SaveChanges();
            }
        }

        [Test]
        public void Assert()
        {
            using (var db = new HowShopContext())
            {
                var products = db.Products.ToList();

                products[0].Name.ShouldBe("iPhone 6");
                products[0].Price.ShouldBe(699.99m);

                products[1].Name.ShouldBe("Samsung Galaxy S7");
                products[1].Price.ShouldBe(799.99m);
            }
        }
    }
}
