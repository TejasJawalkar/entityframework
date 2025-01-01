using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoTask.Entity
{
  public class EmployeeOuput
  {
    public Int64 E_Id { get; set; }
    public string? F_Name { get; set; }
    public string? M_Name { get; set; }
    public string? L_Name { get; set; }
    public string? Mobile { get; set; }
    public string? Address { get; set; }
  }

  public class EmployeeInput
  {
    [FromForm] public Int64 E_Id { get; set; } = 0;
    [FromForm] public string? F_Name { get; set; }
    [FromForm] public string? M_Name { get; set; }
    [FromForm] public string? L_Name { get; set; }
    [FromForm] public string? Mobile { get; set; }
    [FromForm] public string? Address { get; set; }
  }

  public class ListOutput
  {
    public List<EmployeeOuput> employees { get; set; }
  }

}
