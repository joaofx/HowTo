using System.Linq;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using NUnit.Framework;
using Shouldly;

namespace HowTo.IntegratedTests.Commands
{
    [TestFixture]
    public class UserEditTest : IntegratedTest
    {
        [Test]
        public void Should_save()
        {
            // arrange
            var command = new UserEdit.Command
            {
                Name = "John Lennon",
                Email = "john@shop.com",
                Password = "123",
                ConfirmPassword = "123",
                Profile = Profile.Admin
            };

            // act
            Send(command);

            // assert
            WithDb(db =>
            {
                var user = db.Users.Single();
                user.Name.ShouldBe(command.Name);
                user.Email.ShouldBe(command.Email);
                user.Password.ShouldBe(command.Password);
                user.Profile.ShouldBe(command.Profile);
            });
        }
    }
}
