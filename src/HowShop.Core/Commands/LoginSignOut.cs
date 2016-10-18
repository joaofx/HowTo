using HowShop.Core.Security;
using MediatR;

namespace HowShop.Core.Commands
{
    public class LoginSignOut
    {
        public class Command : IRequest
        {
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly UserSession _userSession;

            public Handler(UserSession userSession)
            {
                _userSession = userSession;
            }

            protected override void HandleCore(Command message)
            {
                _userSession.SignOut();
            }
        }
    }
}