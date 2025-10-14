using Domain.Common;
using Domain.Result;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryDesignerSet<TEntity>
        : IDBQueryDesigner<
            TEntity,
            Result<TEntity[]>,
            IDBQueryDesignerSet<TEntity>
            >
        where TEntity : BaseEntity
    {
        IDBQueryDesignerSingular<TEntity> Get(Guid id);
        IDBQueryDesignerSet<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        IDBQueryDesignerSet<TEntity> Pagination(int indexPage, int sizePage);
        IDBQuerySender<int> Count();
    }
}
