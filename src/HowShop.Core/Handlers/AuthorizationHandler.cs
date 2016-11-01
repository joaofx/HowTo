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
        private readonly IAuthorization<TRequest> _authorization;
        private readonly IUserSession _userSession;

        public AuthorizationHandler(IRequestHandler<TRequest, TResponse> inner, IAuthorization<TRequest> authorization, IUserSession userSession)
        {
            _inner = inner;
            _authorization = authorization;
            _userSession = userSession;
        }

        public TResponse Handle(TRequest request)
        {
            if (_userSession.User.Profile.DoNotHaveAccessTo(_authorization.Feature))
            {
                App.Log.Info($"Current user {_userSession.User.Name} does not have access to {_authorization.Feature}");
                throw new UnauthorizedException(_authorization.Feature);
            }

            return _inner.Handle(request);
        }
    }
}