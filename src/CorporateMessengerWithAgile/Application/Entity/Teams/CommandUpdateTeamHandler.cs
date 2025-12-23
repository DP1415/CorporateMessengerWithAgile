using Application.AbsCommand.Update;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Teams
{
    public class CommandUpdateTeamHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateTeam, Team, TeamDto>(context, mapper)
    {
        protected override Result<Team> Update(Team entity, CommandUpdateTeam request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Exception;
                entity.Title = title;
            }

            if (request.StandardSprintDuration.HasValue)
                entity.StandardSprintDuration = request.StandardSprintDuration.Value;

            if (request.ProjectId.HasValue)
                entity.ProjectId = request.ProjectId.Value;

            return entity;
        }
    }
}
