using Application.Interfaces; 
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetAllProfessors()
        {
            var professors = await _professorService.GetAllProfessorsAsync();
            return Ok(professors);
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearProfessors()
        {
            await _professorService.ClearProfessorsAsync();
            return NoContent();
        }
    }
}
