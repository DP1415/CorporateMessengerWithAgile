using Domain.Entity;
using System.Linq.Expressions;

namespace Application.AbsQuery.Options
{
    public class Filter<TEntity>(Expression<Func<TEntity, bool>> filter) : AbsOption<TEntity> where TEntity : BaseEntity
    {
        public override IQueryable<TEntity> AddOption(IQueryable<TEntity> dbset)
        {
            return dbset.AsQueryable().Where(filter);
        }
    }
}
