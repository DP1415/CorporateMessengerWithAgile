using Domain.Abstract.DBQueryDesigner;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.DBQueryDesigner
{

    public abstract class AbstractDBQueryDesigner<TEntity, TResult, TDBQuery>
        : AbstractDBQuerySender<TEntity, TResult>
        , IDBQueryDesigner<TEntity, TResult, TDBQuery>
        where TEntity : BaseEntity
        where TDBQuery : AbstractDBQuerySender<TEntity, TResult>
    {
        protected TDBQuery _queryFromReturn;

        protected AbstractDBQueryDesigner(AppDbContext dbContext, TDBQuery queryFromReturn) : base(dbContext)
        {
            _queryFromReturn = queryFromReturn;
        }

        public
            TDBQuery
            Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            _query = _query.Include(navigationProperty);
            return _queryFromReturn;
        }

        public
            IDBQueryDesignerInclude<TEntity, TResult, TProperty, TDBQuery>
            IncludeWith<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            _query = _query.Include(navigationProperty);
            var result = new DBQueryDesignerInclude<TEntity, TResult, TProperty, TDBQuery>(_queryFromReturn, navigationProperty);
            return result;
        }
    }

    public abstract class AbstractDBQueryDesigner<TEntity, TResult>
        : AbstractDBQueryDesigner<
            TEntity,
            TResult,
            AbstractDBQueryDesigner<TEntity, TResult>
            >
        , IDBQueryDesigner<TEntity, TResult>
        where TEntity : BaseEntity
    {
        protected AbstractDBQueryDesigner(AppDbContext dbContext) : base(dbContext, null!)
        {
            _queryFromReturn = this;
        }


        IDBQueryDesigner<TEntity, TResult>
            IDBQueryDesigner<TEntity, TResult, IDBQueryDesigner<TEntity, TResult>>.Include<TProperty>
            (Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            return Include(navigationProperty);
        }

        IDBQueryDesignerInclude<TEntity, TResult, TProperty, IDBQueryDesigner<TEntity, TResult>>
            IDBQueryDesigner<TEntity, TResult, IDBQueryDesigner<TEntity, TResult>>.IncludeWith<TProperty>
            (Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            return
                (IDBQueryDesignerInclude<TEntity, TResult, TProperty, IDBQueryDesigner<TEntity, TResult>>)
                IncludeWith(navigationProperty);
        }

        //public IDBQueryDesigner<TEntity, TResult> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        //{
        //    _query = _query.Include(navigationProperty);
        //    return this;
        //}

        //public IDBQueryDesignerInclude<TEntity, TResult, TProperty, IDBQueryDesigner<TEntity, TResult>>
        //    IncludeWich<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        //{
        //    _query = _query.Include(navigationProperty);
        //    var result = new DBQueryDesignerInclude<TEntity, TResult, TProperty, AbstractDBQueryDesigner<TEntity, TResult>>(this, navigationProperty);
        //    return (IDBQueryDesignerInclude<TEntity, TResult, TProperty, IDBQueryDesigner<TEntity, TResult>>)result;
        //    //_query = _query.Include(navigationProperty);
        //    //IDBQueryDesignerInclude<TEntity, TResult, TProperty, IDBQueryDesigner<TEntity, TResult>>
        //    //    result = new
        //    //    DBQueryDesignerInclude<TEntity, TResult, TProperty, AbstractDBQueryDesigner<TEntity, TResult>>
        //    //    (this, navigationProperty);
        //    //return result;
        //}
    }
}