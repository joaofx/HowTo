using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;

namespace HowShop.Core.Commands
{
    public class ProductEdit
    {
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
    }
}