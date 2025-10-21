using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesignerSingular<TEntity>
        : IDBQueryDesigner<
            TEntity,
            TEntity,
            IDBQueryDesigner<TEntity, TEntity>
            >
        where TEntity : BaseEntity
    {
        IDBQueryDesigner<TEntity, TEntity> Get(Guid id);

        IDBQueryDesigner<TEntity, TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}
