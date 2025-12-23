using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.PositionInCompany_s
{
    public class CommandDeletePositionInCompanyHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeletePositionInCompany, PositionInCompany>(context);
}
