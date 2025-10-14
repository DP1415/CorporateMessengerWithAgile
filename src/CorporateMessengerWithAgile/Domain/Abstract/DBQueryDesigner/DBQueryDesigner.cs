using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public abstract class DBQueryDesigner<TEntity, TResult, TBuilder> : DBQuerySender<TResult>
        where TEntity : BaseEntity
    {
        public abstract TBuilder Include<TProperty>(
            Expression<Func<TEntity, TProperty>> navigationProperty);
    }
}
