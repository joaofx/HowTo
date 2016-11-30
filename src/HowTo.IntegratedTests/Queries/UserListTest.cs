using System.Linq;
using HowShop.Core;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using NUnit.Framework;
using Ploeh.SemanticComparison;
using Ploeh.SemanticComparison.Fluent;
using Shouldly;
using SolidR.Core;
using SolidR.TestSupport;

namespace HowTo.IntegratedTests.Queries
{
    [TestFixture]
    public class UserListTest : IntegratedTest
    {
        [Test]
        public void Should_list_users()
        {
            // arrange
            var admin = Fixture.Create<User>(_ => _.Profile = Profile.Admin);
            var user2 = Fixture.Create<User>();
            var user3 = Fixture.Create<User>();

            SaveAll(admin, user2, user3);

            TestUserSession.CurrentUser = () => admin;

            // act
            var result = Send(new UserList.Query());

            // assert
            // TODO: compare all properties
            result.Count().ShouldBe(3);
            //result.At(0).AsSource().OfLikeness<User>().ShouldEqual(admin);
            result.ShouldContain(admin);
            result.ShouldContain(user2);
            result.ShouldContain(user3);
        }

        [Test]
        [ExpectedException(typeof(UnauthorizedException))]
        public void Should_throw_exception_when_user_has_no_authorization()
        {
            // arrange
            var userWithNotAuthorizedProfile = Fixture.Create<User>(_ => _.Profile = Profile.Customer);
            TestUserSession.CurrentUser = () => userWithNotAuthorizedProfile;

            // act & assert
            Send(new UserList.Query());
        }
    }
}
