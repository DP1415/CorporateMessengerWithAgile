using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.PositionInCompany_s.Commands.PositionInCompanyDelete
{
    public class CommandDeletePositionInCompanyHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeletePositionInCompany, PositionInCompany>(context);
}
