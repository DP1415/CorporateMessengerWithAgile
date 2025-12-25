using Application.Dto;
using Application.AbsQuery.Options;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsQuery
{
    public abstract class AbsQueryHandler<TQuery, TEntity, TDto> :
        IRequestHandler<TQuery, IEnumerable<TDto>>
        where TQuery : AbsQuery<TEntity, TDto>
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

        public async Task<IEnumerable<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
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
