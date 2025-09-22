using Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // настройка
            builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Application.DependencyInjection.Assembly));
            builder.Services.AddValidatorsFromAssembly(Application.DependencyInjection.Assembly);

            // Регистрируем DbContext с InMemory базой
            builder.Services.AddDbContext<Persistence.AppDbContext>(options => options.UseInMemoryDatabase("CorporateMessengerDb"));
            builder.Services.AddScoped<IRepository<Domain.Entity.User>, Persistence.Repository.UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
