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
                ResponseDate = responseDto.ResponseDate,
                ResponseText = responseDto.ResponseText
            };

            await _responseService.AddResponseAsync(response);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetAllResponses()
        {
            var responses = await _responseService.GetResponsesAsync();
            return Ok(responses);
        }

        [HttpGet("{studentId}/{examId}")]
        public async Task<ActionResult<Response>> GetResponseById(int studentId, int examId)
        {
            var response = await _responseService.GetResponseByIdAsync(studentId, examId);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut("{studentId}/{examId}")]
        public async Task<IActionResult> UpdateResponse(int studentId, int examId, [FromBody] ResponseDto responseDto)
        {
            var response = new Response
            {
                StudentId = studentId,
                ExamId = examId,
                ResponseDate = responseDto.ResponseDate,
                ResponseText = responseDto.ResponseText
            };

            await _responseService.UpdateResponseAsync(response);
            return Ok(response);
        }

        [HttpDelete("{studentId}/{examId}")]
        public async Task<IActionResult> DeleteResponse(int studentId, int examId)
        {
            await _responseService.DeleteResponseAsync(studentId, examId);
            return Ok();
        }
    }
}

