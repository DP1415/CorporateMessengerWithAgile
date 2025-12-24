using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

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
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations(); // Включаем поддержку атрибутов
            });

            // настройка
            builder.Services.AddAutoMapper(Application.DependencyInjection.Assembly);
            builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssemblies(Application.DependencyInjection.Assembly));
            builder.Services.AddValidatorsFromAssembly(Application.DependencyInjection.Assembly);

            // Регистрируем DbContext с InMemory базой
            builder.Services.AddDbContext<Persistence.AppDbContext>(options => options.UseInMemoryDatabase("CorporateMessengerDb"));

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                //options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                //options.JsonSerializerOptions.Converters.Add(new ValueObjectJsonConverterFactory());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Инициализируем базу данных начальными данными
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<Persistence.AppDbContext>();
                    //SeedData.SeedDataFunc(context);
                }

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
