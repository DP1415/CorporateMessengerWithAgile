using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Companies.Command
{
    public record CommandUpdateCompany
    (
        Guid Id,
        string? Title
    )
    : AbsCommandUpdateEntityById<Company, CompanyDto>(Id);
}
