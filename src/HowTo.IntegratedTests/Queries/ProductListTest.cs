using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using NUnit.Framework;
using Shouldly;

namespace HowTo.IntegratedTests.Queries
{
    [TestFixture]
    public class ProductListTest : IntegratedTest
    {
        [Test]
        public void Should_list_products()
        {
            // arrange
            // TODO - Use AutoFixture
            var iphone = new Product("iPhone", 599.99m);
            var galaxy = new Product("Galaxy", 499.49m);
            var motorola = new Product("Motorola", 355.55m);

            SaveAll(iphone, galaxy, motorola);

            // act
            var result = Send(new ProductList.Query());

            // assert
            Assert.Fail();
            //result.Count().ShouldBe(3);
            //result.ShouldContain(iphone);
            //result.ShouldContain(galaxy);
            //result.ShouldContain(motorola);
        }
    }
}
