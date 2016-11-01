using System.Collections.Generic;
using System.Linq;
using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using MediatR;

namespace HowShop.Core.Queries
{
    public class UserList
    {
        public class Query : IRequest<IEnumerable<User>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<User>>
        {
            private readonly HowShopContext _db;

            public Handler(HowShopContext db)
            {
                _db = db;
            }

            public IEnumerable<User> Handle(Query message)
            {
                return _db.Users.ToList();
            }
        }

        public class Authorization : IAuthorization<Query>
        {
            public Feature Feature => Feature.ManageUsers;
        }
    }
}