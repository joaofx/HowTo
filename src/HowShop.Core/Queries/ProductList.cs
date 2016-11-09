using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
                var query = _db.Products
                    .Include(x => x.Category);

                if (message.Name.NotEmpty())
                    query = query.Where(x => x.Name.Contains(message.Name));

                if (message.Categories.NotEmpty())
                    query = query.WhereIn(x => x.CategoryId, message.Categories);

                var result = new Result()
                {
                    Products = query.ProjectTo<Product>().Future(),
                    ListOfCategories = _db.Categories.Future()
                };

                Mapper.Map(message, result);

                return result;
            }
        }

        public class Result
        {
            public string Name { get; set; }
            public long[] Categories { get; set; }
            public IEnumerable<Product> Products { get; set; }
            public IEnumerable<Category> ListOfCategories { get; set; }
        }

        public class Product
        {
            public string Name { get; set; }
            public string CategoryName { get; set; }
            public decimal Price { get; set; }
            public long Id { get; set; }
        }
    }
}