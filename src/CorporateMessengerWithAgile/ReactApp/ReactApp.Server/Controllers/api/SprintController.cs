using Application.Dto;
using Application.Entity.Sprints;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class SprintController(ISender sender) : ApiControllerBase
        <
            Sprint,
            SprintDto,
            SprintsGetAllQuery,
            CommandCreateSprint,
            CommandUpdateSprint,
            CommandDeleteSprint
        >(
            sender,
            id => new CommandDeleteSprint(id)
        );
}
