using System;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using HowToEntityFramework.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;

namespace HowToEntityFramework.HowTo
{
    [TestFixture]
    public class SoftDeleteTest : IntegratedTest
    {
        [Test]
        public void When_deleting_ISoftDeletable_entity_should_update_IsDeleted_to_true_and_not_bringing_it_in_normal_queries()
        {
            // arrange
            using (var db = new DatabaseContext())
            {
                db.Users.Add(new User("John", 20));
                db.Users.Add(new User("Paul", 30));
                db.Users.Add(new User("Ringo", 40));
                db.Users.Add(new User("George", 50));

                db.SaveChanges();
            }

            // act
            using (var db = new DatabaseContext())
            {
                var john = db.Users.Single(x => x.Name == "John");
                john.IsDeleted = true;
                db.SaveChanges();
            }

            // assert
            using (var db = new DatabaseContext())
            {
                db.Users.Count(x => x.Name == "John").ShouldBe(0);
                db.Users.Count().ShouldBe(3); // beatles without john
            }
        }
    }
}
