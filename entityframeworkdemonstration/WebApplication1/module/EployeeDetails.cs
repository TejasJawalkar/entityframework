using System.ComponentModel.DataAnnotations;

namespace WebApplication1.module
{
  public class EployeeDetails
  {
    [Key]
    public Int64 E_D_Id { get; set; }
    public Int64 E_Id { get; set; } //Foreign Key From Employee Table
    [MaxLength(100)]
    public string Address { get; set; }
    [MaxLength(20)]
    public string MobileNo { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    public Employee Employee { get; set; } // Reference Navigation Property i.e. used to show E_Id belogns to this table
  }
}
