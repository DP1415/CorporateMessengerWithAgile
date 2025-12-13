using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Sprints
{
    public record CommandCreateSprint(
        DateTime DateStart,
        DateTime DateEnd,
        Guid TeamId
    ) : AbsCommandCreateEntity<Sprint, SprintDto>;
}
