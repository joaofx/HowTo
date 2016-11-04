using System.Collections.Generic;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;
using SolidR.Core;

namespace HowShop.Core.Queries
{
    public class ProductList
    {
        public class Query : IRequest<IEnumerable<Product>>
        {
            public string Name { get; set; }
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
                var query = _db.Products;

                if (message.Name.NotEmpty())
                    query.Where(x => x.Name.Contains(message.Name));

                return query.ToList();
            }
        }
    }
}