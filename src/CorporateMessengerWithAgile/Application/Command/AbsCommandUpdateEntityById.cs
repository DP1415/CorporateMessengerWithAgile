using Application.Dto;
using Domain.Common;

namespace Application.Command
{
    public abstract record AbsCommandUpdateEntityById<TEntity, TDto>
        (
            Guid Id
        )
        : AbsCommandUpdateEntityBase<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
