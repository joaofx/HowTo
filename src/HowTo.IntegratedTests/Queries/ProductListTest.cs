using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using NUnit.Framework;
using Shouldly;
using SolidR.Core;

namespace HowTo.IntegratedTests.Queries
{
    [TestFixture]
    public class ProductListTest : IntegratedTest
    {
        [Test]
        public void Should_list_products_with_filters()
        {
            // arrange
            var tablet = Fixture.Create<Category>();
            var smartPhone = Fixture.Create<Category>();

            var iphone = Fixture.Create<Product>(x => x.Category = smartPhone);
            var galaxy = Fixture.Create<Product>(x => x.Category = smartPhone);
            var ipad = Fixture.Create<Product>(x => x.Category = tablet);

            SaveAll(tablet, smartPhone, iphone, galaxy, ipad);

            // act
            var query = new ProductList.Query
            {
                Categories = new[] { smartPhone.Id },
                Name = iphone.Name.Substring(1, 10)
            };

            var result = Send(query);

            // assert
            result.Products.Count().ShouldBe(1);

            result.Products.At(0).Name.ShouldBe(iphone.Name);
            result.Products.At(0).CategoryName.ShouldBe(smartPhone.Name);

            result.Categories.ShouldBe(query.Categories);
            result.Name.ShouldBe(query.Name);
        }
    }
}
