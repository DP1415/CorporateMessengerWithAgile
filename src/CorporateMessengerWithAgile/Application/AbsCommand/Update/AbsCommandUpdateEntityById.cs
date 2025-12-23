using Application.Dto;
using Domain.Common;

namespace Application.AbsCommand.Update
{
    public abstract record AbsCommandUpdateEntityById<TEntity, TDto>
        (
            Guid Id
        )
        : AbsCommandUpdateEntityBase<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
