using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
        public class BelongController : ControllerBase
        {
            private readonly IBelongService _belongService;

            public BelongController(IBelongService belongService)
            {
                _belongService = belongService;
            }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BelongSimpleDto>>> GetAllBelongs()
        {
            var belongs = await _belongService.GetAllBelongsAsync();

            // Write in console how many belongs have been retrieved
            System.Console.WriteLine($"{belongs.Count()} belongs have been retrieved");

            return Ok(belongs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BelongSimpleDto>> GetBelongById(int id)
        {
            var belong = await _belongService.GetBelongByIdAsync(id);
            if (belong == null)
            {
                return NotFound();
            }

            // Write in console what belong has been retrieved
            System.Console.WriteLine($"Belong relationship with ID {id} has been retrieved");

            return Ok(belong);
        }

        [HttpPost]
            public async Task<IActionResult> AddBelong([FromBody] BelongDto belongDto)
            {
                if (belongDto == null)
                {
                    return BadRequest("Invalid data.");
                }

            //Write in console what belong has been added to what exam
            System.Console.WriteLine($"Question ID {belongDto.Q_ID} added to Exam ID {belongDto.X_ID}");
            await _belongService.AddBelongAsync(belongDto);
                return Ok("Belong relationship added successfully.");
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBelong(int id, [FromBody] Belong belong)
        {
            var existingBelong = await _belongService.GetBelongByIdAsync(id);
            if (existingBelong == null)
            {
                return NotFound();
            }

            belong.Id = id;
            await _belongService.UpdateBelongAsync(belong);

            // Write in console what belong has been updated
            System.Console.WriteLine($"Belong relationship with ID {id} has been updated");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBelong(int id)
        {
            var belong = await _belongService.GetBelongByIdAsync(id);
            if (belong == null)
            {
                return NotFound();
            }

            await _belongService.DeleteBelongAsync(id);

            // Write in console what belong has been deleted
            System.Console.WriteLine($"Belong relationship with ID {id} has been deleted");

            return NoContent();
        }

        [HttpGet("exam/{examId}/questions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByExamId(int examId)
        {
            var questions = await _belongService.GetQuestionsByExamIdAsync(examId);
            if (questions == null)
            {
                return NotFound();
            }

            // Write to the console how many questions this exam id has
            System.Console.WriteLine($"Exam ID {examId} has {questions.Count()} questions");

            return Ok(questions);
        }
    }
}

