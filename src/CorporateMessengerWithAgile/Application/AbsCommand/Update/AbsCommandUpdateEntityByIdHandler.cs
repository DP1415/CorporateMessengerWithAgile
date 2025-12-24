using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsCommand.Update
{
    abstract public class AbsCommandUpdateEntityByIdHandler<TCommand, TEntity, TDto>(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityBaseHandler<TCommand, TEntity, TDto>(context, mapper)
        where TCommand : AbsCommandUpdateEntityById<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected override Task<TEntity?> GetEntity(TCommand request, CancellationToken cancellationToken) =>
            _dbSet.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}