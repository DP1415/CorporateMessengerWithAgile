using Domain.Common;
using Domain.Result;

namespace Domain.Abstract.DBQueryDesigner
{
    public abstract class DBQueryDesignerSingular<TEntity>
        : DBQueryDesigner<TEntity, Result<TEntity>, DBQueryDesignerSingular<TEntity>>
        where TEntity : BaseEntity
    {
    }
}
