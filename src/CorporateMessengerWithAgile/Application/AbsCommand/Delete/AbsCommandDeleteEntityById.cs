using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.AbsCommand.Delete
{
    public abstract record AbsCommandDeleteEntityById<TEntity>
        (
            Guid Id
        )
        : AbsCommand<Result> where TEntity : BaseEntity;

    public abstract record AbsAuthorizedCommandDeleteEntityById<TEntity>
        (
            Guid Id
        )
        : AbsCommandDeleteEntityById<TEntity>(Id), IAuthorizedRequest 
        where TEntity : BaseEntity
    {
        public Guid CurrentUserId { get; set; }
    }
}
