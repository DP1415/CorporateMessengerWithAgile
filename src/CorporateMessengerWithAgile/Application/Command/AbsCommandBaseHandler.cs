using MediatR;
using Persistence;

namespace Application.Command
{
    public abstract class AbsCommandBaseHandler<TCommand, TResult>
        : IRequestHandler<TCommand, TResult>
        where TCommand : AbsCommandBase<TResult>
    {
        protected readonly AppDbContext _context;

        public AbsCommandBaseHandler(AppDbContext context)
        {
            _context = context;
        }

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
