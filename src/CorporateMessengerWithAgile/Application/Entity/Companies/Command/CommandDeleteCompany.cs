using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Companies.Command
{
    public record CommandDeleteCompany(Guid Id) : AbsCommandDeleteEntityById<Company>(Id);
}
