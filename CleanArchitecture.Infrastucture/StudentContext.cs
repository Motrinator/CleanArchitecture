using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastucture
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
