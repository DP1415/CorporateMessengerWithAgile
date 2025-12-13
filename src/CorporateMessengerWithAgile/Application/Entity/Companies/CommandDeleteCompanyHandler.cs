using Application.Command;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Companies
{
    public class CommandDeleteCompanyHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteCompany, Company>(context);
}
