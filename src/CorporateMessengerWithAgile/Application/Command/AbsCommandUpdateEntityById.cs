using Domain.Common;
using Domain.Result;

namespace Application.Command
{
    public abstract record AbsCommandUpdateEntityById<TEntity>
        (
            Guid Id
        )
        : AbsCommandUpdateEntityBase<TEntity> where TEntity : BaseEntity;
}
