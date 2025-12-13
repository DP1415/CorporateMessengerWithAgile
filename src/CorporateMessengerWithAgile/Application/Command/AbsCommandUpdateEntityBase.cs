using Application.Dto;
using Domain.Common;
using Domain.Result;

namespace Application.Command
{
    public abstract record AbsCommandUpdateEntityBase<TEntity, TDto> : AbsCommandBase<Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
