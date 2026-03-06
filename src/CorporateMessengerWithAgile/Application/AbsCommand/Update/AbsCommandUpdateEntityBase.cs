using Application.AbsCommand.Delete;
using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Update
{
    public abstract record AbsCommandUpdateEntityBase<TEntity, TDto> : AbsCommand<Result<TDto>>
        where TEntity : BaseEntity
        where TDto : BaseDto;

    public abstract record AbsAuthorizedCommandUpdateEntityBase<TEntity, TDto>
        : AbsCommandUpdateEntityBase<TEntity, TDto>, IAuthorizedRequest
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public Guid CurrentUserId { get; set; }
    }
}
