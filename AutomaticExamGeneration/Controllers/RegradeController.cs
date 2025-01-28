using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegradeController : ControllerBase
    {
        private readonly IRegradeService _regradeService;

        public RegradeController(IRegradeService regradeService)
        {
            _regradeService = regradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegradeDto>>> GetAllRegrades()
        {
            var regrades = await _regradeService.GetAllRegradesAsync();

            // Write in console the number of regrades
            System.Console.WriteLine($"There are {regrades.Count()} regrades.");

            return Ok(regrades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegradeDto>> GetRegradeById(int id)
        {
            var regrade = await _regradeService.GetRegradeByIdAsync(id);
            if (regrade == null)
                return NotFound();

            // Write in console the regrade that has been found
            System.Console.WriteLine($"Regrade with ID {id} found.");

            return Ok(regrade);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegrade([FromBody] RegradeDto regradeDto)
        {
            await _regradeService.AddRegradeAsync(regradeDto);

            // Write in console the regrade that has been added with its value
            System.Console.WriteLine($"Regrade added with value {regradeDto.GradeValue}.");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegrade(int id, [FromBody] RegradeDto regradeDto)
        {
            await _regradeService.UpdateRegradeAsync(id, regradeDto);

            // Write in console the regrade that has been updated with its value
            System.Console.WriteLine($"Regrade with ID {id} updated with value {regradeDto.GradeValue}.");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegrade(int id)
        {
            await _regradeService.DeleteRegradeAsync(id);

            // Write in console the regrade that has been deleted
            System.Console.WriteLine($"Regrade with ID {id} deleted.");

            return Ok();
        }
    }
}
