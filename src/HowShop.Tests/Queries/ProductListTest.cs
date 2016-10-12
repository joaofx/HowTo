using System;
using System.Collections.Generic;
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

namespace HowShop.Tests.Queries
{
    [TestFixture]
    public class ProductListTest : IntegratedTest
    {
        [Test]
        public void Should_list_products()
        {
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
            var result = Send(query);

            // assert
            result.Count().ShouldBe(3);
            result.ShouldContain(iphone);
            result.ShouldContain(galaxy);
            result.ShouldContain(motorola);
        }

        //protected void SendCommand(IRequest message)
        //{
        //    SendCommand((IRequest<Unit>)message);
        //}

        protected TResult Send<TResult>(IRequest<TResult> message)
        {
            using (var nestedContainer = App.Container.GetNestedContainer())
            {
                var result = default(TResult);

                WithDb(nestedContainer, (db, container) =>
                {
                    var mediator = container.GetInstance<IMediator>();
                    result = mediator.Send(message);
                });

                return result;
            }
        }

        public void WithDb(IContainer container, Action<DatabaseContext, IContainer> action)
        {
            using (var db = container.GetInstance<DatabaseContext>())
            {
                try
                {
                    db.BeginTransaction();
                    action(db, container);
                    db.CloseTransaction();
                }
                catch (Exception e)
                {
                    db.CloseTransaction(e);
                    throw;
                }
            }
        }
    }
}
