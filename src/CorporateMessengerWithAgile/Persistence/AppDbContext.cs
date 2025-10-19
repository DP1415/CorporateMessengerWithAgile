using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Entity.User> Users { get; set; }
        public DbSet<Domain.Entity.Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmployeeConfiguration());
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
