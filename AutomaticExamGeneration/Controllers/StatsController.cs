using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsService _statsService;

        public StatsController(IStatsService statsService)
        {
            _statsService = statsService;
        }

        [HttpGet("exams-by-assignment/{assignmentName}")]
        public async Task<ActionResult<IEnumerable<ExamStatsDto>>> GetExamsByAssignmentName(string assignmentName)
        {
            var stats = await _statsService.GetExamsByAssignmentNameAsync(assignmentName);
            return Ok(stats);
        }

        [HttpGet("most-used-questions/{assignmentName}")]
        public async Task<ActionResult<IEnumerable<MostUsedQuestionDto>>> GetMostUsedQuestionsByAssignmentName(string assignmentName)
        {
            var questions = await _statsService.GetMostUsedQuestionsByAssignmentNameAsync(assignmentName);
            return Ok(questions);
        }
    }
}
