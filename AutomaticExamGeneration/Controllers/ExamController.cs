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

            var exam = new Exam
            {

                AssignmentId = examDto.AssignmentId,
                ProfessorId = examDto.ProfessorId,
                Date = examDto.Date,
                TotalQuestions = examDto.TotalQuestions,
                Difficulty = examDto.Difficulty,
                TopicLimit = examDto.TopicLimit
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
            var exam = new Exam
            {
                Id = id,
                AssignmentId = examDto.AssignmentId,
                ProfessorId = examDto.ProfessorId,
                Date = examDto.Date,
                TotalQuestions = examDto.TotalQuestions,
                Difficulty = examDto.Difficulty,
                TopicLimit = examDto.TopicLimit
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
    }
}
