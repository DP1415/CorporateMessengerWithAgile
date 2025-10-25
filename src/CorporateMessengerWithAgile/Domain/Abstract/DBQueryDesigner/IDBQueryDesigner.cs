using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesigner<TEntity, TResult, TDBQuery>
        : IDBQuerySender<TResult>
        where TEntity : BaseEntity
        where TDBQuery : IDBQuerySender<TResult>
    {
        TDBQuery Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
        IDBQueryDesignerInclude<TEntity, TResult, TProperty, TDBQuery>
            IncludeWith<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
    }

    public interface IDBQueryDesigner<TEntity, TResult>
        : IDBQueryDesigner<
            TEntity,
            TResult,
            IDBQueryDesigner<TEntity, TResult>
            >
        where TEntity : BaseEntity
    { }
}
