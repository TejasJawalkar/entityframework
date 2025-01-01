using System.ComponentModel.DataAnnotations;

namespace DemoTask.Entity.Models
{
  public class EmployeeEntity
  {
    [Key]
    public long E_Id { get; set; }
    [Required]
    [StringLength(100)]
    public string F_Name { get; set; }
    [Required]
    [StringLength(100)]
    public string M_Name { get; set; }
    [Required]
    [StringLength(100)]
    public string L_Name { get; set; }
    [Required]
    [StringLength(20)]
    public string Mobile { get; set; }
    [Required]
    [StringLength(150)]
    public string Address { get; set; }
  }
}
