using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;

namespace HowTo.IntegratedTests.HowTo.HowToEntityFramework
{
    [TestFixture]
    public class SoftDeleteTest : IntegratedTest
    {
        [Test]
        public void When_deleting_ISoftDeletable_entity_should_update_IsDeleted_to_true_and_not_bringing_it_in_normal_queries()
        {
            // arrange
            using (var db = new HowShopContext())
            {
                db.Users.Add(new User("John", "admin@admin.com", "123"));
                db.Users.Add(new User("Paul", "admin@admin.com", "123"));
                db.Users.Add(new User("Ringo", "admin@admin.com", "123"));
                db.Users.Add(new User("George", "admin@admin.com", "123"));

                db.SaveChanges();
            }

            // act
            using (var db = new HowShopContext())
            {
                var john = db.Users.Single(x => x.Name == "John");
                john.IsDeleted = true;
                db.SaveChanges();
            }

            // assert
            using (var db = new HowShopContext())
            {
                db.Users.Count(x => x.Name == "John").ShouldBe(0);
                db.Users.Count().ShouldBe(3); // beatles without john
            }
        }
    }
}
