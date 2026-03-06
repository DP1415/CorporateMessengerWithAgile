using MediatR;

namespace Application.AbsCommand
{

    public abstract record AbsCommand<TResult> : IRequest<TResult>;
    public abstract record AbsAuthorizedCommand<TResult> : AbsCommand<TResult>, IAuthorizedRequest { public Guid CurrentUserId { get; set; } }
}
