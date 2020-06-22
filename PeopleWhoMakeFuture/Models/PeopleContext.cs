using Microsoft.EntityFrameworkCore;

namespace PeopleWhoMakeFuture.Models
{
    public class PeopleContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Language> Languages { get; set; }

        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
