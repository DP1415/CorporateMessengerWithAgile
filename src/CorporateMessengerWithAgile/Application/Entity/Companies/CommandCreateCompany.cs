using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Companies
{
    public record CommandCreateCompany
    (
        string Title
    )
    : AbsCommandCreateEntity<Company, CompanyDto>;
}
