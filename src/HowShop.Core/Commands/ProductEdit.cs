using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;
using SolidR.Core;

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
                var command = _db.Products.Where(x => x.Id == message.Id).ProjectToFirstOrDefault<Command>();
                command.Categories = _db.Categories.Select(x => new SelectLookup() { Id = x.Id, DisplayName = x.Name }); // TODO: Conventional way to fill select lookups
                return command;
            }
        }

        public class Command : IRequest
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public IEnumerable<SelectLookup> Categories { get; set; } = new List<SelectLookup>();
            public long CategoryId { get; set; }
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly HowShopContext _db;

            public Handler(HowShopContext db)
            {
                _db = db;
            }

            // TODO: fetch Category on database
            // TODO: set association Product.Category = message.Category
            // TODO: conventional way to handle and tell user when Category does not exist on db

            protected override void HandleCore(Command command)
            {
                var category = _db.Categories.Find(command.CategoryId);
                var product = new Product(command.Name, command.Price);
                Mapper.Map(command, product);
                product.Category = category;
                _db.Products.Add(product);
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Price).GreaterThan(0);
                RuleFor(x => x.CategoryId).NotEmpty();
            }
        }
    }
}