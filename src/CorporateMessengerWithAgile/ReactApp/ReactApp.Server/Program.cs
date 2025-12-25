
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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(Application.DependencyInjection.Assembly);
            builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Application.DependencyInjection.Assembly));
            builder.Services.AddValidatorsFromAssembly(Application.DependencyInjection.Assembly);
            builder.Services.AddDbContext<Persistence.AppDbContext>(options => options.UseInMemoryDatabase("CorporateMessengerDb"));

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
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
