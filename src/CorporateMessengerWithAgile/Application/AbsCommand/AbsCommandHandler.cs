using AutoMapper;
using MediatR;
using Persistence;

namespace Application.AbsCommand
{
    public abstract class AbsCommandHandler<TCommand, TResult>(AppDbContext context, IMapper mapper)
        : IRequestHandler<TCommand, TResult>
        where TCommand : AbsCommand<TResult>
    {
        protected readonly AppDbContext _context = context;
        protected readonly IMapper _mapper = mapper;

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
