using MediatR;

namespace HowShop.Core.Queries
{
    public class AdminList
    {
        public class Query : IRequest
        {
        }

        public class Handler : RequestHandler<Query>
        {
            protected override void HandleCore(Query message)
            {
            }
        }
    }
}