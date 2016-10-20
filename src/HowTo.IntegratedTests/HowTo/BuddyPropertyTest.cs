using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NodaMoney;
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

        [Test]
        public void Should_save_complex_type()
        {
            // arrange
            using (var db = new HowShopContext())
            {
                var joao = new User("Joao");

                joao.ChangeSettings(new UserSettingsEdit.Command
                {
                    Currency = Currency.FromCode("EUR")
                });
                
                db.Users.Add(joao);

                db.SaveChanges();
            }

            using (var db = new HowShopContext())
            {
                var user = db.Users.First();
                user.Currency.Code.ShouldBe("EUR");
            }
        }
    }
}
