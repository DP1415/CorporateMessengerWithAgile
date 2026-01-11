using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

namespace ReactApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddAuth(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(Application.DependencyInjection.Assembly);
            builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Application.DependencyInjection.Assembly));
            builder.Services.AddValidatorsFromAssembly(Application.DependencyInjection.Assembly);
            builder.Services.AddDbContext<Persistence.AppDbContext>(options => options.UseInMemoryDatabase("CorporateMessengerDb"));
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement((document) => new OpenApiSecurityRequirement()
                {
                    [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                });
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("https://localhost:53418").AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Persistence.AppDbContext>();
                SeedData.SeedDataFunc(context);
            }
            app.UseCors("AllowFrontend");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
