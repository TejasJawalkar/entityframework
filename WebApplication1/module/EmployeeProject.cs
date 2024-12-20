using System.ComponentModel.DataAnnotations;

namespace WebApplication1.module
{
  public class EmployeeProject
  {
    [Key]
    public Int64 EP_Id { get; set; }
    public Int64 E_Id { get; set; }
    public Employee Employee { get; set; }
    public Int64 Projects_Id { get;set; }
    public Projects Projects { get; set; }

  }
}
