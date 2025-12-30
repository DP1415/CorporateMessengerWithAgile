using Application.Dto;
using Application.Entity.Companies.Queries.GetAll;
using Application.Entity.Companies.Command;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class CompanyController(ISender sender) : ApiControllerBase(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAll(
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CompaniesGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<CompanyDto>> Create(
            [FromBody] CommandCreateCompany command,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CommandDeleteCompany(id), cancellationToken);

        [HttpPut]
        public async Task<Result<CompanyDto>> Update(
            [FromBody] CommandUpdateCompany command,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(command, cancellationToken);
    }
}