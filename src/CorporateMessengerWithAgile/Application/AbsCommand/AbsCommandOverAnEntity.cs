using Domain.Entity;

namespace Application.AbsCommand
{
    public abstract record AbsCommandOverAnEntity<TEntity, TResult> : AbsCommand<TResult>
        where TEntity : BaseEntity;
}
