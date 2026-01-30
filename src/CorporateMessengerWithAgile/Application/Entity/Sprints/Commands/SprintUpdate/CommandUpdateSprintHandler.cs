using Application.AbsCommand.Update;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.Sprints.Commands.SprintUpdate
{
    public class CommandUpdateSprintHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateSprint, Sprint, SprintSummaryDto>(context, mapper)
    {
        protected override Result<Sprint> Update(Sprint entity, CommandUpdateSprint request)
        {
            if (request.DateStart.HasValue)
            {
                entity.DateStart = request.DateStart.Value;
            }

            if (request.DateEnd.HasValue)
            {
                entity.DateEnd = request.DateEnd.Value;
            }

            if (request.TeamId.HasValue)
            {
                entity.TeamId = request.TeamId.Value;
            }

            return entity;
        }
    }
}
