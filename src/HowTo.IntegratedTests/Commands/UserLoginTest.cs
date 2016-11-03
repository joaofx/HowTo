﻿using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using SolidR.Core;
using SolidR.TestFx;
using static HowTo.IntegratedTests.Testing;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class UserLoginTest : IntegratedTest
    {
        [Test]
        public void Should_login_user()
        {
            // arrange
            var userSession = Substitute.For<IUserSession>();

            // TODO: using global container. If we use child container, 
            // no problem we inject another instance other than was configured by registry
            App.Container.EjectAllInstancesOf<IUserSession>();
            App.Container.Inject(userSession);

            var john = Fixtures.Create<User>();

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
