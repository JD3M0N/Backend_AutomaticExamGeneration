using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachController : ControllerBase
    {
        private readonly ITeachService _teachService;

        public TeachController(ITeachService teachService)
        {
            _teachService = teachService;
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
    }
}
