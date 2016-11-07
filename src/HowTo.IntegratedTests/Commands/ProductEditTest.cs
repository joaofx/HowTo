using System.Data.Entity;
using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using NUnit.Framework;
using Shouldly;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class ProductEditTest : IntegratedTest
    {
        [Test]
        public void Should_save()
        {
            // arrange
            var category = Fixture.Create<Category>();
            SaveAll(category);
            var command = new ProductEdit.Command
            {
                Name = "Ferrari",
                Price = 150900.99m,
                CategoryId = category.Id
            };

            // act
            Send(command);

            // assert
            WithDb(db =>
            {
                var product = db.Products.Include(x => x.Category).Single();
                product.Name.ShouldBe(command.Name);
                product.Price.ShouldBe(command.Price);
                product.Category.ShouldBe(category);
            });
        }
    }
}
