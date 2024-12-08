using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Threading.Tasks;
using Application.Dtos; 
using Domain.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;

        public StudentController(IStudentService studentService, IUserService userService)
        {
            _studentService = studentService;
            _userService = userService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetStudents()
        //{
        //    var students = await _studentService.GetStudentsAsync();
        //    return Ok(students);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        //{
        //    if (studentDto == null)
        //    {
        //        return BadRequest("Invalid student data.");
        //    }

        //    // Create User
        //    var user = await _userService.AddUserAsync(studentDto.Name, studentDto.LastName, studentDto.Email, studentDto.Password, "Student");

        //    // Create Student
        //    var student = new Student
        //    {
        //        Id = user.Id,
        //        Name = $"{studentDto.Name} {studentDto.LastName}",
        //        Age = studentDto.Age,
        //        Grade = studentDto.Grade
        //    };

        //    await _studentService.AddStudentAsync(student);

        //    return Ok(student);
        //}


        //[HttpDelete("clear")]
        //public async Task<IActionResult> ClearStudents()
        //{
        //    await _studentService.ClearStudentsAsync();
        //    return NoContent();
        //}
    }
}
