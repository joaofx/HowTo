using System.Data;
using System.Data.Entity;
using MediatR;

namespace SolidR.Handlers
{
    public class TransactionHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly DbContext _dbContext;

        public TransactionHandler(IRequestHandler<TRequest, TResponse> inner, DbContext dbContext)
        {
            _inner = inner;
            _dbContext = dbContext;
        }

        public TResponse Handle(TRequest message)
        {
            using (var transaction = _dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var response = _inner.Handle(message);

                    _dbContext.SaveChanges();
                    transaction.Commit();

                    return response;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}