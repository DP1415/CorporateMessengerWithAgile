using Application.AbsCommand.Create;
using Application.AbsCommand.Delete;
using Application.AbsCommand.Update;
using Application.AbsQuery;
using Application.Dto;
using Domain.Entity;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.Abstract
{
    [Route("cmwa/api/[controller]")]
    public abstract class ApiControllerBase<
            TEntity,
            TEntityDto,
            TCommandGetAll,
            TCommandCreate,
            TCommandUpdate,
            TCommandDelete
        >(
            ISender sender,
            Func<Guid, TCommandDelete> deleteCommandFactory
        )
        : AbstractController(sender)
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
        where TCommandGetAll : AbsQueryGetAllEntity<TEntity, TEntityDto>, new()
        where TCommandCreate : AbsCommandCreateEntity<TEntity, TEntityDto>
        where TCommandUpdate : AbsCommandUpdateEntityById<TEntity, TEntityDto>
        where TCommandDelete : AbsCommandDeleteEntityById<TEntity>
    {
        protected const string ApiControllerBaseTag = "cmwa/api";

        [HttpGet]
        public async Task<IEnumerable<TEntityDto>> GetAll(
            CancellationToken cancellationToken = default
            ) => await Sender.Send(new TCommandGetAll(), cancellationToken);

        [HttpPost]
        public async Task<Result<TEntityDto>> Create(
            [FromBody] TCommandCreate command,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(command, cancellationToken);

        [HttpPut]
        public async Task<Result<TEntityDto>> Update(
            [FromBody] TCommandUpdate command,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(deleteCommandFactory(id), cancellationToken);
    }
}
