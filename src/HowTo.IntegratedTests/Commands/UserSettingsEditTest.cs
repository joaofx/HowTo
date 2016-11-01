using System;
using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Concerns;
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
            var admin = Fixtures.Create<User>();
            SaveAll(admin);

            // act
            Send(new UserSettingsEdit.Command
            {
                UserId = admin.Id,
                Language = Language.FromId("pt_BR"),
                Culture = Culture.FromId("pt_BR"),
                // TODO: change to NodaTime
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time"),
                Currency = Currency.FromCode("EUR")
            });

            // assert
            WithDb(db =>
            {
                var user = db.Users.Single();
                user.Name.ShouldBe(admin.Name);
                user.Language.Id.ShouldBe("pt_BR");
                user.Culture.Id.ShouldBe("pt_BR");
                user.TimeZone.Id.ShouldBe("Tokyo Standard Time");
                user.Currency.Code.ShouldBe("EUR");
            });
        }
    }
}
