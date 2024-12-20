using System.ComponentModel.DataAnnotations;

namespace WebApplication1.module
{
  public class Projects
  {
    [Key]
    public Int64 Project_Id { get; set; }
    [MaxLength(150)]
    public String PrjectName { get; set; }
    public ICollection<EmployeeProject> EmployeeProjects { get; set; } 
  }
}
