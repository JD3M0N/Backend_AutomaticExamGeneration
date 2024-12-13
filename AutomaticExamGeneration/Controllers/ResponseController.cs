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

        [HttpPost]
        public async Task<IActionResult> AddResponse([FromBody] ResponseDto responseDto)
        {

            var response = new Response
            {
                StudentId = responseDto.StudentId,
                ExamId = responseDto.ExamId,
                Date = responseDto.Date,
                Solution = responseDto.Solution
            };

            await _responseService.AddResponseAsync(response);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetAllResponses()
        {
            var responses = await _responseService.GetResponseAsync();
            return Ok(responses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponse(int id, [FromBody] ResponseDto responseDto)
        {
            var response = new Response
            {
                Id = id,
                StudentId = responseDto.StudentId,
                ExamId = responseDto.ExamId,
                Date = responseDto.Date,
                Solution = responseDto.Solution
            };

            await _responseService.UpdateResponseAsync(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            await _responseService.DeleteResponseAsync(id);
            return Ok();
        }
    }
}