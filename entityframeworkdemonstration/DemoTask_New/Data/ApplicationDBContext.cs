using DemoTask_New.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DemoTask_New.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }

        public DbSet<DataEntityClass> DataEntities { get; set; }
    }
}
