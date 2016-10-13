using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NodaTime;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;

namespace HowTo.IntegratedTests.HowTo
{
    [TestFixture]
    public class BuddyPropertyTest : IntegratedTest
    {
        [Test]
        public void Should_save_not_primitive_type()
        {
            // arrange
            using (var db = new HowShopContext())
            {
                var dublin = new Store("Dublin", new LocalTime(9, 0), new LocalTime(19, 0));
                //var amsterdam = new Store("Amsterdam", new LocalTime(9, 0), new LocalTime(18, 0));

                db.Stores.Add(dublin);
                //db.Stores.Add(amsterdam);

                db.SaveChanges();
            }

            using (var db = new HowShopContext())
            {
                var dublin = db.Stores.FirstOrDefault(x => x.Name == "Dublin");

                dublin.OpenAt.ShouldBe(new LocalTime(9, 0));
                //dublin.CloseAt.ShouldBe(new LocalTime(19, 0));
            }
        }
    }
}
