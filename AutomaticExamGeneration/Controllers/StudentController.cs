using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Net.WebSockets;
using Application.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IUserValidationService _userValidationService;

        public StudentController(IStudentService studentService, IUserValidationService userValidationService)
        {
            _studentService = studentService;
            _userValidationService = userValidationService; 
        }

        //[HttpPost]
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            if (await _userValidationService.EmailExistsAsync(studentDto.Email))
            {
                Console.WriteLine("El correo ya está registrado.");
                return BadRequest(new { message = "El correo ya está registrado." });
            }

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
