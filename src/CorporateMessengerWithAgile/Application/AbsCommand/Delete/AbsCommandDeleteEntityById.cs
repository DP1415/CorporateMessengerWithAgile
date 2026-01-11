using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Delete
{
    public abstract record AbsCommandDeleteEntityById<TEntity>
        (
            Guid Id
        )
        : AbsCommand<Result> where TEntity : BaseEntity;
}
