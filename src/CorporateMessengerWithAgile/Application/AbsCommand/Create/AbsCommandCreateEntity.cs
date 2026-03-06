using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Create
{
    public abstract record AbsCommandCreateEntity<TEntity, TDto> : AbsCommand<Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;

    public abstract record AbsAuthorizedCommandCreateEntity<TEntity, TDto> : AbsCommandCreateEntity<TEntity, TDto>, IAuthorizedRequest
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public Guid CurrentUserId { get; set; }
    }
}
