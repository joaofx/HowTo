using System;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using HowShop.Core.Queries;
using MediatR;
using NUnit.Framework;
using Shouldly;
using SolidR;
using SolidR.TestFx;
using StructureMap;

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
            var mediator = App.Container.GetInstance<IMediator>();
            var iphone = new Product("iPhone", 599.99m);
            var galaxy = new Product("Galaxy", 499.49m);
            var motorola = new Product("Motorola", 355.55m);

            SaveAll(iphone, galaxy, motorola);

            // act
            //var result = Send(new ProductList.Query());
            var result = mediator.Send(new ProductList.Query());

            // assert
            result.Count().ShouldBe(3);
            result.ShouldContain(iphone);
            result.ShouldContain(galaxy);
            result.ShouldContain(motorola);
        }
    }
}
