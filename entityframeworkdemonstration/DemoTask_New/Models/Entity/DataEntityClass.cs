using System.ComponentModel.DataAnnotations;

namespace DemoTask_New.Models.Entity
{
    public class DataEntityClass
    {
        [Key]
        public Int64 Data_Id { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [MaxLength(100)]
        public string? First_Name { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [MaxLength(100)]
        public string? Last_Name { get; set; }
        [Required(ErrorMessage = "Enter Valid Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public String? Gender { get;set; }
        [Required(ErrorMessage = "Select Country")]
        public String? Country { get; set; }
        [Required(ErrorMessage = "Enter Valid Email Address")]
        [RegularExpression(@"^\d{10}$", ErrorMessage ="Phone No Should be 10 Digit Long and Contain Only Digits.")]
        public String? Phone_No { get; set; }    
        [Required(ErrorMessage="Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        public String? Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }=DateTime.Now;
    }

}
