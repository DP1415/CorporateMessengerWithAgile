using Application.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Command
{
    abstract public class AbsCommandCreateEntityHandler<TCommand, TEntity, TDto>
        : AbsCommandBaseHandler<TCommand, Result<TDto>>
        where TCommand : AbsCommandCreateEntity<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly DbSet<TEntity> _dbSet;

        public AbsCommandCreateEntityHandler(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _dbSet = context.Set<TEntity>();
        }

        public override async Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            Result<TEntity> entity = Create(request);
            if (entity.IsFailure) return entity.Exception;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TDto>(entity.Value);
        }

        public abstract Result<TEntity> Create(TCommand request);
    }
}
