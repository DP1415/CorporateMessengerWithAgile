using MediatR;

namespace Application.AbsCommand
{
    public abstract record AbsCommand<TResult> : IRequest<TResult>;
}
