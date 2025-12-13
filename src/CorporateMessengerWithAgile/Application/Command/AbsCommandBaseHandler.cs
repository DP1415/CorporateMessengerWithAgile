using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Command
{
    public abstract class AbsCommandBaseHandler<TCommand, TResult>
        : IRequestHandler<TCommand, TResult>
        where TCommand : AbsCommandBase<TResult>
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public AbsCommandBaseHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
