using Application.Dto;
using Application.AbsQuery.Options;
using Domain.Entity;
using MediatR;

namespace Application.AbsQuery
{
    public abstract record AbsQuery<TEntity, TDto>
        (
            AbsOption<TEntity>[]? Options = null
        )
        : IRequest<IEnumerable<TDto>>
        where TDto : BaseDto
        where TEntity : BaseEntity;
}
