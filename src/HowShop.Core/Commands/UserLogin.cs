using System.Linq;
using System.Security.Claims;
using System.Web;
using FluentValidation;
using HowShop.Core.Concerns;
using HowShop.Core.Infra;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SolidR.Core;

namespace HowShop.Core.Commands
{
    public class UserLogin
    {
        public class Command : IRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly HowShopContext _db;
            private readonly IUserSession _userSession;

            public Handler(HowShopContext db, IUserSession userSession)
            {
                _db = db;
                _userSession = userSession;
            }

            protected override void HandleCore(Command message)
            {
                var user = _db.Users
                    .Where(x => x.Email == message.Email)
                    .Where(x => x.Password == message.Password)
                    .SingleOrDefault();

                if (user == null)
                    throw new BusinessRulesException("Email and password not found");

                _userSession.Login(user, message.RememberMe);
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }
}