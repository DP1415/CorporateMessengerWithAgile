using Domain.Common;
using Domain.Result;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesignerSingular<TEntity>
        : IDBQueryDesigner<
            TEntity,
            Result<TEntity>,
            IDBQueryDesignerSingular<TEntity>
            >
        where TEntity : BaseEntity
    {
        IDBQueryDesigner<TEntity, Result<TEntity>, IDBQueryDesignerSingular<TEntity>> Get(Guid id);

        IDBQueryDesigner<TEntity, Result<TEntity>, IDBQueryDesignerSingular<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
    }
}
