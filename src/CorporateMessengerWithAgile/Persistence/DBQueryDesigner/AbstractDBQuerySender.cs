using Domain.Abstract.DBQueryDesigner;
using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DBQueryDesigner
{
    public abstract class AbstractDBQuerySender<TEntity, TResult> : IDBQuerySender<TResult> where TEntity : BaseEntity
    {
        internal readonly AppDbContext _dbContext;
        internal IQueryable<TEntity> _query;

        public AbstractDBQuerySender(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _query = _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<Result<TResult>> SendAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await ExecuteQueryAsync(cancellationToken);
            }
            catch (CustomException customException)
            {
                return customException;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected abstract Task<TResult> ExecuteQueryAsync(CancellationToken cancellationToken);
    }
}