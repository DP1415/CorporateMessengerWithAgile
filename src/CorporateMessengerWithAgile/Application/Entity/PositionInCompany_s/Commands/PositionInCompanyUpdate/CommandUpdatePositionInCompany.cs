using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.PositionInCompany_s.Commands.PositionInCompanyUpdate
{
    public record CommandUpdatePositionInCompany(
        Guid Id,
        string? Title,
        string? Description,
        Guid? CompanyId
    ) : AbsCommandUpdateEntityById<PositionInCompany, PositionInCompanySummaryDto>(Id);
}
