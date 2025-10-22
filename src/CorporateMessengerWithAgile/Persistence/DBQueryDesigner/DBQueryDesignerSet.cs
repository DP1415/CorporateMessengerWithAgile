using Domain.Abstract.DBQueryDesigner;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Persistence.DBQueryDesigner
{
    public class DBQueryDesignerSet<TEntity>
        : AbstractDBQueryDesigner<
            TEntity,
            TEntity[],
            DBQueryDesignerSet<TEntity>
        >
        , IDBQueryDesignerSet<TEntity>
        where TEntity : BaseEntity
    {
        private class QueryCount(AppDbContext dbContext) : AbstractDBQuerySender<TEntity, int>(dbContext)
        {
            protected override Task<int> ExecuteQueryAsync
                (CancellationToken cancellationToken)
                => _query.CountAsync(cancellationToken);
        }
        private class QueryAny(AppDbContext dbContext) : AbstractDBQuerySender<TEntity, bool>(dbContext)
        {
            protected override Task<bool> ExecuteQueryAsync
                (CancellationToken cancellationToken)
                => _query.AnyAsync(cancellationToken);
        }

        public DBQueryDesignerSet(AppDbContext dbContext) : base(dbContext, null!) { _queryFromReturn = this; } //TODO проверить не ломает ли null

        public IDBQuerySender<int> Count => new QueryCount(_dbContext);
        public IDBQuerySender<bool> Any => new QueryAny(_dbContext);
        public IDBQueryDesigner<TEntity, TEntity> First() => new QueryFirst(_dbContext);

        public IDBQueryDesignerSet<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            _query = _query.Where(predicate);
            return this;
        }

        private class QueryFirst(AppDbContext dbContext) : AbstractDBQueryDesigner<TEntity, TEntity>(dbContext)
        {
            protected override Task<TEntity> ExecuteQueryAsync(CancellationToken cancellationToken)
                => _query.FirstAsync(cancellationToken: cancellationToken);
        }

        public IDBQueryDesignerSet<TEntity> Pagination(int indexPage, int sizePage)
        {
            _query = _query.Skip(indexPage * sizePage).Take(sizePage);
            return this;
        }

        protected override Task<TEntity[]> ExecuteQueryAsync(CancellationToken cancellationToken) => _query.ToArrayAsync(cancellationToken);

        IDBQueryDesignerSet<TEntity> IDBQueryDesigner<TEntity, TEntity[], IDBQueryDesignerSet<TEntity>>.Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            return Include(navigationProperty);
        }

        IDBQueryDesignerInclude<TEntity, TEntity[], TProperty, IDBQueryDesignerSet<TEntity>> IDBQueryDesigner<TEntity, TEntity[], IDBQueryDesignerSet<TEntity>>.IncludeWith<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            return (IDBQueryDesignerInclude<TEntity, TEntity[], TProperty, IDBQueryDesignerSet<TEntity>>)IncludeWith(navigationProperty);
        }
    }
}