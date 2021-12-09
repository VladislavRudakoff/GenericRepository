using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestTask.Models;

namespace TestTask.DAL
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Order { get; set; }

        private readonly IConfiguration Configuration;

        public StoreDbContext(IConfiguration configuration)
        {
            Configuration = configuration;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            optionsBuilder.LogTo(System.Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                new Role { Id=0, Name="User"},
                new Role { Id=1, Name="Admin"},
                });
        }
    }
}
