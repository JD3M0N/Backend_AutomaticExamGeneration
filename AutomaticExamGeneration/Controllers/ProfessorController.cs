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

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessor([FromBody] ProfessorDto professorDto)
        {
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            await _professorService.DeleteProfessorAsync(id);
            return Ok();
        }
    }
}
