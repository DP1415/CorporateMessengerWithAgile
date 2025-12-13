using Application.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Command
{
    public abstract class AbsCommandUpdateEntityBaseHandler<TCommand, TEntity, TDto>
        : AbsCommandBaseHandler<TCommand, Result<TDto>>
        where TCommand : AbsCommandUpdateEntityBase<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected readonly DbSet<TEntity> _dbSet;

        public AbsCommandUpdateEntityBaseHandler(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _dbSet = context.Set<TEntity>();
        }

        public override async Task<Result<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity? entity = await GetEntity(request, cancellationToken);
            if (entity == null) return new Exception($"{typeof(TEntity).Name} not found");

            Result<TEntity> updateResult = Update(entity, request);
            if (updateResult.IsFailure) return updateResult.Exception;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TDto>(updateResult.Value);
        }
        protected abstract Task<TEntity?> GetEntity(TCommand request, CancellationToken cancellationToken);
        protected abstract Result<TEntity> Update(TEntity entity, TCommand request);
    }
}
