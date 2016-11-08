using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;
using SolidR.Core;
using SolidR.Core.EntityFramework;
using Z.EntityFramework.Plus;

namespace HowShop.Core.Queries
{
    public class ProductList
    {
        public class Query : IRequest<Result>
        {
            public string Name { get; set; }
            public long[] Categories { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result>
        {
            private readonly HowShopContext _db;

            public Handler(HowShopContext db)
            {
                _db = db;
            }

            public Result Handle(Query message)
            {
                // TODO: Automapper between Query and Result filter properties
                // TODO: Projection to select only fields used by screen
                // TODO: Use ToFuture to query Products and Categories in one round trip

                var query = _db.Products
                    .Include(x => x.Category);

                if (message.Name.NotEmpty())
                    query = query.Where(x => x.Name.Contains(message.Name));

                if (message.Categories.NotEmpty())
                    query = query.WhereIn(x => x.CategoryId, message.Categories);

                return new Result
                {
                    Products = query.Future(),
                    Name = message.Name,
                    Categories = message.Categories,
                    ListOfCategories = _db.Categories.Future()
                };
            }
        }

        public class Result
        {
            public string Name { get; set; }
            public long[] Categories { get; set; }
            public IEnumerable<Product> Products { get; set; }
            public IEnumerable<Category> ListOfCategories { get; set; }
        }
    }
}