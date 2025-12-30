using Application.Dto;
using Application.Entity.Companies.Queries.GetAll;
using Application.Entity.Companies.Queries.GetById;
using Application.Entity.Projects.Queries.GetByCompanyId;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.reports
{
    [Tags(ReportsControllerBaseTag)]
    public class CompanyController(ISender sender) : ReportsControllerBase(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetAll(
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CompaniesGetAllQuery(), cancellationToken);

        [HttpGet("{companyId:guid}")]
        public async Task<Result<CompanyGetByIdDto>> GetCompanyById(
            Guid companyId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CompanyGetByIdQuery(companyId), cancellationToken);


        [HttpGet("{companyId:guid}/Project")]
        public async Task<Result<ProjectGetByCompanyIdDto>> GetAll(
            Guid companyId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new ProjectGetByCompanyIdQuery(companyId), cancellationToken);
    }
}
