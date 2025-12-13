using Domain.Common;
using Domain.Result;

namespace Application.Command
{
    public abstract record AbsCommandUpdateEntityBase<TEntity> : AbsCommandBase<Result<TEntity>> where TEntity : BaseEntity;
}
