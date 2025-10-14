using Domain.Common;
using Domain.Result;

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
    }
}
