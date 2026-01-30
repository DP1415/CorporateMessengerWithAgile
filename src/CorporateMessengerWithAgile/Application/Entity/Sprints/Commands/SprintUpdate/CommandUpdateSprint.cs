using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Sprints.Commands.SprintUpdate
{
    public record CommandUpdateSprint(
        Guid Id,
        DateTime? DateStart,
        DateTime? DateEnd,
        Guid? TeamId
    ) : AbsCommandUpdateEntityById<Sprint, SprintSummaryDto>(Id);
}
