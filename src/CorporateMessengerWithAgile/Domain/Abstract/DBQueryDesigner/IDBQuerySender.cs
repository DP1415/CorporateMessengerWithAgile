using Domain.Result;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQuerySender<TResult>
    {
        Task<Result<TResult>> SendAsync(CancellationToken cancellationToken = default);
    }
}
