using Domain.Common;
using Domain.Result;

namespace Application.Command
{
    public abstract record AbsCommandCreateEntity<TEntity> : AbsCommandBase<Result<TEntity>> where TEntity : BaseEntity;
}
