using Application.Dto;
using Application.Query.Options;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Query
{
    public abstract class AbsQueryHandler<TQueryWithOption, TEntity, TDto> :
        IRequestHandler<TQueryWithOption, IEnumerable<TDto>>
        where TQueryWithOption : AbsQuery<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;

        public AbsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TDto>> Handle(TQueryWithOption request, CancellationToken cancellationToken)
        {
            if (request.Options is null) return _mapper.Map<IEnumerable<TDto>>(await _dbSet.ToArrayAsync(cancellationToken));

            IQueryable<TEntity> query = _dbSet.AsQueryable();

            foreach (AbsOption<TEntity> option in request.Options)
            {
                query = option.AddOption(query);
            }

            return _mapper.Map<IEnumerable<TDto>>(query);
        }
    }
}
