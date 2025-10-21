using Domain.Abstract.DBQueryDesigner;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.DBQueryDesigner
{
    public class DBQueryDesignerInclude<TEntity, TResult, TFirstProperty, TQuery>
        : IDBQueryDesignerInclude<TEntity, TResult, TFirstProperty, TQuery>
        where TEntity : BaseEntity
        where TQuery : AbstractDBQuerySender<TEntity, TResult>
    {
        private readonly TQuery _queryFromReturn;
        private readonly Expression<Func<TEntity, TFirstProperty>> _navigationFirstProperty;

        public DBQueryDesignerInclude(
            TQuery queryFromReturn,
            Expression<Func<TEntity, TFirstProperty>> navigationFirstProperty)
        {
            _queryFromReturn = queryFromReturn;
            _navigationFirstProperty = navigationFirstProperty;
        }

        public IDBQueryDesignerInclude<TEntity, TResult, TFirstProperty, TQuery> And<TProperty>(
            Expression<Func<TFirstProperty, TProperty>> navigationProperty)
        {
            _queryFromReturn._query = _queryFromReturn._query.Include(_navigationFirstProperty).ThenInclude(navigationProperty);
            return this;
        }

        public IDBQueryDesignerInclude<TEntity, TResult, TNextProperty, TQuery> AlongWich<TNextProperty>(
            Expression<Func<TFirstProperty, TNextProperty>> navigationProperty)
        {
            _queryFromReturn._query = _queryFromReturn._query.Include(_navigationFirstProperty).ThenInclude(navigationProperty);

            Expression<Func<TEntity, TNextProperty>> navigationFirstProperty =
                entity => navigationProperty.Compile()(_navigationFirstProperty.Compile()(entity));
            //entity =>
            //{
            //    Func<TEntity, TFirstProperty> fanc_E_FP = _navigationFirstProperty.Compile();
            //    TFirstProperty fp = fanc_E_FP(entity);
            //    Func<TFirstProperty, TNextProperty> fanc_FP_NP = navigationProperty.Compile();
            //    TNextProperty np = fanc_FP_NP(fp);
            //    return np;
            //}

            DBQueryDesignerInclude<TEntity, TResult, TNextProperty, TQuery> result = new(_queryFromReturn, navigationFirstProperty);
            return result;
        }

        public TQuery Then => _queryFromReturn;
    }
}