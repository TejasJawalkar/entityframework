using Microsoft.EntityFrameworkCore;
using WebApplication1.module;

namespace WebApplication1.data
{
  public class Context : DbContext
  {
    private readonly string ConnectionString = "";
    public Context()
    {
      ConnectionString = "Data Source=DESKTOP-AD72JDE;Initial Catalog=EFCoreDemoDB;Integrated Security=True;Trust Server Certificate=True";
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<EployeeDetails> EployeeDetails { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects  { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(ConnectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      #region OneToOneRelation
      modelBuilder.Entity<Employee>()
       .HasOne(ed => ed.EployeeDetails)
       .WithOne(p => p.Employee)
       .HasForeignKey<EployeeDetails>(o => o.E_Id);
      #endregion

      #region OneToManyRelation
      modelBuilder.Entity<Employee>()
        .HasOne(o => o.Manager)
        .WithMany(e => e.Employees)
        .HasForeignKey(p => p.M_Id);
      #endregion

      #region ManyToManyRelation
      modelBuilder.Entity<EmployeeProject>().HasKey(ep => new{ ep.E_Id, ep.Projects_Id, ep.EP_Id });

      modelBuilder.Entity<EmployeeProject>().HasOne(e => e.Employee).WithMany(o => o.EmployeeProjects).HasForeignKey(f=>f.E_Id);

      modelBuilder.Entity<EmployeeProject>().HasOne(e => e.Projects).WithMany(o => o.EmployeeProjects).HasForeignKey(f => f.Projects_Id);
      #endregion
    }
  }
}
