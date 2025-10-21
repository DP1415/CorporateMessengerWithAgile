using Domain.Common;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesignerSet<TEntity>
        : IDBQueryDesigner<
            TEntity,
            TEntity[],
            IDBQueryDesignerSet<TEntity>
            >
        where TEntity : BaseEntity
    {
        IDBQueryDesigner<TEntity, TEntity> First();

        IDBQueryDesignerSet<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        IDBQueryDesignerSet<TEntity> Pagination(int indexPage, int sizePage);
        IDBQuerySender<int> Count { get; }
        IDBQuerySender<bool> Any { get; }
    }
}
