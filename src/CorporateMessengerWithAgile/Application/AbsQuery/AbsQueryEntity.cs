using Application.Dto;
using Application.AbsQuery.Options;
using Domain.Entity;

namespace Application.AbsQuery
{
    public abstract record AbsQueryEntity<TEntity, TDto>
        (
            AbsOption<TEntity>[]? Options = null
        )
        : AbsQuery<IEnumerable<TDto>>
        where TDto : BaseDto
        where TEntity : BaseEntity;
}
