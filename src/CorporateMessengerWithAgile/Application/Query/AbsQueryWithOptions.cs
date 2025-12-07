using Application.Query.Options;
using Domain.Common;
using MediatR;

namespace Application.Query
{
    public abstract record AbsQueryWithOptions<TEntity>
        (
            AbsOption<TEntity>[] Options
        )
        : IRequest<TEntity[]> where TEntity : BaseEntity;
}
