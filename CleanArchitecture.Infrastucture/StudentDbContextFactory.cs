using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastucture
{
    public class StudentDbContextFactory : IDbContextFactory<StudentContext>
    {
        public StudentContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();

            optionsBuilder.UseInMemoryDatabase("DefaultConnection");

            return new StudentContext(optionsBuilder.Options);
        }
    }
}
