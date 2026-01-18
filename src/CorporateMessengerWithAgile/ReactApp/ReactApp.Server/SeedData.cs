using Domain.Entity;
using Domain.ValueObjects;
using Persistence;

namespace ReactApp.Server
{
    /// <summary>
    /// Seeds the database with initial data for testing and development purposes.
    /// All IDs are valid UUID v4: xxxxxxxx-xxxx-4xxx-[89ab]xxxx-xxxxxxxxxxxx
    /// </summary>
    internal static class SeedData
    {
        internal static void SeedDataFunc(AppDbContext context)
        {
            if (context.Users.Any())
            {
                // Already seeded
                return;
            }

            #region Companies
            // Create sample companies
            var techSolutions = new Company
            {
                Id = Guid.Parse("11111111-1111-4111-8111-111111111111"),
                Title = Title.Create("Tech Solutions Inc.").Value,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var innovativeProjects = new Company
            {
                Id = Guid.Parse("22222222-2222-4222-a222-222222222222"),
                Title = Title.Create("Innovative Projects LLC").Value,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Companies.AddRange(techSolutions, innovativeProjects);
            #endregion

            #region Positions
            // Create sample positions within companies
            var positions = new[]
            {
                new PositionInCompany
                {
                    Id = Guid.Parse("33333333-3333-4333-b333-333333333331"),
                    CompanyId = techSolutions.Id,
                    Title = Title.Create("Software Developer").Value,
                    Description = Text.Create("Develops software solutions and applications.").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PositionInCompany
                {
                    Id = Guid.Parse("33333333-3333-4333-9333-333333333332"),
                    CompanyId = techSolutions.Id,
                    Title = Title.Create("Project Manager").Value,
                    Description = Text.Create("Manages project timelines and resources.").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new PositionInCompany
                {
                    Id = Guid.Parse("33333333-3333-4333-8333-333333333333"),
                    CompanyId = innovativeProjects.Id,
                    Title = Title.Create("Team Lead").Value,
                    Description = Text.Create("Leads and coordinates a team of developers.").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.PositionsInCompany.AddRange(positions);
            #endregion

            #region Users
            // Create sample users (system accounts)
            var users = new[]
            {
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-b444-444444444441"),
                    Email = Email.Create("admin@techsolutions.com").Value,
                    Username = Username.Create("admin").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("123456789").Value,
                    Role = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-a444-444444444442"),
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
                    Id = Guid.Parse("44444444-4444-4444-8444-444444444443"),
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
            #endregion

            #region Employees
            // Link users to companies via employees
            var employees = new[]
            {
                new Employee
                {
                    Id = Guid.Parse("55555555-5555-4555-9555-555555555551"),
                    CompanyId = techSolutions.Id,
                    PositionInCompanyId = positions[0].Id, // Software Developer
                    UserId = users[0].Id, // admin
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.Parse("55555555-5555-4555-a555-555555555552"),
                    CompanyId = techSolutions.Id,
                    PositionInCompanyId = positions[1].Id, // Project Manager
                    UserId = users[1].Id, // jane.smith
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.Parse("55555555-5555-4555-b555-555555555553"),
                    CompanyId = innovativeProjects.Id,
                    PositionInCompanyId = positions[2].Id, // Team Lead
                    UserId = users[2].Id, // mike.johnson
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Employees.AddRange(employees);
            #endregion

            #region Projects
            // Create sample projects under companies
            var projects = new[]
            {
                new Project
                {
                    Id = Guid.Parse("66666666-6666-4666-8666-666666666661"),
                    CompanyId = techSolutions.Id,
                    Title = Title.Create("Corporate Messenger Development").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = Guid.Parse("66666666-6666-4666-9666-666666666662"),
                    CompanyId = techSolutions.Id,
                    Title = Title.Create("Mobile App Redesign").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Projects.AddRange(projects);
            #endregion

            #region Teams
            // Create teams under projects
            var teams = new[]
            {
                new Team
                {
                    Id = Guid.Parse("77777777-7777-4777-a777-777777777771"),
                    ProjectId = projects[0].Id,
                    Title = Title.Create("Backend Team").Value,
                    StandardSprintDuration = 14,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Team
                {
                    Id = Guid.Parse("77777777-7777-4777-b777-777777777772"),
                    ProjectId = projects[0].Id,
                    Title = Title.Create("Frontend Team").Value,
                    StandardSprintDuration = 14,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Teams.AddRange(teams);
            #endregion

            #region Team Members
            // Create team members linking employees to teams
            var teamMembers = new[]
            {
                new TeamMember
                {
                    Id = Guid.Parse("88888888-8888-4888-8888-888888888881"),
                    EmployeeId = employees[0].Id,
                    TeamId = teams[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TeamMember
                {
                    Id = Guid.Parse("88888888-8888-4888-9888-888888888882"),
                    EmployeeId = employees[1].Id,
                    TeamId = teams[0].Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.TeamMembers.AddRange(teamMembers);
            #endregion

            #region Sprints
            // Create sprints for teams
            var sprints = new[]
            {
                new Sprint
                {
                    Id = Guid.Parse("99999999-9999-4999-a999-999999999991"),
                    TeamId = teams[0].Id,
                    DateStart = DateTime.UtcNow.AddDays(-14),
                    DateEnd = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Sprint
                {
                    Id = Guid.Parse("99999999-9999-4999-b999-999999999992"),
                    TeamId = teams[0].Id,
                    DateStart = DateTime.UtcNow,
                    DateEnd = DateTime.UtcNow.AddDays(14),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.Sprints.AddRange(sprints);
            #endregion

            #region Task Items
            // Create task items for projects
            var taskItems = new[]
            {
                new TaskItem
                {
                    Id = Guid.Parse("AAAAAAAA-AAAA-4AAA-8AAA-AAAAAAAAAAA1"),
                    ProjectId = projects[0].Id,
                    AuthorId = employees[1].Id,
                    ResponsibleId = employees[0].Id,
                    Title = Title.Create("Implement User Authentication").Value,
                    Description = Text.Create("Implement user authentication system with JWT tokens.").Value,
                    Priority = 1,
                    Complexity = 3,
                    Deadline = DateTime.UtcNow.AddDays(30),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TaskItem
                {
                    Id = Guid.Parse("AAAAAAAA-AAAA-4AAA-9AAA-AAAAAAAAAAA2"),
                    ProjectId = projects[0].Id,
                    AuthorId = employees[1].Id,
                    ResponsibleId = employees[0].Id,
                    Title = Title.Create("Design Database Schema").Value,
                    Description = Text.Create("Design database schema for the messenger.").Value,
                    Priority = 2,
                    Complexity = 2,
                    Deadline = DateTime.UtcNow.AddDays(15),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.TaskItems.AddRange(taskItems);
            #endregion

            #region Task Item in Sprints
            // Link tasks to sprints
            var taskItemInSprints = new[]
            {
                new TaskItemInSprint
                {
                    Id = Guid.Parse("BBBBBBBB-BBBB-4BBB-ABBB-BBBBBBBBBBB1"),
                    TaskItemId = taskItems[0].Id,
                    SprintId = sprints[1].Id,
                    TaskStatus = TaskItemStatus.Status1,
                    Description = Text.Create("Task in current sprint.").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.TaskItemInSprints.AddRange(taskItemInSprints);
            #endregion

            #region Kanban Board Columns
            // Create kanban board columns for teams
            var kanbanColumns = new[]
            {
                new KanbanBoardColumn
                {
                    Id = Guid.Parse("CCCCCCCC-CCCC-4CCC-8CCC-CCCCCCCCCCC1"),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status1,
                    PositionOnBoard = 1,
                    Title = Title.Create("To Do").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KanbanBoardColumn
                {
                    Id = Guid.Parse("CCCCCCCC-CCCC-4CCC-9CCC-CCCCCCCCCCC2"),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status2,
                    PositionOnBoard = 2,
                    Title = Title.Create("In Progress").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KanbanBoardColumn
                {
                    Id = Guid.Parse("CCCCCCCC-CCCC-4CCC-ACCC-CCCCCCCCCCC3"),
                    TeamId = teams[0].Id,
                    TaskStatus = TaskItemStatus.Status2,
                    PositionOnBoard = 3,
                    Title = Title.Create("Done").Value,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            context.KanbanBoardColumns.AddRange(kanbanColumns);
            #endregion

            context.SaveChanges();
        }
    }
}