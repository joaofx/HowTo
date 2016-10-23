using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using NodaMoney;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;
using static HowTo.IntegratedTests.Testing;

namespace HowTo.IntegratedTests.HowTo.HowToEntityFramework
{
    [TestFixture]
    public class BuddyPropertyTest : IntegratedTest
    {
        [Test]
        public void Should_save()
        {
            // arrange
            var admin = new User("Admin");
            admin.ChangeSettings(new UserSettingsEdit.Command
            {
                Language = Language.FromId("pt_BR")
            });
            SaveAll(admin);

            // assert
            WithDb(db =>
            {
                var user = db.Users.Single();
                user.Language.Id.ShouldBe("pt_BR");
            });
        }

        [Test]
        public void Should_query_value_property()
        {
            // arrange
            var admin = new User("Admin");
            admin.ChangeSettings(new UserSettingsEdit.Command
            {
                Language = Language.FromId("pt_BR")
            });
            SaveAll(admin);

            // assert
            WithDb(db =>
            {
                var user = db.Users.Single(x => x.LanguageValue == "pt_BR");
                user.Language.Id.ShouldBe("pt_BR");
            });
        }
    }
}
