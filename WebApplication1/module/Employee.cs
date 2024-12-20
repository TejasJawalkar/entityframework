using System.ComponentModel.DataAnnotations;

namespace WebApplication1.module
{
  public class Employee
  {
    [Key]
    public Int64 E_Id { get; set; } //Primary Key
    [MaxLength(100)]
    public string E_F_Name { get; set; }
    [MaxLength(100)]
    public string E_L_Name { get; set; }
    public double Salary { get; set; }
    // one to one relationship
    public EployeeDetails EployeeDetails { get; set; } //Reference Navigation to Dependent
    //one to many relationship
    public Int64 M_Id { get; set; }
    public Manager Manager { get; set; }
    public ICollection<EmployeeProject> EmployeeProjects { get; set; }
  }
}
