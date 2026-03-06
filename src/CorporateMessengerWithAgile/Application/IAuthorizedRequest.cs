using MediatR;

namespace Application
{
    public interface IAuthorizedRequest: IRequest { public Guid CurrentUserId { get; set; } }
}
