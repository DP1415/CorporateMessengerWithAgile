using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Companies.Command.CompanyUpdate
{
    public record CommandUpdateCompany
    (
        Guid Id,
        string? Title
    )
    : AbsCommandUpdateEntityById<Company, CompanySummaryDto>(Id);
}
