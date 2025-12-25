using Domain.Entity;

namespace Application.AbsQuery
{
    public abstract record AbsQueryEntity<TEntity, TResult>
        : AbsQuery<TResult>
        where TEntity : BaseEntity;
}
