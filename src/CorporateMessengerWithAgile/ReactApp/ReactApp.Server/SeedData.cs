using Domain.Entity;
using Domain.ValueObjects;
using Persistence;
using System;

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

            DateTime now = DateTime.UtcNow;

            #region Companies
            Company[] companies =
            [
                new Company
                {
                    Id = Guid.Parse("11111111-1111-4111-8111-111111111111"),
                    Title = Title.Create("ТехноРешения ООО").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Company
                {
                    Id = Guid.Parse("22222222-2222-4222-a222-222222222222"),
                    Title = Title.Create("Инновационные Проекты ЗАО").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Company
                {
                    Id = Guid.Parse("22222222-2222-4222-b222-222222222223"),
                    Title = Title.Create("Цифровые Системы ПАО").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Company
                {
                    Id = Guid.Parse("22222222-2222-4222-c222-222222222224"),
                    Title = Title.Create("ГлобалТек ООО").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new Company
                {
                    Id = Guid.Parse("22222222-2222-4222-d222-222222222225"),
                    Title = Title.Create("СтартапЛаборатория ИП").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                }
            ];

            context.Companies.AddRange(companies);
            #endregion

            #region Positions
            List<PositionInCompany> positions = [];
            int positionIdBase = 1;
            foreach (Company company in companies)
            {
                PositionInCompany[] positionsInCompany =
                [
                    new PositionInCompany
                    {
                        Id = Guid.Parse($"33333333-3333-4333-{(8 + positionIdBase % 4):x}333-3333333333{positionIdBase++:D2}"),
                        CompanyId = company.Id,
                        Title = Title.Create("Разработчик ПО").Value,
                        Description = Text.Create("Разрабатывает программное обеспечение и приложения.").Value,
                        CreatedAt = now,
                        UpdatedAt = now
                    },
                    new PositionInCompany
                    {
                        Id = Guid.Parse($"33333333-3333-4333-{(8 + positionIdBase % 4):x}333-3333333333{positionIdBase++:D2}"),
                        CompanyId = company.Id,
                        Title = Title.Create("Менеджер проекта").Value,
                        Description = Text.Create("Управляет сроками и ресурсами проекта.").Value,
                        CreatedAt = now,
                        UpdatedAt = now
                    },
                    new PositionInCompany
                    {
                        Id = Guid.Parse($"33333333-3333-4333-{(8 + positionIdBase % 4):x}333-3333333333{positionIdBase++:D2}"),
                        CompanyId = company.Id,
                        Title = Title.Create("Тимлид").Value,
                        Description = Text.Create("Руководит командой разработчиков.").Value,
                        CreatedAt = now,
                        UpdatedAt = now
                    }
                ];
                positions.AddRange(positionsInCompany);
            }

            context.PositionsInCompany.AddRange(positions);
            #endregion

            #region Users
            User[] users =
            [
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-b444-444444444441"),
                    Email = Email.Create("admin@techsolutions.com").Value,
                    Username = Username.Create("admin").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567890").Value,
                    Role = "Admin",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-a444-444444444442"),
                    Email = Email.Create("jane.smith@techsolutions.com").Value,
                    Username = Username.Create("janesmith").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567891").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-8444-444444444443"),
                    Email = Email.Create("mike.johnson@innovative.com").Value,
                    Username = Username.Create("mikej").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567892").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-9444-444444444444"),
                    Email = Email.Create("alex.petrov@digital.ru").Value,
                    Username = Username.Create("alexpetrov").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567893").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-c444-444444444445"),
                    Email = Email.Create("elena.sidorova@globaltech.ru").Value,
                    Username = Username.Create("elenas").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567894").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-d444-444444444446"),
                    Email = Email.Create("ivan.kuznetsov@startuplab.ru").Value,
                    Username = Username.Create("ivank").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567895").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-e444-444444444447"),
                    Email = Email.Create("olga.morozova@techsolutions.com").Value,
                    Username = Username.Create("olgam").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567896").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-f444-444444444448"),
                    Email = Email.Create("dmitry.orlov@innovative.com").Value,
                    Username = Username.Create("dmitryo").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567897").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-0444-444444444449"),
                    Email = Email.Create("natalia.volkova@digital.ru").Value,
                    Username = Username.Create("nataliav").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567898").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                },
                new User
                {
                    Id = Guid.Parse("44444444-4444-4444-1444-44444444444a"),
                    Email = Email.Create("sergey.popov@globaltech.ru").Value,
                    Username = Username.Create("sergeyp").Value,
                    PasswordHashed = PasswordHashed.Create("Password123!").Value,
                    PhoneNumber = PhoneNumber.Create("1234567899").Value,
                    Role = "User",
                    CreatedAt = now,
                    UpdatedAt = now
                }
            ];

            context.Users.AddRange(users);
            #endregion

            #region Employees
            List<Employee> employees = [];

            for (int i = 0; i < users.Length; i++)
            {
                employees.Add(new Employee
                {
                    Id = Guid.Parse($"55555555-5555-4555-8555-5555555555{i * 2 + 1:D2}"),
                    CompanyId = companies[0].Id,
                    PositionInCompanyId = positions[0].Id,
                    UserId = users[i].Id,
                    CreatedAt = now,
                    UpdatedAt = now
                });

                employees.Add(new Employee
                {
                    Id = Guid.Parse($"55555555-5555-4555-9555-5555555555{i * 2 + 2:D2}"),
                    CompanyId = companies[1].Id,
                    PositionInCompanyId = positions[3].Id,
                    UserId = users[i].Id,
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.Employees.AddRange(employees);
            #endregion

            #region Projects
            List<Project> projects = [];
            foreach (Company company in companies)
            {
                projects.Add(new Project
                {
                    Id = Guid.Parse($"66666666-6666-4666-{(8 + projects.Count % 4):x}666-6666666666{projects.Count + 1:D2}"),
                    CompanyId = company.Id,
                    Title = Title.Create($"Проект '{company.Title.Value}'").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.Projects.AddRange(projects);
            #endregion

            #region Teams
            List<Team> teams = [];
            foreach (Project project in projects)
            {
                teams.Add(new Team
                {
                    Id = Guid.Parse($"77777777-7777-4777-{(8 + teams.Count % 4):x}777-7777777777{teams.Count + 1:D2}"),
                    ProjectId = project.Id,
                    Title = Title.Create("Основная команда").Value,
                    StandardSprintDuration = 14,
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.Teams.AddRange(teams);
            #endregion

            #region Team Members
            List<TeamMember> teamMembers = [];
            for (int i = 0; i < employees.Count; i++)
            {
                teamMembers.Add(new TeamMember
                {
                    Id = Guid.Parse($"88888888-8888-4888-{(8 + i % 4):x}888-8888888888{i + 1:D2}"),
                    EmployeeId = employees[i].Id,
                    TeamId = teams[i % teams.Count].Id,
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.TeamMembers.AddRange(teamMembers);
            #endregion

            #region Sprints
            List<Sprint> sprints = [];
            foreach (Team team in teams)
            {
                sprints.Add(new Sprint
                {
                    Id = Guid.Parse($"99999999-9999-4999-{(8 + sprints.Count % 4):x}999-9999999999{sprints.Count + 1:D2}"),
                    TeamId = team.Id,
                    DateStart = now.AddDays(-14),
                    DateEnd = now,
                    CreatedAt = now,
                    UpdatedAt = now
                });

                sprints.Add(new Sprint
                {
                    Id = Guid.Parse($"99999999-9999-4999-{(9 + sprints.Count % 4):x}999-9999999999{sprints.Count + 1:D2}"),
                    TeamId = team.Id,
                    DateStart = now,
                    DateEnd = now.AddDays(14),
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.Sprints.AddRange(sprints);
            #endregion

            #region Task Items
            List<TaskItem> taskItems = [];
            string[] taskTitles =
            [
                "Реализовать аутентификацию пользователей",
                "Спроектировать схему базы данных",
                "Настроить CI/CD пайплайн",
                "Разработать REST API для мессенджера",
                "Оптимизировать производительность фронтенда",
                "Написать unit-тесты для модуля авторизации",
                "Интегрировать push-уведомления",
                "Реализовать чат в реальном времени",
                "Подключить систему логирования",
                "Настроить мониторинг ошибок",
                "Разработать админку для управления пользователями",
                "Добавить поддержку темной темы",
                "Импортировать данные из старой системы",
                "Настроить резервное копирование БД",
                "Реализовать двухфакторную аутентификацию",
                "Оптимизировать SQL-запросы",
                "Добавить локализацию интерфейса",
                "Реализовать экспорт отчетов в PDF",
                "Настроить защиту от DDoS-атак",
                "Разработать документацию API",

                "Реализовать восстановление пароля по email",
                "Настроить CORS для внешних клиентов",
                "Добавить валидацию форм на стороне клиента",
                "Интегрировать OpenID Connect",
                "Реализовать загрузку файлов с прогресс-баром",
                "Настроить кэширование через Redis",
                "Реализовать пагинацию для списка сообщений",
                "Добавить поиск по истории чата",
                "Реализовать онлайн-статус пользователей",
                "Настроить rate limiting для API",
                "Реализовать soft delete для пользователей",
                "Добавить историю входов в аккаунт",
                "Интегрировать Sentry для фронтенда",
                "Реализовать drag-and-drop для прикреплений",
                "Настроить HTTPS и HSTS",
                "Реализовать bulk-операции для админки",
                "Добавить поддержку emoji в чате",
                "Реализовать уведомления о прочтении сообщений",
                "Настроить health-check эндпоинты",
                "Реализовать автоматическую очистку старых сессий",

                "Мигрировать с SQLite на PostgreSQL",
                "Реализовать role-based access control (RBAC)",
                "Добавить audit log для критических действий",
                "Реализовать WebSocket heartbeat",
                "Настроить Docker-образы для всех сервисов",
                "Реализовать endpoint для проверки токена",
                "Добавить поддержку Markdown в сообщениях",
                "Реализовать автосохранение черновиков",
                "Настроить alerting в Grafana",
                "Реализовать экспорт чата в JSON",
                "Добавить ограничение на размер загружаемых файлов",
                "Реализовать повторную отправку уведомлений",
                "Настроить retry-механизм для фоновых задач",
                "Реализовать endpoint для массовой рассылки",
                "Добавить поддержку WebP для изображений",
                "Реализовать гео-локацию для пользователей",
                "Настроить backup-стратегию с шифрованием",
                "Реализовать endpoint для смены email",
                "Добавить подтверждение email при регистрации",
                "Реализовать автоматическое обновление зависимостей",

                "Настроить SSO через Google Workspace",
                "Реализовать endpoint для получения статистики",
                "Добавить поддержку темной темы в мобильном приложении",
                "Реализовать механизм отзыва токенов",
                "Настроить tracing с Jaeger",
                "Реализовать endpoint для экспорта пользователей",
                "Добавить капчу при регистрации",
                "Реализовать автоматическое архивирование старых чатов",
                "Настроить мониторинг использования памяти",
                "Реализовать endpoint для импорта контактов",
                "Добавить поддержку нескольких устройств",
                "Реализовать endpoint для удаления аккаунта",
                "Настроить политику безопасности CSP",
                "Реализовать endpoint для обновления профиля",
                "Добавить поддержку биометрической аутентификации",
                "Реализовать endpoint для получения активных сессий",
                "Настроить автоматическое масштабирование в облаке",
                "Реализовать endpoint для сброса настроек",
                "Добавить поддержку offline-режима",
                "Реализовать endpoint для получения логов пользователя"
            ];

            string[] taskDescriptions =
            [
                "Реализовать систему аутентификации с использованием JWT.",
                "Создать ER-диаграмму и таблицы для хранения сообщений и пользователей.",
                "Настроить автоматическую сборку и деплой через GitHub Actions.",
                "Создать endpoints для регистрации, входа и работы с сообщениями.",
                "Уменьшить время загрузки главной страницы на 50%.",
                "Покрыть модуль авторизации тестами на 90%.",
                "Интегрировать Firebase Cloud Messaging.",
                "Использовать WebSocket для передачи сообщений в реальном времени.",
                "Подключить Serilog и отправку логов в Elasticsearch.",
                "Настроить Sentry для отслеживания ошибок в продакшене.",
                "Создать интерфейс для блокировки и удаления пользователей.",
                "Добавить переключатель между светлой и темной темами.",
                "Написать скрипт миграции данных из CSV.",
                "Настроить ежедневные бэкапы PostgreSQL.",
                "Добавить TOTP через Google Authenticator.",
                "Переписать медленные запросы с использованием индексов.",
                "Добавить поддержку русского и английского языков.",
                "Реализовать генерацию PDF через iTextSharp.",
                "Настроить Cloudflare WAF и rate limiting.",
                "Описать все эндпоинты в Swagger/OpenAPI.",

                "Реализовать отправку ссылки для сброса пароля на email пользователя.",
                "Настроить CORS-политики для разрешения запросов с доверенных доменов.",
                "Добавить валидацию email, телефона и пароля на стороне клиента.",
                "Интегрировать вход через корпоративные аккаунты Google или Microsoft.",
                "Реализовать прогресс-бар и отмену загрузки файлов.",
                "Настроить Redis для кэширования часто запрашиваемых данных.",
                "Реализовать пагинацию с limit/offset для списка сообщений.",
                "Добавить полнотекстовый поиск по истории переписки.",
                "Отображать зелёную точку рядом с именем онлайн-пользователя.",
                "Ограничить количество запросов с одного IP в минуту.",
                "Реализовать мягкое удаление без физического удаления из БД.",
                "Отображать дату, время и IP-адрес последних входов.",
                "Подключить Sentry для отслеживания ошибок в браузере.",
                "Реализовать перетаскивание файлов в область чата.",
                "Настроить принудительное использование HTTPS и HSTS headers.",
                "Реализовать массовое удаление, блокировку или экспорт пользователей.",
                "Добавить поддержку emoji и реакций на сообщения.",
                "Отображать двойную галочку при прочтении сообщения.",
                "Создать /health и /ready эндпоинты для Kubernetes.",
                "Автоматически удалять сессии старше 30 дней.",

                "Выполнить миграцию с SQLite на PostgreSQL для production.",
                "Реализовать управление ролями: admin, moderator, user.",
                "Логировать все действия с изменением данных пользователей.",
                "Отправлять ping-сообщения каждые 30 секунд для поддержания соединения.",
                "Создать Dockerfile и docker-compose для всех микросервисов.",
                "Реализовать эндпоинт для проверки валидности JWT-токена.",
                "Добавить поддержку форматирования текста через Markdown.",
                "Автоматически сохранять черновик сообщения каждые 5 секунд.",
                "Настроить алерты при превышении порога CPU или памяти.",
                "Реализовать экспорт истории чата в формате JSON.",
                "Ограничить размер загружаемых файлов до 10 МБ.",
                "Реализовать повторную отправку push-уведомлений при ошибке.",
                "Добавить retry с экспоненциальной задержкой для фоновых задач.",
                "Реализовать отправку уведомлений группе пользователей.",
                "Добавить поддержку формата WebP для уменьшения трафика.",
                "Хранить и отображать геопозицию последнего входа (опционально).",
                "Шифровать резервные копии с помощью AES-256.",
                "Реализовать смену email с подтверждением нового адреса.",
                "Требовать подтверждение email после регистрации.",
                "Настроить Dependabot для автоматического обновления зависимостей.",

                "Реализовать вход через Google Workspace SSO.",
                "Создать эндпоинт для получения статистики по пользователям и сообщениям.",
                "Синхронизировать тему с системными настройками мобильного устройства.",
                "Реализовать механизм немедленного отзыва всех токенов пользователя.",
                "Настроить распределённый трейсинг запросов через Jaeger.",
                "Реализовать экспорт списка пользователей в CSV или JSON.",
                "Добавить reCAPTCHA v3 при регистрации новых аккаунтов.",
                "Автоматически архивировать чаты без активности более 6 месяцев.",
                "Мониторить использование памяти процессами в реальном времени.",
                "Реализовать импорт контактов из CSV или vCard.",
                "Поддерживать одновременный вход с нескольких устройств.",
                "Реализовать полное удаление аккаунта с подтверждением.",
                "Настроить Content Security Policy для защиты от XSS.",
                "Реализовать обновление аватара, имени и статуса.",
                "Добавить вход по Face ID или Touch ID на iOS/Android.",
                "Отображать список активных сессий с возможностью завершения.",
                "Настроить autoscaling в AWS/GCP на основе метрик нагрузки.",
                "Реализовать сброс пользовательских настроек к значениям по умолчанию.",
                "Поддерживать работу приложения без интернета (кэш последних данных).",
                "Предоставлять логи действий пользователя за последние 30 дней."
            ];

            if (taskTitles.Length != taskDescriptions.Length)
                throw new InvalidOperationException($"Количество заголовков и описаний задач не совпадает! ({taskTitles.Length}, {taskDescriptions.Length})");

            for (int i = 0; i < taskTitles.Length; i++)
            {
                taskItems.Add(new TaskItem
                {
                    Id = Guid.Parse($"AAAAAAAA-AAAA-4AAA-{(8 + (i % 4)):x}AAA-AAAAAAAAAA{i + 1:D2}"),
                    ProjectId = projects[i % projects.Count].Id,
                    AuthorId = employees[(i + 1) % employees.Count].Id,
                    ResponsibleId = employees[i % employees.Count].Id,
                    Title = Title.Create(taskTitles[i]).Value,
                    Description = Text.Create(taskDescriptions[i]).Value,
                    Priority = (i % 3) + 1,
                    Complexity = (i % 5) + 1,
                    Deadline = now.AddDays(7 + i * 2),
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.TaskItems.AddRange(taskItems);
            #endregion

            #region Task Item in Sprints
            List<TaskItemInSprint> taskItemInSprints = [];

            for (int i = 0; i < taskItems.Count; i++)
            {
                if (sprints.Count == 0) break;

                int sprintIndex = i % sprints.Count;
                taskItemInSprints.Add(new TaskItemInSprint
                {
                    Id = Guid.Parse($"BBBBBBBB-BBBB-4BBB-{(8 + (i % 4)):x}BBB-BBBBBBBBBB{i + 1:D2}"),
                    TaskItemId = taskItems[i].Id,
                    SprintId = sprints[sprintIndex].Id,
                    TaskStatus = (TaskItemStatus)((i % 3) + 1),
                    Description = Text.Create($"Задача в спринте #{sprintIndex + 1}").Value,
                    CreatedAt = now,
                    UpdatedAt = now
                });
            }

            context.TaskItemInSprints.AddRange(taskItemInSprints);
            #endregion

            #region Kanban Board Columns
            List<KanbanBoardColumn> kanbanColumns = [];
            foreach (Team team in teams)
            {
                kanbanColumns.AddRange([
                    new KanbanBoardColumn
                    {
                        Id = Guid.Parse($"CCCCCCCC-CCCC-4CCC-{(8 + kanbanColumns.Count % 4):x}CCC-CCCCCCCCCC{kanbanColumns.Count + 1:D2}"),
                        TeamId = team.Id,
                        TaskStatus = TaskItemStatus.Status1,
                        PositionOnBoard = 1,
                        Title = Title.Create("К выполнению").Value,
                        CreatedAt = now,
                        UpdatedAt = now
                    },
                    new KanbanBoardColumn
                    {
                        Id = Guid.Parse($"CCCCCCCC-CCCC-4CCC-{(9 + kanbanColumns.Count % 4):x}CCC-CCCCCCCCCC{kanbanColumns.Count + 1:D2}"),
                        TeamId = team.Id,
                        TaskStatus = TaskItemStatus.Status2,
                        PositionOnBoard = 2,
                        Title = Title.Create("В работе").Value,
                        CreatedAt = now,
                        UpdatedAt = now
                    },
                    new KanbanBoardColumn
                    {
                        Id = Guid.Parse($"CCCCCCCC-CCCC-4CCC-{(10 + kanbanColumns.Count % 4):x}CCC-CCCCCCCCCC{kanbanColumns.Count + 1:D2}"),
                        TeamId = team.Id,
                        TaskStatus = TaskItemStatus.Status3,
                        PositionOnBoard = 3,
                        Title = Title.Create("Завершено").Value,
                        CreatedAt = now,
                        UpdatedAt = now
                    }
                ]);
            }

            context.KanbanBoardColumns.AddRange(kanbanColumns);
            #endregion

            context.SaveChanges();
        }
    }
}