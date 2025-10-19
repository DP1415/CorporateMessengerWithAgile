namespace Persistence
{
    public static class TableNames
    {
        // Таблицы сущностей
        public const string Companies = nameof(Companies);
        public const string Employees = nameof(Employees);
        public const string KanbanBoardColumns = nameof(KanbanBoardColumns);
        public const string PositionsInCompanies = nameof(PositionsInCompanies);
        public const string Projects = nameof(Projects);
        public const string Sprints = nameof(Sprints);
        public const string TaskItems = nameof(TaskItems);
        public const string TaskItemsInSprints = nameof(TaskItemsInSprints);
        public const string TaskItemStatuses = nameof(TaskItemStatuses);
        public const string Teams = nameof(Teams);
        public const string TeamMembers = nameof(TeamMembers);
        public const string Users = nameof(Users);

        // Вспомогательные таблицы полей
        public const string Emails = nameof(Emails);
        public const string PasswordHashes = nameof(PasswordHashes); 
        public const string PhoneNumbers = nameof(PhoneNumbers);
        public const string Texts = nameof(Texts);
        public const string Titles = nameof(Titles);
        public const string Usernames = nameof(Usernames);
    }
}
