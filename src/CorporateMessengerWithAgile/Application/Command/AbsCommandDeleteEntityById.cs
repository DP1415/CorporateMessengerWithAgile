using Domain.Common;
using Domain.Result;

namespace Application.Command
{
    public abstract record AbsCommandDeleteEntityById<TEntity>
        (
            Guid Id
        )
        : AbsCommandBase<Result> where TEntity : BaseEntity;
}
