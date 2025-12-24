using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Query.Options
{
    public class Include<TEntity, TProperty>(System.Linq.Expressions.Expression<Func<TEntity, TProperty>> includeExpression) : AbsOption<TEntity> where TEntity : BaseEntity
    {
        public override IQueryable<TEntity> AddOption(IQueryable<TEntity> dbset)
        {
            return dbset.AsQueryable().Include(includeExpression);
        }
    }
}
