using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TDBQuery>
        where TEntity : BaseEntity
        where TDBQuery : IDBQuerySender<TResult>
    {
        IDBQueryDesignerInclude<TEntity, TResult, TCurrentProperty, TDBQuery> And<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty);
        IDBQueryDesignerInclude<TEntity, TResult, TNextProperty, TDBQuery> AlongWich<TNextProperty>(Expression<Func<TCurrentProperty, TNextProperty>> navigationProperty);

        TDBQuery Then { get; }
    }
}
