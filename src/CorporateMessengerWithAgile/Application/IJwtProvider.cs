using Domain.Entity;

namespace Application
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
