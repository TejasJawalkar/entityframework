using DemoTask.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoTask.Data
{
  public class ApplicationDbContext:DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {}

    public DbSet<EmployeeEntity> Employees { get; set; } 
  }
}
