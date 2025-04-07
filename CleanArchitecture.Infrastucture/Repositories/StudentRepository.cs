using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CleanArchitecture.Infrastucture.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContextFactory<StudentContext> _studentContext;

        public StudentRepository(IDbContextFactory<StudentContext> studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<Guid> CreateAsync(Student student)
        {
            await using var context = await _studentContext.CreateDbContextAsync().ConfigureAwait(false);

            await context.Students.AddAsync(student);

            return student.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await using var context = await _studentContext.CreateDbContextAsync().ConfigureAwait(false);

            var deletedCount = await context.Students.Where(x => x.Id == id).ExecuteDeleteAsync();

            return deletedCount > 0;
        }

        public async Task<IReadOnlyCollection<Student>> GetAllAsync()
        {
            await using var context = await _studentContext.CreateDbContextAsync().ConfigureAwait(false);

            return await context.Students.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Student?> GetAsync(Guid id)
        {
            await using var context = await _studentContext.CreateDbContextAsync().ConfigureAwait(false);

            return await context.Students.SingleOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> IsExistAsync(string name)
        {
            await using var context = await _studentContext.CreateDbContextAsync().ConfigureAwait(false);

            return await context.Students.AnyAsync(x => x.Name == name).ConfigureAwait(false);
        }
    }
}
