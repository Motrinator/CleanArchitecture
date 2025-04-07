using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<ActionResult> Index()
        {
            var students = await _studentService.GetAllAsync().ConfigureAwait(false);

            return View(students);
        }

        // GET: StudentsController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var student = await _studentService.GetAsync(id).ConfigureAwait(false);

            return View(student);
        }

        // GET: StudentsController/Create
        public async Task<ActionResult> Create(StudentDto studentDto)
        {
            ArgumentNullException.ThrowIfNull(studentDto);

            var studentId = await _studentService.CreateAsync(studentDto).ConfigureAwait(false);

            return RedirectToAction("Details", studentId);
        }
    }
}
