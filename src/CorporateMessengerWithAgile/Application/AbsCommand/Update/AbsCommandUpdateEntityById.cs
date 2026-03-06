using Application.Dto;
using Domain.Entity;

namespace Application.AbsCommand.Update
{
    public abstract record AbsCommandUpdateEntityById<TEntity, TDto>
        (
            Guid Id
        )
        : AbsCommandUpdateEntityBase<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto;

    public abstract record AbsAuthorizedCommandUpdateEntityById<TEntity, TDto>
        (
            Guid Id
        )
        : AbsCommandUpdateEntityById<TEntity, TDto>(Id), IAuthorizedRequest
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public Guid CurrentUserId { get; set; }
    }
}
