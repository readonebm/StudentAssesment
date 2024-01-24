using Microsoft.EntityFrameworkCore;
using StudentAssesment.Models.Student;

namespace StudentAssesment.Controllers.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {      
        }

        public DbSet<Student> Students { get; set; }
    }


}
