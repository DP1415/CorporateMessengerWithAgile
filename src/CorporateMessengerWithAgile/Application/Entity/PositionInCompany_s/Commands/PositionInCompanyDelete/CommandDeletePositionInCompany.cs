using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.PositionInCompany_s.Commands.PositionInCompanyDelete
{
    public record CommandDeletePositionInCompany(Guid Id) : AbsCommandDeleteEntityById<PositionInCompany>(Id);
}
