using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        public async Task<IActionResult> AddExam([FromBody] ExamDto examDto)
        {
            if (examDto == null)
                return BadRequest("Invalid data.");

            bool validState = false;

            if (examDto.State == "validated" || examDto.State == "denied")
            {
                validState = true;
            }

            var exam = new Exam
            {

                AssignmentId = examDto.AssignmentId,
                ProfessorId = examDto.ProfessorId,
                Date = examDto.Date,
                TotalQuestions = examDto.TotalQuestions,
                Difficulty = examDto.Difficulty,
                TopicLimit = examDto.TopicLimit,
                //if it is not a valid state then the value will be null
                State = validState ? examDto.State : "null"
            };

            // Write in console what exam has been added to what assignment
            System.Console.WriteLine($"Exam added to Assignment ID {exam.AssignmentId}");
            await _examService.AddExamAsync(exam);
            return Ok(exam);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetAllExams()
        {
            var exams = await _examService.GetExamsAsync();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExamById(int id)
        {
            var exam = await _examService.GetExamByIdAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, [FromBody] ExamDto examDto)
        {
            bool validState = false;

            if (examDto.State == "validated" || examDto.State == "denied")
            {
                validState = true;
            }

            var exam = new Exam
            {
                Id = id,
                AssignmentId = examDto.AssignmentId,
                ProfessorId = examDto.ProfessorId,
                Date = examDto.Date,
                TotalQuestions = examDto.TotalQuestions,
                Difficulty = examDto.Difficulty,
                TopicLimit = examDto.TopicLimit,
                //if it is not a valid state then the value will be null
                State = validState ? examDto.State : "null"
            };

            // Write in console that an exam has been updated
            System.Console.WriteLine($"Exam ID {id} updated");
            await _examService.UpdateExamAsync(exam);
            return Ok(exam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            await _examService.DeleteExamAsync(id);
            return Ok();
        }

        [HttpPatch("{id}/state")]
        public async Task<IActionResult> UpdateExamState(int id, [FromBody] string state)
        {
            await _examService.UpdateExamStateAsync(id, state);

            // Write in console that the state of an exam has been updated
            System.Console.WriteLine($"State of Exam ID {id} updated to {state}");

            return Ok();
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateExam([FromBody] ExamGenerationRequestDto request)
        {
            var exam = await _examService.GenerateExamAsync(request);

            // Write in console that an exam has been generated
            System.Console.WriteLine($"Exam generated for Assignment ID {request.AssignmentId}");

            return Ok(exam);
        }

    }
}
