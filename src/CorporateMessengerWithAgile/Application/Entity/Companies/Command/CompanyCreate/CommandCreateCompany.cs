using Application.AbsCommand.Create;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Companies.Command.CompanyCreate
{
    public record CommandCreateCompany
    (
        string Title
    )
    : AbsCommandCreateEntity<Company, CompanySummaryDto>;
}
