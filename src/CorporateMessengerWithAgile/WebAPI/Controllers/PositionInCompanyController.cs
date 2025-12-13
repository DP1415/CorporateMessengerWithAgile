using Application.Dto;
using Application.Entity.PositionInCompany_s;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionInCompanyController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<PositionInCompanyDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new PositionInCompaniesGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<PositionInCompanyDto>> Create(
            [FromBody] CommandCreatePositionInCompany command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeletePositionInCompany(id), cancellationToken);

        [HttpPut]
        public async Task<Result<PositionInCompanyDto>> Change(
            [FromBody] CommandUpdatePositionInCompany command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}
