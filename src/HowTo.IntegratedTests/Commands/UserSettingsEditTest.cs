using System;
using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using NodaMoney;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;
using static HowTo.IntegratedTests.Testing;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class UserSettingsEditTest : IntegratedTest
    {
        [Test]
        public void Should_save()
        {
            // arrange
            var admin = new User("Admin");
            SaveAll(admin);

            // act
            Send(new UserSettingsEdit.Command
            {
                UserId = admin.Id,
                Language = "pt-BR",
                Culture = "pt_BR",
                TimeZone = "1200",
                Currency = Currency.FromCode("EUR")
            });

            // assert
            WithDb(db =>
            {
                var user = db.Users.Single();
                user.Name.ShouldBe(admin.Name);
                user.Language.ShouldBe("pt-BR");
                user.Culture.ShouldBe("pt_BR");
                user.TimeZone.ShouldBe(1200);
                user.Currency.Code.ShouldBe("EUR");

                //var byBuddyProp = db.Users.Single(x => x.Currency == Currency.FromCode("EUR"));
                //byBuddyProp.ShouldBe(user);
            });
        }
    }
}
