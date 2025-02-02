using Application.Interfaces;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Dtos;

namespace Application.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository _statsRepository;

        public StatsService(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        public async Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentAsync(int assignmentId)
        {
            return await _statsRepository.GetExamsByAssignmentAsync(assignmentId);
        }

        public async Task<IEnumerable<ExamStatsDto>> GetExamsByAssignmentNameAsync(string assignmentName)
        {
            return await _statsRepository.GetExamsByAssignmentNameAsync(assignmentName);
        }
        public async Task<IEnumerable<QuestionUsageStatsDto>> GetMostUsedQuestionsAsync(int assignmentId)
        {
            return await _statsRepository.GetMostUsedQuestionsAsync(assignmentId);
        }

        public async Task<IEnumerable<ValidatedExamDto>> GetValidatedExamsByProfessorAsync(int professorId)
        {
            return await _statsRepository.GetValidatedExamsByProfessorAsync(professorId);
        }
        public async Task<IEnumerable<ExamPerformanceDto>> GetExamPerformanceAsync(int examId)
        {
            return await _statsRepository.GetExamPerformanceAsync(examId);
        }
        public async Task<IEnumerable<UnusedQuestionDto>> GetUnusedQuestionsAsync()
        {
            return await _statsRepository.GetUnusedQuestionsAsync();
        }
        public async Task<IEnumerable<ExamComparisonDto>> CompareExamsAcrossAssignmentsAsync()
        {
            return await _statsRepository.CompareExamsAcrossAssignmentsAsync();
        }
    }
}
