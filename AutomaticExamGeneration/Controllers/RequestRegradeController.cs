using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestRegradeController : ControllerBase
    {
        private readonly IRequestRegradeService _requestRegradeService;

        public RequestRegradeController(IRequestRegradeService requestRegradeService)
        {
            _requestRegradeService = requestRegradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestRegradeDto>>> GetAllRequestRegrades()
        {
            var requestRegrades = await _requestRegradeService.GetAllRequestRegradesAsync();

            // Write in console the request regrades amount
            System.Console.WriteLine($"Request regrades amount: {requestRegrades.Count()}");

            return Ok(requestRegrades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestRegradeDto>> GetRequestRegradeById(int id)
        {
            var requestRegrade = await _requestRegradeService.GetRequestRegradeByIdAsync(id);
            if (requestRegrade == null)
                return NotFound();

            // Write in console the request regrade id
            System.Console.WriteLine($"Request regrade ID: {id}");

            return Ok(requestRegrade);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequestRegrade([FromBody] RequestRegradeDto requestRegradeDto)
        {
            await _requestRegradeService.AddRequestRegradeAsync(requestRegradeDto);

            // Write in console that the request regrade has been added from what student to what profesor
            System.Console.WriteLine($"Request regrade added from Student ID {requestRegradeDto.StudentId} to Professor ID {requestRegradeDto.ProfessorId}");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequestRegrade(int id, [FromBody] RequestRegradeDto requestRegradeDto)
        {
            await _requestRegradeService.UpdateRequestRegradeAsync(id, requestRegradeDto);

            // Write in console that the request regrade has been updated
            System.Console.WriteLine($"Request regrade ID {id} updated");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestRegrade(int id)
        {
            await _requestRegradeService.DeleteRequestRegradeAsync(id);

            // Write in console that the request regrade has been deleted
            System.Console.WriteLine($"Request regrade ID {id} deleted");

            return Ok();
        }
    }
}
