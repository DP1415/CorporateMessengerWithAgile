using Domain.Common;
using System.Linq.Expressions;

namespace Application.Query.Options
{
    public class OrderBy<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> keySelector) : AbsOption<TEntity> where TEntity : BaseEntity
    {
        public override IQueryable<TEntity> AddOption(IQueryable<TEntity> dbset)
        {
            return dbset.AsQueryable().OrderBy(keySelector);
        }
    }
}
