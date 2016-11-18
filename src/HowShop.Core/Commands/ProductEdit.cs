using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;
using SolidR.Core.Domain;

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
                var command = _db.Products.Where(x => x.Id == message.Id).ProjectToFirstOrDefault<Command>();
                command.Categories = _db.Categories.Select(x => new Lookup {Id = x.Id, DisplayName = x.Name}).ToList();
                return command;
                //return new Command
                //{
                //    Name = product.Name,
                //    Price = product.Price,
                //};
            }
        }

        public class Command : IRequest
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public IEnumerable<Lookup> Categories { get; set; } = new List<Lookup>();
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
                //var category = _db.Categories.Find(command.Category.Id);
                //var product = new Product(command.Name, command.Price);
                //product.Category = category;
                //_db.Products.Add(product);
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

    public class Lookup : ILookupable
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
    }
}