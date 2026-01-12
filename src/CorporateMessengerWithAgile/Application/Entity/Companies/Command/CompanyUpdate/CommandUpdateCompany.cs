using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Companies.Command.CompanyUpdate
{
    public record CommandUpdateCompany
    (
        Guid Id,
        string? Title
    )
    : AbsCommandUpdateEntityById<Company, CompanyDto>(Id);
}
