using Domain.Entity;
using Domain.ValueObjects;
using Persistence;

namespace ReactApp.Server
{
    internal static class SeedData
    {
        internal static void SeedDataFunc(AppDbContext context)
        {
            // Создаем компании
            var company1 = new Company
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = Title.Create("Tech Solutions Inc.").Value,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var company2 = new Company
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
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
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333331"),
                    CompanyId = company1.Id,
                    Title = Title.Create("Software Developer").Value,
                    Description = Text.Create("Разработчик программного обеспечения").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PositionInCompany
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333332"),
                    CompanyId = company1.Id,
                    Title = Title.Create("Project Manager").Value,
                    Description = Text.Create("Менеджер проектов").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PositionInCompany
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    CompanyId = company2.Id,
                    Title = Title.Create("Team Lead").Value,
                    Description = Text.Create("Руководитель команды").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.PositionsInCompany.AddRange(positions);

            var users = new[]
            {
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444441"),
                    Email = Email.Create("john.doe@techsolutions.com").Value,
                    Username = Username.Create("johndoe").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("123456789").Value,
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444442"),
                    Email = Email.Create("jane.smith@techsolutions.com").Value,
                    Username = Username.Create("janesmith").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("123456789").Value,
                    Role = "User",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444443"),
                    Email = Email.Create("mike.johnson@innovative.com").Value,
                    Username = Username.Create("mikej").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("123456789").Value,
                    Role = "User",
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
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555551"),
                    CompanyId = company1.Id,
                    PositionInCompanyId = positions[0].Id,
                    UserId = users[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555552"),
                    CompanyId = company1.Id,
                    PositionInCompanyId = positions[1].Id,
                    UserId = users[1].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555553"),
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
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666661"),
                    CompanyId = company1.Id,
                    Title = Title.Create("Corporate Messenger Development").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = Guid.Parse("66666666-6666-6666-6666-666666666662"),
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
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777771"),
                    ProjectId = projects[0].Id,
                    Title = Title.Create("Backend Team").Value,
                    StandardSprintDuration = 14,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Team
                {
                    Id = Guid.Parse("77777777-7777-7777-7777-777777777772"),
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
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888881"),
                    EmployeeId = employees[0].Id,
                    TeamId = teams[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TeamMember
                {
                    Id = Guid.Parse("88888888-8888-8888-8888-888888888882"),
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
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999991"),
                    TeamId = teams[0].Id,
                    DateStart = DateTime.UtcNow.AddDays(-14),
                    DateEnd = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sprint
                {
                    Id = Guid.Parse("99999999-9999-9999-9999-999999999992"),
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
                    Id = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA1"),
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
                    Id = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAA2"),
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
                    Id = Guid.Parse("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBB1"),
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
                    Id = Guid.Parse("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCC1"),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status1,
                    PositionOnBoard = 1,
                    Title = Title.Create("To Do").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KanbanBoardColumn
                {
                    Id = Guid.Parse("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCC2"),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status2,
                    PositionOnBoard = 2,
                    Title = Title.Create("In Progress").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KanbanBoardColumn
                {
                    Id = Guid.Parse("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCC3"),
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
