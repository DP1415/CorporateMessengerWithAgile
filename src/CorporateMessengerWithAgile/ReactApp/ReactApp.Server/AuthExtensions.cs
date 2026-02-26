using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ReactApp.Server
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JwtSettings:SecretKey is missing in appsettings.json");
            var issuer = jwtSettings["Issuer"] ?? throw new InvalidOperationException("JwtSettings:Issuer is missing in appsettings.json");
            var audience = jwtSettings["Audience"] ?? throw new InvalidOperationException("JwtSettings:Audience is missing in appsettings.json");

            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey)),
                ValidIssuer = issuer,
                ValidAudience = audience,
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => { options.TokenValidationParameters = tokenValidationParameters; });

            services.AddScoped<Application.IJwtProvider, Infrastructure.Authentication.JwtProvider>();
            services.Configure<Infrastructure.Authentication.JwtProviderSettings>(jwtSettings);

            //services.AddAuthorizationBuilder()
            //    .AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"))
            //    .AddPolicy("UserOnly", policy => policy.RequireRole("User"))
            //    .AddPolicy("UserOrAdmin", policy => policy.RequireRole("User", "Admin"));

            return services;
        }
    }
}
