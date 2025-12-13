using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.PositionInCompany_s
{
    public record CommandCreatePositionInCompany(
        string Title,
        string Description,
        Guid CompanyId
    ) : AbsCommandCreateEntity<PositionInCompany, PositionInCompanyDto>;
}
