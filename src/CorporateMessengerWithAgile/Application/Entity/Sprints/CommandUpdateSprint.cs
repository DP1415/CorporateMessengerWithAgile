using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Sprints
{
    public record CommandUpdateSprint(
        Guid Id,
        DateTime? DateStart,
        DateTime? DateEnd,
        Guid? TeamId
    ) : AbsCommandUpdateEntityById<Sprint, SprintDto>(Id);
}
