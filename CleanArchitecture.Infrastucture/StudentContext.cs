using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastucture
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> optionsBuilder) : base(optionsBuilder)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Test");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
