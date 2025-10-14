using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesigner<TEntity, TResult, TQuery>
        : IDBQuerySender<TResult>
        where TEntity : BaseEntity
        where TQuery : IDBQuerySender<TResult>
    {
        TQuery Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
    }
}
