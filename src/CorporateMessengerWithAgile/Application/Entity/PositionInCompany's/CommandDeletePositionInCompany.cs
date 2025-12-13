using Application.Command;
using Domain.Entity;

namespace Application.Entity.PositionInCompany_s
{
    public record CommandDeletePositionInCompany(Guid Id) : AbsCommandDeleteEntityById<PositionInCompany>(Id);
}
