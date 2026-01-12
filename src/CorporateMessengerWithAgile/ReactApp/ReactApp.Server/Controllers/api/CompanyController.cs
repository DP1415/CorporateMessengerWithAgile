using Application.Dto;
using Application.Entity.Companies.Command.CompanyCreate;
using Application.Entity.Companies.Command.CompanyDelete;
using Application.Entity.Companies.Command.CompanyUpdate;
using Application.Entity.Companies.Queries.GetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class CompanyController(ISender sender) : ApiControllerBase
        <
            Company,
            CompanyDto,
            CompaniesGetAllQuery,
            CommandCreateCompany,
            CommandUpdateCompany,
            CommandDeleteCompany
        >(
            sender,
            id => new CommandDeleteCompany(id)
        );
}
