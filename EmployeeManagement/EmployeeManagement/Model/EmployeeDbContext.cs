using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .Property(employee => employee.Id)
                        .ValueGeneratedOnAdd();

        }

        public DbSet<Employee> employees { get; set;}
    }
}
