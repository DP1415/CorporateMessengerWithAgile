using Application.Dto;
using Application.Entity.Companies.Queries.GetAll;
using Application.Entity.Companies.Queries.GetById;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [ApiController]
    [Route("cmwa/[controller]")]
    public class CompanyController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAll(
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CompaniesGetAllQuery(), cancellationToken);

        [HttpGet("{id:guid}")]
        public async Task<Result<CompanyGetByIdDto>> GetCompanyById(
            Guid id,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CompanyGetByIdQuery(id), cancellationToken);
    }
}
