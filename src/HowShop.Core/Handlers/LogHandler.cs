using MediatR;
using SolidR.Core;

namespace HowShop.Core.Handlers
{
    public class LogHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        
        public LogHandler(IRequestHandler<TRequest, TResponse> inner)
        {
            _inner = inner;
        }

        public TResponse Handle(TRequest request)
        {
            App.Log.Info($"Start handling request {request.GetType()}");
            var response = _inner.Handle(request);
            App.Log.Info($"Finished handling request {request.GetType()}");
            return response;
        }
    }
}