using Domain.Abstract.DBQueryDesigner;
using Domain.Entity;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

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
            builder.Services.AddScoped<
                IDBQueryDesignerSet<Domain.Entity.User>,
                Persistence.DBQueryDesigner.DBQueryDesignerSet<Domain.Entity.User>
                >();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Инициализируем базу данных начальными данными
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<Persistence.AppDbContext>();
                    SeedData(context);
                }

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        private static void SeedData(AppDbContext context)
        {
            // Создаем компании
            var company1 = new Company
            {
                Id = Guid.NewGuid(),
                Title = Title.Create("Tech Solutions Inc.").Value,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var company2 = new Company
            {
                Id = Guid.NewGuid(),
                Title = Title.Create("Innovative Projects LLC").Value,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Companies.AddRange(company1, company2);

            // Создаем должности
            var positions = new[]
            {
                new PositionInCompany
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company1.Id,
                    Title = Title.Create("Software Developer").Value,
                    Description = Text.Create("Разработчик программного обеспечения").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PositionInCompany
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company1.Id,
                    Title = Title.Create("Project Manager").Value,
                    Description = Text.Create("Менеджер проектов").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PositionInCompany
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company2.Id,
                    Title = Title.Create("Team Lead").Value,
                    Description = Text.Create("Руководитель команды").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.PositionsInCompany.AddRange(positions);

            // Создаем пользователей
            var users = new[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = Email.Create("john.doe@techsolutions.com").Value,
                    Username = Username.Create("johndoe").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = Email.Create("jane.smith@techsolutions.com").Value,
                    Username = Username.Create("janesmith").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = Email.Create("mike.johnson@innovative.com").Value,
                    Username = Username.Create("mikej").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Users.AddRange(users);

            // Создаем сотрудников
            var employees = new[]
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company1.Id,
                    PositionInCompanyId = positions[0].Id,
                    UserId = users[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company1.Id,
                    PositionInCompanyId = positions[1].Id,
                    UserId = users[1].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company2.Id,
                    PositionInCompanyId = positions[2].Id,
                    UserId = users[2].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Employees.AddRange(employees);

            // Создаем проекты
            var projects = new[]
            {
                new Project
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company1.Id,
                    Title = Title.Create("Corporate Messenger Development").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    CompanyId = company1.Id,
                    Title = Title.Create("Mobile App Redesign").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Projects.AddRange(projects);

            // Создаем команды
            var teams = new[]
            {
                new Team
                {
                    Id = Guid.NewGuid(),
                    ProjectId = projects[0].Id,
                    Title = Title.Create("Backend Team").Value,
                    StandardSprintDuration = 14,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    ProjectId = projects[0].Id,
                    Title = Title.Create("Frontend Team").Value,
                    StandardSprintDuration = 14,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Teams.AddRange(teams);

            // Создаем членов команд
            var teamMembers = new[]
            {
                new TeamMember
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employees[0].Id,
                    TeamId = teams[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TeamMember
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employees[1].Id,
                    TeamId = teams[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.TeamMembers.AddRange(teamMembers);

            // Создаем спринты
            var sprints = new[]
            {
                new Sprint
                {
                    Id = Guid.NewGuid(),
                    TeamId = teams[0].Id,
                    DateStart = DateTime.UtcNow.AddDays(-14),
                    DateEnd = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sprint
                {
                    Id = Guid.NewGuid(),
                    TeamId = teams[0].Id,
                    DateStart = DateTime.UtcNow,
                    DateEnd = DateTime.UtcNow.AddDays(14),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Sprints.AddRange(sprints);

            // Создаем задачи
            var taskItems = new[]
            {
                new TaskItem
                {
                    Id = Guid.NewGuid(),
                    ProjectId = projects[0].Id,
                    AuthorId = employees[1].Id,
                    ResponsibleId = employees[0].Id,
                    Title = Title.Create("Implement User Authentication").Value,
                    Description = Text.Create("Реализовать систему аутентификации пользователей с JWT токенами").Value,
                    Priority = 1,
                    Complexity = 3,
                    Deadline = DateTime.UtcNow.AddDays(30),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TaskItem
                {
                    Id = Guid.NewGuid(),
                    ProjectId = projects[0].Id,
                    AuthorId = employees[1].Id,
                    ResponsibleId = employees[0].Id,
                    Title = Title.Create("Design Database Schema").Value,
                    Description = Text.Create("Спроектировать схему базы данных для мессенджера").Value,
                    Priority = 2,
                    Complexity = 2,
                    Deadline = DateTime.UtcNow.AddDays(15),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.TaskItems.AddRange(taskItems);

            // Создаем связи задач со спринтами
            var taskItemInSprints = new[]
            {
                new TaskItemInSprint
                {
                    Id = Guid.NewGuid(),
                    TaskItemId = taskItems[0].Id,
                    SprintId = sprints[1].Id,
                    TaskStatus = TaskItemStatus.Status1,
                    Description = Text.Create("Задача в текущем спринте").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.TaskItemInSprints.AddRange(taskItemInSprints);

            // Создаем колонки канбан-доски
            var kanbanColumns = new[]
            {
                new KanbanBoardColumn
                {
                    Id = Guid.NewGuid(),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status1,
                    PositionOnBoard = 1,
                    Title = Title.Create("To Do").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KanbanBoardColumn
                {
                    Id = Guid.NewGuid(),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status2,
                    PositionOnBoard = 2,
                    Title = Title.Create("In Progress").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KanbanBoardColumn
                {
                    Id = Guid.NewGuid(),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status2,
                    PositionOnBoard = 3,
                    Title = Title.Create("Done").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.KanbanBoardColumns.AddRange(kanbanColumns);

            context.SaveChanges();
        }
    }
}
