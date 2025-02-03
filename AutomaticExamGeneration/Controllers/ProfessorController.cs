using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IUserValidationService _userValidationService;
        private readonly ITopicService _topicService;

        public ProfessorController(IProfessorService professorService, IUserValidationService userValidationService, ITopicService topicService)
        {
            _professorService = professorService;
            _userValidationService = userValidationService;
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorDto professorDto)
        {
            if (await _userValidationService.EmailExistsAsync(professorDto.Email))
            {
                Console.WriteLine("El correo ya está registrado.");
                return BadRequest(new { message = "El correo ya está registrado." });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(professorDto.Password);

            var professor = new Professor
            {
                Name = professorDto.Name,
                Email = professorDto.Email,
                Password = hashedPassword, // Guardar la contraseña hasheada
                Specialization = professorDto.Specialization
            };

            await _professorService.AddProfessorAsync(professor);
            Console.WriteLine($"professor '{professor.Name}' added correctly.");
            return Ok(professor);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetAllProfessors()
        {
            var professors = await _professorService.GetProfessorsAsync();
            return Ok(professors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, [FromBody] ProfessorDto professorDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(professorDto.Password);

            var professor = new Professor
            {
                Id = id,
                Name = professorDto.Name,
                Email = professorDto.Email,
                Password = hashedPassword,
                Specialization = professorDto.Specialization
            };

            await _professorService.UpdateProfessorAsync(professor);
            Console.WriteLine($"professor '{professor.Name}' modified correctly.");
            return Ok(professor);
        }

        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetProfessorById(int professorId)
        {
            var professor = await _professorService.GetProfessorByIdAsync(professorId);

            if (professor == null)
            {
                return NotFound($"No professor found with ID {professorId}.");
            }

            // Write to the console the professor's name
            Console.WriteLine($"Professor: {professor.Name} founded");

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            await _professorService.DeleteProfessorAsync(id);
            return Ok();
        }

        [HttpGet("professor/{professorId}")]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopicsByProfessorId(int professorId)
        {
            var topics = await _topicService.GetTopicsByProfessorIdAsync(professorId);
            if (topics == null)
            {
                return NotFound();
            }

            Console.WriteLine($"Topics for professor: {professorId}");
            foreach (var topic in topics)
            {
                Console.WriteLine($"- {topic.Name}");
            }

            return Ok(topics);
        }

        [HttpGet("{professorId}/unvalidated-exams")]
        public async Task<IActionResult> GetUnvalidatedExams(int professorId)
        {
            var exams = await _professorService.GetUnvalidatedExamsByProfessorIdAsync(professorId);

            if (exams == null || !exams.Any())
                return NotFound(new { message = "No hay exámenes pendientes de validación para este profesor." });

            // Write to the console how many exams this professor id can validate
            Console.WriteLine($"Professor with ID {professorId} can validate {exams.Count()} exams.");

            return Ok(exams);
        }

        [HttpGet("{professorId}/reviewable-exams")]
        public async Task<IActionResult> GetReviewableExams(int professorId)
        {
            var exams = await _professorService.GetReviewableExamsAsync(professorId);

            if (exams == null || !exams.Any())
            {
                // Write to the console that there are no exams available for review
                Console.WriteLine("No hay exámenes disponibles para revisión.");

                return NotFound(new { message = "No hay exámenes disponibles para revisión." });
            }

            // Write to the console how many exams this professor id can review
            Console.WriteLine($"Professor with ID {professorId} can review {exams.Count()} exams.");

            return Ok(exams);
        }
    }
}
