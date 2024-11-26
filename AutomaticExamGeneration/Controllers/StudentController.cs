using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }
    }
}
