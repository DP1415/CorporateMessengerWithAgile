using Application.Dto;
using Application.Query.Options;
using Domain.Common;
using MediatR;

namespace Application.Query
{
    public abstract record AbsQueryWithOptions<TEntity, TDto>
        (
            AbsOption<TEntity>[] Options
        )
        : IRequest<IEnumerable<TDto>>
        where TDto : BaseDto
        where TEntity : BaseEntity;
}
