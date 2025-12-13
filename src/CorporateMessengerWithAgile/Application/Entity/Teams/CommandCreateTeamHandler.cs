using Application.Command;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Teams
{
    public class CommandCreateTeamHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateTeam, Team, TeamDto>(context, mapper)
    {
        public override Result<Team> Create(CommandCreateTeam request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Exception;

            var team = new Team
            {
                Title = title,
                StandardSprintDuration = request.StandardSprintDuration,
                ProjectId = request.ProjectId
            };

            return team;
        }
    }
}
