using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Sprints.Commands.SprintCreate
{
    public record CommandCreateSprint(
        DateTime DateStart,
        DateTime DateEnd,
        Guid TeamId
    ) : AbsCommandCreateEntity<Sprint, SprintDto>;
}
