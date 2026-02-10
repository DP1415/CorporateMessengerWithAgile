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
        #region Create Entity
        private static Company CreateCompany(string id, string title) => new()
        {
            Id = Guid.Parse(id),
            Title = Title.Create(title).Value,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static PositionInCompany CreatePositionInCompany(string id, Company company, string title, string description) => new()
        {
            Id = Guid.Parse(id),
            CompanyId = company.Id,
            Title = Title.Create(title).Value,
            Description = Text.Create(description).Value,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static User CreateUser(string id, string email, string username, string password, string phoneNumber, string role) => new()
        {
            Id = Guid.Parse(id),
            Email = Email.Create(email).Value,
            Username = Username.Create(username).Value,
            PasswordHashed = PasswordHashed.Create(password).Value,
            PhoneNumber = PhoneNumber.Create(phoneNumber).Value,
            Role = role,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static Employee CreateEmployee(string id, Company company, PositionInCompany position, User user) => new()
        {
            Id = Guid.Parse(id),
            CompanyId = company.Id,
            PositionInCompanyId = position.Id,
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static Project CreateProject(string id, Company company, string title) => new()
        {
            Id = Guid.Parse(id),
            CompanyId = company.Id,
            Title = Title.Create(title).Value,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static Team CreateTeam(string id, Project project, string title, int sprintDuration) => new()
        {
            Id = Guid.Parse(id),
            ProjectId = project.Id,
            Title = Title.Create(title).Value,
            StandardSprintDuration = sprintDuration,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static TeamMember CreateTeamMember(string id, Employee employee, Team team) => new()
        {
            Id = Guid.Parse(id),
            EmployeeId = employee.Id,
            TeamId = team.Id,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static Sprint CreateSprint(string id, Team team, DateTime dateStart, DateTime dateEnd) => new()
        {
            Id = Guid.Parse(id),
            TeamId = team.Id,
            DateStart = dateStart,
            DateEnd = dateEnd,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static TaskItem CreateTaskItem(string id, Project project, Employee author, Employee responsible, string title, string description, int priority, int complexity, DateTime deadline) => new()
        {
            Id = Guid.Parse(id),
            ProjectId = project.Id,
            AuthorId = author.Id,
            ResponsibleId = responsible.Id,
            Title = Title.Create(title).Value,
            Description = Text.Create(description).Value,
            Priority = priority,
            Complexity = complexity,
            Deadline = deadline,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static TaskItemInSprint CreateTaskItemInSprint(string id, TaskItem taskItem, Sprint sprint, TaskItemStatus status, string description) => new()
        {
            Id = Guid.Parse(id),
            TaskItemId = taskItem.Id,
            SprintId = sprint.Id,
            TaskStatus = status,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        private static KanbanBoardColumn CreateKanbanBoardColumn(string id, Team team, TaskItemStatus status, int position, string title) => new()
        {
            Id = Guid.Parse(id),
            TeamId = team.Id,
            TaskStatus = status,
            PositionOnBoard = position,
            Title = Title.Create(title).Value,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        #endregion

        private static User CreateMainUser() => CreateUser("00000001-0000-4444-bbbb-faaaaaaaaa01", "main@main.com", "janesmith", "Password123!", "1111111111", "User");

        internal static void SeedDataFunc(AppDbContext context)
        {
            if (context.Users.Any()) return;

            //CreateMainData(context);

            CreateOtherData(context);
        }

        private static void CreateOtherData(AppDbContext context)
        {
            User user1 = CreateMainUser();
            User user2 = CreateUser("00000001-0000-4444-aaaa-faaaaaaaaa02", "dev@main.com", "alexdev", "SecurePass456!", "2222222222", "Developer");

            Company company = CreateCompany("00000002-1111-4444-aaaa-faaaaaaaaa01", "Main Тестовая Компания ООО");

            PositionInCompany positionLead = CreatePositionInCompany("00000003-0001-4444-aaaa-0001aaaaaa01", company, "Главный разработчик", "Единственный разработчик в компании.");
            PositionInCompany positionDev = CreatePositionInCompany("00000003-0001-4444-aaaa-0001aaaaaa02", company, "Старший разработчик", "Backend-разработчик.");

            Employee employee1 = CreateEmployee("00000004-1111-4444-aaaa-faaaaaaaaa01", company, positionLead, user1);
            Employee employee2 = CreateEmployee("00000004-1111-4444-aaaa-faaaaaaaaa02", company, positionDev, user2);

            Project projectAlpha = CreateProject("00000005-1111-4444-aaaa-faaaaaaaaa01", company, "Тестовый проект");
            Project projectNeuron = CreateProject("00000005-1111-4444-aaaa-faaaaaaaaa02", company, "Проект Нейрон");
            Project projectGalaxy = CreateProject("00000005-1111-4444-aaaa-faaaaaaaaa03", company, "Проект Галактика");

            Team teamAlpha1 = CreateTeam("00000006-1111-4444-aaaa-faaaaaaaaa01", projectAlpha, "Команда Альфа", 14);
            Team teamAlpha2 = CreateTeam("00000006-1111-4444-aaaa-faaaaaaaaa02", projectAlpha, "Команда Бета", 14);

            TeamMember tmAlpha1 = CreateTeamMember("00000008-1111-4444-aaaa-faaaaaaaaa01", employee1, teamAlpha1);
            TeamMember tmAlpha2 = CreateTeamMember("00000008-1111-4444-aaaa-faaaaaaaaa02", employee1, teamAlpha2);

            var now = DateTime.UtcNow;

            // Создаем спринты для команд
            Sprint sprint1 = CreateSprint("0000000a-1111-4444-aaaa-faaaaaaaaa01", teamAlpha1, now.AddDays(-14), now.AddDays(0));
            Sprint sprint2 = CreateSprint("0000000a-1111-4444-aaaa-faaaaaaaaa02", teamAlpha1, now.AddDays(1), now.AddDays(15));
            Sprint sprint3 = CreateSprint("0000000a-1111-4444-aaaa-faaaaaaaaa03", teamAlpha2, now.AddDays(-10), now.AddDays(4));
            Sprint sprint4 = CreateSprint("0000000a-1111-4444-aaaa-faaaaaaaaa04", teamAlpha2, now.AddDays(5), now.AddDays(19));

            // Создаем задачи
            TaskItem task1 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa01", projectAlpha, employee1, employee2, "Разработка главной страницы", "Создать компонент главной страницы с навигацией", 2, 3, now.AddDays(10));
            TaskItem task2 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa02", projectAlpha, employee1, employee1, "Настройка аутентификации", "Реализовать систему входа и регистрации пользователей", 1, 4, now.AddDays(14));
            TaskItem task3 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa03", projectNeuron, employee1, employee1, "Анализ алгоритмов", "Исследование эффективности различных ML-алгоритмов", 3, 5, now.AddDays(20));
            TaskItem task4 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa04", projectAlpha, employee1, employee2, "Разработка профильной страницы", "Создание страницы профиля пользователя", 2, 2, now.AddDays(8));
            TaskItem task5 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa05", projectAlpha, employee1, employee1, "Настройка логирования", "Реализовать систему логирования событий", 1, 3, now.AddDays(12));
            TaskItem task6 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa06", projectAlpha, employee1, employee2, "Тестирование API", "Написать unit-тесты для основных API-эндпоинтов", 3, 4, now.AddDays(15));
            TaskItem task7 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa07", projectAlpha, employee1, employee1, "Оптимизация производительности", "Улучшение скорости загрузки страниц", 2, 3, now.AddDays(11));
            TaskItem task8 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa08", projectAlpha, employee1, employee2, "Интеграция с внешним API", "Подключение стороннего сервиса", 2, 4, now.AddDays(13));
            TaskItem task9 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa09", projectAlpha, employee1, employee1, "Реализация уведомлений", "Система внутренних уведомлений", 1, 2, now.AddDays(9));
            TaskItem task10 = CreateTaskItem("00000009-1111-4444-aaaa-faaaaaaaaa10", projectAlpha, employee1, employee2, "Разработка админ-панели", "Интерфейс управления контентом", 3, 5, now.AddDays(18));

            // Создаем задачи в спринтах
            TaskItemInSprint taskInSprint1 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa01", task1, sprint1, TaskItemStatus.InProgress, "В работе");
            TaskItemInSprint taskInSprint2 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa02", task2, sprint1, TaskItemStatus.Available, "В работе");
            TaskItemInSprint taskInSprint3 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa03", task3, sprint2, TaskItemStatus.Postponed, "Запланировано");
            TaskItemInSprint taskInSprint4 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa04", task4, sprint2, TaskItemStatus.InProgress, "В работе");
            TaskItemInSprint taskInSprint5 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa05", task5, sprint3, TaskItemStatus.Available, "В работе");
            TaskItemInSprint taskInSprint6 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa06", task6, sprint3, TaskItemStatus.Postponed, "Запланировано");
            TaskItemInSprint taskInSprint7 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa07", task7, sprint4, TaskItemStatus.InProgress, "В работе");
            TaskItemInSprint taskInSprint8 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa08", task8, sprint4, TaskItemStatus.Available, "В работе");
            TaskItemInSprint taskInSprint9 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa09", task9, sprint1, TaskItemStatus.InProgress, "В работе");
            TaskItemInSprint taskInSprint10 = CreateTaskItemInSprint("0000000b-1111-4444-aaaa-faaaaaaaaa10", task10, sprint2, TaskItemStatus.Postponed, "Запланировано");

            context.Users.AddRange(user1, user2);
            context.Companies.Add(company);
            context.PositionsInCompany.AddRange(positionLead, positionDev);
            context.Employees.AddRange(employee1, employee2);
            context.Projects.AddRange(projectAlpha, projectNeuron, projectGalaxy);
            context.Teams.AddRange(teamAlpha1, teamAlpha2);
            context.TeamMembers.AddRange(tmAlpha1, tmAlpha2);
            context.Sprints.AddRange(sprint1, sprint2, sprint3, sprint4);
            context.TaskItems.AddRange(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10);
            context.TaskItemInSprints.AddRange(taskInSprint1, taskInSprint2, taskInSprint3, taskInSprint4, taskInSprint5, taskInSprint6, taskInSprint7, taskInSprint8, taskInSprint9, taskInSprint10);

            context.SaveChanges();
        }

        private static void CreateMainData(AppDbContext context)
        {
            var now = DateTime.UtcNow;

            #region Users
            User[] users =
            [
                CreateMainUser(),
                CreateUser("00000002-0000-4444-aaaa-aaaaaaaaaa02", "maria@techsolutions.com", "maria", "Password123!", "1111111112", "User"),
                CreateUser("00000003-0000-4444-aaaa-aaaaaaaaaa03", "alex@innovative.com", "alex", "Password123!", "2222222221", "User"),
                CreateUser("00000004-0000-4444-aaaa-aaaaaaaaaa04", "olga@innovative.com", "olga", "Password123!", "2222222222", "User"),
                CreateUser("00000005-0000-4444-aaaa-aaaaaaaaaa05", "dmitry@digital.ru", "dmitry", "Password123!", "3333333331", "User"),
                CreateUser("00000006-0000-4444-aaaa-aaaaaaaaaa06", "elena@digital.ru", "elena", "Password123!", "3333333332", "User")
            ];
            context.Users.AddRange(users);
            #endregion

            #region Companies
            Company[] companies =
            [
                CreateCompany("00000007-1111-4444-aaaa-faaaaaaaaa01", "Main ТехноРешения ООО"),
                CreateCompany("00000008-2222-4444-aaaa-aaaaaaaaaa02", "Инновационные Проекты ЗАО"),
                CreateCompany("00000009-3333-4444-aaaa-aaaaaaaaaa03", "Цифровые Системы ПАО")
            ];
            context.Companies.AddRange(companies);
            #endregion

            #region Positions
            PositionInCompany[] positions =
            [
                CreatePositionInCompany("00000010-0001-4444-baaa-0001aaaaaa01", companies[0], "main Разработчик ПО", "Основной разработчик."),
                CreatePositionInCompany("00000011-0001-4444-baaa-0001aaaaaa02", companies[0], "DevOps Инженер", "Настройка и поддержка CI/CD."),
                CreatePositionInCompany("00000012-0002-4444-aaaa-0002aaaaaa01", companies[1], "Разработчик ПО", "Основной разработчик."),
                CreatePositionInCompany("00000013-0002-4444-aaaa-0002aaaaaa02", companies[1], "DevOps Инженер", "Настройка и поддержка CI/CD."),
                CreatePositionInCompany("00000014-0003-4444-aaaa-0003aaaaaa01", companies[2], "Разработчик ПО", "Основной разработчик."),
                CreatePositionInCompany("00000015-0003-4444-aaaa-0003aaaaaa02", companies[2], "DevOps Инженер", "Настройка и поддержка CI/CD.")
            ];
            context.PositionsInCompany.AddRange(positions);
            #endregion

            #region Employees
            Employee[] employees =
            [
                CreateEmployee("00000016-1111-4444-aaaa-faaaaaaaaa01", companies[0], positions[0], users[0]),
                CreateEmployee("00000017-1111-4444-aaaa-aaaaaaaaaa02", companies[0], positions[1], users[1]),
                CreateEmployee("00000018-2222-4444-aaaa-aaaaaaaaaa03", companies[1], positions[2], users[2]),
                CreateEmployee("00000019-2222-4444-aaaa-aaaaaaaaaa04", companies[1], positions[3], users[3]),
                CreateEmployee("00000020-3333-4444-aaaa-aaaaaaaaaa05", companies[2], positions[4], users[4]),
                CreateEmployee("00000021-3333-4444-aaaa-aaaaaaaaaa06", companies[2], positions[5], users[5])
            ];
            context.Employees.AddRange(employees);
            #endregion

            #region Projects
            Project[] projects =
            [
                CreateProject("00000022-1111-4444-aaaa-faaaaaaaaa01", companies[0], "main CRM система"),
                CreateProject("00000023-2222-4444-aaaa-baaaaaaaaa02", companies[0], "Мобильное приложение"),
                CreateProject("00000024-3333-4444-aaaa-aaaaaaaaaa03", companies[1], "BI Dashboard"),
                CreateProject("00000025-4444-4444-aaaa-aaaaaaaaaa04", companies[1], "Аналитический модуль"),
                CreateProject("00000026-5555-4444-aaaa-aaaaaaaaaa05", companies[2], "Облачная платформа"),
                CreateProject("00000027-1111-4444-aaaa-aaaaaaaaaa06", companies[2], "CI/CD сервис"),
            ];
            context.Projects.AddRange(projects);
            #endregion

            #region Teams
            Team[] teams =
            [
                CreateTeam("00000028-1111-4444-aaaa-faaaaaaaaa01", projects[0], "main Команда CRM", 14),
                CreateTeam("00000029-2222-4444-aaaa-aaaaaaaaaa02", projects[1], "Мобильная команда", 14),
                CreateTeam("00000030-3333-4444-aaaa-aaaaaaaaaa03", projects[2], "BI команда", 14),
                CreateTeam("00000031-4444-4444-aaaa-aaaaaaaaaa04", projects[3], "Аналитики", 14),
                CreateTeam("00000032-5555-4444-aaaa-aaaaaaaaaa05", projects[4], "Cloud Team", 14),
                CreateTeam("00000033-1111-4444-aaaa-aaaaaaaaaa06", projects[5], "DevOps Team", 14),
                CreateTeam("00000034-1111-4444-aaaa-faaaaaaaaa07", projects[0], "main Команда CRM2", 14),
            ];
            context.Teams.AddRange(teams);
            #endregion

            #region TeamMembers
            TeamMember[] teamMembers =
            [
                CreateTeamMember("00000035-1111-4444-aaaa-faaaaaaaaa01", employees[0], teams[0]),
                CreateTeamMember("00000036-2222-4444-aaaa-aaaaaaaaaa02", employees[1], teams[1]),
                CreateTeamMember("00000037-3333-4444-aaaa-aaaaaaaaaa03", employees[2], teams[2]),
                CreateTeamMember("00000038-4444-4444-aaaa-aaaaaaaaaa04", employees[3], teams[3]),
                CreateTeamMember("00000039-5555-4444-aaaa-aaaaaaaaaa05", employees[4], teams[4]),
                CreateTeamMember("00000040-6666-4444-aaaa-aaaaaaaaaa06", employees[5], teams[5]),
                CreateTeamMember("00000041-1111-4444-aaaa-faaaaaaaaa07", employees[0], teams[6]),
            ];
            context.TeamMembers.AddRange(teamMembers);
            #endregion

            #region Sprints
            Sprint[] sprints =
            [
                CreateSprint("00000042-1111-4444-aaaa-aaaaaaaaaa01", teams[0], now.AddDays(-14), now),
                CreateSprint("00000043-1111-4444-aaaa-aaaaaaaaaa02", teams[0], now, now.AddDays(14)),
                CreateSprint("00000044-2222-4444-aaaa-aaaaaaaaaa03", teams[1], now.AddDays(-14), now),
                CreateSprint("00000045-2222-4444-aaaa-aaaaaaaaaa04", teams[1], now, now.AddDays(14)),
                CreateSprint("00000046-3333-4444-aaaa-aaaaaaaaaa05", teams[2], now.AddDays(-14), now),
                CreateSprint("00000047-3333-4444-aaaa-aaaaaaaaaa06", teams[2], now, now.AddDays(14)),
                CreateSprint("00000048-4444-4444-aaaa-aaaaaaaaaa07", teams[3], now.AddDays(-14), now),
                CreateSprint("00000049-4444-4444-aaaa-aaaaaaaaaa08", teams[3], now, now.AddDays(14)),
                CreateSprint("00000050-5555-4444-aaaa-aaaaaaaaaa09", teams[4], now.AddDays(-14), now),
                CreateSprint("00000051-5555-4444-aaaa-aaaaaaaaaa10", teams[4], now, now.AddDays(14)),
                CreateSprint("00000052-6666-4444-aaaa-aaaaaaaaaa11", teams[5], now.AddDays(-14), now),
            ];
            context.Sprints.AddRange(sprints);
            #endregion

            #region Task Items
            TaskItem[] taskItems =
            [
                CreateTaskItem("00000053-1111-4444-aaaa-aaaaaaaaaa01", projects[0], employees[0], employees[0], "Спроектировать БД", "ER-диаграмма и миграции", 1, 3, now.AddDays(5)),
                CreateTaskItem("00000054-2222-4444-aaaa-aaaaaaaaaa02", projects[0], employees[0], employees[0], "Реализовать авторизацию", "JWT + refresh tokens", 2, 2, now.AddDays(7)),
                CreateTaskItem("00000055-3333-4444-aaaa-aaaaaaaaaa03", projects[0], employees[0], employees[0], "UI списка клиентов", "React + таблица", 1, 2, now.AddDays(10)),
                CreateTaskItem("00000056-4444-4444-aaaa-aaaaaaaaaa04", projects[0], employees[0], employees[0], "Unit-тесты", "Покрыть сервисы", 3, 1, now.AddDays(12)),
                CreateTaskItem("00000057-5555-4444-aaaa-aaaaaaaaaa05", projects[1], employees[0], employees[0], "Настроить сборку", "Webpack + TypeScript", 2, 2, now.AddDays(6)),
                CreateTaskItem("00000058-6666-4444-aaaa-aaaaaaaaaa06", projects[1], employees[0], employees[0], "Push-уведомления", "Firebase integration", 1, 4, now.AddDays(14)),
                CreateTaskItem("00000059-7777-4444-aaaa-aaaaaaaaaa07", projects[2], employees[1], employees[1], "Подключить данные", "Источники: PostgreSQL, API", 1, 3, now.AddDays(8)),
                CreateTaskItem("00000060-8888-4444-aaaa-aaaaaaaaaa08", projects[2], employees[1], employees[1], "Графики", "D3.js или Chart.js", 2, 3, now.AddDays(11))
            ];
            context.TaskItems.AddRange(taskItems);
            #endregion

            #region Task Item in Sprints
            TaskItemInSprint[] taskItemInSprints =
            [
                CreateTaskItemInSprint("00000061-1111-4444-aaaa-aaaaaaaaaa01", taskItems[0], sprints[0], TaskItemStatus.Available, "В работе"),
                CreateTaskItemInSprint("00000062-2222-4444-aaaa-aaaaaaaaaa02", taskItems[1], sprints[0], TaskItemStatus.Postponed, "Запланировано"),
                CreateTaskItemInSprint("00000063-3333-4444-aaaa-aaaaaaaaaa03", taskItems[2], sprints[1], TaskItemStatus.InProgress, "Завершено"),
                CreateTaskItemInSprint("00000064-4444-4444-aaaa-aaaaaaaaaa04", taskItems[3], sprints[1], TaskItemStatus.Available, "В работе"),
                CreateTaskItemInSprint("00000065-5555-4444-aaaa-aaaaaaaaaa05", taskItems[4], sprints[2], TaskItemStatus.Postponed, "Запланировано"),
                CreateTaskItemInSprint("00000066-6666-4444-aaaa-aaaaaaaaaa06", taskItems[5], sprints[3], TaskItemStatus.Available, "В работе"),
                CreateTaskItemInSprint("00000067-7777-4444-aaaa-aaaaaaaaaa07", taskItems[6], sprints[4], TaskItemStatus.Postponed, "Запланировано"),
                CreateTaskItemInSprint("00000068-8888-4444-aaaa-aaaaaaaaaa08", taskItems[7], sprints[5], TaskItemStatus.InProgress, "Завершено")
            ];
            context.TaskItemInSprints.AddRange(taskItemInSprints);
            #endregion

            #region Kanban Board Columns
            KanbanBoardColumn[] kanbanColumns =
            [
                CreateKanbanBoardColumn("00000069-1111-4444-aaaa-aaaaaaaaaa01", teams[0], TaskItemStatus.Postponed, 1, "К выполнению"),
                CreateKanbanBoardColumn("00000070-2222-4444-aaaa-aaaaaaaaaa02", teams[0], TaskItemStatus.Available, 2, "В работе"),
                CreateKanbanBoardColumn("00000071-3333-4444-aaaa-aaaaaaaaaa03", teams[0], TaskItemStatus.InProgress, 3, "Завершено"),
                CreateKanbanBoardColumn("00000072-1111-4444-aaaa-aaaaaaaaaa04", teams[1], TaskItemStatus.Postponed, 1, "К выполнению"),
                CreateKanbanBoardColumn("00000073-2222-4444-aaaa-aaaaaaaaaa05", teams[1], TaskItemStatus.Available, 2, "В работе"),
                CreateKanbanBoardColumn("00000074-3333-4444-aaaa-aaaaaaaaaa06", teams[1], TaskItemStatus.InProgress, 3, "Завершено")
            ];
            context.KanbanBoardColumns.AddRange(kanbanColumns);
            #endregion

            context.SaveChanges();
        }
    }
}
