using CleanArchitecture.Application.Services.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Guid> CreateAsync(StudentDto studentDto)
        {
            if (await _studentRepository.IsExistAsync(studentDto.Name))
            {
                throw new InvalidDataException("Student already exists");
            }

            return await _studentRepository.CreateAsync(new Student { Name = studentDto.Name }).ConfigureAwait(false);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _studentRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync().ConfigureAwait(false);

            return students.Select(x => new StudentDto { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<StudentDto?> GetAsync(Guid id)
        {
            var student = await _studentRepository.GetAsync(id).ConfigureAwait(false);

            if (student is null)
            {
                return null;
            }

            return new StudentDto { Id = student.Id, Name = student.Name };
        }
    }
}
