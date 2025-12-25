using MediatR;

namespace Application.AbsQuery
{
    public abstract record AbsQuery<TResult> : IRequest<TResult>;
}
