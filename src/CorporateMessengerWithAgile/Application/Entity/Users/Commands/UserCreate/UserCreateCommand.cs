using MediatR;

namespace Application.Entity.Users.Commands.UserCreate
{
    public record UserCreateCommand(
        string UserName,
        string Email,
        string password
        ) : IRequest<Guid>;
}
