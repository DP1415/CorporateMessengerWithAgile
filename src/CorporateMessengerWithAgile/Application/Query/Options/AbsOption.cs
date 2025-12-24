using Domain.Entity;

namespace Application.Query.Options
{
    public abstract class AbsOption<TEntity> where TEntity : BaseEntity
    {
        public abstract IQueryable<TEntity> AddOption(IQueryable<TEntity> dbset);
    }
}
