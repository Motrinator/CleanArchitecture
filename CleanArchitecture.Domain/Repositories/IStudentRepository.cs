using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<Guid> CreateAsync(Student studentDto);
        Task<Student?> GetAsync(Guid id);
        Task<IReadOnlyCollection<Student>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<bool> IsExistAsync(string name);
    }
}
