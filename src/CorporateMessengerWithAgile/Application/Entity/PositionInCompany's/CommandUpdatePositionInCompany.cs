using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.PositionInCompany_s
{
    public record CommandUpdatePositionInCompany(
        Guid Id,
        string? Title,
        string? Description,
        Guid? CompanyId
    ) : AbsCommandUpdateEntityById<PositionInCompany, PositionInCompanyDto>(Id);
}
