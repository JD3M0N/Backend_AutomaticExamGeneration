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
            var exam = new Exam
            {
                AssignmentId = examDto.AssignmentId,
                ProfessorId = examDto.ProfessorId,
                PPT = examDto.PPT,
                CT = examDto.CT,
                CTP = examDto.CTP,
                Date = examDto.Date
            };

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
                PPT = examDto.PPT,
                CT = examDto.CT,
                CTP = examDto.CTP,
                Date = examDto.Date
            };

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
