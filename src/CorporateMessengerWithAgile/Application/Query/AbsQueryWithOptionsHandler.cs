using Application.Dto;
using Application.Query.Options;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Query
{
    public abstract class AbsQueryWithOptionsHandler<TQueryWithOption, TEntity, TDto> :
        IRequestHandler<TQueryWithOption, IEnumerable<TDto>>
        where TQueryWithOption : AbsQueryWithOptions<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;

        public AbsQueryWithOptionsHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TDto>> Handle(TQueryWithOption request, CancellationToken cancellationToken)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();

            foreach (AbsOption<TEntity> option in request.Options)
            {
                query = option.AddOption(query);
            }

            TEntity[] entities = await query.ToArrayAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
    }
}
