using Domain.Entity;

namespace Application.Query.Options
{
    public class Take<TEntity>(int count) : AbsOption<TEntity> where TEntity : BaseEntity
    {
        public override IQueryable<TEntity> AddOption(IQueryable<TEntity> dbset)
        {
            return dbset.AsQueryable().Take(count);
        }
    }
}
