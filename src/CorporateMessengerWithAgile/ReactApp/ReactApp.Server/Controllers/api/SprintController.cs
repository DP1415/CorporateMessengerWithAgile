using Application.Dto.Summary;
using Application.Entity.Sprints.Commands.SprintCreate;
using Application.Entity.Sprints.Commands.SprintDelete;
using Application.Entity.Sprints.Commands.SprintUpdate;
using Application.Entity.Sprints.Queries.SprintsGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class SprintController(ISender sender) : ApiControllerBase
        <
            Sprint,
            SprintSummaryDto,
            SprintsGetAllQuery,
            CommandCreateSprint,
            CommandUpdateSprint,
            CommandDeleteSprint
        >(
            sender,
            id => new CommandDeleteSprint(id)
        );
}
