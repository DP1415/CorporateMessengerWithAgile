using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Companies.Command
{
    public class CommandDeleteCompanyHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteCompany, Company>(context);
}
