using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Delete
{
    public abstract record AbsCommandDeleteEntityById<TEntity>
        (
            Guid Id
        )
        : AbsCommandOverAnEntity<TEntity, Result> where TEntity : BaseEntity;
}
