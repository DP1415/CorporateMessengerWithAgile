using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Companies
{
    public record CommandUpdateCompany
    (
        Guid Id,
        string? Title
    )
    : AbsCommandUpdateEntityById<Company, CompanyDto>(Id);
}
