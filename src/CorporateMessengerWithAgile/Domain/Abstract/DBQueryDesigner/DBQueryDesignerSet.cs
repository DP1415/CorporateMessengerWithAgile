using Domain.Common;
using Domain.Result;
using System.Linq.Expressions;

namespace Domain.Abstract.DBQueryDesigner
{
    public abstract class DBQueryDesignerSet<TEntity>
        : DBQueryDesigner<TEntity, Result<TEntity[]>, DBQueryDesignerSet<TEntity>>
        where TEntity : BaseEntity
    {
        public abstract DBQueryDesignerSingular<TEntity> Get(Guid id);

        public abstract DBQueryDesignerSet<TEntity> Filter(
            Expression<Func<TEntity, bool>> predicate);

        public abstract DBQueryDesignerSet<TEntity> Pagination(
            int indexPage, int sizePage);

        public abstract DBQuerySender<int> Count();
    }
}
