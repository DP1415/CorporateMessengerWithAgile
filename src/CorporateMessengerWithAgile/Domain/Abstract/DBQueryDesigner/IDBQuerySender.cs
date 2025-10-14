namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQuerySender<TResult>
    {
        Task<TResult> SendAsync(CancellationToken cancellationToken = default);
    }
}
