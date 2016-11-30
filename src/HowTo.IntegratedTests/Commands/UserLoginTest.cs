using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using SolidR.Core;
using SolidR.TestSupport;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class UserLoginTest : IntegratedTest
    {
        [Test]
        public void Should_login_user()
        {
            // arrange
            var userSession = Fixture.Mock<IUserSession>();
            var john = Fixture.Create<User>();

            SaveAll(john);

            // act
            Send(new UserLogin.Command()
            {
                Email = john.Email,
                Password = john.Password,
                RememberMe = true
            });

            // assert
            userSession.Received().Login(john, true);
        }
    }
}
