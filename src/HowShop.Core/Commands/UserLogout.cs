using HowShop.Core.Concerns;
using MediatR;

namespace HowShop.Core.Commands
{
    public class UserLogout
    {
        public class Command : IRequest
        {
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly IUserSession _userSession;

            public Handler(IUserSession userSession)
            {
                _userSession = userSession;
            }

            protected override void HandleCore(Command message)
            {
                _userSession.Logout();
            }
        }
    }
}