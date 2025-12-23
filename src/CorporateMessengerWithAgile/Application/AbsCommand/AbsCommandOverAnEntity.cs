using Domain.Common;

namespace Application.AbsCommand
{
    public abstract record AbsCommandOverAnEntity<TEntity, TResult> : AbsCommand<TResult>
        where TEntity : BaseEntity;
}
