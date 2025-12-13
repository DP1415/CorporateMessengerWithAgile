using Application.Dto;
using Application.Query.Options;
using Domain.Common;
using MediatR;

namespace Application.Query
{
    public abstract record AbsQuery<TEntity, TDto>
        (
            AbsOption<TEntity>[]? Options = null
        )
        : IRequest<IEnumerable<TDto>>
        where TDto : BaseDto
        where TEntity : BaseEntity;
}
