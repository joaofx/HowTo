using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;
using static HowTo.IntegratedTests.Testing;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class ProductEditTest : IntegratedTest
    {
        [Test]
        public void Should_save()
        {
            // arrange
            var command = new ProductEdit.Command
            {
                Name = "Ferrari",
                Price = 150900.99m
            };

            // act
            Send(command);

            // assert
            WithDb(db =>
            {
                var product = db.Products.Single();
                product.Name.ShouldBe(command.Name);
                product.Price.ShouldBe(command.Price);
            });
        }
    }
}
