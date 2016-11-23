using System;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.Core;
using SolidR.TestFx;

namespace HowTo.IntegratedTests.HowTo.HowToEntityFramework
{
    [TestFixture]
    public class AuditableTest : IntegratedTest
    {
        [Test]
        public void When_creating_or_updating_Auditable_should_fill_auditable_properties()
        {
            var createdAt = new DateTime(2016, 1, 2, 3, 4, 5);
            var updatedAt = new DateTime(2017, 6, 7, 8, 9, 10);

            // arrange & CreateAt
            App.Clock = () => createdAt;

            WithDb(db =>
            {
                db.Products.Add(new Product("iPhone", 599));
                db.Products.Add(new Product("Galaxyyy", 499));
                db.Products.Add(new Product("Motorola", 399));

                db.SaveChanges();
            });

            // act & UpdateAt
            App.Clock = () => updatedAt;

            WithDb(db =>
            {
                var galaxy = db.Products.Single(x => x.Name == "Galaxyyy");
                galaxy.Edit("Galaxy");
                db.SaveChanges();
            });

            // assert
            WithDb(db =>
            {
                var galaxy = db.Products.Single(x => x.Name == "Galaxy");
                galaxy.Audit.CreatedAt.ShouldBe(createdAt);
                galaxy.Audit.UpdatedAt.ShouldBe(updatedAt);
            });
        }
    }
}
