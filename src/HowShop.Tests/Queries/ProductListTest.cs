using System.Collections;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using HowShop.Core.Queries;
using MediatR;
using NUnit.Framework;
using Shouldly;
using SolidR;
using SolidR.TestFx;

namespace HowShop.Tests.Queries
{
    [TestFixture]
    public class ProductListTest : IntegratedTest
    {
        [Test]
        public void Should_list_products()
        {
            var mediator = App.Container.GetInstance<IMediator>();

            // arrange
            var iphone = new Product("iPhone", 599.99m);
            var galaxy = new Product("Galaxy", 499.49m);
            var motorola = new Product("Motorola", 355.55m);

            using (var db = new DatabaseContext())
            {
                db.Products.Add(iphone);
                db.Products.Add(galaxy);
                db.Products.Add(motorola);

                db.SaveChanges();
            }

            var query = new ProductList.Query();

            // act
            var result = mediator.Send(query);

            // assert
            result.Count().ShouldBe(3);
            result.ShouldContain(iphone);
            result.ShouldContain(galaxy);
            result.ShouldContain(motorola);
        }
    }
}
