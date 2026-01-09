using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.AbsCommand.Create
{
    abstract public class AbsCommandCreateEntityHandler<TCommand, TEntity, TDto>(AppDbContext context, IMapper mapper)
        : AbsCommandOverAnEntityHandler<TCommand, TEntity, Result<TDto>>(context, mapper)
        where TCommand : AbsCommandCreateEntity<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public override async Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            Result<TEntity> entity = Create(request);
            if (entity.IsFailure) return entity.Error;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TDto>(entity.Value);
        }

        public abstract Result<TEntity> Create(TCommand request);
    }
}
