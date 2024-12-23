using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkUse1._0._0.module
{
    public class Manager
    {
        [Key]
        public long M_Id { get; set; }
        [MaxLength(100)]
        public string M_F_Name { get; set; }
        [MaxLength(100)]
        public string M_L_Name { get; set; }
        [MaxLength(200)]
        public string M_Address { get; set; }

        //Collection Navigation property to represent one to many relationship
        public ICollection<Employee> Employees { get; set; }
    }
}
