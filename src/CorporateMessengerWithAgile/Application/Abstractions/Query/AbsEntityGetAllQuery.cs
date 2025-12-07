using Domain.Common;
using MediatR;

namespace Application.Abstractions.Query
{
    public abstract record AbsEntityGetAllQuery<T> : IRequest<T[]> where T : BaseEntity { }
}
