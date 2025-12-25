using AutoMapper;
using MediatR;
using Persistence;

namespace Application.AbsQuery
{
    public abstract class AbsQueryHandler<TQuery, TResult>(AppDbContext context, IMapper mapper)
        : IRequestHandler<TQuery, TResult>
        where TQuery : AbsQuery<TResult>
    {
        protected readonly AppDbContext _context = context;
        protected readonly IMapper _mapper = mapper;

        public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
