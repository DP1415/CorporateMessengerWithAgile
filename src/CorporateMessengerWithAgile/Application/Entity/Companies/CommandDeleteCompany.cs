using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Companies
{
    public record CommandDeleteCompany(Guid Id) : AbsCommandDeleteEntityById<Company>(Id);
}
