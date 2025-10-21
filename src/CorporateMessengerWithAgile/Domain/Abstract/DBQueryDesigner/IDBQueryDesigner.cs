using Domain.Common;
using Domain.Result;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQuerySender<TResult>
    {
        Task<Result<TResult>> SendAsync(CancellationToken cancellationToken = default);
    }

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

    public interface IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TDBQuery>
        where TEntity : BaseEntity
        where TDBQuery : IDBQuerySender<TResult>
    {
        IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TDBQuery> And<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty);
        IDBQueryDesignerInclude<TEntity, TResult, TNextProperty, TDBQuery> AlongWich<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty);

        TDBQuery Then { get; }
    }
}
