using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkUse1._0._0.module
{
    public class Projects
    {
        [Key]
        public long Project_Id { get; set; }
        [MaxLength(150)]
        public string PrjectName { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
