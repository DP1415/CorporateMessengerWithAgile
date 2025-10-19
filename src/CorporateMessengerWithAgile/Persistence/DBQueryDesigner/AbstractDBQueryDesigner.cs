using Domain.Abstract.DBQueryDesigner;
using Domain.Common;
using Domain.Result;
using System.Linq.Expressions;

namespace Persistence.DBQueryDesigner
{
    public abstract class AbstractDBQuerySender<TResult> : IDBQuerySender<TResult>
    {
        protected readonly AppDbContext _dbContext;

        public AbstractDBQuerySender(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TResult> SendAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AbstractDBQueryDesigner<TEntity, TResult, TQuery>
        : AbstractDBQuerySender<TResult>
        where TEntity : BaseEntity
        where TQuery : IDBQuerySender<TResult>
    {
        public AbstractDBQueryDesigner(AppDbContext dbContext) : base(dbContext)
        {
        }

        public TQuery Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            throw new NotImplementedException();
        }
        public IDBQueryDesignerInclude<TEntity, TResult, TProperty, TQuery> IncludeWich<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AbstractDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TQuery>
        where TEntity : BaseEntity
        where TQuery : IDBQuerySender<TResult>
    {
        public IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TQuery> And<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty)
        {
            throw new NotImplementedException();
        }
        public IDBQueryDesignerInclude<TEntity, TResult, TNextProperty, TQuery> AlongWich<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty)
        {
            throw new NotImplementedException();
        }

        public TQuery Then
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }



    public abstract class AbstractDBQueryDesignerSet<TEntity>
        : AbstractDBQueryDesigner<
            TEntity,
            Result<TEntity[]>,
            IDBQueryDesignerSet<TEntity>
            >
        where TEntity : BaseEntity
    {
        public AbstractDBQueryDesignerSet(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IDBQueryDesigner<TEntity, Result<TEntity>, IDBQueryDesignerSingular<TEntity>> First()
        {
            throw new NotImplementedException();
        }

        public IDBQueryDesignerSet<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IDBQueryDesignerSet<TEntity> Pagination(int indexPage, int sizePage)
        {
            throw new NotImplementedException();
        }
        public IDBQuerySender<int> Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public IDBQuerySender<bool> Any
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }


    public abstract class AbstractDBQueryDesignerSingular<TEntity>
        : AbstractDBQueryDesigner<
            TEntity,
            Result<TEntity>,
            IDBQueryDesignerSingular<TEntity>
            >
        where TEntity : BaseEntity
    {
        protected AbstractDBQueryDesignerSingular(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IDBQueryDesigner<TEntity, Result<TEntity>, IDBQueryDesignerSingular<TEntity>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDBQueryDesigner<TEntity, Result<TEntity>, IDBQueryDesignerSingular<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }

}
