using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;
using Application.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachController : ControllerBase
    {
        private readonly ITeachService _teachService;
        private readonly IProfessorService _professorService;
        private readonly IAssignmentService _assignmentService;

        public TeachController(ITeachService teachService, IProfessorService professorService, IAssignmentService assignmentService)
        {
            _teachService = teachService;
            _professorService = professorService;
            _assignmentService = assignmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeach([FromBody] TeachDto teachDto)
        {
            var teach = new Teach
            {
                ProfessorId = teachDto.ProfessorId,
                AssignmentId = teachDto.AssignmentId
            };

            await _teachService.AddTeachAsync(teach);
            return Ok(teach);
        }
        [HttpPost("add-with-email-and-assignment")]
        public async Task<IActionResult> AddTeachWithEmailAndAssignment([FromBody] TeachWithEmailDto teachDto)
        {
            if (teachDto == null || string.IsNullOrEmpty(teachDto.Email) || string.IsNullOrEmpty(teachDto.AssignmentName))
                return BadRequest("Invalid data.");

            // Buscar al profesor por correo
            var professor = await _professorService.GetProfessorByEmailAsync(teachDto.Email);
            if (professor == null)
                return NotFound("Professor with the given email not found.");

            // Buscar la asignatura por nombre
            var assignmentId = await _assignmentService.GetAssignmentIdByNameAsync(teachDto.AssignmentName);
            if (assignmentId == null)
                return NotFound("Assignment with the given name not found.");

            // Crear una nueva entrada en Teach
            var teach = new Teach
            {
                ProfessorId = professor.Id,
                AssignmentId = assignmentId.Value
            };

            await _teachService.AddTeachAsync(teach);

            // Escribir en la consola el nombre del profesor y el nombre de la asignatura
            Console.WriteLine($"{professor.Name} teaches {teachDto.AssignmentName}");

            return Ok("Teach entry added successfully.");
        }


        //[HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeachDto>>> GetAllTeaches()
        {
            var teaches = await _teachService.GetTeachesAsync();
            return Ok(teaches);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeach(int id)
        {
            await _teachService.DeleteTeachAsync(id);
            return Ok();
        }

        [HttpGet("professor/{professorId}/assignments")]
        public async Task<IActionResult> GetAssignmentsByProfessorId(int professorId)
        {
            var assignments = await _teachService.GetAssignmentsByProfessorIdAsync(professorId);
            if (assignments == null || !assignments.Any())
                return NotFound("No assignments found for the given professor ID.");

            // Write to the console how many assignments this professor id has
            Console.WriteLine($"Professor : {professorId} teaches : {assignments.Count()} assignments.");

            return Ok(assignments);
        }

    }
}
