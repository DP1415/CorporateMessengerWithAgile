using Domain.Common;

namespace Domain.Abstract.DBQueryDesigner
{
    public interface IDBQueryBuilder
    {
        IDBQueryDesignerSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        IDBQueryDesignerSingular<TEntity> Singular<TEntity>() where TEntity : BaseEntity;
    }
}
