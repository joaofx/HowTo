using FluentValidation;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;

namespace HowShop.Core.Commands
{
    public class ProductEdit
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
                var product = _db.Products.Find(message.Id);

                return new Command
                {
                    Name = product.Name,
                    Price = product.Price
                };
            }
        }

        public class Command : IRequest
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
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
                var product = new Product(message.Name, message.Price);
                _db.Products.Add(product);
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Price).GreaterThan(0);
            }
        }
    }
}