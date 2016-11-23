using System.Linq;
using HowShop.Core.Domain;
using NUnit.Framework;
using Shouldly;

namespace HowTo.IntegratedTests.HowTo.HowToEntityFramework
{
    [TestFixture]
    public class IntegratableNameTest : IntegratedTest
    {
        [Test]
        public void Should_handle_product_integration_name_before_persist()
        {
            // arrange
            var samsung = Fixture.Create<Product>(x => x.Name = "Samsung Galaxy S7");

            // act
            SaveAll(samsung);

            // assert
            WithDb(db =>
            {
                var product = db.Products.Single();
                product.IntegrationName.ShouldBe("SamsungGalaxyS7");
            });
        }
    }
}
