using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkUse1._0._0.module
{
    public class EmployeeProject
    {
        [Key]
        public long EP_Id { get; set; }
        public long E_Id { get; set; }
        public Employee Employee { get; set; }
        public long Projects_Id { get; set; }
        public Projects Projects { get; set; }

    }
}
