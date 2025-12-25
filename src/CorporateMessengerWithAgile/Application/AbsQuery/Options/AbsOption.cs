using Domain.Entity;

namespace Application.AbsQuery.Options
{
    public abstract class AbsOption<TEntity> where TEntity : BaseEntity
    {
        public abstract IQueryable<TEntity> AddOption(IQueryable<TEntity> dbset);
    }
}
