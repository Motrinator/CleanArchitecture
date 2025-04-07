using CleanArchitecture.Application.Services.DTOs;

namespace CleanArchitecture.Application.Services.Students
{
    public interface IStudentService
    {
        Task<Guid> CreateAsync(StudentDto studentDto);
        Task<StudentDto?> GetAsync(Guid id);
        Task<IReadOnlyCollection<StudentDto>> GetAllAsync();
        Task<bool> DeleteAsync(Guid id);
    }
}
