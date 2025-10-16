using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQuerySender<TResult>
    {
        Task<TResult> SendAsync(CancellationToken cancellationToken = default);
    }

    public interface IDBQueryDesigner<TEntity, TResult, TQuery>
        : IDBQuerySender<TResult>
        where TEntity : BaseEntity
        where TQuery : IDBQuerySender<TResult>
    {
        TQuery Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
        IDBQueryDesignerInclude<TEntity, TResult, TProperty, TQuery> IncludeWich<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty);
    }

    public interface IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TQuery>
        where TEntity : BaseEntity
        where TQuery : IDBQuerySender<TResult>
    {
        IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TQuery> And<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty);
        IDBQueryDesignerInclude<TEntity, TResult, TNextProperty, TQuery> AlongWich<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty);

        TQuery Then { get; }
    }
}
