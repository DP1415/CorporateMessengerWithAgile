using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsCommand.Update
{
    public abstract class AbsCommandUpdateEntityBaseHandler<TCommand, TEntity, TDto>(AppDbContext context, IMapper mapper)
        : AbsCommandOverAnEntityHandler<TCommand, TEntity, Result<TDto>>(context, mapper)
        where TCommand : AbsCommandUpdateEntityBase<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        public override async Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity? entity = await GetEntity(request, cancellationToken);
            if (entity == null) return new Error($"{typeof(TEntity).Name} not found", $"{typeof(TEntity).Name} not found");

            Result<TEntity> updateResult = Update(entity, request);
            if (updateResult.IsFailure) return updateResult.Error;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TDto>(updateResult.Value);
        }
        protected abstract Task<TEntity?> GetEntity(TCommand request, CancellationToken cancellationToken);
        protected abstract Result<TEntity> Update(TEntity entity, TCommand request);
    }
}
