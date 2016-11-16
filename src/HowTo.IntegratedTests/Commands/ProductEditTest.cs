using System.Data.Entity;
using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using NUnit.Framework;
using Shouldly;
using SolidR.Core;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class ProductEditTest : IntegratedTest
    {
        [Test]
        public void Should_handle_command()
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

        [Test]
        public void Should_handle_query()
        {
            // arrange
            var category = Fixture.Create<Category>();
            var otherCategory = Fixture.Create<Category>();
            var product = Fixture.Create<Product>(x => x.Category = category);

            SaveAll(category, otherCategory, product);

            var command = new ProductEdit.Query
            {
                Id = product.Id
            };

            // act
            var result = Send(command);

            result.Name.ShouldBe(product.Name);
            result.Price.ShouldBe(product.Price);
            result.CategoryId.ShouldBe(product.CategoryId);
            result.Categories.Count().ShouldBe(2);
            result.Categories.At(0).DisplayName.ShouldContain(category.DisplayName);
            result.Categories.At(1).DisplayName.ShouldContain(otherCategory.DisplayName);
        }
    }
}
