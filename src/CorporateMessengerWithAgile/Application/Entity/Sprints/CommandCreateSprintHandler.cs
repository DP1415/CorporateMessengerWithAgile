using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.Sprints
{
    public class CommandCreateSprintHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateSprint, Sprint, SprintDto>(context, mapper)
    {
        public override Result<Sprint> Create(CommandCreateSprint request)
        {
            var sprint = new Sprint
            {
                DateStart = request.DateStart,
                DateEnd = request.DateEnd,
                TeamId = request.TeamId
            };

            return sprint;
        }
    }
}
