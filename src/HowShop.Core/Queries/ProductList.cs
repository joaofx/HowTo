using System.Collections.Generic;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;

namespace HowShop.Core.Queries
{
    public class ProductList
    {
        public class Query : IRequest<IEnumerable<Product>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Product>>
        {
            private readonly HowShopContext _db;

            public Handler(HowShopContext db)
            {
                _db = db;
            }

            public IEnumerable<Product> Handle(Query message)
            {
                return _db.Products.ToList();
            }
        }
    }
}