using Application.Dto;
using Domain.Common;
using Domain.Result;

namespace Application.AbsCommand.Create
{
    public abstract record AbsCommandCreateEntity<TEntity, TDto> : AbsCommandOverAnEntity<TEntity, Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;
}
