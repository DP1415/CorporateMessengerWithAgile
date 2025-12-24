using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Create
{
    public abstract record AbsCommandCreateEntity<TEntity, TDto> : AbsCommandOverAnEntity<TEntity, Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
