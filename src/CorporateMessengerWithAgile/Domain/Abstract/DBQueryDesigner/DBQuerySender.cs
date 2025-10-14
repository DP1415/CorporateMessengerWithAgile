namespace Domain.Abstract.DBQueryDesigner
{
    public abstract class DBQuerySender<TResult>
    {
        public abstract Task<TResult> SendAsync(CancellationToken cancellationToken = default);
    }
}
