using Microsoft.EntityFrameworkCore;

namespace InterviewApi.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() { }
        public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }
    }
}
