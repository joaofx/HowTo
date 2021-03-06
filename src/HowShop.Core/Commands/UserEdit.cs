using FluentValidation;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;

namespace HowShop.Core.Commands
{
    public class UserEdit
    {
        public class Query : IRequest<Command>
        {
            public long Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Command>
        {
            private readonly HowShopContext _db;

            public QueryHandler(HowShopContext db)
            {
                _db = db;
            }

            public Command Handle(Query message)
            {
                // TODO: use automapper
                var user = _db.Users.Find(message.Id);

                return new Command
                {
                    Name = user.Name,
                    Email = user.Email,
                    Profile = user.Profile
                };
            }
        }

        public class Command : IRequest
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public Profile Profile { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly HowShopContext _db;

            public Handler(HowShopContext db)
            {
                _db = db;
            }

            protected override void HandleCore(Command message)
            {
                // TODO: hash password
                // TODO: can't change password
                var user = new User(message);
                _db.Users.Add(user);
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).NotEmpty().Equal(x => x.ConfirmPassword);
                RuleFor(x => x.ConfirmPassword).NotEmpty();
            }
        }
    }
}