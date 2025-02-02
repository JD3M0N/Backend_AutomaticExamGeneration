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

        [HttpGet("most-used-questions/{assignmentId}")]
        public async Task<ActionResult<IEnumerable<QuestionUsageStatsDto>>> GetMostUsedQuestions(int assignmentId)
        {
            var stats = await _statsService.GetMostUsedQuestionsAsync(assignmentId);

            // Write in console that we are fetching most used questions by assignment ID
            System.Console.WriteLine($"Fetching most used questions for Assignment ID {assignmentId}");

            return Ok(stats);
        }

        [HttpGet("validated-exams/{professorId}")]
        public async Task<ActionResult<IEnumerable<ValidatedExamDto>>> GetValidatedExamsByProfessor(int professorId)
        {
            var validatedExams = await _statsService.GetValidatedExamsByProfessorAsync(professorId);

            // Write in console that we are fetching validated exams by professor ID and how many exams he has validated
            System.Console.WriteLine($"Fetching validated exams for Professor ID {professorId} - {validatedExams.Count()} exams validated");

            return Ok(validatedExams);
        }

        [HttpGet("exam-performance/{examId}")]
        public async Task<ActionResult<IEnumerable<ExamPerformanceDto>>> GetExamPerformance(int examId)
        {
            var examPerformance = await _statsService.GetExamPerformanceAsync(examId);

            // Write in console that we are fetching exam performance by exam ID
            System.Console.WriteLine($"Fetching exam performance for Exam ID {examId}");

            return Ok(examPerformance);
        }

        [HttpGet("unused-questions")]
        public async Task<ActionResult<IEnumerable<UnusedQuestionDto>>> GetUnusedQuestions()
        {
            var unusedQuestions = await _statsService.GetUnusedQuestionsAsync();

            // Write in console that we are fetching unused questions
            System.Console.WriteLine("Fetching unused questions");

            return Ok(unusedQuestions);
        }

        [HttpGet("compare-exams")]
        public async Task<ActionResult<IEnumerable<ExamComparisonDto>>> CompareExamsAcrossAssignments()
        {
            var examComparisons = await _statsService.CompareExamsAcrossAssignmentsAsync();

            // Write in console that we are comparing exams across assignments
            System.Console.WriteLine("Comparing exams across assignments");

            return Ok(examComparisons);
        }
    }
}

