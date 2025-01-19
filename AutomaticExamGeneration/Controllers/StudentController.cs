using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Net.WebSockets;

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

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(studentDto.Password);

            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Password = hashedPassword, // Guardar la contraseña hasheada
                Age = studentDto.Age,
                Grade = studentDto.Grade
            };

            await _studentService.AddStudentAsync(student);
            Console.WriteLine($"student '{studentDto.Name}' added correctly.");
            return Ok(student);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(studentDto.Password);

            var student = new Student
            {
                Id = id,
                Name = studentDto.Name,
                Email = studentDto.Email,
                Password = hashedPassword,
                Age = studentDto.Age,
                Grade = studentDto.Grade
            };

            await _studentService.UpdateStudentAsync(student);
            Console.WriteLine($"student '{studentDto.Name}' modified correctly.");
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok();
        }
    }
}
