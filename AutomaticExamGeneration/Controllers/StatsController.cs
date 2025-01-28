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

        [HttpGet("exams-by-assignment/{assignmentId}")]
        public async Task<ActionResult<IEnumerable<ExamStatsDto>>> GetExamsByAssignment(int assignmentId)
        {
            var stats = await _statsService.GetExamsByAssignmentAsync(assignmentId);
            // Write in console that we are getting exams by assignment ID
            System.Console.WriteLine($"Getting exams by Assignment ID {assignmentId}");
            return Ok(stats);
        }

        [HttpGet("exams-by-assignment-name/{assignmentName}")]
        public async Task<ActionResult<IEnumerable<ExamStatsDto>>> GetExamsByAssignmentName(string assignmentName)
        {
            var stats = await _statsService.GetExamsByAssignmentNameAsync(assignmentName);
            // Write in console that we are getting exams by assignment name
            System.Console.WriteLine($"Getting exams by Assignment Name {assignmentName}");
            return Ok(stats);
        }
    }
}

