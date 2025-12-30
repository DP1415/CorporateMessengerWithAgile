using Application.Dto;
using Application.Entity.PositionInCompany_s;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class PositionInCompanyController(ISender sender) : ApiControllerBase
        <
            PositionInCompany,
            PositionInCompanyDto,
            PositionInCompaniesGetAllQuery,
            CommandCreatePositionInCompany,
            CommandUpdatePositionInCompany,
            CommandDeletePositionInCompany
        >(
            sender,
            id => new CommandDeletePositionInCompany(id)
        );
}
