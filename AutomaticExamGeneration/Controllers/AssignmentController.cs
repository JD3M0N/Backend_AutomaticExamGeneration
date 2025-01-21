using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private readonly IProfessorService _professorService;

        public AssignmentController(IAssignmentService assignmentService, IProfessorService professorService)
        {
            _assignmentService = assignmentService;
            _professorService = professorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignment([FromBody] AssignmentDto assignmentDto)
        {
            var assignment = new Assignment
            {
                Name = assignmentDto.Name,
                StudyProgram = assignmentDto.StudyProgram,
                ProfessorId = assignmentDto.ProfessorId
            };

            await _assignmentService.AddAssignmentAsync(assignment);
            return Ok(assignment);
        }


[HttpPost("add-with-email")]
        public async Task<IActionResult> AddAssignmentWithEmail([FromBody] AssignmentWithEmailDto assignmentDto)
        {
            if (assignmentDto == null)
                return BadRequest("Invalid data.");

            // Buscar al profesor por correo 
            var professor = await _professorService.GetProfessorByEmailAsync(assignmentDto.Email);
            if (professor == null)
                return NotFound("Professor with the given email not found.");

            // Crear la asignatura
            var assignment = new Assignment
            {
                Name = assignmentDto.Name,
                StudyProgram = assignmentDto.StudyProgram,
                ProfessorId = professor.Id
            };

            // Guardar en la base de datos
            await _assignmentService.AddAssignmentAsync(assignment);

            // Escribir en la consola el nombre y el ID del profesor
            Console.WriteLine($"Professor added: Name = {professor.Name}, ID = {professor.Id}");

            return Ok("Assignment added successfully.");
        }


    [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAssignments()
        {
            var assignments = await _assignmentService.GetAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignmentById(int id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] AssignmentDto assignmentDto)
        {
            var assignment = new Assignment
            {
                Id = id,
                Name = assignmentDto.Name,
                StudyProgram = assignmentDto.StudyProgram,
                ProfessorId = assignmentDto.ProfessorId
            };

            await _assignmentService.UpdateAssignmentAsync(assignment);
            return Ok(assignment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return Ok();
        }
    }
}
