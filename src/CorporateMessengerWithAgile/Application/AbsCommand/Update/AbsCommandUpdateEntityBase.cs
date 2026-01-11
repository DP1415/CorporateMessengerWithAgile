using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Update
{
    public abstract record AbsCommandUpdateEntityBase<TEntity, TDto> : AbsCommand<Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
