using System.Linq;
using HowShop.Core;
using HowShop.Core.Domain;
using HowShop.Core.Queries;
using MediatR;
using NUnit.Framework;
using Shouldly;
using SolidR;
using SolidR.TestFx;
using static HowTo.IntegratedTests.Testing;

namespace HowTo.IntegratedTests.Queries
{
    [TestFixture]
    public class UserListTest : IntegratedTest
    {
        [Test]
        public void Should_list_users()
        {
            // arrange
            var admin = Fixtures.Create<User>(_ => _.Profile = Profile.Admin);
            var user2 = Fixtures.Create<User>();
            var user3 = Fixtures.Create<User>();

            SaveAll(admin, user2, user3);

            TestUserSession.CurrentUser = () => admin;

            // act
            var result = Send(new UserList.Query());

            // assert
            // TODO: compare all properties
            result.Count().ShouldBe(3);
            result.ShouldContain(admin);
            result.ShouldContain(user2);
            result.ShouldContain(user3);
        }

        [Test]
        [ExpectedException(typeof(UnauthorizedException))]
        public void Should_throw_exception_when_user_has_no_authorization()
        {
            // arrange
            var user2 = Fixtures.Create<User>(_ => _.Profile = Profile.Customer);
            TestUserSession.CurrentUser = () => user2;

            // act & assert
            Send(new UserList.Query());
        }
    }
}
