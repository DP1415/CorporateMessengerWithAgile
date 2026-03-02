using Application.AbsQuery.Options;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsQuery
{
    public abstract record AbsQuery<TEntity, TResult> : AbsQuery<TResult> where TEntity : BaseEntity;
    public abstract record AbsAuthorizedQuery<TEntity, TResult> : AbsQuery<TEntity, TResult>, IAuthorizedQuery where TEntity : BaseEntity { public Guid CurrentUserId { get; set; } }
    public abstract class AbsQueryHandler<TQuery, TEntity, TResult>(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TQuery, TResult>(context, mapper)
        where TQuery : AbsQuery<TEntity, TResult>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    }

    public abstract class AbsQueryEntityWithOptionsHandler<TQuery, TEntity, TDto>(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TQuery, IEnumerable<TDto>>(context, mapper)
        where TQuery : AbsQueryEntityWithOptions<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public override async Task<IEnumerable<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            if (request.Options is null)
                return _mapper.Map<IEnumerable<TDto>>(await _dbSet.ToArrayAsync(cancellationToken));

            IQueryable<TEntity> query = _dbSet.AsQueryable();
            foreach (AbsOption<TEntity> option in request.Options)
            {
                query = option.AddOption(query);
            }
            return _mapper.Map<IEnumerable<TDto>>(query);
        }
    }
}
