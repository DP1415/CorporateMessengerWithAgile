using Application.Dto;
using Application.AbsQuery.Options;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsQuery
{
    public abstract class AbsQueryEntityWithOptionsHandler<TQuery, TEntity, TDto>(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TQuery, IEnumerable<TDto>>(context, mapper)
        where TQuery : AbsQueryEntityWithOptions<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public override async Task<IEnumerable<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
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
