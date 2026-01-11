using Application;
using Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public sealed class JwtProvider(IOptions<JwtProviderSettings> options) : IJwtProvider
    {
        private readonly DateTime Expires = DateTime.UtcNow.Add(options.Value.Expires);
        private readonly string SecretKey = options.Value.SecretKey;
        private readonly string Issuer = options.Value.Issuer;
        private readonly string Audience = options.Value.Audience;

        public string GenerateToken(User user)
        {
            Claim[] payload = [
                new ("sub", user.Id.ToString()),
                new ("email", user.Email.Value),
                new ("role", user.Role)
            ];

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials signingCredentials = new(key, algorithm: SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: Issuer,
                audience: Audience,
                claims: payload,
                expires: Expires,
                signingCredentials: signingCredentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
