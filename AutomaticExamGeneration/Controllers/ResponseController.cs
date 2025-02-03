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
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDto>>> GetAllResponses()
        {
            var responses = await _responseService.GetAllResponsesAsync();

            // Write in console the number of responses
            Console.WriteLine($"Number of responses: {responses.Count()}");
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetResponseById(int id)
        {
            var response = await _responseService.GetResponseByIdAsync(id);
            if (response == null)
                return NotFound();

            // Write in console the response
            Console.WriteLine($"Response: {response}");

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddResponse([FromBody] ResponseDto responseDto)
        {
            await _responseService.AddResponseAsync(responseDto);

            // Write in console the response added
            Console.WriteLine($"Response added: {responseDto}");
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponse(int id, [FromBody] ResponseDto responseDto)
        {
            await _responseService.UpdateResponseAsync(id, responseDto);

            // Write in console the response updated
            Console.WriteLine($"Response updated: {responseDto}");
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            await _responseService.DeleteResponseAsync(id);

            // Write in console the response deleted
            Console.WriteLine($"Response deleted: {id}");
            return Ok();
        }

        [HttpGet("exam/{examId}/student/{studentId}")]
        public async Task<ActionResult<IEnumerable<ResponseDto>>> GetResponsesByExamAndStudent(int examId, int studentId)
        {
            var responses = await _responseService.GetResponsesByExamAndStudentAsync(examId, studentId);
            if (responses == null || !responses.Any())
                return NotFound();

            // Write in console the number of responses found
            Console.WriteLine($"Number of responses for exam {examId} and student {studentId}: {responses.Count()}");

            return Ok(responses);
        }
    }
}
