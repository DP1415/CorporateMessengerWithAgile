using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Entity.User> Users { get; set; }
        public DbSet<Domain.Entity.Employee> Employees { get; set; }
        public DbSet<Domain.Entity.Company> Companies { get; set; }
        public DbSet<Domain.Entity.PositionInCompany> PositionsInCompany { get; set; }
        public DbSet<Domain.Entity.Project> Projects { get; set; }
        public DbSet<Domain.Entity.Team> Teams { get; set; }
        public DbSet<Domain.Entity.TeamMember> TeamMembers { get; set; }
        public DbSet<Domain.Entity.Sprint> Sprints { get; set; }
        public DbSet<Domain.Entity.TaskItem> TaskItems { get; set; }
        public DbSet<Domain.Entity.TaskItemInSprint> TaskItemInSprints { get; set; }
        public DbSet<Domain.Entity.KanbanBoardColumn> KanbanBoardColumns { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PositionInCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TeamConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.SprintConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TaskItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TaskItemInSprintConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.KanbanBoardColumnConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Для разработки используем InMemory базу
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("CorporateMessengerDb");
            }
            //optionsBuilder.UseNpgsql("Username=postgres;Password=password;Host=localhost;Port=5432;Database=dbtest;");
            //base.OnConfiguring(optionsBuilder);
        }
    }

}
