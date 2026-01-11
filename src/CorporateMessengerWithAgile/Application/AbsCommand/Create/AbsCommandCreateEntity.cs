using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Create
{
    public abstract record AbsCommandCreateEntity<TEntity, TDto> : AbsCommand<Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
