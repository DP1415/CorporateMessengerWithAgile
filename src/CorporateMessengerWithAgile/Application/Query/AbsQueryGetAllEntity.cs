using Domain.Common;
using MediatR;

namespace Application.Query
{
    public abstract record AbsQueryGetAllEntity<TEntity> : IRequest<TEntity[]> where TEntity : BaseEntity { }
}
