using API.Model.DB;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(p => p.Department)
            .WithMany(b => b.Employees)
            .HasForeignKey(p => p.DepNo);

            modelBuilder.Entity<Employee>()
            .HasOne(p => p.Position)
            .WithMany(b => b.Employees)
            .HasForeignKey(p => p.PositionNo);
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<EmployeeBackup> EmployeeBackup { get; set; }      
    }
}
