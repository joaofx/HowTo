using HowShop.Core.Concerns;
using HowShop.Core.Domain;
using MediatR;
using SolidR.Core;

namespace HowShop.Core.Handlers
{
    public class AuthorizationHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly IAuthorization<TRequest>[] _authorization;
        private readonly IUserSession _userSession;

        public AuthorizationHandler(
            IRequestHandler<TRequest, TResponse> inner, 
            IAuthorization<TRequest>[] authorization, 
            IUserSession userSession)
        {
            _inner = inner;
            _authorization = authorization;
            _userSession = userSession;
        }

        public TResponse Handle(TRequest request)
        {
            foreach (var authorization in _authorization)
            {
                if (_userSession.IsLogged == false)
                {
                    App.Log.Info($"Current user is not logged to access {authorization.Feature}");
                    throw new UnauthorizedException(authorization.Feature);
                }

                if (_userSession.User.Profile.DoNotHaveAccessTo(authorization.Feature))
                {
                    App.Log.Info($"Current user {_userSession.User.Name} does not have access to {authorization.Feature}");
                    throw new UnauthorizedException(authorization.Feature);
                }
            }

            return _inner.Handle(request);
        }
    }
}