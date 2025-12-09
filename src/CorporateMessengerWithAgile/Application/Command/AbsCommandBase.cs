using MediatR;

namespace Application.Command
{
    public abstract record AbsCommandBase<TResult> : IRequest<TResult>;
}
